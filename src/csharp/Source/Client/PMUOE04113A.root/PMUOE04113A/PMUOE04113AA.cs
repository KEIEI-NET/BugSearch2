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
    /// ���ω񓚕\���@�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���ω񓚕\���Ɋւ���A�N�Z�X������s���܂��B</br>
    /// <br>Programmer	: �Ɠc �M�u</br>
    /// <br>Date		: 2008/11/10</br>
    /// <br>            : 2008/12/10 �Ɠc �M�u�@�i���ɂ͉񓚕i����\��</br>
    /// <br>              2008/12/19 �Ɠc �M�u�@UOE�K�C�h���̃}�X�^�Ɉ�v������̂������ꍇ�͕ҏW���Ȃ��ł��̂܂ܕ\��</br>
    /// <br>              2009/01/20 �Ɠc �M�u�@�s��Ή�[10208][10256]</br>
    /// </remarks>
    public class PMUOE04113AA
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
        // �K�C�h�敪
        private const int GUIDEDIVCD_SECTION = 3;           // ���_�敪
        // �f�[�^
        private const int ESTMTANSINFO_FIRST = 0;           // ���ω񓚏�񏉊��f�[�^�ʒu

        // HashTable
        private Hashtable _estmtAnsInfoHTable = null;       // ���ω񓚏��(key�FINDEX)
        private Hashtable _gridHeaderHTable = null;         // �O���b�h�w�b�_�[(key�F�ʐM�A�Z���u��ID(�ʐM�v���O����ID))
        private Hashtable _uoeOrderDtlHTable = null;        // UOE������}�X�^(key�FUOE������R�[�h)
        private Hashtable _uoeGuideNameHTable = null;       // UOE�K�C�h���̃}�X�^(key�F���_�R�[�h-UOE������R�[�h)

        private string _enterpriseCode = string.Empty;      // ��ƃR�[�h
        private string _sectionCode = string.Empty;         // ���_�R�[�h
        private int _estmtAnsInfoHTableIndex = 0;           // ���ω񓚏��INDEX

        #region GridHeaderInfo�\����
        /// <summary>
        /// �O���b�h�w�b�_�[���@�\����
        /// </summary>
        internal struct GridHeaderInfo
        {
            private string _variableName1;      // �݌ɂP
            private string _variableName2;      // �݌ɂQ
            private string _variableName3;      // �[��
            private string _variableName4;      // ���

            /// <summary>
            /// �O���b�h�w�b�_�[�f�[�^�ǉ�
            /// </summary>
            /// <param name="variableName1">�ύ��ږ���1(�݌ɐ�1)</param>
            /// <param name="variableName2">�ύ��ږ���2(�݌ɐ�2)</param>
            /// <param name="variableName3">�ύ��ږ���3(�[��)</param>
            /// <param name="variableName4">�ύ��ږ���4(���)</param>
            public void Add(string variableName1, string variableName2, string variableName3, string variableName4)
            {
                _variableName1 = variableName1;
                _variableName2 = variableName2;
                _variableName3 = variableName3;
                _variableName4 = variableName4;
            }

            /// <summary>�ύj�ږ���1(�݌ɐ�1)</summary>
            public string variableName1
            {
                get { return _variableName1; }
            }
            /// <summary>�ύ��ږ���2(�݌ɐ�2)</summary>
            public string variableName2
            {
                get { return _variableName2; }
            }
            /// <summary>�ύ��ږ���3(�[��)</summary>
            public string variableName3
            {
                get { return _variableName3; }
            }
            /// <summary>�ύ��ږ���4(���)</summary>
            public string variableName4
            {
                get { return _variableName4; }
            }
        }
        #endregion
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
        public PMUOE04113AA(List<EstmtSndRcvJnl> estmtSndRcvJnlList, string enterpriseCode, string sectionCode)
        {
            // ��ƃR�[�h
            this._enterpriseCode = enterpriseCode;

            // ���_�R�[�h
            this._sectionCode = sectionCode;

            // �O���b�h�w�b�_�[
            this.CreateGridHeaderHTable();

            // UOE�K�C�h���̃}�X�^
            this.CreateUOEGuideNameHTable();

            // UOE������}�X�^
            this.CreateUOEOrderDtlHTable();

            // UOE����M�W���[�i���f�[�^
            this.CreateEstmtAnsInfoHTable(estmtSndRcvJnlList);
        }
        # endregion ��Constructor - end

        #region ��Public���\�b�h
        #region ��SearchFirst(���񌟍�)
        /// <summary>
        /// �����\���f�[�^�擾
        /// </summary>
        /// <param name="supplierDataSet">�O���b�h���׈ȊO(�w�b�_�[�A�O���b�h�w�b�_�[�A���v)�̃f�[�^</param>
        /// <param name="detailDataSet">�O���b�h����</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : �����\���p�f�[�^���擾���܂��B ��SearchBefore�ASearchNext�̑O�ɌĂяo���K�v������܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public bool SearchFirst(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // ����ȊO�̌Ăяo����NG
            if (this._estmtAnsInfoHTableIndex != -1)
            {
                supplierDataSet = null;
                detailDataSet = null;
                return false;
            }

            bool status = this.GetDispInfoAll(ESTMTANSINFO_FIRST, out supplierDataSet, out detailDataSet);
            return status;
        }
        #endregion

        #region ��SearchBefore(�O�f�[�^����)
        /// <summary>
        /// �O�f�[�^�擾
        /// </summary>
        /// <param name="supplierDataSet">�O���b�h���׈ȊO(�w�b�_�[�A�O���b�h�w�b�_�[�A���v)�̃f�[�^</param>
        /// <param name="detailDataSet">�O���b�h����</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : ���ݑI������Ă���f�[�^��1�O�̃f�[�^���擾���܂��B�f�[�^�������ꍇ��false���Ԃ�܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public bool SearchBefore(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 1�O�̃f�[�^���擾
            bool status = this.GetDispInfoAll(this._estmtAnsInfoHTableIndex - 1, out supplierDataSet, out detailDataSet);
            return status;
        }
        #endregion

        #region ��SearchNext(���f�[�^����)
        /// <summary>
        /// ���f�[�^�擾
        /// </summary>
        /// <param name="supplierDataSet">�O���b�h���׈ȊO(�w�b�_�[�A�O���b�h�w�b�_�[�A���v)�̃f�[�^</param>
        /// <param name="detailDataSet">�O���b�h����</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : ���ݑI������Ă���f�[�^��1��̃f�[�^���擾���܂��B�f�[�^�������ꍇ��false���Ԃ�܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public bool SearchNext(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 1��̃f�[�^���擾
            bool status = this.GetDispInfoAll(this._estmtAnsInfoHTableIndex + 1, out supplierDataSet, out detailDataSet);
            return status;
        }
        #endregion
        #endregion ��Public���\�b�h - end

        #region ��Private���\�b�h
        #region ���O���b�h�w�b�_�[HashTable�֘A
        #region ��CreateGridHeaderHTable(HashTable�쐬)
        // �O���b�h�w�b�_�[HashTable�쐬
        /// <summary>
        /// �O���b�h�w�b�_�[HashTable�쐬
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�w�b�_�[HashTable���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void CreateGridHeaderHTable()
        {
            // this.SetGridHeaderInfo(�ʐM�A�Z���u��ID(�ʐM�v���O����ID), �݌ɐ�1, �݌ɐ�2, �[��, ���);
            this.AddGridHeaderInfoHTable(PROGRAMID_NOTHING, "", "", "", "");                        // ����
            this.AddGridHeaderInfoHTable(PROGRAMID_TOYOTA, "�{��", "���_", "�[��", "���");         // �g���^
            this.AddGridHeaderInfoHTable(PROGRAMID_NISSAN, "", "", "�w��", "�݊�");                 // �j�b�T��
            this.AddGridHeaderInfoHTable(PROGRAMID_MITSUBISHI, "�{��", "���_", "���i�f", "���");   // �~�c�r�V
            this.AddGridHeaderInfoHTable(PROGRAMID_MATSUDA_OLD, "�{��", "���_", "���i��", "�݊�");  // ���}�c�_
            this.AddGridHeaderInfoHTable(PROGRAMID_MATSUDA_NEW, "", "", "���i��", "�݊�");          // �V�}�c�_
            this.AddGridHeaderInfoHTable(PROGRAMID_HONDA, "�{��", "���_", "�[��", "���");          // �z���_
        }
        #endregion

        #region ��AddGridHeaderInfoHTable(HashTable�Ƀf�[�^�ǉ�)
        /// <summary>
        /// �O���b�h�w�b�_�[HashTable�f�[�^�ǉ�
        /// </summary>
        /// <param name="key">HashTable�L�[</param>
        /// <param name="Variable1">�ύ��ږ���1</param>
        /// <param name="Variable2">�ύ��ږ���2</param>
        /// <param name="Variable3">�ύ��ږ���3</param>
        /// <param name="Variable4">�ύ��ږ���4</param>
        /// <remarks>
        /// <br>Note       : �n���ꂽ�l������HashTable�Ƀf�[�^��ǉ����܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void AddGridHeaderInfoHTable(int key, string Variable1, string Variable2, string Variable3, string Variable4)
        {
            if (this._gridHeaderHTable == null)
            {
                this._gridHeaderHTable = new Hashtable();
            }

            GridHeaderInfo gridHeaderInfo = new GridHeaderInfo();
            gridHeaderInfo.Add(Variable1, Variable2, Variable3, Variable4);

            // HashTable�ɒǉ�(�L�[�F�ʐM�A�Z���u��ID(�ʐM�v���O����ID))
            this._gridHeaderHTable[key] = gridHeaderInfo;
        }
        #endregion

        #region ��GetHeaderVariableaName(HashTable��DataRow�R�s�[)
        /// <summary>
        /// �O���b�h�w�b�_�[HashTable�f�[�^�擾
        /// </summary>
        /// <param name="estmtSndRcvJnl">UOE����M�W���[�i��(����)</param>
        /// <param name="dataRow">�O���b�h�w�b�_�[�ۑ��pDataRow</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�w�b�_�[HashTable���f�[�^���擾���ADataRow�ɕۑ����܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void GetHeaderVariableName(EstmtSndRcvJnl estmtSndRcvJnl, ref DataRow dataRow)
        {
            // UOE����������ɒʐM�A�Z���u��ID(�ʐM�v���O����ID)���擾
            int programId = this.GetProgramIdFromUOEOrderDtlHTable(estmtSndRcvJnl.UOESupplierCd);

            // �w�b�_�[���擾
            if (this._gridHeaderHTable.ContainsKey(programId) == false )
            {
                dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName1] = string.Empty;
                dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName2] = string.Empty;
                dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName3] = string.Empty;
                dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName4] = string.Empty;
                return;
            }

            GridHeaderInfo gridHeaderInfo = (GridHeaderInfo)this._gridHeaderHTable[programId];

            if (programId == PROGRAMID_MATSUDA_NEW)
            {
                // �V�}�c�_�̂�UOE�K�C�h���̃}�X�^���擾
                dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName1] = this.GetUOEGuideNm(estmtSndRcvJnl.UOESectionCode1, estmtSndRcvJnl.UOESupplierCd);
                dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName2] = this.GetUOEGuideNm(estmtSndRcvJnl.UOESectionCode2, estmtSndRcvJnl.UOESupplierCd);
            }
            else
            {
                dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName1] = gridHeaderInfo.variableName1;
                dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName2] = gridHeaderInfo.variableName2;
            }
            dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName3] = gridHeaderInfo.variableName3;
            dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName4] = gridHeaderInfo.variableName4;
        }
        #endregion
        #endregion ���O���b�h�w�b�_�[HashTable�֘A - end

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
                string key = dataRow["UOEGuideCode"].ToString() + "-" + dataRow["UOESupplierCd"].ToString();    // �L�[�F�K�C�h�R�[�h(UOE���_�R�[�h)-UOE������R�[�h
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
                int code = 0;
                bool ret = int.TryParse(uoeSectionCode, out code);
                //return code.ToString("0000");         //DEL 2008/12/19
                return code.ToString();                 //ADD 2008/12/19
            }

            string key = uoeSectionCode + "-" + uoeSupplierCd.ToString();
            if (this._uoeGuideNameHTable.ContainsKey(key))
            {
                return this._uoeGuideNameHTable[key].ToString();
            }
            else
            {
                int code = 0;
                bool ret = int.TryParse(uoeSectionCode, out code);
                //return code.ToString("0000");         //DEL 2008/12/19
                return code.ToString();                 //ADD 2008/12/19   
            }
        }
        #endregion
        #endregion ��UOE�K�C�h���̃}�X�^HashTable�֘A - end

        #region �����ω񓚏��HashTable�֘A
        #region ��CreateEstmtAnsInfoHTable(HashTable�쐬)
        /// <summary>
        /// ���ω񓚏��HashTable�쐬
        /// </summary>
        /// <param name="estmtSndRcvJnlList">UOE����M�W���[�i��(����)���X�g</param>
        /// <remarks>
        /// <br>Note       : �n���ꂽUOE����M�W���[�i��(����)���X�g��UOE������AUOE�����ԍ��P�ʂɂ܂Ƃ߂�HashTable�Ɋi�[���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void CreateEstmtAnsInfoHTable(List<EstmtSndRcvJnl> estmtSndRcvJnlList)
        {

            string bfKey = string.Empty;
            int listCnt = 0;
            int hashTableCnt = 0;
            List<EstmtSndRcvJnl> estmtAnsInfoListGroup = new List<EstmtSndRcvJnl>();

            this._estmtAnsInfoHTable = new Hashtable();
            foreach (EstmtSndRcvJnl estmtSndRcvJnl in estmtSndRcvJnlList)
            {
                // �L�[�FUOE������-UOE�����ԍ�
                string key = estmtSndRcvJnl.UOESupplierCd + "-" + estmtSndRcvJnl.UOESalesOrderNo;

                if ((bfKey != key) && (bfKey != string.Empty))
                {
                    // �ŏ��ȊO�ŃL�[���ς������
                    // UOE������,�����ԍ��P�ʂɂ܂Ƃ߂��f�[�^��HashTable�ɒǉ�
                    this._estmtAnsInfoHTable[hashTableCnt] = estmtAnsInfoListGroup;
                    hashTableCnt++;

                    // ������
                    estmtAnsInfoListGroup = new List<EstmtSndRcvJnl>();
                    listCnt = 0;
                }

                estmtAnsInfoListGroup.Add(estmtSndRcvJnl);
                listCnt++;

                bfKey = key;
            }

            // �Ō�̃f�[�^��HashTable�ɒǉ�
            this._estmtAnsInfoHTable[hashTableCnt] = estmtAnsInfoListGroup;

            // �����ʒu
            this._estmtAnsInfoHTableIndex = -1;
        }
        #endregion

        #region ��GetDispInfoAll(HashTable�f�[�^�擾)
        /// <summary>
        /// ���ω񓚏��HashTable�f�[�^�擾
        /// </summary>
        /// <param name="index">�����ʒu</param>
        /// <param name="supplierDataSet">�O���b�h���׈ȊO(�w�b�_�[�A�O���b�h�w�b�_�[�A���v)�̃f�[�^</param>
        /// <param name="detailDataSet">�O���b�h���׃f�[�^</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽindex�����Ɍ��ω񓚏��HashTable����f�[�^���擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private bool GetDispInfoAll(int index, out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            detailDataSet = null;
            supplierDataSet = null;

            // �f�[�^������
            if (this._estmtAnsInfoHTable == null)
            {
                return false;
            }

            // INDEX�͈͊O
            if (this._estmtAnsInfoHTable.ContainsKey(index) == false)
            {
                return false;
            }

            // ���׈ȊO�pDataTable�쐬
            DataTable supplierDataTable = null;
            PMUOE04112EA.CreateDataTableSupplier(ref supplierDataTable);

            // ���חpDataTable�쐬
            DataTable detailDataTable = null;
            PMUOE04112EA.CreateDataTableDetail(ref detailDataTable);

            double answerListPriceTotal = 0;
            double answerSalesUnitCostTotal = 0;
            DataRow supplierDataRow = supplierDataTable.NewRow();

            List<EstmtSndRcvJnl> estmtSndRcvJnlList = (List<EstmtSndRcvJnl>)this._estmtAnsInfoHTable[index];
            foreach (EstmtSndRcvJnl estmtSndRcvJnl in estmtSndRcvJnlList)
            {
                // �ŏ��̂�
                if (detailDataTable.Rows.Count == 0)
                {
                    // ��ʕ\���p��������擾
                    supplierDataRow[PMUOE04112EA.ct_Col_UOESupplierName] = estmtSndRcvJnl.UOESupplierName;  // ������
                    supplierDataRow[PMUOE04112EA.ct_Col_UoeRemark1] = estmtSndRcvJnl.UoeRemark1;            // ���}�[�N�P
                    supplierDataRow[PMUOE04112EA.ct_Col_UoeRemark2] = estmtSndRcvJnl.UoeRemark2;            // ���}�[�N�Q

                    // �O���b�h�w�b�_�[���쐬
                    this.GetHeaderVariableName(estmtSndRcvJnl, ref supplierDataRow);
                }

                // dataRow�쐬
                DataRow detailDataRow = detailDataTable.NewRow();
                this.CopyToDataRowFromEstmtSndRcvJnl(estmtSndRcvJnl, ref detailDataRow);

                detailDataTable.Rows.Add(detailDataRow);

                // ���v�Z�o
                /* ---DEL 2009/01/20 �s��Ή�[10256] ----------------------------------------->>>>>
                //answerListPriceTotal += estmtSndRcvJnl.AnswerListPrice;
                //answerSalesUnitCostTotal += estmtSndRcvJnl.AnswerSalesUnitCost;
                   ---DEL 2009/01/20 �s��Ή�[10256] -----------------------------------------<<<<< */
                // ---ADD 2009/01/20 �s��Ή�[10256] ----------------------------------------->>>>>
                answerListPriceTotal += estmtSndRcvJnl.AnswerListPrice * estmtSndRcvJnl.AcceptAnOrderCnt;               // ���ύ��v
                answerSalesUnitCostTotal += estmtSndRcvJnl.AnswerSalesUnitCost * estmtSndRcvJnl.AcceptAnOrderCnt;       // �d�؍��v
                // ---ADD 2009/01/20 �s��Ή�[10256] -----------------------------------------<<<<<
            }

            // ��ʕ\���p���v�l�쐬
            supplierDataRow[PMUOE04112EA.ct_Col_AnswerListPriceTotal] = answerListPriceTotal.ToString("#,##0");             // �W�����i���v
            supplierDataRow[PMUOE04112EA.ct_Col_AnswerSalesUnitCostTotal] = answerSalesUnitCostTotal.ToString("#,##0");     // ���P�����v

            supplierDataTable.Rows.Add(supplierDataRow);

            // �߂�l�pDataSet�쐬
            supplierDataSet = new DataSet();
            supplierDataSet.Tables.Add(supplierDataTable);

            detailDataSet = new DataSet();
            detailDataSet.Tables.Add(detailDataTable);

            this._estmtAnsInfoHTableIndex = index;      // ���݂̈ʒu
            return true;
        }
        #endregion

        #region ��CopyToDataRowFromEstmtSndRcvJnl(UOE����M�W���[�i����DataRow�R�s�[)
        /// <summary>
        /// UOE����M�W���[�i��(����)��DataRow�쐬
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="estmtSndRcvJnl"></param>
        /// <remarks>
        /// <br>Note       : UOE����M�W���[�i��(����)�̓��e������DataRow���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void CopyToDataRowFromEstmtSndRcvJnl(EstmtSndRcvJnl estmtSndRcvJnl, ref DataRow dataRow)
        {
            dataRow[PMUOE04112EA.ct_Col_UOESalesOrderRowNo] = estmtSndRcvJnl.UOESalesOrderRowNo;    // UOE�����s�ԍ�
            dataRow[PMUOE04112EA.ct_Col_GoodsNo] = estmtSndRcvJnl.GoodsNo;                          // �i��
            // ���[�J�[
            if (estmtSndRcvJnl.GoodsMakerCd == 0)
            {
                dataRow[PMUOE04112EA.ct_Col_GoodsMakerCd] = "";
            }
            else
            {
                dataRow[PMUOE04112EA.ct_Col_GoodsMakerCd] = estmtSndRcvJnl.GoodsMakerCd.ToString("0000");
            }
            /* ---DEL 2009/01/20 �s��Ή�[10208] ----------------------------------------------------------------------------------->>>>>
            //dataRow[PMUOE04112EA.ct_Col_GoodsName] = estmtSndRcvJnl.GoodsName;                      // �i��       //DEL 2008/12/10 �񓚕i����\��
            dataRow[PMUOE04112EA.ct_Col_GoodsName] = estmtSndRcvJnl.AnswerPartsName;                // �񓚕i��     //ADD 2008/12/10
               ---DEL 2009/01/20 �s��Ή�[10208] -----------------------------------------------------------------------------------<<<<< */
            dataRow[PMUOE04112EA.ct_Col_GoodsName] = estmtSndRcvJnl.GoodsName;                      // �񓚕i��     //ADD 2009/01/20 �s��Ή�[10208]
            dataRow[PMUOE04112EA.ct_Col_AcceptAnOrderCnt] = estmtSndRcvJnl.AcceptAnOrderCnt;        // ����
            dataRow[PMUOE04112EA.ct_Col_AnswerListPrice] = estmtSndRcvJnl.AnswerListPrice;          // �W�����i
            dataRow[PMUOE04112EA.ct_Col_AnswerSalesUnitCost] = estmtSndRcvJnl.AnswerSalesUnitCost;  // ���P��

            // �R�����g
            /* ---DEL 2009/01/22 �s��Ή�[10344] ------------------------------------------->>>>>
            if (string.IsNullOrEmpty(estmtSndRcvJnl.HeadErrorMassage) == false)
            {
                dataRow[PMUOE04112EA.ct_Col_Comment] = estmtSndRcvJnl.HeadErrorMassage;
            }
            else if (string.IsNullOrEmpty(estmtSndRcvJnl.LineErrorMassage) == false)
            {
                dataRow[PMUOE04112EA.ct_Col_Comment] = estmtSndRcvJnl.LineErrorMassage;
            }
            else if (string.IsNullOrEmpty(estmtSndRcvJnl.SubstPartsNo) == false)
            {
                dataRow[PMUOE04112EA.ct_Col_Comment] = estmtSndRcvJnl.SubstPartsNo;
            }
            else
            {
                dataRow[PMUOE04112EA.ct_Col_Comment] = string.Empty;
            }
               ---DEL 2009/01/22 �s��Ή�[10344] -------------------------------------------<<<<< */
            // ---DEL 2009/01/22 �s��Ή�[10344] ------------------------------------------->>>>>
            if (string.IsNullOrEmpty(estmtSndRcvJnl.HeadErrorMassage.Trim()) == false)
            {
                dataRow[PMUOE04112EA.ct_Col_Comment] = estmtSndRcvJnl.HeadErrorMassage;
            }
            else if (string.IsNullOrEmpty(estmtSndRcvJnl.LineErrorMassage.Trim()) == false)
            {
                dataRow[PMUOE04112EA.ct_Col_Comment] = estmtSndRcvJnl.LineErrorMassage;
            }
            else if (string.IsNullOrEmpty(estmtSndRcvJnl.SubstPartsNo.Trim()) == false)
            {
                dataRow[PMUOE04112EA.ct_Col_Comment] = estmtSndRcvJnl.SubstPartsNo;
            }
            else
            {
                dataRow[PMUOE04112EA.ct_Col_Comment] = string.Empty;
            }
            // ---DEL 2009/01/22 �s��Ή�[10344] -------------------------------------------<<<<<

            #region �ύ���
            // UOE����������ɒʐM�A�Z���u��ID(�ʐM�v���O����ID)�擾
            int programId = this.GetProgramIdFromUOEOrderDtlHTable(estmtSndRcvJnl.UOESupplierCd);

            switch (programId)
            {
                case PROGRAMID_TOYOTA:
                    {
                        dataRow[PMUOE04112EA.ct_Col_Variable1] = estmtSndRcvJnl.HeadQtrsStock;      // �{���݌�
                        dataRow[PMUOE04112EA.ct_Col_Variable2] = estmtSndRcvJnl.BranchStock;        // ���_�݌�
                        dataRow[PMUOE04112EA.ct_Col_Variable3] = estmtSndRcvJnl.UOEDelivDateCd;     // UOE�[���R�[�h
                        dataRow[PMUOE04112EA.ct_Col_Variable4] = estmtSndRcvJnl.UOESubstCode;       // UOE��փR�[�h
                        break;
                    }
                case PROGRAMID_NISSAN:
                    {
                        dataRow[PMUOE04112EA.ct_Col_Variable1] = string.Empty;                      // �Ȃ�
                        dataRow[PMUOE04112EA.ct_Col_Variable2] = string.Empty;                      // �Ȃ�
                        dataRow[PMUOE04112EA.ct_Col_Variable3] = estmtSndRcvJnl.PartsLayerCd;       // �w��
                        dataRow[PMUOE04112EA.ct_Col_Variable4] = estmtSndRcvJnl.UOESubstCode;       // UOE��փR�[�h
                        break;
                    }
                case PROGRAMID_MITSUBISHI:
                    {
                        dataRow[PMUOE04112EA.ct_Col_Variable1] = estmtSndRcvJnl.HeadQtrsStock;      // �{���݌�
                        dataRow[PMUOE04112EA.ct_Col_Variable2] = estmtSndRcvJnl.BranchStock;        // ���_�݌�
                        dataRow[PMUOE04112EA.ct_Col_Variable3] = estmtSndRcvJnl.UOEPriceCode;       // UOE���i�R�[�h
                        dataRow[PMUOE04112EA.ct_Col_Variable4] = estmtSndRcvJnl.UOESubstCode;       // UOE��փR�[�h
                        break;
                    }
                case PROGRAMID_MATSUDA_OLD:
                    {
                        dataRow[PMUOE04112EA.ct_Col_Variable1] = estmtSndRcvJnl.HeadQtrsStock;      // �{���݌�
                        dataRow[PMUOE04112EA.ct_Col_Variable2] = estmtSndRcvJnl.BranchStock;        // ���_�݌�
                        dataRow[PMUOE04112EA.ct_Col_Variable3] = estmtSndRcvJnl.UOEPriceCode;       // UOE���i�R�[�h
                        dataRow[PMUOE04112EA.ct_Col_Variable4] = estmtSndRcvJnl.UOESubstCode;       // UOE��փR�[�h
                        break;
                    }
                case PROGRAMID_MATSUDA_NEW:
                    {
                        dataRow[PMUOE04112EA.ct_Col_Variable1] = estmtSndRcvJnl.UOESectionStock1;   // UOE���_�݌�1
                        dataRow[PMUOE04112EA.ct_Col_Variable2] = estmtSndRcvJnl.UOESectionStock2;   // UOE���_�݌�2
                        dataRow[PMUOE04112EA.ct_Col_Variable3] = estmtSndRcvJnl.UOEPriceCode;       // UOE���i�R�[�h
                        dataRow[PMUOE04112EA.ct_Col_Variable4] = estmtSndRcvJnl.UOESubstCode;       // UOE��փR�[�h
                        break;
                    }
                case PROGRAMID_HONDA:
                    {
                        dataRow[PMUOE04112EA.ct_Col_Variable1] = estmtSndRcvJnl.HeadQtrsStock;      // �{���݌�
                        dataRow[PMUOE04112EA.ct_Col_Variable2] = estmtSndRcvJnl.BranchStock;        // ���_�݌�
                        dataRow[PMUOE04112EA.ct_Col_Variable3] = estmtSndRcvJnl.UOEDelivDateCd;     // UOE�[���R�[�h
                        dataRow[PMUOE04112EA.ct_Col_Variable4] = estmtSndRcvJnl.UOESubstCode;       // UOE��փR�[�h
                        break;
                    }
                default:
                    {
                        dataRow[PMUOE04112EA.ct_Col_Variable1] = string.Empty;                      // �{���݌�
                        dataRow[PMUOE04112EA.ct_Col_Variable2] = string.Empty;                      // ���_�݌�
                        dataRow[PMUOE04112EA.ct_Col_Variable3] = string.Empty;                      // UOE�[���R�[�h
                        dataRow[PMUOE04112EA.ct_Col_Variable4] = string.Empty;                      // ���
                        break;
                    }
            }
            #endregion
        }
        #endregion
        #endregion �����ω񓚏��HashTable�֘A - end
        #endregion ��Private���\�b�h - end
    }
}

