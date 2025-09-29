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
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����񓚕\���@�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �����񓚕\���Ɋւ���A�N�Z�X������s���܂��B</br>
    /// <br>Programmer	: �Ɠc �M�u</br>
    /// <br>Date		: 2008/11/06</br>
    /// <br>UpdateNote  : 2008/11/28 �Ɠc �M�u�@�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>              2008/12/18 �Ɠc �M�u�@�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>               �@�V�}�c�_�͂l�e����"�a�n"�Ƃ��ă^�C�g���\��</br>
    /// <br>               �A�z���_�̕\�����@�ύX</br>
    /// <br>               �B�W���P���A���P����0�ƂȂ�o�O�C��</br>
    /// <br>               �C���������N���X���ڒǉ�</br>
    /// <br>              2009/01/20 �Ɠc �M�u�@�s��Ή�[10165]</br>
    /// <br>              2009/01/21 �Ɠc �M�u�@�s��Ή�[10134][10173]</br>
    /// <br>              2010/01/20 �H�� �b�D�@�g���^ UOE Web �Ή�</br>
    /// <br>Update Note : 2010/03/08 �k���r PM1006</br>
    /// <br>              �O���b�h�^�C�g���̕\������Ή�</br>
    /// <br>UpdateNote  : 2010/04/27 zhshh</br>
    /// <br>              PM1007C �O�HUOE-WEB�Ή��ɔ����d�l�ǉ�</br>
    /// <br>UpdateNote  : 2010/05/14 ������</br>
    /// <br>              PM1008 �O���b�h�^�C�g���̕\������̑Ή�(����UOEWeb)</br>
    /// <br>UpdateNote  : 2010/12/31 ������</br>
    /// <br>              UOE����������</br>
    /// <br>UpdateNote  : 2011/01/30 �� ��</br>
    /// <br>              UOE����������</br>
    /// <br>UpdateNote  : 2011/03/01 liyp</br>
    /// <br>              ���YUOE������B�Ή�</br>
    /// <br>UpdateNote  : 2011/05/10 �{�z��</br>
    /// <br>              �O���b�h�w�b�_�[HashTable�֘A�̕ύX</br>
    /// <br>UpdateNote  : 2011/10/25 ������</br>
    /// <br>              ��NET-WEB�Ή��ɔ����d�l�ǉ� �O���b�h�w�b�_�[HashTable�֘A�̕ύX</br>
    /// </remarks>
    public class PMUOE04104AA
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
        // --- ADD 2011/10/25 ---------->>>>>
        private const int PROGRAMID_NET_WEB = 1003;       //��NET-WEB
        // --- ADD 2011/10/25 ----------<<<<<
        // --- ADD 2010/05/14 ---------->>>>>
        private const int PROGRAMID_MEIJI_WEB = 1004;        // ����UOE(web)
        // --- ADD 2010/05/14 ----------<<<<<
        // ADD 2010/01/20 �g���^ UOE Web �Ή� ---------->>>>>
        private const int PROGRAMID_TOYOTA_WEB= 103;        // �g���^ �d�q�J�^���O
        private const int PROGRAMID_HONDA_WEB = 502;        // �z���_ e-Parts
        // ADD 2010/01/20 �g���^ UOE Web �Ή� ----------<<<<<
        // --- ADD 2010/03/08 ---------->>>>>
        private const int PROGRAMID_NISSAN_WEB = 203;        // ���YUOE(web)
        // --- ADD 2010/03/08 ----------<<<<<
        // --- ADD 2010/04/27 ---------->>>>>
        private const int PROGRAMID_MITSUBISHI_WEB = 302;        // �O�HUOE(web)
        // --- ADD 2010/04/27 ----------<<<<<
        // --- ADD 2010/12/31 ---------->>>>>
        private const int PROGRAMID_NISSAN_AUTOWEB = 204;        // ���YUOE(web����)
        private const int PROGRAMID_MITSUBISHI_AUTOWEB = 303;    // �O�HUOE(web����)
        // --- ADD 2010/12/31 ----------<<<<<
        private const int PROGRAMID_TOYOTA_104 = 104;        // �g���^�������� // ADD 2011/01/30 �� ��
        // --- ADD 2011/03/01 ------------------------------------------>>>>>
        private const int PROGRAMID_NISSAN_WEB_205 = 205;
        private const int PROGRAMID_NISSAN_WEB_206 = 206;
        // --- ADD 2011/03/01 ------------------------------------------<<<<<
        // --- ADD 2011/05/10 ---------->>>>>
        private const int PROGRAMID_MAZDA_WEB = 403;        // �}�Y�_UOE
        // --- ADD 2010/05/10 ----------<<<<<
        // �f�[�^
        private const int ORDERANSINFO_FIRST = 0;           // �����񓚏�񏉊��f�[�^�ʒu

        // HashTable
        private Hashtable _orderAnsInfoHTable = null;       // �����񓚏��(key�FINDEX)
        private Hashtable _gridHeaderHTable = null;         // �O���b�h�w�b�_�[(key�F�ʐM�A�Z���u��ID(�ʐM�v���O����ID))
        private Hashtable _uoeOrderDtlHTable = null;        // UOE������}�X�^(key�FUOE������R�[�h)

        private string _enterpriseCode = string.Empty;      // ��ƃR�[�h
        private string _sectionCode = string.Empty;         // ���_�R�[�h
        private int _orderAnsInfoHTableIndex = 0;           // �����񓚏��INDEX

        private IUOEAnswerLedgerOrderWorkDB _iUOEAnswerLedgerOrderWorkDB = null;        // �����f�[�^�擾�p�����[�g�I�u�W�F�N�g

        #region GridHeaderInfo�\����
        /// <summary>
        /// �O���b�h�w�b�_�[���@�\����
        /// </summary>
        internal struct GridHeaderInfo
        {
            private string _variableName1;      // ���_�`�[
            private string _variableName2;      // BO�`�[1
            private string _variableName3;      // BO�`�[2
            private string _variableName4;      // BO�`�[3
            private string _variableName5;      // BO�Ǘ�No.
            private string _variableName6;      // MF

            /// <summary>
            /// �O���b�h�w�b�_�[�f�[�^�ǉ�
            /// </summary>
            /// <param name="variableName1">�ύ��ږ���1(���_�`�[)</param>
            /// <param name="variableName2">�ύ��ږ���2(BO�`�[1)</param>
            /// <param name="variableName3">�ύ��ږ���3(BO�`�[2)</param>
            /// <param name="variableName4">�ύ��ږ���4(BO�`�[3)</param>
            /// <param name="variableName5">�ύ��ږ���5(BO�Ǘ�No.)</param>
            /// <param name="variableName6">�ύ��ږ���6(MF)</param>
            public void Add(string variableName1, string variableName2, string variableName3, string variableName4,string variableName5, string variabelName6)
            {
                _variableName1 = variableName1;
                _variableName2 = variableName2;
                _variableName3 = variableName3;
                _variableName4 = variableName4;
                _variableName5 = variableName5;
                _variableName6 = variabelName6;
            }

            /// <summary>�ύ��ږ���1(���_�`�[)</summary>
            public string variableName1
            {
                get { return _variableName1; }
            }
            /// <summary>�ύ��ږ���2(BO�`�[1)</summary>
            public string variableName2
            {
                get { return _variableName2; }
            }
            /// <summary>�ύ��ږ���3(BO�`�[2)</summary>
            public string variableName3
            {
                get { return _variableName3; }
            }
            /// <summary>�ύ��ږ���4(BO�`�[3)</summary>
            public string variableName4
            {
                get { return _variableName4; }
            }
            /// <summary>�ύ��ږ���5(BO�Ǘ�No.)</summary>
            public string variableName5
            {
                get { return _variableName5; }
            }
            /// <summary>�ύ��ږ���6(MF)</summary>
            public string variableName6
            {
                get { return _variableName6; }
            }
        }
        #endregion

        #region UOEOrderDtlInfo�\����
        internal struct UOEOrderDtlInfo
        {
            private string _programId;          // �ʐM�A�Z���u��ID(�v���O����ID)
            private string _uoeSupplierName;    // UOE�����於��
            private string _hondaSectionCode;   // �S�����_(�z���_����)

            /// <summary>
            /// ������}�X�^�f�[�^�ǉ�
            /// </summary>
            /// <param name="programId">�ʐM�A�Z���u��ID(�v���O����ID)</param>
            /// <param name="uoeSupplierName">UOE�����於��</param>
            /// <param name="hondaSectionCode">�S�����_(�z���_����)</param>
            /* --- DEL 2008/12/18 �A -------------------------------------------------->>>>>
            public void Add(string programId, string uoeSupplierName)
            {
                _programId = programId;
                _uoeSupplierName = uoeSupplierName;
            }
               --- DEL 2008/12/18 �A --------------------------------------------------<<<<< */
            // --- ADD 2008/12/18 �A -------------------------------------------------->>>>>
            public void Add(string programId, string uoeSupplierName, string hondaSectionCode)
            {
                _programId = programId;
                _uoeSupplierName = uoeSupplierName;
                _hondaSectionCode = hondaSectionCode;
            }
            // --- ADD 2008/12/18 �A --------------------------------------------------<<<<<
            /// <summary> �ʐM�A�Z���u��ID(�v���O����ID) </summary>
            public string ProgramId { get { return _programId; } }
            /// <summary> UOE�����於�� </summary>
            public string UOESupplierName { get { return _uoeSupplierName; } }
            /// <summary> �S�����_(�z���_����) </summary>
            public string HondaSectionCode { get { return _hondaSectionCode; } }        //ADD 2008/12/18 �A
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
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        public PMUOE04104AA(List<OrderSndRcvJnl> orderSndRcvJnlList, string enterpriseCode, string sectionCode)
        {
            // ��ƃR�[�h
            this._enterpriseCode = enterpriseCode;

            // ���_�R�[�h
            this._sectionCode = sectionCode;

            // �O���b�h�w�b�_�[
            this.CreateGridHeaderHTable();

            // UOE������}�X�^
            this.CreateUOEOrderDtlHTable();

            if (orderSndRcvJnlList == null)
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iUOEAnswerLedgerOrderWorkDB = (IUOEAnswerLedgerOrderWorkDB)MediationUOEAnswerLedgerOrderWorkDB.GetUOEAnswerLedgerOrderWorkDB();

                this._orderAnsInfoHTable = null;
            }
            else
            {
                // UOE����M�W���[�i���f�[�^
                this.CreateOrderAnsInfoHTable(orderSndRcvJnlList);
            }
        }
        # endregion ��Constructor - end

        #region ��Public���\�b�h
        #region ��SearchFirst(���񌟍�)
        /// <summary>
        /// �����\���f�[�^�擾(�P�̋N���ȊO��)
        /// </summary>
        /// <param name="supplierDataSet">�O���b�h���׈ȊO(�w�b�_�[�A�O���b�h�w�b�_�[)�̃f�[�^</param>
        /// <param name="detailDataSet">�O���b�h����</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : �����\���p�f�[�^���擾���܂��B ��SearchBefore�ASearchNext�̑O�ɌĂяo���K�v������܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        public bool SearchFirst(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // ����ȊO�̌Ăяo����NG
            if (this._orderAnsInfoHTableIndex != -1)
            {
                supplierDataSet = null;
                detailDataSet = null;
                return false;
            }

            bool status = this.GetDispInfoAll(ORDERANSINFO_FIRST, out supplierDataSet, out detailDataSet);
            return status;
        }

        /// <summary>
        /// �����\���f�[�^�擾(�P�̋N����p)
        /// </summary>
        /// <param name="uoeAnswerLedgerOrderCndtn">�����f�[�^���o����</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : �����\���p�f�[�^���擾���܂��B ��SearchBefore�ASearchNext�̑O�ɌĂяo���K�v������܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        public bool SearchFirst(UOEAnswerLedgerOrderCndtn uoeAnswerLedgerOrderCndtn, out string errorMsg)
        {
            List<OrderSndRcvJnl> orderSndRcvJnlList = null;

            // �����f�[�^���o
            bool status = this.CreateOrderSndRcvJnl(uoeAnswerLedgerOrderCndtn, out errorMsg, out orderSndRcvJnlList);
            if (status == true)
            {
                // ���o�f�[�^������HashTable���쐬
                this.CreateOrderAnsInfoHTable(orderSndRcvJnlList);
            }

            return status;
        }
        #endregion

        #region ��SearchBefore(�O�f�[�^����)
        /// <summary>
        /// �O�f�[�^�擾
        /// </summary>
        /// <param name="supplierDataSet">�O���b�h���׈ȊO(�w�b�_�[�A�O���b�h�w�b�_�[)�̃f�[�^</param>
        /// <param name="detailDataSet">�O���b�h����</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : ���ݑI������Ă���f�[�^��1�O�̃f�[�^���擾���܂��B�f�[�^�������ꍇ��false���Ԃ�܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        public bool SearchBefore(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 1�O�̃f�[�^���擾
            bool status = this.GetDispInfoAll(this._orderAnsInfoHTableIndex - 1, out supplierDataSet, out detailDataSet);
            return status;
        }
        #endregion

        #region ��SearchNext(���f�[�^����)
        /// <summary>
        /// ���f�[�^�擾
        /// </summary>
        /// <param name="supplierDataSet">�O���b�h���׈ȊO(�w�b�_�[�A�O���b�h�w�b�_�[)�̃f�[�^</param>
        /// <param name="detailDataSet">�O���b�h����</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : ���ݑI������Ă���f�[�^��1��̃f�[�^���擾���܂��B�f�[�^�������ꍇ��false���Ԃ�܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        public bool SearchNext(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 1��̃f�[�^���擾
            bool status = this.GetDispInfoAll(this._orderAnsInfoHTableIndex + 1, out supplierDataSet, out detailDataSet);
            return status;
        }
        #endregion

        #region ��ExistsUOESupplierCd(UOE������}�X�^���݃`�F�b�N�@�P�̋N����p)
        /// <summary>
        /// UOE������}�X�^���݃`�F�b�N
        /// </summary>
        /// <param name="uoeSupplierCd">UOE������R�[�h</param>
        /// <returns>True�F���݁AFalse�F������</returns>
        /// <remarks>
        /// <br>Note       : UOE������R�[�h��UOE������}�X�^�ɓo�^����Ă��邩�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        public bool ExistsUOESupplierCd(int uoeSupplierCd)
        {
            if (this._uoeOrderDtlHTable == null)
            {
                return false;
            }

            if (this._uoeOrderDtlHTable.ContainsKey(uoeSupplierCd) == false)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region ��GetUOESupplierName(UOE�����於�̎擾�@�P�̋N����p)
        /// <summary>
        /// UOE�����於�̎擾
        /// </summary>
        /// <param name="uoeSupplierCd">UOE������R�[�h</param>
        /// <returns>UOE�����於��</returns>
        /// <remarks>
        /// <br>Note       : UOE������R�[�h������UOE�����於�̂��擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        public string GetUOESupplierName(int uoeSupplierCd)
        {
            return this.GetUOESupplierNameFromUOEOrderDtlHTable(uoeSupplierCd);
        }
        #endregion

        #region ��GetGridHeaderDataSet(�O���b�h�σw�b�_�[���̎擾�@�P�̋N����p)
        /// <summary>
        /// �O���b�h�w�b�_�[���̎擾
        /// </summary>
        /// <param name="uoeSupplierCd">������R�[�h</param>
        /// <param name="dataSet">�w�b�_�[�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�w�b�_�[���̂��擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        public void GetGridHeaderDataSet(int uoeSupplierCd, out DataSet dataSet)
        {
            // DataTable�쐬
            DataTable supplierDataTable = null;
            PMUOE04103EA.CreateDataTableSupplier(ref supplierDataTable);

            // DataRow�쐬
            DataRow supplierDataRow = supplierDataTable.NewRow();

            // �f�[�^�擾
            this.GetHeaderVariableName(uoeSupplierCd, ref supplierDataRow);

            // DataSet�쐬
            supplierDataTable.Rows.Add(supplierDataRow);

            dataSet = new DataSet();
            dataSet.Tables.Add(supplierDataTable);
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
        /// <br>Date       : 2008/11/06</br>
        /// <br>UpdateNote : 2010/03/08 �k���r �O���b�h�^�C�g���̕\������̑Ή�</br>
        /// <br>UpdateNote : 2010/05/14 ������ �O���b�h�^�C�g���̕\������̑Ή�(����UOEWeb)</br>
        /// <br>UpdateNote : 2010/12/31 ������ UOE����������</br>
        /// <br>UpdateNote : 2011/01/30 �� �� UOE����������</br>
        /// <br>UpdateNote : 2011/03/01 liyp ���YUOE������B�Ή�</br>
        /// <br>UpdateNote : 2011/05/10 �{�z�� �O���b�h�w�b�_�[HashTable�֘A�̕ύX</br>
        /// <br>UpdateNote : 2011/10/25 ������ ��NET-WEB�Ή��ɔ����d�l�ǉ� �O���b�h�w�b�_�[HashTable�֘A�̕ύX</br>
        /// </remarks>
        private void CreateGridHeaderHTable()
        {
            // this.SetGridHeaderInfo(�ʐM�A�Z���u��ID(�ʐM�v���O����ID), ���_�`�[, BO�`�[1, BO�`�[2, BO�`�[3, BO�Ǘ�No., MF);
            this.AddGridHeaderInfoHTable(PROGRAMID_NOTHING, "", "", "", "", "", "");                                // ����
            this.AddGridHeaderInfoHTable(PROGRAMID_TOYOTA, "���_", "�r�e", "�g�e", "�q�e", "","�l�e");              // �g���^
            this.AddGridHeaderInfoHTable(PROGRAMID_NISSAN, "�����_", "�T�u", "���C��", "�����_","�d�n","�a�n");     // �j�b�T��
            this.AddGridHeaderInfoHTable(PROGRAMID_MITSUBISHI, "���_", "�T�u", "�{��", "", "", "�l�e");             // �~�c�r�V
            this.AddGridHeaderInfoHTable(PROGRAMID_MATSUDA_OLD, "���_", "�x�X", "�{��", "", "", "�a�n");            // ���}�c�_
            //this.AddGridHeaderInfoHTable(PROGRAMID_MATSUDA_NEW, "���_", "�����_", "�����_", "", "", "");            // �V�}�c�_       //DEL 2008/12/18 �@
            this.AddGridHeaderInfoHTable(PROGRAMID_MATSUDA_NEW, "���_", "�����_", "�����_", "", "", "�a�n");        // �V�}�c�_         //ADD 2008/12/18 �@
            //this.AddGridHeaderInfoHTable(PROGRAMID_HONDA, "���_", "�r�e", "", "�o�׌�", "", "");                    // �z���_         //DEL 2008/12/18 �A
            this.AddGridHeaderInfoHTable(PROGRAMID_HONDA, "", "���_", "", "�r�e", "", "");                          // �z���_           //ADD 2008/12/18 �A
            this.AddGridHeaderInfoHTable(PROGRAMID_PRIME, "���_", "�a�n", "", "", "", "");                          // �D��
            // ADD 2011/10/25 ---------->>>>>
            this.AddGridHeaderInfoHTable(PROGRAMID_NET_WEB, "���_", "�a�n", "", "", "", "");                        // ��NET-WEB
            // ADD 2011/10/25 ----------<<<<<
            // ADD 2010/01/20 �g���^ UOE Web �Ή� ---------->>>>>
            this.AddGridHeaderInfoHTable(PROGRAMID_TOYOTA_WEB, "���_", "�r�e", "�g�e", "�q�e", "", "�l�e"); // �g���^ �d�q�J�^���O
            this.AddGridHeaderInfoHTable(PROGRAMID_HONDA_WEB, "", "���_", "", "�r�e", "", "");              // �z���_ e-Parts
            // ADD 2010/01/20 �g���^ UOE Web �Ή� ----------<<<<<
            // --- ADD 2010/03/08 ---------->>>>>
            this.AddGridHeaderInfoHTable(PROGRAMID_NISSAN_WEB, "�����_", "�T�u", "���C��", "�����_", "�d�n", "�a�n"); // ���YUOE(web)
            // --- ADD 2010/03/08 ----------<<<<<
            this.AddGridHeaderInfoHTable(PROGRAMID_NISSAN_AUTOWEB, "�����_", "�T�u", "���C��", "�����_", "�d�n", "�a�n"); // ���YUOE(web����) // ADD 2010/12/31
            // --- ADD 2010/04/27 ---------->>>>>
            this.AddGridHeaderInfoHTable(PROGRAMID_MITSUBISHI_WEB, "���_", "�T�u", "�{��", "", "", "�l�e"); // �O�HUOE(web)
            // --- ADD 2010/04/27 ----------<<<<<
            this.AddGridHeaderInfoHTable(PROGRAMID_MITSUBISHI_AUTOWEB, "���_", "�T�u", "�{��", "", "", "�l�e"); // �O�HUOE(web����) // ADD 2010/12/31
            // --- ADD 2010/05/14 ---------->>>>>
            this.AddGridHeaderInfoHTable(PROGRAMID_MEIJI_WEB, "���_", "�a�n", "", "", "", ""); // ����UOE(web)
            // --- ADD 2010/05/14 ----------<<<<<
            this.AddGridHeaderInfoHTable(PROGRAMID_TOYOTA_104, "���_", "�r�e", "�g�e", "�q�e", "", "�l�e"); // �g���^�������� // ADD 2011/01/30 �� ��
            // --- ADD 2011/03/01 ---------->>>>>
            this.AddGridHeaderInfoHTable(PROGRAMID_NISSAN_WEB_205, "�����_", "�T�u", "���C��", "�����_", "�d�n", "�a�n");
            this.AddGridHeaderInfoHTable(PROGRAMID_NISSAN_WEB_206, "�����_", "�T�u", "���C��", "�����_", "�d�n", "�a�n");
            // --- ADD 2011/03/01 ----------<<<<<
            // --- ADD 2011/05/10 ---------->>>>>
            this.AddGridHeaderInfoHTable(PROGRAMID_MAZDA_WEB, "���_", "�T�u", "�{��", "", "", "�l�e"); // �}�Y�_UOE
            // --- ADD 2011/05/10 ----------<<<<<
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
        /// <param name="Variable5">�ύ��ږ���5</param>
        /// <param name="Variable6">�ύ��ږ���6</param>
        /// <remarks>
        /// <br>Note       : �n���ꂽ�l������HashTable�Ƀf�[�^��ǉ����܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void AddGridHeaderInfoHTable(int key, string variable1, string variable2, string variable3, string variable4, string variable5, string variable6)
        {
            if (this._gridHeaderHTable == null)
            {
                this._gridHeaderHTable = new Hashtable();
            }

            GridHeaderInfo gridHeaderInfo = new GridHeaderInfo();
            gridHeaderInfo.Add(variable1, variable2, variable3, variable4, variable5, variable6);

            // HashTable�ɒǉ�(�L�[�F�ʐM�A�Z���u��ID(�ʐM�v���O����ID))
            this._gridHeaderHTable[key] = gridHeaderInfo;
        }
        #endregion

        #region ��GetHeaderVariableaName(HashTable��DataRow�R�s�[)
        /// <summary>
        /// �O���b�h�w�b�_�[HashTable�f�[�^�擾
        /// </summary>
        /// <param name="orderSndRcvJnl">UOE����M�W���[�i��(����)</param>
        /// <param name="dataRow">�O���b�h�w�b�_�[�ۑ��pDataRow</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�w�b�_�[HashTable���f�[�^���擾���ADataRow�ɕۑ����܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void GetHeaderVariableName(int uoeSupplierCd, ref DataRow dataRow)
        {
            // UOE����������ɒʐM�A�Z���u��ID(�ʐM�v���O����ID)���擾
            int programId = this.GetProgramIdFromUOEOrderDtlHTable(uoeSupplierCd);

            // �w�b�_�[���擾
            if (this._gridHeaderHTable.ContainsKey(programId) == false )
            {
                dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName1] = string.Empty;
                dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName2] = string.Empty;
                dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName3] = string.Empty;
                dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName4] = string.Empty;
                dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName5] = string.Empty;
                dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName6] = string.Empty;
                return;
            }

            GridHeaderInfo gridHeaderInfo = (GridHeaderInfo)this._gridHeaderHTable[programId];
            // �ύ���
            dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName1] = gridHeaderInfo.variableName1;
            dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName2] = gridHeaderInfo.variableName2;
            dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName3] = gridHeaderInfo.variableName3;
            dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName4] = gridHeaderInfo.variableName4;
            dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName5] = gridHeaderInfo.variableName5;
            dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName6] = gridHeaderInfo.variableName6;

            // --- ADD 2008/12/18 �A --------------------------------------------------------------------------------------->>>>>
            // �z���_�̕\���̂ݓ���
            if (programId == PROGRAMID_HONDA)
            {
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName1] = "�o�׌�";
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName2] = "�o�א�";
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName3] = "�o�׌�";
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName4] = "�o�א�";
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName5] = string.Empty;
            }
            else
            {
            // --- ADD 2008/12/18 �A ---------------------------------------------------------------------------------------<<<<<
                // �w�o�א��x����
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName1] = this.GetHeaderShipmentName(gridHeaderInfo.variableName1);
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName2] = this.GetHeaderShipmentName(gridHeaderInfo.variableName2);
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName3] = this.GetHeaderShipmentName(gridHeaderInfo.variableName3);
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName4] = this.GetHeaderShipmentName(gridHeaderInfo.variableName4);
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName5] = this.GetHeaderShipmentName(gridHeaderInfo.variableName5);
            }   //ADD 2008/12/18 �A
        }
        #endregion

        #region ��GetHeaderShipmentName(�O���b�h�w�b�_�["�o�א�"�̕\��/��\���𔻒�)
        /// <summary>
        /// �O���b�h�w�b�_�["�o�א�"�\������
        /// </summary>
        /// <param name="variableName">�ύ��ږ���</param>
        /// <returns>�\������</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�w�b�_�[�̉ύ��ږ��̂����ɏo�א��̕\��/��\���𔻒肵�܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private string GetHeaderShipmentName(string variableName)
        {
            if (string.IsNullOrEmpty(variableName))
            {
                return string.Empty;
            }
            else
            {
                return "�o�א�";
            }
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
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void CreateUOEOrderDtlHTable()
        {
            DataSet retDataSet = new DataSet();

            // UOE������}�X�^�f�[�^�擾(PMUOE09022A)
            UOESupplierAcs uoeSupplierAcs = new UOESupplierAcs();
            int status = uoeSupplierAcs.Search(ref retDataSet, this._enterpriseCode, this._sectionCode);

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

                UOEOrderDtlInfo uoeOrderDtlInfo = new UOEOrderDtlInfo();
                //uoeOrderDtlInfo.Add(dataRow["CommAssemblyId"].ToString(), dataRow["UOESupplierName"].ToString());     //DEL 2008/12/18 �A
                // --- ADD 2008/12/18 �A --------------------------------------------------------------------------------------------->>>>>
                uoeOrderDtlInfo.Add(dataRow["CommAssemblyId"].ToString()
                                    , dataRow["UOESupplierName"].ToString()
                                    , dataRow["HondaSectionCode"].ToString());
                // --- ADD 2008/12/18 �A ---------------------------------------------------------------------------------------------<<<<<
                this._uoeOrderDtlHTable[key] = uoeOrderDtlInfo;
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
        /// <br>Date       : 2008/11/06</br>
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

            UOEOrderDtlInfo uoeOrderDtlInfo = (UOEOrderDtlInfo)this._uoeOrderDtlHTable[uoeSupplierCd];

            bool ret = int.TryParse(uoeOrderDtlInfo.ProgramId, out programId);
            return programId;
        }
        #endregion

        #region  ��GetUOESupplierNameFromUOEOrderDtlHTable(UOE�����於�̎擾)
        /// <summary>
        /// UOE�����於�̎擾
        /// </summary>
        /// <param name="uoeSupplierCd">UOE������R�[�h</param>
        /// <returns>UOE�����於��</returns>
        /// <remarks>
        /// <br>Note       : UOE������R�[�h������UOE������}�X�^HashTable����UOE�����於�̂��擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private string GetUOESupplierNameFromUOEOrderDtlHTable(int uoeSupplierCd)
        {
            string uoeSupplierName = string.Empty;

            // �f�[�^������
            if (this._uoeOrderDtlHTable == null)
            {
                return uoeSupplierName;
            }

            // INDEX�͈͊O
            if (this._uoeOrderDtlHTable.ContainsKey(uoeSupplierCd) == false)
            {
                return uoeSupplierName;
            }

            UOEOrderDtlInfo uoeOrderDtlInfo = (UOEOrderDtlInfo)this._uoeOrderDtlHTable[uoeSupplierCd];

            uoeSupplierName = uoeOrderDtlInfo.UOESupplierName;
            return uoeSupplierName;
        }
        #endregion

        #region  ��GetHondaSectionCodeFromUOEOrderDtlHTable(�S�����_(�z���_����)�擾)      ADD 2008/12/18 �A
        /// <summary>
        /// �S�����_(�z���_����)�擾
        /// </summary>
        /// <param name="uoeSupplierCd">UOE������R�[�h</param>
        /// <returns>�S�����_(�z���_����)</returns>
        /// <remarks>
        /// <br>Note       : UOE������R�[�h������UOE������}�X�^HashTable����S�����_(�z���_����)���擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/12/18</br>
        /// </remarks>
        private string GetHondaSectionCodeFromUOEOrderDtlHTable(int uoeSupplierCd)
        {
            string hondaSectionCode = string.Empty;

            // �f�[�^������
            if (this._uoeOrderDtlHTable == null)
            {
                return hondaSectionCode;
            }

            // INDEX�͈͊O
            if (this._uoeOrderDtlHTable.ContainsKey(uoeSupplierCd) == false)
            {
                return hondaSectionCode;
            }

            UOEOrderDtlInfo uoeOrderDtlInfo = (UOEOrderDtlInfo)this._uoeOrderDtlHTable[uoeSupplierCd];

            hondaSectionCode = uoeOrderDtlInfo.HondaSectionCode;
            return hondaSectionCode;
        }
        #endregion
        #endregion ��UOE������}�X�^HashTable�֘A - end

        #region �������񓚏��HashTable�֘A
        #region ��CreateOrderAnsInfoHTable(HashTable�쐬)
        /// <summary>
        /// �����񓚏��HashTable�쐬
        /// </summary>
        /// <param name="orderSndRcvJnlList">UOE����M�W���[�i��(����)���X�g</param>
        /// <remarks>
        /// <br>Note       : �n���ꂽUOE����M�W���[�i��(����)���X�g��UOE������AUOE�����ԍ��P�ʂɂ܂Ƃ߂�HashTable�Ɋi�[���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void CreateOrderAnsInfoHTable(List<OrderSndRcvJnl> orderSndRcvJnlList)
        {
            string bfKey = string.Empty;
            int listCnt = 0;
            int hashTableCnt = 0;
            List<OrderSndRcvJnl> orderAnsInfoListGroup = new List<OrderSndRcvJnl>();

            this._orderAnsInfoHTable = new Hashtable();
            foreach (OrderSndRcvJnl orderSndRcvJnl in orderSndRcvJnlList)
            {
                // �L�[�FUOE������-UOE�����ԍ�
                string key = orderSndRcvJnl.UOESupplierCd + "-" + orderSndRcvJnl.UOESalesOrderNo;

                if ((bfKey != key) && (bfKey != string.Empty))
                {
                    // �ŏ��ȊO�ŃL�[���ς������
                    // UOE������,�����ԍ��P�ʂɂ܂Ƃ߂��f�[�^��HashTable�ɒǉ�
                    this._orderAnsInfoHTable[hashTableCnt] = orderAnsInfoListGroup;
                    hashTableCnt++;

                    // ������
                    orderAnsInfoListGroup = new List<OrderSndRcvJnl>();
                    listCnt = 0;
                }

                orderAnsInfoListGroup.Add(orderSndRcvJnl);
                listCnt++;

                bfKey = key;
            }

            // �Ō�̃f�[�^��HashTable�ɒǉ�
            this._orderAnsInfoHTable[hashTableCnt] = orderAnsInfoListGroup;

            // �����ʒu
            this._orderAnsInfoHTableIndex = -1;
        }
        #endregion

        #region ��GetDispInfoAll(HashTable�f�[�^�擾)
        /// <summary>
        /// �����񓚏��HashTable�f�[�^�擾
        /// </summary>
        /// <param name="index">�����ʒu</param>
        /// <param name="supplierDataSet">�O���b�h���׈ȊO(�w�b�_�[�A�O���b�h�w�b�_�[�A���v)�̃f�[�^</param>
        /// <param name="detailDataSet">�O���b�h���׃f�[�^</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽindex�����ɔ����񓚏��HashTable����f�[�^���擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private bool GetDispInfoAll(int index, out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            detailDataSet = null;
            supplierDataSet = null;

            // �f�[�^������
            if (this._orderAnsInfoHTable == null)
            {
                return false;
            }

            // INDEX�͈͊O
            if (this._orderAnsInfoHTable.ContainsKey(index) == false)
            {
                return false;
            }

            // ���׈ȊO�pDataTable�쐬
            DataTable supplierDataTable = null;
            PMUOE04103EA.CreateDataTableSupplier(ref supplierDataTable);

            // ���חpDataTable�쐬
            DataTable detailDataTable = null;
            PMUOE04103EA.CreateDataTableDetail(ref detailDataTable);

            DataRow supplierDataRow = supplierDataTable.NewRow();

            List<OrderSndRcvJnl> orderSndRcvJnlList = (List<OrderSndRcvJnl>)this._orderAnsInfoHTable[index];
            foreach (OrderSndRcvJnl orderSndRcvJnl in orderSndRcvJnlList)
            {
                // �ŏ��̂�
                if (detailDataTable.Rows.Count == 0)
                {
                    // ��ʕ\���p��������擾
                    supplierDataRow[PMUOE04103EA.ct_Col_SalesDate] = orderSndRcvJnl.ReceiveDate.ToString("yyyy/MM/dd") + " " +
                                                                     orderSndRcvJnl.ReceiveTime.ToString("000000").Insert(2, ":").Insert(5,":");   // ������

                    supplierDataRow[PMUOE04103EA.ct_Col_UOESalesOrderNo] = orderSndRcvJnl.UOESalesOrderNo.ToString("000000");   // �����ԍ�
                    supplierDataRow[PMUOE04103EA.ct_Col_UOESupplierName] = orderSndRcvJnl.UOESupplierName;                      // ������
                    supplierDataRow[PMUOE04103EA.ct_Col_UoeRemark1] = orderSndRcvJnl.UoeRemark1;                                // ���}�[�N�P
                    supplierDataRow[PMUOE04103EA.ct_Col_UoeRemark2] = orderSndRcvJnl.UoeRemark2;                                // ���}�[�N�Q
                    supplierDataRow[PMUOE04103EA.ct_Col_DeliveredGoodsDivNm] = orderSndRcvJnl.DeliveredGoodsDivNm;              // �[�i�敪
                    supplierDataRow[PMUOE04103EA.ct_Col_FollowDeliGoodsDivNm] = orderSndRcvJnl.FollowDeliGoodsDivNm;            // �g�[�i�敪
                    supplierDataRow[PMUOE04103EA.ct_Col_UOEResvdSectionNm] = orderSndRcvJnl.UOEResvdSectionNm;                  // ���_
                    supplierDataRow[PMUOE04103EA.ct_Col_EmployeeName] = orderSndRcvJnl.EmployeeName;                            // �˗���

                    // �O���b�h�w�b�_�[���쐬
                    this.GetHeaderVariableName(orderSndRcvJnl.UOESupplierCd, ref supplierDataRow);

                    // �V�X�e���敪
                    #region
                    switch (orderSndRcvJnl.SystemDivCd)
                    {
                        case 0:
                            {
                                supplierDataRow[PMUOE04103EA.ct_Col_SystemDivName] = "�����";
                                break;
                            }
                        case 1:
                            {
                                supplierDataRow[PMUOE04103EA.ct_Col_SystemDivName] = "�`��";
                                break;
                            }
                        case 2:
                            {
                                supplierDataRow[PMUOE04103EA.ct_Col_SystemDivName] = "����";
                                break;
                            }
                        case 3:
                            {
                                supplierDataRow[PMUOE04103EA.ct_Col_SystemDivName] = "�݌Ɉꊇ";
                                break;
                            }
                    }
                    #endregion
                }

                // dataRow�쐬
                DataRow detailDataRow = detailDataTable.NewRow();
                this.CopyToDataRowFromOrderSndRcvJnl(orderSndRcvJnl, ref detailDataRow);

                detailDataTable.Rows.Add(detailDataRow);
            }

            supplierDataTable.Rows.Add(supplierDataRow);

            // �߂�l�pDataSet�쐬
            supplierDataSet = new DataSet();
            supplierDataSet.Tables.Add(supplierDataTable);

            detailDataSet = new DataSet();
            detailDataSet.Tables.Add(detailDataTable);

            this._orderAnsInfoHTableIndex = index;      // ���݂̈ʒu
            return true;
        }
        #endregion

        #region ��CopyToDataRowFromOrderSndRcvJnl(UOE����M�W���[�i����DataRow�R�s�[)
        /// <summary>
        /// UOE����M�W���[�i��(����)��DataRow�쐬
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="orderSndRcvJnl"></param>
        /// <remarks>
        /// <br>Note       : UOE����M�W���[�i��(����)�̓��e������DataRow���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void CopyToDataRowFromOrderSndRcvJnl(OrderSndRcvJnl orderSndRcvJnl, ref DataRow dataRow)
        {
            dataRow[PMUOE04103EA.ct_Col_UOESalesOrderRowNo] = orderSndRcvJnl.UOESalesOrderRowNo;        // UOE�����s�ԍ�
            dataRow[PMUOE04103EA.ct_Col_GoodsNo] = orderSndRcvJnl.GoodsNo;                              // �i��
            dataRow[PMUOE04103EA.ct_Col_ListPrice] = orderSndRcvJnl.AnswerListPrice;                    // �񓚒艿
            dataRow[PMUOE04103EA.ct_Col_Blank1] = string.Empty;                                         // ��1
            /* --- DEL 2008/12/18 �A ------------------------------------------------------------------------------------------------>>>>> 
            dataRow[PMUOE04103EA.ct_Col_UOESectionSlipNo] = orderSndRcvJnl.UOESectionSlipNo;            // ���_�`�[
            dataRow[PMUOE04103EA.ct_Col_BOSlipNo1] = orderSndRcvJnl.BOSlipNo1;                          // BO�`�[1
            dataRow[PMUOE04103EA.ct_Col_BOSlipNo2] = orderSndRcvJnl.BOSlipNo2;                          // BO�`�[2
            dataRow[PMUOE04103EA.ct_Col_BOManagementNo] = orderSndRcvJnl.BOManagementNo;                // BO�Ǘ��ԍ�
               --- ADD 2008/12/18 �A ------------------------------------------------------------------------------------------------<<<<< */
            dataRow[PMUOE04103EA.ct_Col_Blank2] = string.Empty;                                         // ��2
            dataRow[PMUOE04103EA.ct_Col_UOESubstMark] = orderSndRcvJnl.UOESubstMark;                    // ���
            /* ---DEL 2009/01/21 �s��Ή�[10173] ----------------------------------------------------------------------------------------------->>>>>
            //dataRow[PMUOE04103EA.ct_Col_GoodsName] = orderSndRcvJnl.GoodsName;                          // �i��                       //DEL 2008/11/28
            dataRow[PMUOE04103EA.ct_Col_GoodsName] = orderSndRcvJnl.AnswerPartsName;                    // �i��(�񓚕i����\��)         //ADD 2008/11/28
               ---DEL 2009/01/21 �s��Ή�[10173] -----------------------------------------------------------------------------------------------<<<<< */
            dataRow[PMUOE04103EA.ct_Col_GoodsName] = orderSndRcvJnl.GoodsName;                          // �i��(�񓚕i����\��)         //ADD 2009/01/21 �s��Ή�[10173]
            dataRow[PMUOE04103EA.ct_Col_AcceptAnOrderCnt] = orderSndRcvJnl.AcceptAnOrderCnt;            // �󒍐���
            dataRow[PMUOE04103EA.ct_Col_BOCode] = orderSndRcvJnl.BoCode;                                // BO�敪
            dataRow[PMUOE04103EA.ct_Col_SalesUnitCost] = orderSndRcvJnl.AnswerSalesUnitCost;            // �񓚌����P��
            /* --- DEL 2008/12/18 �A ------------------------------------------------------------------------------------------------>>>>> 
            // --- DEL 2008/11/28 �[���͕\�������Ȃ� -------------------------------------------------------------------------------->>>>>
            //dataRow[PMUOE04103EA.ct_Col_UOESectOutGoodsCnt] = orderSndRcvJnl.UOESectOutGoodsCnt;        // UOE���_�o�ɐ�
            //dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt1] = orderSndRcvJnl.BOShipmentCnt1;                // BO�o�ɐ�1
            //dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt2] = orderSndRcvJnl.BOShipmentCnt2;                // BO�o�ɐ�2
            //dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt3] = orderSndRcvJnl.BOShipmentCnt3;                // BO�o�ɐ�3
            //dataRow[PMUOE04103EA.ct_Col_EOAlwcCount] = orderSndRcvJnl.EOAlwcCount;                      // EO������
            //dataRow[PMUOE04103EA.ct_Col_MakerFollowCnt] = orderSndRcvJnl.MakerFollowCnt;                // ���[�J�[�t�H���[��
            // --- DEL 2008/11/28 ---------------------------------------------------------------------------------------------------<<<<<
            // --- ADD 2008/11/28 --------------------------------------------------------------------------------------------------->>>>>
            dataRow[PMUOE04103EA.ct_Col_UOESectOutGoodsCnt] = this.ChangeZero(orderSndRcvJnl.UOESectOutGoodsCnt);   // UOE���_�o�ɐ�
            dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt1] = this.ChangeZero(orderSndRcvJnl.BOShipmentCnt1);           // BO�o�ɐ�1
            dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt2] = this.ChangeZero(orderSndRcvJnl.BOShipmentCnt2);           // BO�o�ɐ�2
            dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt3] = this.ChangeZero(orderSndRcvJnl.BOShipmentCnt3);           // BO�o�ɐ�3
            dataRow[PMUOE04103EA.ct_Col_EOAlwcCount] = this.ChangeZero(orderSndRcvJnl.EOAlwcCount);                 // EO������
            dataRow[PMUOE04103EA.ct_Col_MakerFollowCnt] = this.ChangeZero(orderSndRcvJnl.MakerFollowCnt);           // ���[�J�[�t�H���[��
            // --- ADD 2008/11/28 ---------------------------------------------------------------------------------------------------<<<<<
               --- ADD 2008/12/18 �A ------------------------------------------------------------------------------------------------<<<<< */
            dataRow[PMUOE04103EA.ct_Col_SubstPartsNo] = orderSndRcvJnl.SubstPartsNo;                    // ��֕i��

            // --- ADD 2008/12/18 �A ------------------------------------------------------------------------------------------------>>>>>
            int programId = this.GetProgramIdFromUOEOrderDtlHTable(orderSndRcvJnl.UOESupplierCd);
            string format = "#,###;-#,###;";
            // �z���_�̏ꍇ�A����\��
            if (programId == PROGRAMID_HONDA)
            {
                string hondaSectionCode = this.GetHondaSectionCodeFromUOEOrderDtlHTable(orderSndRcvJnl.UOESupplierCd);
                dataRow[PMUOE04103EA.ct_Col_UOESectionSlipNo] = string.Empty;                                           // �Ȃ�
                dataRow[PMUOE04103EA.ct_Col_BOSlipNo1] = orderSndRcvJnl.UOESectionSlipNo;                               // ���_
                dataRow[PMUOE04103EA.ct_Col_BOSlipNo2] = string.Empty;                                                  // �Ȃ�
                dataRow[PMUOE04103EA.ct_Col_BOSlipNo3] = orderSndRcvJnl.BOSlipNo1;                                      // �r�e
                dataRow[PMUOE04103EA.ct_Col_BOManagementNo] = string.Empty;                                             // �Ȃ�
                dataRow[PMUOE04103EA.ct_Col_UOESectOutGoodsCnt] = hondaSectionCode;                                     // �o�׌�
                dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt1] = orderSndRcvJnl.UOESectOutGoodsCnt.ToString(format);       // ���_�o�א�
                dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt2] = orderSndRcvJnl.SourceShipment;                            // �o�׌�
                dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt3] = orderSndRcvJnl.BOShipmentCnt1.ToString(format);           // �r�e�o�א�
                dataRow[PMUOE04103EA.ct_Col_EOAlwcCount] = string.Empty;                                                // �Ȃ�
                dataRow[PMUOE04103EA.ct_Col_MakerFollowCnt] = string.Empty;                                             // �Ȃ�
            }
            else
            {
                dataRow[PMUOE04103EA.ct_Col_UOESectionSlipNo] = orderSndRcvJnl.UOESectionSlipNo;                        // ���_�`�[
                dataRow[PMUOE04103EA.ct_Col_BOSlipNo1] = orderSndRcvJnl.BOSlipNo1;                                      // BO�`�[1
                dataRow[PMUOE04103EA.ct_Col_BOSlipNo2] = orderSndRcvJnl.BOSlipNo2;                                      // BO�`�[2
                dataRow[PMUOE04103EA.ct_Col_BOSlipNo3] = orderSndRcvJnl.BOSlipNo3;                                      // BO�`�[3
                dataRow[PMUOE04103EA.ct_Col_BOManagementNo] = orderSndRcvJnl.BOManagementNo;                            // BO�Ǘ��ԍ�
                dataRow[PMUOE04103EA.ct_Col_UOESectOutGoodsCnt] = orderSndRcvJnl.UOESectOutGoodsCnt.ToString(format);   // UOE���_�o�ɐ�
                dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt1] = orderSndRcvJnl.BOShipmentCnt1.ToString(format);           // BO�o�ɐ�1
                dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt2] = orderSndRcvJnl.BOShipmentCnt2.ToString(format);           // BO�o�ɐ�2
                dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt3] = orderSndRcvJnl.BOShipmentCnt3.ToString(format);           // BO�o�ɐ�3
                dataRow[PMUOE04103EA.ct_Col_EOAlwcCount] = orderSndRcvJnl.EOAlwcCount.ToString(format);                 // EO������
                dataRow[PMUOE04103EA.ct_Col_MakerFollowCnt] = orderSndRcvJnl.MakerFollowCnt.ToString(format);           // ���[�J�[�t�H���[��
            }
            // --- ADD 2008/12/18 �A ------------------------------------------------------------------------------------------------<<<<<

            // ���[�J�[�R�[�h
            if (orderSndRcvJnl.GoodsMakerCd == 0)
            {
                dataRow[PMUOE04103EA.ct_Col_GoodsMakerCd] = string.Empty;
            }
            else
            {
                dataRow[PMUOE04103EA.ct_Col_GoodsMakerCd] = orderSndRcvJnl.GoodsMakerCd.ToString("0000");
            }

            /* --- DEL 2008/12/18 �A ------------------------------------------------------------------------------------------------>>>>> 
            // BO�`�[3
            int programId = this.GetProgramIdFromUOEOrderDtlHTable(orderSndRcvJnl.UOESupplierCd);
            if (programId == PROGRAMID_HONDA)
            {
                dataRow[PMUOE04103EA.ct_Col_BOSlipNo3] = orderSndRcvJnl.SourceShipment;             // �o�׌�
            }
            else
            {
                dataRow[PMUOE04103EA.ct_Col_BOSlipNo3] = orderSndRcvJnl.BOSlipNo3;                  // BO�`�[3
            }
               --- DEL 2008/12/18 �A ------------------------------------------------------------------------------------------------<<<<< */
            // �q�ɁE�I��
            Int32 warehouseCode;
            try
            {
                warehouseCode = Int32.Parse(orderSndRcvJnl.WarehouseCode);
                dataRow[PMUOE04103EA.ct_Col_WarehouseShelfNo] = warehouseCode.ToString("0000") + " " + orderSndRcvJnl.WarehouseShelfNo;
            }
            catch
            {
                dataRow[PMUOE04103EA.ct_Col_WarehouseShelfNo] = orderSndRcvJnl.WarehouseCode + " " + orderSndRcvJnl.WarehouseShelfNo;
            }

            // �o�א��v(�e�o�א� + �l�e)
            double shipmentCntTotal = orderSndRcvJnl.UOESectOutGoodsCnt
                                    + orderSndRcvJnl.BOShipmentCnt1
                                    + orderSndRcvJnl.BOShipmentCnt2
                                    + orderSndRcvJnl.BOShipmentCnt3
                                    + orderSndRcvJnl.EOAlwcCount
                                    + orderSndRcvJnl.MakerFollowCnt;


            // �c(�󒍐��� - �o�א��v)
            double remainderCount = orderSndRcvJnl.AcceptAnOrderCnt - shipmentCntTotal;
            dataRow[PMUOE04103EA.ct_Col_RemainderCount] = remainderCount;

            // �R�����g
            #region
            //if (string.IsNullOrEmpty(orderSndRcvJnl.HeadErrorMassage) == false)           //DEL 2009/01/21 �s��Ή�[10134]
            if (string.IsNullOrEmpty(orderSndRcvJnl.HeadErrorMassage.Trim()) == false)      //ADD 2009/01/21 �s��Ή�[10134]
            {
                // �w�b�h�G���[���b�Z�[�W
                dataRow[PMUOE04103EA.ct_Col_Comment] = orderSndRcvJnl.HeadErrorMassage;
            }
            //else if (string.IsNullOrEmpty(orderSndRcvJnl.LineErrorMassage) == false)      //DEL 2009/01/21 �s��Ή�[10134]
            else if (string.IsNullOrEmpty(orderSndRcvJnl.LineErrorMassage.Trim()) == false) //ADD 2009/01/21 �s��Ή�[10134]
            {
                // ���C���G���[���b�Z�[�W
                dataRow[PMUOE04103EA.ct_Col_Comment] = orderSndRcvJnl.LineErrorMassage;
            }
            //else if (string.IsNullOrEmpty(orderSndRcvJnl.SubstPartsNo) == false)          //DEL 2009/01/21 �s��Ή�[10134]
            else if (string.IsNullOrEmpty(orderSndRcvJnl.SubstPartsNo.Trim()) == false)     //ADD 2009/01/21 �s��Ή�[10134]
            {
                // ��֕i��
                dataRow[PMUOE04103EA.ct_Col_Comment] = orderSndRcvJnl.SubstPartsNo;
            }
            else
            {
                dataRow[PMUOE04103EA.ct_Col_Comment] = string.Empty;
            }
            #endregion

            // �O�i�F
            #region
            /* ---DEL 2009/01/20 �s��Ή�[10165] ------------------------------------------------------------------->>>>>
            if ((remainderCount != 0) || (orderSndRcvJnl.MakerFollowCnt != 0) || (orderSndRcvJnl.AnswerSalesUnitCost == 0))
            {
                // �u�c != 0�v or �uҰ��̫۰�� != 0�v or �u�񓚌����P�� = 0�v
                dataRow[PMUOE04103EA.ct_Col_ForeColor] = "BLUE";
            }
            else if ((string.IsNullOrEmpty(orderSndRcvJnl.HeadErrorMassage)) &&
                     (string.IsNullOrEmpty(orderSndRcvJnl.LineErrorMassage)) &&
                     (string.IsNullOrEmpty(orderSndRcvJnl.SubstPartsNo) == false))
            {
                // ��֕i�� != ��߰�
                dataRow[PMUOE04103EA.ct_Col_ForeColor] = "GREEN";
            }
            else if (shipmentCntTotal == 0)
            {
                // UOE���_�o�ɐ� + BO�o�ɐ�1�`3 + Ұ��̫۰�� + EO������ = 0
                dataRow[PMUOE04103EA.ct_Col_ForeColor] = "RED";
            }
            else
            {
                dataRow[PMUOE04103EA.ct_Col_ForeColor] = string.Empty;
            }
               ---DEL 2009/01/20 �s��Ή�[10165] -------------------------------------------------------------------<<<<< */
            // ---ADD 2009/01/20 �s��Ή�[10165] ------------------------------------------------------------------->>>>>
            // ��֕i
            if ((string.IsNullOrEmpty(orderSndRcvJnl.HeadErrorMassage.Trim())) &&
                (string.IsNullOrEmpty(orderSndRcvJnl.LineErrorMassage.Trim())) &&
                (string.IsNullOrEmpty(orderSndRcvJnl.SubstPartsNo.Trim()) == false))
            {
                dataRow[PMUOE04103EA.ct_Col_ForeColor] = "GREEN";
            }
            // �S���c
            else if (shipmentCntTotal == 0)
            {
                dataRow[PMUOE04103EA.ct_Col_ForeColor] = "RED";
            }
            // �d�ؖ���/�ꕔ�c/Ұ��̫۰��
            else if ((remainderCount != 0) || (orderSndRcvJnl.MakerFollowCnt != 0) || (orderSndRcvJnl.AnswerSalesUnitCost == 0))
            {
                dataRow[PMUOE04103EA.ct_Col_ForeColor] = "BLUE";
            }
            else
            {
                dataRow[PMUOE04103EA.ct_Col_ForeColor] = string.Empty;
            }
            // ---ADD 2009/01/20 �s��Ή�[10165] -------------------------------------------------------------------<<<<<
            #endregion
        }
        #endregion

        /* --- DEL 2008/12/18 �A ------------------------------------------------------------------------------------------------>>>>> 
        #region ��ChangeZero(�[���l�ϊ�)        //ADD 2008/11/28
        /// <summary>
        /// �[���l�ϊ�
        /// </summary>
        /// <param name="value">�ϊ��O�̒l</param>
        /// <returns>�ϊ���̒l</returns>
        /// <remarks>
        /// <br>Note       : �ϊ��O�̒l���[���ł����DBNull�Ƃ���B�[���ȊO�͂��̂܂ܕԂ��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private Object ChangeZero(int value)
        {
            if (value == 0)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }
        #endregion
               --- DEL 2008/12/18 �A ------------------------------------------------------------------------------------------------<<<<< */
        #endregion �������񓚏��HashTable�֘A - end

        #region �������f�[�^��OrderSndRcvJnl�쐬�֘A(�P�̋N����p)
        #region ��CreateOrderSndRcvJnl(UOE����M�W���[�i��(����)�쐬�@�P�̋N����p)
        /// <summary>
        /// UOE����M�W���[�i���쐬(�P�̋N����p)
        /// </summary>
        /// <param name="uoeAnswerLedgerOrderCndtn">�����f�[�^���o����</param>
        /// <param name="errorMsg">�G���[���b�Z�[�W</param>
        /// <param name="orderSndRcvJnlList">UOE����M�W���[�i��</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : ���o���������ɔ����f�[�^���擾��AUOE����M�W���[�i�����쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private bool CreateOrderSndRcvJnl(UOEAnswerLedgerOrderCndtn uoeAnswerLedgerOrderCndtn, out string errorMsg, out List<OrderSndRcvJnl> orderSndRcvJnlList)
        {
            errorMsg = string.Empty;
            orderSndRcvJnlList = new List<OrderSndRcvJnl>();

            // ���o����
            UOEAnswerLedgerOrderCndtnWork uoeAnswerLedgerOrderCndtnWork = new UOEAnswerLedgerOrderCndtnWork();
            uoeAnswerLedgerOrderCndtnWork.EnterpriseCode = uoeAnswerLedgerOrderCndtn.EnterpriseCode;        // ��ƃR�[�h
            uoeAnswerLedgerOrderCndtnWork.SectionCode = uoeAnswerLedgerOrderCndtn.SectionCode;              // ���_�R�[�h
            uoeAnswerLedgerOrderCndtnWork.SystemDivCd = uoeAnswerLedgerOrderCndtn.SystemDivCd;              // �V�X�e���敪(-1�F�S�� �Œ�)
            uoeAnswerLedgerOrderCndtnWork.St_ReceiveDate = uoeAnswerLedgerOrderCndtn.St_ReceiveDate;        // �J�n������
            uoeAnswerLedgerOrderCndtnWork.Ed_ReceiveDate = uoeAnswerLedgerOrderCndtn.Ed_ReceiveDate;        // �I��������
            uoeAnswerLedgerOrderCndtnWork.UOESupplierCd = uoeAnswerLedgerOrderCndtn.UOESupplierCd;          // ������
            uoeAnswerLedgerOrderCndtnWork.UOEKind = uoeAnswerLedgerOrderCndtn.UOEKind;                      // UOE���          //ADD 2008/12/18 �C
            uoeAnswerLedgerOrderCndtnWork.St_InputDay = uoeAnswerLedgerOrderCndtn.St_InputDay;              // ���͓�(�J�n)     //ADD 2008/12/18 �C
            uoeAnswerLedgerOrderCndtnWork.Ed_InputDay = uoeAnswerLedgerOrderCndtn.Ed_InputDay;              // ���͓�(�I��)     //ADD 2008/12/18 �C 

            // �f�[�^���o            
            Object arrayList = null;
            int status = this._iUOEAnswerLedgerOrderWorkDB.Search(out arrayList, (object)uoeAnswerLedgerOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        errorMsg = "�Y���f�[�^������܂���";
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                default:
                    errorMsg = "�����f�[�^�̓Ǎ��Ɏ��s���܂����B";
                    return false;
            }

            // �����f�[�^��UOE����M�W���[�i���p��List�ɃZ�b�g
            foreach (UOEAnswerLedgerResultWork uoeAnswerLedgerResultWork in (ArrayList)arrayList)
            {
                OrderSndRcvJnl orderSndRcvJnl;

                this.CopyToOrderSndRcvJnlFromUOEAnswerLedgerResultWork(uoeAnswerLedgerResultWork, out orderSndRcvJnl);

                orderSndRcvJnlList.Add(orderSndRcvJnl);
            }


            return true;
        }
        #endregion

        #region ��CopyToOrderSndRcvJnlFromUOEAnswerLedgerResultWork(�����f�[�^��UOE����M�W���[�i���R�s�[�@�P�̋N����p)
        /// <summary>
        /// �����f�[�^��UOE����M�W���[�i���R�s�[(�P�̋N����p)
        /// </summary>
        /// <param name="uoeAnswerLedgerResultWork">�����f�[�^</param>
        /// <param name="orderSndRcvJnl">UOE����M�W���[�i��</param>
        /// <remarks>
        /// <br>Note       : �����f�[�^�̓��e������UOE����M�W���[�i��(����)���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void CopyToOrderSndRcvJnlFromUOEAnswerLedgerResultWork(UOEAnswerLedgerResultWork uoeAnswerLedgerResultWork, out OrderSndRcvJnl orderSndRcvJnl)
        {
            orderSndRcvJnl = new OrderSndRcvJnl();
            orderSndRcvJnl.CreateDateTime = uoeAnswerLedgerResultWork.CreateDateTime;                   // �쐬����
            orderSndRcvJnl.UpdateDateTime = uoeAnswerLedgerResultWork.UpdateDateTime;                   // �X�V����
            orderSndRcvJnl.EnterpriseCode = uoeAnswerLedgerResultWork.EnterpriseCode;                   // ��ƃR�[�h
            orderSndRcvJnl.FileHeaderGuid = uoeAnswerLedgerResultWork.FileHeaderGuid;                   // GUID
            orderSndRcvJnl.UpdEmployeeCode = uoeAnswerLedgerResultWork.UpdEmployeeCode;                 // �X�V�]�ƈ��R�[�h
            orderSndRcvJnl.UpdAssemblyId1 = uoeAnswerLedgerResultWork.UpdAssemblyId1;                   // �X�V�A�Z���u��ID1
            orderSndRcvJnl.UpdAssemblyId2 = uoeAnswerLedgerResultWork.UpdAssemblyId2;                   // �X�V�A�Z���u��ID2
            orderSndRcvJnl.LogicalDeleteCode = uoeAnswerLedgerResultWork.LogicalDeleteCode;             // �_���폜�敪
            orderSndRcvJnl.SystemDivCd = uoeAnswerLedgerResultWork.SystemDivCd;                         // �V�X�e���敪
            orderSndRcvJnl.UOESalesOrderNo = uoeAnswerLedgerResultWork.UOESalesOrderNo;                 // UOE�����ԍ�
            orderSndRcvJnl.UOESalesOrderRowNo = uoeAnswerLedgerResultWork.UOESalesOrderRowNo;           // UOE�����s�ԍ�
            orderSndRcvJnl.SendTerminalNo = uoeAnswerLedgerResultWork.SendTerminalNo;                   // ���M�[���ԍ�
            orderSndRcvJnl.UOESupplierCd = uoeAnswerLedgerResultWork.UOESupplierCd;                     // UOE������R�[�h
            orderSndRcvJnl.UOESupplierName = uoeAnswerLedgerResultWork.UOESupplierName;                 // UOE�����於��
            orderSndRcvJnl.CommAssemblyId = uoeAnswerLedgerResultWork.CommAssemblyId;                   // �ʐM�A�Z���u��ID
            orderSndRcvJnl.OnlineNo = uoeAnswerLedgerResultWork.OnlineNo;                               // �I�����C���ԍ�
            orderSndRcvJnl.OnlineRowNo = uoeAnswerLedgerResultWork.OnlineRowNo;                         // �I�����C���s�ԍ�
            orderSndRcvJnl.SalesDate = uoeAnswerLedgerResultWork.SalesDate;                             // ������t
            orderSndRcvJnl.InputDay = uoeAnswerLedgerResultWork.InputDay;                               // ���͓�
            orderSndRcvJnl.DataUpdateDateTime = uoeAnswerLedgerResultWork.DataUpdateDateTime;           // �f�[�^�X�V����
            orderSndRcvJnl.UOEKind = uoeAnswerLedgerResultWork.UOEKind;                                 // UOE���
            //orderSndRcvJnl.SalesSlipNum       // ����`�[�ԍ�
            //orderSndRcvJnl.AcptAnOdrStatus    // �󒍃X�e�[�^�X
            //orderSndRcvJnl.SalesSlipDtlNum    // ���㖾�גʔ�
            orderSndRcvJnl.SectionCode = uoeAnswerLedgerResultWork.SectionCode;                         // ���_�R�[�h
            orderSndRcvJnl.SubSectionCode = uoeAnswerLedgerResultWork.SubSectionCode;                   // ����R�[�h
            orderSndRcvJnl.CustomerCode = uoeAnswerLedgerResultWork.CustomerCode;                       // ���Ӑ�R�[�h
            orderSndRcvJnl.CustomerSnm = uoeAnswerLedgerResultWork.CustomerSnm;                         // ���Ӑ旪��
            orderSndRcvJnl.CashRegisterNo = uoeAnswerLedgerResultWork.CashRegisterNo;                   // ���W�ԍ�
            //orderSndRcvJnl.CommonSeqNo        // ���ʒʔ�
            //orderSndRcvJnl.SupplierFormal     // �d���`��
            //orderSndRcvJnl.SupplierSlipNo     // �d���`�[�ԍ�
            //orderSndRcvJnl.StockSlipDtlNum    // �d�����גʔ�
            orderSndRcvJnl.BoCode = uoeAnswerLedgerResultWork.BoCode;                                   // BO�敪
            orderSndRcvJnl.UOEDeliGoodsDiv = uoeAnswerLedgerResultWork.UOEDeliGoodsDiv;                 // UOE�[�i�敪
            orderSndRcvJnl.DeliveredGoodsDivNm = uoeAnswerLedgerResultWork.DeliveredGoodsDivNm;         // �[�i�敪����
            orderSndRcvJnl.FollowDeliGoodsDiv = uoeAnswerLedgerResultWork.FollowDeliGoodsDiv;           // �t�H���[�[�i�敪
            orderSndRcvJnl.FollowDeliGoodsDivNm = uoeAnswerLedgerResultWork.FollowDeliGoodsDivNm;       // �t�H���[�[�i�敪����
            orderSndRcvJnl.UOEResvdSection = uoeAnswerLedgerResultWork.UOEResvdSection;                 // UOE�w�苒�_
            orderSndRcvJnl.UOEResvdSectionNm = uoeAnswerLedgerResultWork.UOEResvdSectionNm;             // UOE�w�苒�_����
            orderSndRcvJnl.EmployeeCode = uoeAnswerLedgerResultWork.EmployeeCode;                       // �]�ƈ��R�[�h
            orderSndRcvJnl.EmployeeName = uoeAnswerLedgerResultWork.EmployeeName;                       // �]�ƈ�����
            orderSndRcvJnl.GoodsMakerCd = uoeAnswerLedgerResultWork.GoodsMakerCd;                       // ���i���[�J�[�R�[�h
            orderSndRcvJnl.MakerName = uoeAnswerLedgerResultWork.MakerName;                             // ���[�J�[����
            orderSndRcvJnl.GoodsNo = uoeAnswerLedgerResultWork.GoodsNo;                                 // ���i�ԍ�
            orderSndRcvJnl.GoodsNoNoneHyphen = uoeAnswerLedgerResultWork.GoodsNoNoneHyphen;             // �n�C�t�������i�ԍ�
            orderSndRcvJnl.GoodsName = uoeAnswerLedgerResultWork.GoodsName;                             // ���i����
            orderSndRcvJnl.WarehouseCode = uoeAnswerLedgerResultWork.WarehouseCode;                     // �q�ɃR�[�h
            orderSndRcvJnl.WarehouseName = uoeAnswerLedgerResultWork.WarehouseName;                     // �q�ɖ���
            orderSndRcvJnl.WarehouseShelfNo = uoeAnswerLedgerResultWork.WarehouseShelfNo;               // �q�ɒI��
            orderSndRcvJnl.AcceptAnOrderCnt = uoeAnswerLedgerResultWork.AcceptAnOrderCnt;               // �󒍐���
            orderSndRcvJnl.ListPrice = uoeAnswerLedgerResultWork.ListPrice;                             // �艿
            orderSndRcvJnl.SalesUnitCost = uoeAnswerLedgerResultWork.SalesUnitCost;                     // �����P��
            orderSndRcvJnl.SupplierCd = uoeAnswerLedgerResultWork.SupplierCd;                           // �d����R�[�h
            orderSndRcvJnl.SupplierSnm = uoeAnswerLedgerResultWork.SupplierSnm;                         // �d���旪��
            orderSndRcvJnl.UoeRemark1 = uoeAnswerLedgerResultWork.UoeRemark1;                           // UOE���}�[�N1
            orderSndRcvJnl.UoeRemark2 = uoeAnswerLedgerResultWork.UoeRemark2;                           // UOE���}�[�N2
            orderSndRcvJnl.ReceiveDate = uoeAnswerLedgerResultWork.ReceiveDate;                         // ��M���t
            orderSndRcvJnl.ReceiveTime = uoeAnswerLedgerResultWork.ReceiveTime;                         // ��M����
            orderSndRcvJnl.AnswerMakerCd = uoeAnswerLedgerResultWork.AnswerMakerCd;                     // �񓚃��[�J�[�R�[�h
            orderSndRcvJnl.AnswerPartsNo = uoeAnswerLedgerResultWork.AnswerPartsNo;                     // �񓚕i��
            orderSndRcvJnl.AnswerPartsName = uoeAnswerLedgerResultWork.AnswerPartsName;                 // �񓚕i��
            orderSndRcvJnl.SubstPartsNo = uoeAnswerLedgerResultWork.SubstPartsNo;                       // ��֕i��
            orderSndRcvJnl.UOESectOutGoodsCnt = uoeAnswerLedgerResultWork.UOESectOutGoodsCnt;           // UOE���_�o�ɐ�
            orderSndRcvJnl.BOShipmentCnt1 = uoeAnswerLedgerResultWork.BOShipmentCnt1;                   // BO�o�ɐ�1
            orderSndRcvJnl.BOShipmentCnt2 = uoeAnswerLedgerResultWork.BOShipmentCnt2;                   // BO�o�ɐ�2
            orderSndRcvJnl.BOShipmentCnt3 = uoeAnswerLedgerResultWork.BOShipmentCnt3;                   // BO�o�ɐ�3
            orderSndRcvJnl.MakerFollowCnt = uoeAnswerLedgerResultWork.MakerFollowCnt;                   // ���[�J�[�t�H���[��
            orderSndRcvJnl.NonShipmentCnt = uoeAnswerLedgerResultWork.NonShipmentCnt;                   // ���o�ɐ�
            orderSndRcvJnl.UOESectStockCnt = uoeAnswerLedgerResultWork.UOESectStockCnt;                 // UOE���_�݌ɐ�
            orderSndRcvJnl.BOStockCount1 = uoeAnswerLedgerResultWork.BOStockCount1;                     // BO�݌ɐ�1
            orderSndRcvJnl.BOStockCount2 = uoeAnswerLedgerResultWork.BOStockCount2;                     // BO�݌ɐ�2
            orderSndRcvJnl.BOStockCount3 = uoeAnswerLedgerResultWork.BOStockCount3;                     // BO�݌ɐ�3
            orderSndRcvJnl.UOESectionSlipNo = uoeAnswerLedgerResultWork.UOESectionSlipNo;               // UOE���_�`�[�ԍ�
            orderSndRcvJnl.BOSlipNo1 = uoeAnswerLedgerResultWork.BOSlipNo1;                             // BO�`�[�ԍ�1
            orderSndRcvJnl.BOSlipNo2 = uoeAnswerLedgerResultWork.BOSlipNo2;                             // BO�`�[�ԍ�2
            orderSndRcvJnl.BOSlipNo3 = uoeAnswerLedgerResultWork.BOSlipNo3;                             // BO�`�[�ԍ�3
            orderSndRcvJnl.EOAlwcCount = uoeAnswerLedgerResultWork.EOAlwcCount;                         // EO������
            orderSndRcvJnl.BOManagementNo = uoeAnswerLedgerResultWork.BOManagementNo;                   // BO�Ǘ��ԍ�
            //orderSndRcvJnl.ListPrice = uoeAnswerLedgerResultWork.ListPrice;                             // �񓚒艿           //DEL 2008/12/18 �B
            //orderSndRcvJnl.SalesUnitCost = uoeAnswerLedgerResultWork.SalesUnitCost;                     // �񓚌����P��       //DEL 2008/12/18 �B
            orderSndRcvJnl.AnswerListPrice = uoeAnswerLedgerResultWork.AnswerListPrice;                 // �񓚒艿             //ADD 2008/12/18 �B
            orderSndRcvJnl.AnswerSalesUnitCost = uoeAnswerLedgerResultWork.AnswerSalesUnitCost;         // �񓚌����P��         //ADD 2008/12/18 �B
            orderSndRcvJnl.UOESubstMark = uoeAnswerLedgerResultWork.UOESubstMark;                       // UOE��փ}�[�N
            orderSndRcvJnl.UOEStockMark = uoeAnswerLedgerResultWork.UOEStockMark;                       // UOE�݌Ƀ}�[�N
            orderSndRcvJnl.PartsLayerCd = uoeAnswerLedgerResultWork.PartsLayerCd;                       // �w�ʃR�[�h
            orderSndRcvJnl.MazdaUOEShipSectCd1 = uoeAnswerLedgerResultWork.MazdaUOEShipSectCd1;         // UOE�o�׋��_�R�[�h1(�}�c�_)
            orderSndRcvJnl.MazdaUOEShipSectCd2 = uoeAnswerLedgerResultWork.MazdaUOEShipSectCd2;         // UOE�o�׋��_�R�[�h2(�}�c�_)
            orderSndRcvJnl.MazdaUOEShipSectCd3 = uoeAnswerLedgerResultWork.MazdaUOEShipSectCd3;         // UOE�o�׋��_�R�[�h3(�}�c�_)
            orderSndRcvJnl.MazdaUOESectCd1 = uoeAnswerLedgerResultWork.MazdaUOESectCd1;                 // UOE���_�R�[�h1(�}�c�_)
            orderSndRcvJnl.MazdaUOESectCd2 = uoeAnswerLedgerResultWork.MazdaUOESectCd2;                 // UOE���_�R�[�h2(�}�c�_)
            orderSndRcvJnl.MazdaUOESectCd3 = uoeAnswerLedgerResultWork.MazdaUOESectCd3;                 // UOE���_�R�[�h3(�}�c�_)
            orderSndRcvJnl.MazdaUOESectCd4 = uoeAnswerLedgerResultWork.MazdaUOESectCd4;                 // UOE���_�R�[�h4(�}�c�_)
            orderSndRcvJnl.MazdaUOESectCd5 = uoeAnswerLedgerResultWork.MazdaUOESectCd5;                 // UOE���_�R�[�h5(�}�c�_)
            orderSndRcvJnl.MazdaUOESectCd6 = uoeAnswerLedgerResultWork.MazdaUOESectCd6;                 // UOE���_�R�[�h6(�}�c�_)
            orderSndRcvJnl.MazdaUOESectCd7 = uoeAnswerLedgerResultWork.MazdaUOESectCd7;                 // UOE���_�R�[�h7(�}�c�_)
            orderSndRcvJnl.MazdaUOEStockCnt1 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt1;             // UOE�݌ɐ�1(�}�c�_)
            orderSndRcvJnl.MazdaUOEStockCnt2 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt2;             // UOE�݌ɐ�2(�}�c�_)
            orderSndRcvJnl.MazdaUOEStockCnt3 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt3;             // UOE�݌ɐ�3(�}�c�_)
            orderSndRcvJnl.MazdaUOEStockCnt4 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt4;             // UOE�݌ɐ�4(�}�c�_)
            orderSndRcvJnl.MazdaUOEStockCnt5 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt5;             // UOE�݌ɐ�5(�}�c�_)
            orderSndRcvJnl.MazdaUOEStockCnt6 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt6;             // UOE�݌ɐ�6(�}�c�_)
            orderSndRcvJnl.MazdaUOEStockCnt7 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt7;             // UOE�݌ɐ�7(�}�c�_)
            orderSndRcvJnl.UOEDistributionCd = uoeAnswerLedgerResultWork.UOEDistributionCd;             // UOE���R�[�h
            orderSndRcvJnl.UOEOtherCd = uoeAnswerLedgerResultWork.UOEOtherCd;                           // UOE���R�[�h
            orderSndRcvJnl.UOEHMCd = uoeAnswerLedgerResultWork.UOEHMCd;                                 // UOE�g�l�R�[�h
            orderSndRcvJnl.BOCount = uoeAnswerLedgerResultWork.BOCount;                                 // BO��
            orderSndRcvJnl.UOEMarkCode = uoeAnswerLedgerResultWork.UOEMarkCode;                         // UOE�}�[�N�R�[�h
            orderSndRcvJnl.SourceShipment = uoeAnswerLedgerResultWork.SourceShipment;                   // �o�׌�
            orderSndRcvJnl.ItemCode = uoeAnswerLedgerResultWork.ItemCode;                               // �A�C�e���R�[�h
            orderSndRcvJnl.UOECheckCode = uoeAnswerLedgerResultWork.UOECheckCode;                       // UOE�`�F�b�N�R�[�h
            orderSndRcvJnl.HeadErrorMassage = uoeAnswerLedgerResultWork.HeadErrorMassage;              // �w�b�h�G���[���b�Z�[�W
            orderSndRcvJnl.LineErrorMassage = uoeAnswerLedgerResultWork.LineErrorMassage;              // ���C���G���[���b�Z�[�W
            //orderSndRcvJnl.DataSendCode       // �f�[�^���M�敪
            //orderSndRcvJnl.DataRecoverDiv     // �f�[�^�����敪
            //orderSndRcvJnl.EnterUpdDivSec     // ���ɍX�V�敪(���_)
            //orderSndRcvJnl.EnterUpdDivBO1     // ���ɍX�V�敪(BO1)
            //orderSndRcvJnl.EnterUpdDivBO2     // ���ɍX�V�敪(BO2)
            //orderSndRcvJnl.EnterUpdDivBO3     // ���ɍX�V�敪(BO3)
            //orderSndRcvJnl.EnterUpdDivMaker   // ���ɍX�V�敪(���[�J�[)
            //orderSndRcvJnl.EnterUpdDivEO      // ���ɍX�V�敪(EO)
        }
        #endregion
        #endregion �������f�[�^��OrderSndRcvJnl�쐬�֘A - end
        #endregion ��Private���\�b�h - end
    }
}

