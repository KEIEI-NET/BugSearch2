//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �݌ɓ��ɍX�V
// �v���O�����T�v   : �݌ɓ��ɍX�V�Ŏg�p����f�[�^�̕ҏW���s���B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �� �� ��  2008/09/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/01/14  �C�����e : �݌ɒ������׎擾���̃o�O�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/01/16  �C�����e : �s��Ή�[10145]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/01/19  �C�����e : �s��Ή�[10178]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/02/04  �C�����e : MANTIS�O�s��Ή��@��֕i���A�X�V�d�����׃f�[�^�̔������͕ύX���Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/02/17  �C�����e : �s��Ή�[10140][10177][10529]
//                                  �EHeaderNoAndGuidJoin(�v��f�[�^�̖��ׂƃw�b�_�[��R�t����)�AStockSlipAndDetailJoin(�d���Ǝd�����ׂ�R�t����)�̊eDataSet�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/02/25  �C�����e : �݌ɒ����f�[�^�̍쐬���@�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/05/27  �C�����e : �s��Ή�[13289]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �C �� ��  2010/11/01  �C�����e : MANTIS[0016444]�Ή�
//                                 �@�݌ɒ������׃f�[�^�̎󕥌��`�[�敪�A�󕥌�����敪�̃Z�b�g�C��
//                                 �A�݌ɒ����f�[�^�̎d�����z���v���ďW�v����悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10707327-00 �쐬�S�� : �����x 							
// �C �� ��  2012/02/08  �C�����e : 2012/03/28�z�M���ARedmine#28282�@ 							
//                                  �݌ɓ��ɍX�V�̃G���[���C������							
//----------------------------------------------------------------------------// 							
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ���N�n��
// �C �� ��  2012/08/30  �C�����e : 2012/09/12�z�M���Aredmine #31885:�g�c����@�݌ɓ��ɍX�V�����̑Ή�
//----------------------------------------------------------------------------//	
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ���N�n��
// �C �� ��  2012/09/28  �C�����e : 2012/09/12�z�M���Aredmine #31885:�g�c����@�d����}�X�^�̎��񊨒肪���ݒ�̏ꍇ�͎d���v������d�����ƂȂ�悤�ɏC���̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �� ��
// �C �� ��  2012/10/02  �C�����e : 2012/09/12�z�M���Aredmine #31885:�g�c����@�d�����v�Z�Ɏx�����敪���g�p���Ȃ��悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �� ��
// �C �� ��  2012/10/10  �C�����e : 2012/09/17�z�M���ARedmine#32625 ����Ōv�Z�s���̑Ή��B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : chenw
// �� �� ��  2013/03/07  �C�����e : 2013/04/03�z�M��
//                                  Redmine#34989�̑Ή� ���YUOEWEB�̉���(�n�o�d�m���i�Ή�)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �����
// �C �� ��  2013/05/16  �C�����e : 2013/06/18�z�M���ARedmine#35459 #42�̑Ή�
//----------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// UOE���ɍX�V �f�[�^�m���p�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: UOE���ɍX�V�f�[�^�̊m�菈�����s���܂��B</br>
    /// <br>Programmer	: �Ɠc �M�u</br>
    /// <br>Date		: 2008/09/04</br>
    /// <br>UpdateNote  : 2009/01/14 �Ɠc �M�u�@�݌ɒ������׎擾���̃o�O�C�� </br>
    /// <br>            : 2009/01/16 �Ɠc �M�u�@�s��Ή�[10145]</br>
    /// <br>            : 2009/01/19 �Ɠc �M�u�@�s��Ή�[10178]</br>
    /// <br>            : 2009/02/04 �Ɠc �M�u�@MANTIS�O�s��Ή��@��֕i���A�X�V�d�����׃f�[�^�̔������͕ύX���Ȃ�</br>
    /// <br>            : 2009/02/17 �Ɠc �M�u�@�s��Ή�[10140][10177][10529]</br>
    /// <br>              �EHeaderNoAndGuidJoin(�v��f�[�^�̖��ׂƃw�b�_�[��R�t����)�AStockSlipAndDetailJoin(�d���Ǝd�����ׂ�R�t����)�̊eDataSet�ǉ�</br>
    /// <br>            : 2009/02/25 �Ɠc �M�u�@�݌ɒ����f�[�^�̍쐬���@�ύX</br>
    /// <br>            : 2009/05/27 �Ɠc �M�u�@�s��Ή�[13289]</br>
    /// <br>UpdateNote  : 2012/08/30 ���N�n��</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00 20120912�z�M��</br>
    /// <br>              redmine #31885:�g�c����@�݌ɓ��ɍX�V�����̑Ή�</br>
    /// <br>UpdateNote  : 2012/09/28 ���N�n��</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00 20120912�z�M��</br>
    /// <br>              redmine #31885:�g�c����@�d����}�X�^�̎��񊨒肪���ݒ�̏ꍇ�͎d���v������d�����ƂȂ�悤�ɏC���̑Ή�</br>
    /// <br>UpdateNote  : 2012/10/02 �� ��</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00 20120912�z�M��</br>
    /// <br>              redmine #31885:�g�c����@�d�����v�Z�Ɏx�����敪���g�p���Ȃ��悤�ɏC��</br>
    /// <br>UpdateNote  : 2012/10/10 �� ��</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00 20120917�z�M��</br>
    /// <br>              Redmine#32625 ����Ōv�Z�s���̑Ή��B</br>
    /// <br>UpdateNote  : 2013/05/16 �����</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00 2013/06/18�z�M��</br>
    /// <br>              Redmine#35459 #42�̑Ή�</br>
    /// </remarks>
    class PMUOE01203AB
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region ���萔
        // ���ɍX�V�敪
        private const int ENTERUPDDIV_NOTENTER = 0;         // ������
        private const int ENTERUPDDIV_ENTER = 1;            // ����
        private const bool UOESUBSTMARK_NOEXISTS = false;   // ��֕i�Ȃ�
        private const bool UOESUBSTMARK_EXISTS = true;      // ��֕i����
        private const string OPENFLAG = "OPEN���i"; // ADD chenw 2013/03/07 Redmine#34989
        #endregion

        #region ���ϐ�
        // �A�N�Z�X�N���X
        UOEOrderDtlAcs _uoeOrderDtlAcs = null;              // UOE�����f�[�^�A�N�Z�X�N���X
        GoodsAcs _goodsAcs = null;                          // ���i�}�X�^�A�N�Z�X�N���X
        // �f�[�^�Z�b�g�֘A
        private GridMainDataSet.GridMainTableDataTable _gridMainDataTable = null;   // �O���b�h���C��(�X�V���)�e�[�u��
        // HashTable
        private Hashtable _uoeOrderDtlWorkHTable = null;    // UOE�����f�[�^(key�F�d�����גʔ�)
        private Hashtable _stockSlipWorkHTable = null;      // �d���f�[�^(key�F�d���`�[�ԍ�)
        private Hashtable _stockDetailWorkHTable = null;    // �d�����׃f�[�^(key�F�d�����גʔ�)
        private Hashtable _supplierHTable = null;           // �d����f�[�^(key�F�d����R�[�h)
        // ���̑�
        private List<string> _uoeOrderDtlWorkUpdateList = null; // �X�V�Ώ�UOE�����f�[�^(HashTable�̃L�[���)
        private string _enterpriseCode = string.Empty;          // ��ƃR�[�h
        private bool _stockingPaymentOption = false;            // ���|�I�v�V����
        private int _stockBlnktPrtNoDiv;                        // UOE���Ѓ}�X�^.�݌Ɉꊇ�i�ԋ敪   //ADD 2009/01/16 �s��Ή�[10145]

        private bool _meiJiDiv = false;                         // �����Y�Ƌ敪�@ADD ����� 2013/05/16 Redmine#35459

        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        /// <summary> ���i�}�X�^�A�N�Z�X�N���X </summary>
        public GoodsAcs GoodsAcs { set { this._goodsAcs = value; } }
        /// <summary> ���|�I�v�V���� </summary>
        public bool StockingPaymentOption { set { this._stockingPaymentOption = value; } }
        /// <summary> UOE���Ѓ}�X�^.�݌Ɉꊇ�i�ԋ敪 </summary>                                     //ADD 2009/01/16 �s��Ή�[10145]
        public int StockBlnktPrtNoDiv { set { this._stockBlnktPrtNoDiv = value; } }                 //ADD 2009/01/16 �s��Ή�[10145]
        // ------------ADD ����� 2013/05/16 FOR Redmine#35459--------->>>>
        /// <summary> �����Y�Ƌ敪 </summary>   
        public bool MeiJiDiv { set { this._meiJiDiv = value; } }
        // ------------ADD ����� 2013/05/16 FOR Redmine#35459---------<<<<
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constracter
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="uoeOrderDtlWorkHTable">UOE�����f�[�^HashTable</param>
        /// <param name="gridMainDataTable">�O���b�h���C��(�X�V���)�e�[�u��</param>
        /// <param name="stockSlipWorkHTable">�d���f�[�^HashTable</param>
        /// <param name="stockDetailWorkHTable">�d�����׃f�[�^HashTable</param>
        /// <param name="supplierHtable">�d����f�[�^HashTable</param>
        /// <param name="goodsAcs">���i�}�X�^�A�N�Z�X�N���X</param>
        /// <remarks>
        /// <br>Note       : �N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public PMUOE01203AB(string enterpriseCode
                            ,Hashtable uoeOrderDtlWorkHTable
                            ,GridMainDataSet.GridMainTableDataTable gridMainDataTable
                            ,Hashtable stockSlipWorkHTable
                            ,Hashtable stockDetailWorkHTable
                            ,Hashtable supplierHtable)
        {
            this._enterpriseCode = enterpriseCode;                  // ��ƃR�[�h
            this._uoeOrderDtlWorkHTable = uoeOrderDtlWorkHTable;    // UOE�����f�[�^
            this._gridMainDataTable = gridMainDataTable;            // �O���b�h���C��(�X�V���)�e�[�u��
            this._stockSlipWorkHTable = stockSlipWorkHTable;        // �d���f�[�^HashTable
            this._stockDetailWorkHTable = stockDetailWorkHTable;    // �d�����׃f�[�^HashTable
            this._supplierHTable = supplierHtable;                  // �d����f�[�^HashTable

            // �C���X�^���X����
            this._uoeOrderDtlAcs = new UOEOrderDtlAcs();            // UOE�����f�[�^�A�N�Z�X�N���X
        }
        #endregion

        // ===================================================================================== //
        // �p�u���b�N
        // ===================================================================================== //
        #region ��CreateUOEStcUpdDataList(�X�V�p�I�u�W�F�N�g�쐬���C��)
        /// <summary>
        /// �X�V�p�I�u�W�F�N�g�쐬���C��
        /// </summary>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>�X�V�p�I�u�W�F�N�g(CustomSerializeArrayList�^)</returns>
        /// <remarks>
        /// <br>Note       : �X�V�p�̊e�f�[�^(UOE�����A�d���A�d�����ׁA�݌ɒ���)���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public object CreateUOEStcUpdDataList(out string msg)
        {
            msg = string.Empty;

            // �X�V�Ώۃf�[�^�`�F�b�N
            DataRow[] dataRows = this.GetGridMainDataRows();
            if (dataRows.Length == 0)
            {
                msg = "�Y���f�[�^������܂���B";
                return null;
            }

            CustomSerializeArrayList uoeStcUpdDataList = new CustomSerializeArrayList();

            // ����E�d������f�[�^�쐬
            this.CreateIOWriteCtrlOptWork(ref uoeStcUpdDataList);
            if (uoeStcUpdDataList == null)
            {
                msg = "�S�̏����l�ݒ�}�X�^��ݒ肵�ĉ������B";
                return null;
            }

            // �����E�v��f�[�^�쐬(�d���A�݌ɒ������ɍ쐬����)
            this.CreateOrderDtlArrayList(ref uoeStcUpdDataList);                //ADD 2009/02/25

            // USB�I�v�V����-���|�I�v�V��������
            if (this._stockingPaymentOption == true)
            {
                // �������Ȃ� CommentADD 2009/02/25
                /* ---DEL 2009/02/25 ------------------------------------------>>>>>
                //// �v��f�[�^�쐬
                //this.CreateStockSlipArrayList(ref uoeStcUpdDataList);         //DEL 2009/02/17 �s��Ή�[10140][10177][10529]

                // �����E�v��f�[�^�쐬
                this.CreateOrderDtlArrayList(ref uoeStcUpdDataList);            //ADD 2009/02/17 �s��Ή�[10140][10177][10529]
                   ---DEL 2009/02/25 ------------------------------------------<<<<< */
            }
            else
            {
                // �݌ɒ����f�[�^�쐬
                this.CreateStockAdjustArrayList(ref uoeStcUpdDataList);
            }

            // UOE�����f�[�^(���ɍX�V�t���O�X�V��)�쐬
            uoeStcUpdDataList.Add(this.CreateUOEOrderDtlWorkList());

            return uoeStcUpdDataList;
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g
        // ===================================================================================== //
        #region ��GetRemainCntMngDiv(�c���Ǘ��敪�擾)�@DEL 2009/05/27 �s��Ή�[13289]
        ///// <summary>
        ///// �c���Ǘ��敪�擾
        ///// </summary>
        ///// <returns>-1�F���s�A���̑��F�c���Ǘ��敪�̒l</returns>
        ///// <remarks>
        ///// <br>Note       : �S�̏����l�ݒ�}�X�^���c���Ǘ��敪���擾���܂��B</br>
        ///// <br>Programmer : �Ɠc �M�u</br>
        ///// <br>Date       : 2008/09/04</br>
        ///// </remarks>
        //private int GetRemainCntMngDiv()
        //{
        //    AllDefSetWork allDefSetWork = new AllDefSetWork();
        //    allDefSetWork.EnterpriseCode = this._enterpriseCode;
        //    object paraobj = allDefSetWork;

        //    // �����[�g�I�u�W�F�N�g�擾
        //    IAllDefSetDB iAllDefSetDB = (IAllDefSetDB)MediationAllDefSetDB.GetAllDefSetDB();

        //    // �ǂݍ���
        //    object retobj = null;
        //    int status = iAllDefSetDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0);
        //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        return -1;
        //    }
        //    ArrayList allDefSetWorkList = retobj as ArrayList;
        //    if (allDefSetWorkList == null)
        //    {
        //        return -1;
        //    }

        //    // �����_�̃f�[�^�擾
        //    for (int index = 0; index <= allDefSetWorkList.Count - 1; index++)
        //    {
        //        allDefSetWork = (AllDefSetWork)allDefSetWorkList[index];
        //        if (allDefSetWork.SectionCode.TrimEnd() == LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd())
        //        {
        //            return allDefSetWork.RemainCntMngDiv;
        //        }
        //    }

        //    return -1;
        //}
        #endregion

        #region ��GetGoodsUnitDataList(���i�݌Ƀ}�X�^���擾)
        /// <summary>
        /// ���i�݌Ƀ}�X�^���擾
        /// </summary>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <returns>null�F�擾���s�A���̑��F�擾�������i�݌Ƀ��X�g</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�A�i�Ԃŏ��i�݌Ƀ}�X�^���������܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private List<GoodsUnitData> GetGoodsUnitDataList(int goodsMakerCd, string goodsNo)
        {
            string msg = string.Empty;
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();

            // ���o����
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.GoodsMakerCd = goodsMakerCd;
            goodsCndtn.GoodsNo = goodsNo;

            int status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtn, false, out goodsUnitDataList, out msg);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return goodsUnitDataList;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region ��GetGridMainDataRows( UOE���ɍX�V���C��(�O���b�h���e���f��)�f�[�^�擾 )
        /// <summary>
        /// UOE���ɍX�V���C��(�O���b�h���e���f��)�f�[�^�擾
        /// </summary>
        /// <returns>�敪���u1�F���Ɂv�u3�F���׏C���v�u9�F�������݁v�̂����ꂩ�ƂȂ��Ă��閾��</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h���C���f�[�^����X�V�Ώۂ̃f�[�^�𒊏o���A�Ԃ��܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private DataRow[] GetGridMainDataRows()
        {
            // �u1�F���Ɂv�u3�F���׏C���v�u9�F�������݁v���Ώ�
            string filter = string.Format("(({0}='{1}') OR ({0}='{2}') OR ({0}='{3}'))"
                                        , this._gridMainDataTable.DivCdColumn.ColumnName
                                        , PMUOE01202EA.DIVCD_ENTER
                                        , PMUOE01202EA.DIVCD_UPDATE
                                        , PMUOE01202EA.DIVCD_DELETE);
            string sort = string.Format("{0}, {1}"
                                        , this._gridMainDataTable.HeaderGridRowNoColumn.ColumnName
                                        , this._gridMainDataTable.DetailGridRowNoColumn.ColumnName);

            return this._gridMainDataTable.Select(filter, sort);
        }
        #endregion

        // ---ADD 2009/02/25 ---------------------------------------------------------------------------->>>>>
        #region ��GetGridMainDataRowsStockAdjust( UOE���ɍX�V���C��(�O���b�h���e���f��)�݌ɒ����p�f�[�^�擾 )
        /// <summary>
        /// UOE���ɍX�V���C��(�O���b�h���e���f��)�f�[�^�擾
        /// </summary>
        /// <returns>�敪���u1�F���Ɂv�u3�F���׏C���v�̂����ꂩ�ƂȂ��Ă��閾��</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h���C���f�[�^����X�V�Ώۂ̃f�[�^�𒊏o���A�Ԃ��܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private DataRow[] GetGridMainDataRowsStockAdjust()
        {
            // �u1�F���Ɂv�u3�F���׏C���v���Ώ�
            string filter = string.Format("(({0}='{1}') OR ({0}='{2}'))"
                                        , this._gridMainDataTable.DivCdColumn.ColumnName
                                        , PMUOE01202EA.DIVCD_ENTER
                                        , PMUOE01202EA.DIVCD_UPDATE);
            string sort = string.Format("{0}, {1}, {2}"
                                        , this._gridMainDataTable.HeaderGridRowNoColumn.ColumnName
                                        , this._gridMainDataTable.WarehouseCodeColumn.ColumnName
                                        , this._gridMainDataTable.DetailGridRowNoColumn.ColumnName);

            return this._gridMainDataTable.Select(filter, sort);
        }
        #endregion
        // ---ADD 2009/02/25 ----------------------------------------------------------------------------<<<<<

        // ����E�d������f�[�^�쐬�֘A
        #region ��CreateIOWriteCtrlOptWork(����E�d������f�[�^�쐬)
        /// <summary>
        /// ����E�d������f�[�^�쐬
        /// </summary>
        /// <param name="uoeStcUpdDataList">����E�d������f�[�^(CustomSerializeArrayList�^)</param>
        /// <remarks>
        /// <br>Note       : ����E�d������f�[�^�̍쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void CreateIOWriteCtrlOptWork(ref CustomSerializeArrayList uoeStcUpdDataList)
        {

            IOWriteCtrlOptWork ioWriteCtrlOptWork = new IOWriteCtrlOptWork();
            ioWriteCtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Purchase;        // ����N�_

            ioWriteCtrlOptWork.EstimateAddUpRemDiv = 0;                         // ���σf�[�^�v��c�敪
            ioWriteCtrlOptWork.AcpOdrrAddUpRemDiv = 0;                          // �󒍃f�[�^�v��c�敪
            ioWriteCtrlOptWork.ShipmAddUpRemDiv = 0;                            // �o�׃f�[�^�v��c�敪
            ioWriteCtrlOptWork.RetGoodsStockEtyDiv = 0;                         // �ԕi���݌ɓo�^�敪
            ioWriteCtrlOptWork.SupplierSlipDelDiv = 0;                         // �d���`�[�폜�敪
            ioWriteCtrlOptWork.EnterpriseCode = this._enterpriseCode;           // ��ƃR�[�h
            ioWriteCtrlOptWork.CarMngDivCd = 0;                                // �ԗ��Ǘ��敪
            // ---DEL 2009/05/27 �s��Ή�[13289] -------------------------------------------->>>>>
            //ioWriteCtrlOptWork.RemainCntMngDiv = this.GetRemainCntMngDiv();     // �c���Ǘ��敪

            //if (ioWriteCtrlOptWork.RemainCntMngDiv == -1)
            //{
            //    // �c���Ǘ��敪�擾���s
            //    uoeStcUpdDataList = null;
            //    return;
            //}
            // ---DEL 2009/05/27 �s��Ή�[13289] --------------------------------------------<<<<<
            ioWriteCtrlOptWork.RemainCntMngDiv = 0;     //ADD 2009/05/27 �s��Ή�[13289]�@��0�Œ�Ƃ���

            uoeStcUpdDataList.Add(ioWriteCtrlOptWork);
        }
        #endregion

        // �v��f�[�^�쐬�֘A
        #region ��CreateStockSlipArrayList(�v��f�[�^�Q�쐬)�@2009/02/17 DEL �s��Ή�[10140][10177][10529]
        ///// <summary>
        ///// �v��f�[�^�Q�쐬
        ///// </summary>
        ///// <param name="uoeStcUpdDataList">�X�V�p�f�[�^</param>
        ///// <remarks>
        ///// <br>Note       : �O���b�h���C��(�X�V���)�f�[�^�A�d���f�[�^�A�d�����׃f�[�^�AUOE�����f�[�^�����Ɍv��f�[�^���쐬���܂��B</br>
        ///// <br>             �܂��AUOE�����f�[�^�̓��ɋ敪���X�V���܂��B</br>
        ///// <br>Programmer : �Ɠc �M�u</br>
        ///// <br>Date       : 2008/09/04</br>
        ///// </remarks>
        //private void CreateStockSlipArrayList(ref CustomSerializeArrayList uoeStcUpdDataList)
        //{
        //    StockSlipListInfo stockSlipListInfo = new StockSlipListInfo();      // �v��f�[�^���ߍ��ݗp�N���X
        //    List<StockDetailWork> stockDetailWork = null;                       // �v�㖾�׃��X�g
        //    GridMainDataSet.GridMainTableRow mainRow = null;                    // �O���b�h���̓f�[�^(���ݒl)
        //    GridMainDataSet.GridMainTableRow mainRowBf = null;                  // �O���b�h���̓f�[�^(�O��l)

        //    // �X�V�Ώۃf�[�^�擾
        //    //DataRow[] dataRows = this.GetGridMainDataRows();                  //DEL 2009/02/17 �s��Ή�[10140][10177][10529]
        //    // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] ---------------------------------------->>>>>
        //    // �v��́u1�F���Ɂv�u3�F���׏C���v���Ώ�
        //    string filter = string.Format("(({0}='{1}') OR ({0}='{2}'))"
        //                                , this._gridMainDataTable.DivCdColumn.ColumnName
        //                                , PMUOE01202EA.DIVCD_ENTER
        //                                , PMUOE01202EA.DIVCD_UPDATE);
        //    string sort = string.Format("{0}, {1}"
        //                                , this._gridMainDataTable.HeaderGridRowNoColumn.ColumnName
        //                                , this._gridMainDataTable.DetailGridRowNoColumn.ColumnName);

        //    DataRow[] dataRows = this._gridMainDataTable.Select(filter, sort);
        //    // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] ----------------------------------------<<<<<
        //    for (int index = 0; index <= dataRows.Length - 1; index++)
        //    {
        //        mainRow = (GridMainDataSet.GridMainTableRow)dataRows[index];

        //        // �w�b�_�[���قȂ�ꍇ�Ɍv��f�[�^�쐬
        //        if ((mainRowBf != null) && (mainRowBf.HeaderGridRowNo != mainRow.HeaderGridRowNo))
        //        {
        //            // �v��f�[�^���ߍ���
        //            stockDetailWork = stockSlipListInfo.StockDetailWorkList;
        //            //stockSlipListInfo.StockSlipWork = this.CreateStockSlipWork(mainRowBf, UOESUBSTMARK_NOEXISTS, stockDetailWork);    //DEL 2009/02/17 �s��Ή�[10140][10177][10529]
        //            stockSlipListInfo.StockSlipWork = this.GetStockSlipWorkUpdate(mainRowBf, stockDetailWork);                          //ADD 2009/02/17 �s��Ή�[10140][10177][10529]

        //            // ���ߍ��񂾌v��f�[�^�A�v�㖾�ׁA���וt���f�[�^���܂Ƃ߂�uoeStcUpdDataList�ɒǉ�
        //            uoeStcUpdDataList.Add(stockSlipListInfo.StockSlipList);

        //            /* ---DEL 2009/02/17 �s��Ή�[10140][10177][10529] ---------------------------------------->>>>>
        //            // ��֕i������ꍇ
        //            if (stockSlipListInfo.StockDetailWorkBfListDataIsExists)
        //            {
        //                // ��֕i�p�����f�[�^���ߍ���
        //                stockSlipListInfo.StockSlipWorkBf = this.CreateStockSlipWork(mainRowBf, UOESUBSTMARK_EXISTS);


        //                // ���ߍ��񂾑�֕i�p�����A�������׃f�[�^���܂Ƃ߂�uoeStcUpdDataList�ɒǉ�
        //                uoeStcUpdDataList.Add(stockSlipListInfo.StockSlipBfList);
        //            }
        //               ---DEL 2009/02/17 �s��Ή�[10140][10177][10529] ----------------------------------------<<<<< */
        //            stockSlipListInfo.ClearItem();
        //        }

        //        // �v�㖾�ׁA���וt���f�[�^���ߍ���
        //        stockSlipListInfo.DtlRelationGuid = Guid.NewGuid();     //GUID�̔�
        //        //stockSlipListInfo.StockDetailWork = this.CreateStockDetailWork(mainRow, UOESUBSTMARK_NOEXISTS);           //DEL 2009/02/17 �s��Ή�[10140][10177][10529]
        //        stockSlipListInfo.StockDetailWork = this.GetStockDetailWorkUpdate(mainRow);                                 //ADD 2009/02/17 �s��Ή�[10140][10177][10529]
        //        stockSlipListInfo.SlipDetailAddInfoWork = this.CreateSlipDetailAddInfoWork(mainRow);

        //        /* ---DEL 2009/01/16 �s��Ή�[10145] ------------------------------------------------------------->>>>>
        //        if (string.IsNullOrEmpty(mainRow.SubstPartsNo.TrimEnd()) == false)
        //        {
        //            // ��֕i�p�������׃f�[�^�𒙂ߍ���
        //            stockSlipListInfo.StockDetailWorkBf = this.CreateStockDetailWork(mainRow, UOESUBSTMARK_EXISTS);
        //        }
        //           ---DEL 2009/01/16 �s��Ή�[10145] ------------------------------------------------------------->>>>> */
        //        /* ---DEL 2009/02/17 �s��Ή�[10140][10177][10529] ----------------------------------------------->>>>>
        //        // ---ADD 2009/01/16 �s��Ή�[10145] ------------------------------------------------------------->>>>>
        //        // ��֕i�̗p�ő�֕i������ꍇ
        //        if (this._stockBlnktPrtNoDiv == 0)
        //        {
        //            if (string.IsNullOrEmpty(mainRow.SubstPartsNo.TrimEnd()) == false)
        //            {
        //                // ��֕i�p�������׃f�[�^�𒙂ߍ���
        //                stockSlipListInfo.StockDetailWorkBf = this.CreateStockDetailWork(mainRow, UOESUBSTMARK_EXISTS);
        //            }
        //        }
        //        // ---ADD 2009/01/16 �s��Ή�[10145] -------------------------------------------------------------<<<<<
        //           ---DEL 2009/02/17 �s��Ή�[10140][10177][10529] -----------------------------------------------<<<<< */

        //        // UOE�����f�[�^�X�V
        //        this.UpdateUOEOrderDtlWork(mainRow.StockSlipDtlNumSrc, mainRow.ColumnDiv, ENTERUPDDIV_ENTER, stockSlipListInfo.DtlRelationGuid);

        //        // 1�O�̏���ێ�
        //        mainRowBf = mainRow;
        //    }

        //    // �ȉ��A�Ō�̃f�[�^������

        //    // �v��f�[�^���ߍ���
        //    stockDetailWork = stockSlipListInfo.StockDetailWorkList;
        //    //stockSlipListInfo.StockSlipWork = this.CreateStockSlipWork(mainRowBf, UOESUBSTMARK_NOEXISTS, stockDetailWork);    //DEL 2009/02/17 �s��Ή�[10140][10177][10529]
        //    stockSlipListInfo.StockSlipWork = this.GetStockSlipWorkUpdate(mainRowBf, stockDetailWork);                          //ADD 2009/02/17 �s��Ή�[10140][10177][10529]

        //    // ���ߍ��񂾌v��f�[�^�A�v�㖾�ׁA���וt���f�[�^���܂Ƃ߂�uoeStcUpdDataList�ɒǉ�
        //    uoeStcUpdDataList.Add(stockSlipListInfo.StockSlipList);

        //    /* ---DEL 2009/02/17 �s��Ή�[10140][10177][10529] ------------------------------------------------>>>>>
        //    // ��֕i������ꍇ
        //    if (stockSlipListInfo.StockDetailWorkBfListDataIsExists)
        //    {
        //        // ��֕i�p�����f�[�^���ߍ���
        //        stockSlipListInfo.StockSlipWorkBf = this.CreateStockSlipWork(mainRowBf, UOESUBSTMARK_EXISTS);


        //        // ���ߍ��񂾑�֕i�p�����A�������׃f�[�^���܂Ƃ߂�uoeStcUpdDataList�ɒǉ�
        //        uoeStcUpdDataList.Add(stockSlipListInfo.StockSlipBfList);
        //    }
        //       ---DEL 2009/02/17 �s��Ή�[10140][10177][10529] ------------------------------------------------<<<<< */
        //}
        #endregion

        #region ��CreateStockSlipWork(�d���f�[�^�쐬)�@2009/02/17 DEL �s��Ή�[10140][10177][10529]
        ///// <summary>
        ///// �X�V�p�d���f�[�^�쐬
        ///// </summary>
        ///// <param name="mainRow">�O���b�h���C��(�X�V���)�f�[�^</param>
        ///// <param name="uoeSubstFlg">True�F��֕i�p�f�[�^�AFalse�F�����v��d���f�[�^</param>
        ///// <returns>�X�V�p�d���f�[�^</returns>
        ///// <remarks>
        ///// <br>Note       : �@�����v��d���f�[�^�̏ꍇ�A�d���f�[�^�A�O���b�h���C��(�X�V���)�f�[�^�����ɍX�V�p�d���f�[�^���쐬���܂��B</br>
        ///// <br>             �A��֕i�p�f�[�^�̏ꍇ�A�d�����׃f�[�^�̓��e�����̂܂ܕԂ��܂��B</br>
        ///// <br>Programmer : �Ɠc �M�u</br>
        ///// <br>Date       : 2008/09/04</br>
        ///// </remarks>
        //private StockSlipWork CreateStockSlipWork(GridMainDataSet.GridMainTableRow mainRow, bool uoeSubstFlg)
        //{
        //    // ����֕i�p�̏ꍇ�A�����炩��CALL�����
        //    return this.CreateStockSlipWork(mainRow, uoeSubstFlg, null);
        //}
        //private StockSlipWork CreateStockSlipWork(GridMainDataSet.GridMainTableRow mainRow, bool uoeSubstFlg, List<StockDetailWork> stockDetailWorkList)
        //{
        //    //StockSlipWork stockSlipWork = (StockSlipWork)this._stockSlipWorkHTable[mainRow.SupplierSlipNo.ToString()];
        //    StockSlipWork stockSlipWork = ((StockSlipWork)this._stockSlipWorkHTable[mainRow.SupplierSlipNo.ToString()]).Clone();        //���l�n��
        //    if (uoeSubstFlg == UOESUBSTMARK_EXISTS)
        //    {
        //        // ��֕i�p�̏ꍇ�A���̂܂ܕԂ�
        //        return stockSlipWork;
        //    }

        //    // �d������Œ[�������R�[�h
        //    int stockCnsTaxFrcProcCd = ((Supplier)this._supplierHTable[stockSlipWork.SupplierCd]).StockCnsTaxFrcProcCd;

        //    stockSlipWork.CreateDateTime = DateTime.MinValue;                           // �쐬����                     [������]
        //    stockSlipWork.UpdateDateTime = DateTime.MinValue;                           // �X�V����                     [������]
        //    stockSlipWork.EnterpriseCode = this._enterpriseCode;                        // ��ƃR�[�h
        //    stockSlipWork.FileHeaderGuid = Guid.Empty;                                  // GUID                         [������]
        //    stockSlipWork.UpdEmployeeCode = string.Empty;                               // �X�V�]�ƈ��R�[�h             [������]
        //    stockSlipWork.UpdAssemblyId1 = string.Empty;                                // �X�V�A�Z���u��ID1            [������]
        //    stockSlipWork.UpdAssemblyId2 = string.Empty;                                // �X�V�A�Z���u��ID2            [������]
        //    stockSlipWork.LogicalDeleteCode = 0;                                        // �_���폜�敪                 [������]
        //    stockSlipWork.SupplierFormal = 0;                                           // �d���`��                     [0�F�d��]
        //    stockSlipWork.SupplierSlipNo = 0;                                           // �d���`�[�ԍ�                 [������]
        //    stockSlipWork.InputDay = DateTime.Today;                                    // ���͓�
        //    stockSlipWork.ArrivalGoodsDay = DateTime.Today;                             // ���ד�
        //    stockSlipWork.StockDate = DateTime.Today;                                   // �d����
        //    stockSlipWork.StockAddUpADate = stockSlipWork.StockDate;                    // �d���v����t                 [�d�����Ɠ��l]
        //    stockSlipWork.PartySaleSlipNum = mainRow.InputSlipNo;                       // �����`�[�ԍ�               [��ʂ̓��͒l(�`�[�ԍ�)]
        //    stockSlipWork.DetailRowCount = stockDetailWorkList.Count;                   // ���א�                       [���ߍ��񂾖��א�]

        //    // �d���f�[�^�̏��Z�o(������d���A�d�����׃��X�g�A�d���[�������敪�A�d������Œ[�������R�[�h)
        //    StockSlipPriceCalculator.TotalPriceSetting(ref stockSlipWork, stockDetailWorkList, stockSlipWork.StockFractionProcCd,stockCnsTaxFrcProcCd);
        //    /*
        //    stockSlipWork.StockTotalPrice;          // �d�����z���v
        //    stockSlipWork.StockSubttlPrice;         // �d�����z���v
        //    stockSlipWork.StockTtlPricTaxInc;       // �d�����z�v(�ō���)
        //    stockSlipWork.StockTtlPricTaxExc;       // �d�����z�v(�Ŕ���)
        //    stockSlipWork.StockNetPrice;            // �d���������z
        //    stockSlipWork.StockPriceConsTax;        // �d�����z����Ŋz
        //    stockSlipWork.TtlItdedStcOutTax;        // �d���O�őΏۊz���v
        //    stockSlipWork.TtlItdedStcInTax;         // �d�����őΏۊz���v
        //    stockSlipWork.TtlItdedStcTaxFree;       // �d����ېőΏۊz���v
        //    stockSlipWork.StockOutTax;              // �d�����z����Ŋz(�O��)
        //    stockSlipWork.StckPrcConsTaxInclu;      // �d�����z����Ŋz(����)
        //    stockSlipWork.StckDisTtlTaxExc;         // �d���l�����z�v(�Ŕ���)
        //    stockSlipWork.ItdedStockDisOutTax;      // �d���l���O�őΏۊz���v
        //    stockSlipWork.ItdedStockDisInTax;       // �d���l�����őΏۊz���v
        //    stockSlipWork.ItdedStockDisTaxFre;      // �d���l����ېőΏۊz���v
        //    stockSlipWork.StockDisOutTax;           // �d���l������Ŋz(�O��)
        //    stockSlipWork.StckDisTtlTaxInclu;       // �d���l������Ŋz(����)
        //    */

        //    return stockSlipWork;
        //}
        #endregion
        // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] --------------------------------------->>>>>
        #region ��GetStockSlipWorkNoUpdate(�X�V�O�d���f�[�^�擾)
        /// <summary>
        /// �X�V�O�d���f�[�^�擾
        /// </summary>
        /// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
        /// <returns>�X�V�O�d���f�[�^</returns>
        /// <remarks>
        /// <br>Note       : �d���`�[�ԍ�������HashTable����X�V�O�̎d���f�[�^���擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/02/17</br>
        /// </remarks>
        private StockSlipWork GetStockSlipWorkNoUpdate(int supplierSlipNo)
        {
            if (this._stockSlipWorkHTable.ContainsKey(supplierSlipNo.ToString()) == false)
            {
                return null;
            }

            return ((StockSlipWork)this._stockSlipWorkHTable[supplierSlipNo.ToString()]).Clone();
        }
        #endregion

        #region ��GetStockSlipWorkUpdate(�X�V��d���f�[�^�擾)
        /// <summary>
        /// �X�V��d���f�[�^�擾
        /// </summary>
        /// <param name="mainRow">�O���b�h���C��(�X�V���)�f�[�^</param>
        /// <param name="stockDetailWorkList">�X�V��d�����׃f�[�^</param>
        /// <returns>�X�V��d���f�[�^</returns>
        /// <remarks>
        /// <br>Note       : �X�V�O�d���f�[�^���x�[�X�Ɋe���ڂ��X�V���ĕԂ��܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>UpdateNote : 2012/08/30 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 20120912�z�M��</br>
        /// <br>             redmine #31885:�g�c����@�݌ɓ��ɍX�V�����̑Ή�</br>
        /// <br> �@�@�@�@�@�@�@�@�@�@�@�@�@ �d�����Ǝd���v����̑Ή�</br>
        /// <br>UpdateNote  : 2012/09/28 ���N�n��</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00 20120912�z�M��</br>
        /// <br>              redmine #31885:�g�c����@�d����}�X�^�̎��񊨒肪���ݒ�̏ꍇ�͎d���v������d�����ƂȂ�悤�ɏC���̑Ή�</br>
        /// <br>UpdateNote  : 2012/10/02 �� ��</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00 20120912�z�M��</br>
        /// <br>              redmine #31885:�g�c����@�d�����v�Z�Ɏx�����敪���g�p���Ȃ��悤�ɏC��</br>
        /// <br>UpdateNote  : 2012/10/10 �� ��</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00 20120917�z�M��</br>
        /// <br>              Redmine#32625 ����Ōv�Z�s���̑Ή��B</br>
        /// <br>UpdateNote : 2013/05/16 �����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2013/06/18�z�M��</br>
        /// <br>              Redmine#35459 #42�̑Ή�</br>
        /// </remarks>
        private StockSlipWork GetStockSlipWorkUpdate(GridMainDataSet.GridMainTableRow mainRow, List<StockDetailWork> stockDetailWorkList)
        {
            // �d���f�[�^�擾
            StockSlipWork stockSlipWork = this.GetStockSlipWorkNoUpdate(mainRow.SupplierSlipNo);
            if (stockSlipWork == null)
            {
                return null;
            }

            // ----- ADD 2012/08/30 ���N�n��  redmine#31885----->>>>>
            int totalDay = 0;
            int nTimeCalcStDate = 0;
            DateTime targetDate = DateTime.MinValue;
            DateTime nextTimeAddUpDate = DateTime.MinValue;
            // �x������擾
            Supplier supplier = (Supplier)this._supplierHTable[mainRow.SupplierCd];
            //UOE�����f�[�^(key�F�d�����גʔ�)
            UOEOrderDtlWork uoeOrderDtlWork = null;

            foreach (string key in this._uoeOrderDtlWorkHTable.Keys)
            {
                string uoeOrderDtlKey = this.GetOrderDtlKey(mainRow.StockSlipDtlNumSrc.ToString(), mainRow.SlipNo);  // ADD ����� 2013/05/16 Redmine#35459

                //if (mainRow.StockSlipDtlNumSrc.ToString().Trim() == key) //  DEL ����� 2013/05/16 Redmine#35459
                if (uoeOrderDtlKey == key)  // ADD ����� 2013/05/16 Redmine#35459
                {
                    uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[key];
                }
            }
            // ----- ADD 2012/08/30 ���N�n��  redmine#31885-----<<<<<

            // �d������Œ[�������R�[�h
            int stockCnsTaxFrcProcCd = ((Supplier)this._supplierHTable[stockSlipWork.SupplierCd]).StockCnsTaxFrcProcCd;

            stockSlipWork.CreateDateTime = DateTime.MinValue;                           // �쐬����                     [������]
            stockSlipWork.UpdateDateTime = DateTime.MinValue;                           // �X�V����                     [������]
            stockSlipWork.EnterpriseCode = this._enterpriseCode;                        // ��ƃR�[�h
            stockSlipWork.FileHeaderGuid = Guid.Empty;                                  // GUID                         [������]
            stockSlipWork.UpdEmployeeCode = string.Empty;                               // �X�V�]�ƈ��R�[�h             [������]
            stockSlipWork.UpdAssemblyId1 = string.Empty;                                // �X�V�A�Z���u��ID1            [������]
            stockSlipWork.UpdAssemblyId2 = string.Empty;                                // �X�V�A�Z���u��ID2            [������]
            stockSlipWork.LogicalDeleteCode = 0;                                        // �_���폜�敪                 [������]
            stockSlipWork.SupplierFormal = 0;                                           // �d���`��                     [0�F�d��]
            stockSlipWork.SupplierSlipNo = 0;                                           // �d���`�[�ԍ�                 [������]
            stockSlipWork.InputDay = DateTime.Today;                                    // ���͓�
            stockSlipWork.ArrivalGoodsDay = DateTime.Today;                             // ���ד�
            // ----- ADD 2012/08/30 ���N�n��  redmine#31885----->>>>>
            if (uoeOrderDtlWork != null)
            {
                stockSlipWork.StockDate = uoeOrderDtlWork.ReceiveDate;                  // �d����<---UOE�����f�[�^�̎�M��
            }
            // ----- ADD 2012/09/28 ���N�n��  redmine#31885----->>>>>
            stockSlipWork.StockAddUpADate = stockSlipWork.StockDate;// �d���v����t
            // �d����
            targetDate = stockSlipWork.StockDate;
            // ����
            totalDay = supplier.PaymentTotalDay;
            //��������J�n��
            nTimeCalcStDate = supplier.NTimeCalcStDate;
            // ----- ADD 2012/09/28 ���N�n��  redmine#31885-----<<<<<
            // ----- DEL 2012/10/02 �� ��  redmine#31885----->>>>>
            ////�x�����敪�R�[�h0:���� 1:���� 2:���X�� 3:���X�X��
            //if (supplier != null && supplier.PaymentMonthCode != 0)
            //{
            //    //stockSlipWork.StockAddUpADate = this.GetNextTotalDate(supplier.PaymentMonthCode - 1, stockSlipWork.StockDate, supplier.PaymentTotalDay).AddDays(1);// �d���v����t //DEL 2012/09/28 ���N�n��  redmine#31885
            //    // ----- ADD 2012/09/28 ���N�n��  redmine#31885----->>>>>
            //    if (!((totalDay == 0) || (nTimeCalcStDate == 0) || (targetDate == DateTime.MinValue)))
            //    {
            //        stockSlipWork.StockAddUpADate = this.GetNextTotalDate(supplier.PaymentMonthCode - 1, stockSlipWork.StockDate, supplier.PaymentTotalDay).AddDays(1);// �d���v����t 
            //    }
            //    // ----- ADD 2012/09/28 ���N�n��  redmine#31885-----<<<<<
            //}
            // ----- DEL 2012/10/02 �� ��  redmine#31885-----<<<<<
            //else // ----- DEL 2012/10/02 �� ��  redmine#31885
            //{ // ----- DEL 2012/10/02 �� ��  redmine#31885
                // ----- DEL 2012/09/28 ���N�n��  redmine#31885----->>>>>
                //stockSlipWork.StockAddUpADate = stockSlipWork.StockDate;// �d���v����t 
                //targetDate = stockSlipWork.StockDate;
                //totalDay = supplier.PaymentTotalDay;
                //nTimeCalcStDate = supplier.NTimeCalcStDate;
                // ----- DEL 2012/09/28 ���N�n��  redmine#31885-----<<<<<
                nextTimeAddUpDate = this.GetNextTotalDate(0, stockSlipWork.StockDate, supplier.PaymentTotalDay).AddDays(1);// �d���v����t 
                // �����A��������J�n�����ݒ肳��Ă��Ȃ��ꍇ�͂��̂܂܏I��
                if (!((totalDay == 0) || (nTimeCalcStDate == 0) || (targetDate == DateTime.MinValue)))
                {
                    // ��������J�n�� �� ����
                    if (nTimeCalcStDate <= totalDay)
                    {
                        // �Ώۓ��̓��t����������J�n���`�����̏ꍇ�ɗ�������
                        if ((nTimeCalcStDate <= targetDate.Day) && (targetDate.Day <= totalDay))
                        {
                            stockSlipWork.StockAddUpADate = nextTimeAddUpDate;
                        }
                    }
                    // ��������J�n�� �� ����
                    else
                    {
                        // �Ώۓ��̓��t��1���`�����A��������J�n���`�����̏ꍇ�ɗ�������
                        if ((1 <= targetDate.Day) && (targetDate.Day <= totalDay) ||
                            (nTimeCalcStDate <= targetDate.Day))
                        {
                            stockSlipWork.StockAddUpADate = nextTimeAddUpDate;
                        }
                    }
                }
            //} // ----- DEL 2012/10/02 �� ��  redmine#31885
            // ----- ADD 2012/08/30 ���N�n��  redmine#31885-----<<<<<
            // ----- DEL 2012/08/30 ���N�n��  redmine#31885----->>>>>
            //stockSlipWork.StockDate = DateTime.Today;                                 // �d���� 
            //stockSlipWork.StockAddUpADate = stockSlipWork.StockDate;                  // �d���v����t                 [�d�����Ɠ��l] 
            // ----- DEL 2012/08/30 ���N�n��  redmine#31885-----<<<<<
            stockSlipWork.PartySaleSlipNum = mainRow.InputSlipNo;                       // �����`�[�ԍ�               [��ʂ̓��͒l(�`�[�ԍ�)]
            stockSlipWork.DetailRowCount = stockDetailWorkList.Count;                   // ���א�                       [���ߍ��񂾖��א�]

            // ----- ADD 2012/10/10 �� �� Redmine#32625 ----->>>>>
            //�d���[�������敪�ƒ[�������P�ʂ̎擾
            //1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj
            StockProcMoney stockProcMoney = this._uoeOrderDtlAcs.GetStockProcMoney(
                                                        1,
                                                        stockCnsTaxFrcProcCd,
                                                        999999999);

            stockSlipWork.StockFractionProcCd = stockProcMoney.FractionProcCd;
            // ----- ADD 2012/10/10 �� �� Redmine#32625 -----<<<<<

            // �d���f�[�^�̏��Z�o(������d���A�d�����׃��X�g�A�d���[�������敪�A�d������Œ[�������R�[�h)
            //StockSlipPriceCalculator.TotalPriceSetting(ref stockSlipWork, stockDetailWorkList, stockSlipWork.StockFractionProcCd, stockCnsTaxFrcProcCd); // DEL 2012/10/10 �� �� Redmine#32625
            StockSlipPriceCalculator.TotalPriceSetting(ref stockSlipWork, stockDetailWorkList, stockProcMoney.FractionProcUnit, stockProcMoney.FractionProcCd); // ADD 2012/10/10 �� �� Redmine#32625
            //---TotalPriceSetting�ł͈ȉ��̍��ڂ��X�V�����(���ɂ����邩���H)---
            //stockSlipWork.StockTotalPrice;          // �d�����z���v
            //stockSlipWork.StockSubttlPrice;         // �d�����z���v
            //stockSlipWork.StockTtlPricTaxInc;       // �d�����z�v(�ō���)
            //stockSlipWork.StockTtlPricTaxExc;       // �d�����z�v(�Ŕ���)
            //stockSlipWork.StockNetPrice;            // �d���������z
            //stockSlipWork.StockPriceConsTax;        // �d�����z����Ŋz
            //stockSlipWork.TtlItdedStcOutTax;        // �d���O�őΏۊz���v
            //stockSlipWork.TtlItdedStcInTax;         // �d�����őΏۊz���v
            //stockSlipWork.TtlItdedStcTaxFree;       // �d����ېőΏۊz���v
            //stockSlipWork.StockOutTax;              // �d�����z����Ŋz(�O��)
            //stockSlipWork.StckPrcConsTaxInclu;      // �d�����z����Ŋz(����)
            //stockSlipWork.StckDisTtlTaxExc;         // �d���l�����z�v(�Ŕ���)
            //stockSlipWork.ItdedStockDisOutTax;      // �d���l���O�őΏۊz���v
            //stockSlipWork.ItdedStockDisInTax;       // �d���l�����őΏۊz���v
            //stockSlipWork.ItdedStockDisTaxFre;      // �d���l����ېőΏۊz���v
            //stockSlipWork.StockDisOutTax;           // �d���l������Ŋz(�O��)
            //stockSlipWork.StckDisTtlTaxInclu;       // �d���l������Ŋz(����)

            return stockSlipWork;
        }

        // ----- ADD 2012/08/30 ���N�n��  redmine#31885----->>>>>
        /// <summary>
        /// �Ώ۔N�����A��������A���ۂɒ��ΏۂƂȂ���t���Z�o���܂��B
        /// </summary>
        /// <param name="targetDate">�Ώ۔N����</param>
        /// <param name="totalDay">�ݒ��̒���</param>
        /// <returns>�Ώی��̎��ۂ̒���</returns>
        /// <remarks>
        /// <br>Note       : �Ώ۔N�����A��������A���ۂɒ��ΏۂƂȂ���t���Z�o���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 20120912�z�M��</br>
        /// <br>             redmine #31885:�g�c����@�݌ɓ��ɍX�V�����̑Ή�</br>
        /// <br> �@�@�@�@�@�@�@�@�@�@�@�@�@ �d�����Ǝd���v����̑Ή�</br>
        /// </remarks>
        private int GetRealTotalDay(DateTime targetDate, int totalDay)
        {
            int retValue = totalDay;
            // �Ώی��̖����擾
            int lastDayofMonth = DateTime.DaysInMonth(targetDate.Year, targetDate.Month);

            if (lastDayofMonth < totalDay) retValue = lastDayofMonth;

            return retValue;
        }

        /// <summary>
        /// �w����t�̎���ȍ~�̒������Z�o���܂��B
        /// </summary>
        /// <param name="loopCnt">0:����,1:����,2:���X��...</param>
        /// <param name="targetdate">�Ώۓ�</param>
        /// <param name="totalDay">����</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �w����t�̎���ȍ~�̒������Z�o���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 20120912�z�M��</br>
        /// <br>             redmine #31885:�g�c����@�݌ɓ��ɍX�V�����̑Ή�</br>
        /// <br> �@�@�@�@�@�@�@�@�@�@�@�@�@ �d�����Ǝd���v����̑Ή�</br>
        /// </remarks>
        private DateTime GetNextTotalDate(int loopCnt, DateTime targetdate, int totalDay)
        {

            DateTime retDate = targetdate;

            // �Ώی��̎��ۂ̒������擾
            int totalDayR = this.GetRealTotalDay(retDate, totalDay);

            // �Ώۓ������ۂ̒������傫���ꍇ��1�������Z
            if (targetdate.Day > totalDayR)
            {
                retDate = retDate.AddMonths(1);

                totalDayR = this.GetRealTotalDay(retDate, totalDay);
            }
            retDate = new DateTime(retDate.Year, retDate.Month, totalDayR);

            return (loopCnt == 0) ? retDate : GetNextTotalDate(loopCnt - 1, retDate.AddDays(1), totalDay);
        }
        // ----- ADD 2012/08/30 ���N�n��  redmine#31885-----<<<<<
        #endregion
        // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] ---------------------------------------<<<<<

        #region ��CreateStockDetailWork(�X�V�p�d�����׃f�[�^�쐬)�@2009/02/17 DEL �s��Ή�[10140][10177][10529]
        ///// <summary>
        ///// �X�V�p�d�����׃f�[�^�쐬
        ///// </summary>
        ///// <param name="mainRow">�O���b�h���C��(�X�V���)�f�[�^</param>
        ///// <param name="uoeSubstFlg">True�F��֕i�p�f�[�^�AFalse�F�����v��d���f�[�^</param>
        ///// <returns>�X�V�p�d�����׃f�[�^</returns>
        ///// <remarks>
        ///// <br>Note       : �@�����v��d���f�[�^�̏ꍇ�A�d�����׃f�[�^�AUOE�����f�[�^�A�O���b�h���C��(�X�V���)�f�[�^�����ɍX�V�p�d�����׃f�[�^���쐬���܂��B</br>
        ///// <br>             �A��֕i�p�f�[�^�̏ꍇ�A�d�����׃f�[�^�̓��e�����̂܂ܕԂ��܂��B</br>
        ///// <br>             ���ȉ���2�_�͊ԈႦ�₷���̂Œ���</br>
        ///// <br>               uoeSubstFlg                 �������v��d���f�[�^or��֕i�p�f�[�^�̔���</br>
        ///// <br>               uoeOrderDtlWork.UOESubstMark�������v��d���f�[�^���ł̑�֕i����</br>
        ///// <br>Programmer : �Ɠc �M�u</br>
        ///// <br>Date       : 2008/09/04</br>
        ///// </remarks>
        //private StockDetailWork CreateStockDetailWork(GridMainDataSet.GridMainTableRow mainRow,bool uoeSubstFlg)
        //{
        //    //StockDetailWork stockDetailWork = (StockDetailWork)this._stockDetailWorkHTable[mainRow.StockSlipDtlNumSrc.ToString()];  // �d�����׃f�[�^
        //    StockDetailWork stockDetailWork = ((StockDetailWork)this._stockDetailWorkHTable[mainRow.StockSlipDtlNumSrc.ToString()]).Clone();  // �d�����׃f�[�^ ���l�n��
        //    if (uoeSubstFlg == UOESUBSTMARK_EXISTS)
        //    {
        //        // ��֕i�p�̏ꍇ�A���̂܂ܕԂ�
        //        return stockDetailWork;
        //    }

        //    UOEOrderDtlWork uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[mainRow.StockSlipDtlNumSrc.ToString()];  // UOE�����f�[�^
        //    if (this._supplierHTable.ContainsKey(stockDetailWork.SupplierCd) == false)
        //    {
        //        // �d���悪����
        //        return null;
        //    }
        //    // �d������Œ[�������R�[�h
        //    int stockCnsTaxFrcProcCd = ((Supplier)this._supplierHTable[stockDetailWork.SupplierCd]).StockCnsTaxFrcProcCd;
        //    // �d�����z�[�������R�[�h
        //    int stockMoneyFrcProcCd = ((Supplier)this._supplierHTable[stockDetailWork.SupplierCd]).StockMoneyFrcProcCd;

        //    stockDetailWork.SupplierFormalSrc = stockDetailWork.SupplierFormal;         // �d���`��(��)                 [�v�㌳�̎d���`��]
        //    stockDetailWork.StockSlipDtlNumSrc = stockDetailWork.StockSlipDtlNum;       // �d�����גʔ�(��)             [�v�㌳�̖��גʔ�]

        //    stockDetailWork.CreateDateTime = DateTime.MinValue;                         // �쐬����                     [������]
        //    stockDetailWork.UpdateDateTime = DateTime.MinValue;                         // �X�V����                     [������]
        //    stockDetailWork.EnterpriseCode = this._enterpriseCode;                      // ��ƃR�[�h
        //    stockDetailWork.FileHeaderGuid = Guid.Empty;                                // GUID                         [������]
        //    stockDetailWork.UpdEmployeeCode = string.Empty;                             // �X�V�]�ƈ��R�[�h             [������]
        //    stockDetailWork.UpdAssemblyId1 = string.Empty;                              // �X�V�A�Z���u��ID1            [������]
        //    stockDetailWork.UpdAssemblyId2 = string.Empty;                              // �X�V�A�Z���u��ID2            [������]
        //    stockDetailWork.LogicalDeleteCode = 0;                                      // �_���폜�敪                 [������]
        //    stockDetailWork.AcceptAnOrderNo = 0;                                        // �󒍔ԍ�                     [������]
        //    stockDetailWork.SupplierFormal = 0;                                         // �d���`��                     [0�F�d��]
        //    stockDetailWork.SupplierSlipNo = 0;                                         // �d���`�[�ԍ�                 [������]
        //    stockDetailWork.CommonSeqNo = 0;                                            // ���ʒʔ�                     [������]
        //    stockDetailWork.StockSlipDtlNum = 0;                                        // �d�����גʔ�                 [������]
        //    //stockDetailWork.SupplierFormalSrc = stockDetailWork.SupplierFormal;         // �d���`��(��)                 [�v�㌳�̎d���`��]
        //    //stockDetailWork.StockSlipDtlNumSrc = stockDetailWork.StockSlipDtlNum;       // �d�����גʔ�(��)             [�v�㌳�̖��גʔ�]
        //    stockDetailWork.ListPriceTaxExcFl = uoeOrderDtlWork.AnswerListPrice;        // �艿(�Ŕ��C����)             [UOE�����f�[�^�̉񓚒艿]
        //    stockDetailWork.RateSectStckUnPrc = string.Empty;                           // �|���ݒ苒�_(�d���P��)       [���ݒ�]
        //    stockDetailWork.RateDivStckUnPrc = string.Empty;                            // �|���ݒ�敪(�d���P��)       [���ݒ�]
        //    stockDetailWork.UnPrcCalcCdStckUnPrc = 0;                                   // �P���Z�o�敪(�d���P��)       [���ݒ�]
        //    stockDetailWork.PriceCdStckUnPrc = 0;                                       // ���i�敪(�d���P��)           [���ݒ�]
        //    stockDetailWork.StdUnPrcStckUnPrc = 0;                                      // ��P��(�d���P��)           [���ݒ�]
        //    stockDetailWork.FracProcUnitStcUnPrc = 0;                                   // �[�������P��(�d���P��)       [���ݒ�]
        //    stockDetailWork.FracProcStckUnPrc = 0;                                      // �[������(�d���P��)           [���ݒ�]
        //    stockDetailWork.StockUnitPriceFl = mainRow.InputAnswerSalesUnitCost;        // �d���P��(�Ŕ��C����)         [��ʂ̓��͒l(���P��)]
        //    stockDetailWork.RateBLGoodsCode = 0;                                        // BL���i�R�[�h(�|��)		    [���ݒ�]
        //    stockDetailWork.RateBLGoodsName = string.Empty;                             // BL���i�R�[�h����(�|��)		[���ݒ�]
        //    stockDetailWork.RateGoodsRateGrpCd = 0;                                     // ���i�|���O���[�v�R�[�h(�|��)	[���ݒ�]
        //    stockDetailWork.RateGoodsRateGrpNm = string.Empty;                          // ���i�|���O���[�v����(�|��)	[���ݒ�]
        //    stockDetailWork.RateBLGroupCode = 0;                                        // BL�O���[�v�R�[�h(�|��)		[���ݒ�]
        //    stockDetailWork.RateBLGroupName = string.Empty;                             // BL�O���[�v����(�|��)		    [���ݒ�]
        //    stockDetailWork.StockCount = mainRow.InputEnterCnt;                         // �d����		                [��ʂ̓��͒l(����)]
        //    //stockDetailWork.OrderCnt = 0;                                               // ��������		                [���ݒ�]        //DEL 2009/02/04
        //    // ---ADD 2009/02/04 ��֕i�ȊO�̎��̂ݔ������ʂ�[���ݒ�]�Ƃ��� --------------------------------------------------->>>>>
        //    if (string.IsNullOrEmpty(uoeOrderDtlWork.SubstPartsNo.TrimEnd()) == true)
        //    {
        //        stockDetailWork.OrderCnt = 0;                                           // ��������		                [���ݒ�]
        //    }
        //    // ---ADD 2009/02/04 ----------------------------------------------------------------------------------------------<<<<<
        //    stockDetailWork.OrderAdjustCnt = 0;                                         // ����������		            [���ݒ�]
        //    stockDetailWork.OrderRemainCnt = 0;                                         // �����c��		                [���ݒ�]
        //    stockDetailWork.StockCountDifference = 0;                                   // �d��������                   [���ݒ�]

        //    // �艿(�ō��C����)
        //    stockDetailWork.ListPriceTaxIncFl = this._uoeOrderDtlAcs.GetStockPriceTaxInc(stockDetailWork.ListPriceTaxExcFl, stockDetailWork.TaxationCode, stockCnsTaxFrcProcCd);

        //    // �d���P��(�ō��C����)
        //    stockDetailWork.StockUnitTaxPriceFl = this._uoeOrderDtlAcs.GetStockPriceTaxInc(stockDetailWork.StockUnitPriceFl, stockDetailWork.TaxationCode, stockCnsTaxFrcProcCd);

        //    // �d���P���ύX�敪
        //    if (stockDetailWork.StockUnitPriceFl == stockDetailWork.BfStockUnitPriceFl)
        //    {
        //        stockDetailWork.StockUnitChngDiv = 0;       // �ύX�Ȃ�
        //    }
        //    else
        //    {
        //        stockDetailWork.StockUnitChngDiv = 1;       // �ύX����
        //    }

        //    // �d�����z(�Ŕ����A�ō���)
        //    long stockPriceTaxInc = 0;
        //    long stockPriceTaxExc = 0;
        //    long stockPriceConsTax = 0;

        //    bool bStatus = this._uoeOrderDtlAcs.CalculationStockPrice(
        //        stockDetailWork.StockCount,
        //        stockDetailWork.StockUnitPriceFl,
        //        stockDetailWork.TaxationCode,
        //        stockMoneyFrcProcCd,
        //        stockCnsTaxFrcProcCd,
        //        out stockPriceTaxInc,
        //        out stockPriceTaxExc,
        //        out stockPriceConsTax);

        //    if (bStatus == true)
        //    {
        //        stockDetailWork.StockPriceTaxExc = stockPriceTaxExc;    //�d�����z�i�Ŕ����j
        //        stockDetailWork.StockPriceTaxInc = stockPriceTaxInc;    //�d�����z�i�ō��݁j
        //    }
        //    else
        //    {
        //        stockDetailWork.StockPriceTaxExc = 0;                   //�d�����z�i�Ŕ����j
        //        stockDetailWork.StockPriceTaxInc = 0;                   //�d�����z�i�ō��݁j
        //    }

        //    // �d�����z����Ŋz(�d�����z�ō���-�d�����z�Ŕ���)
        //    stockDetailWork.StockPriceConsTax = stockDetailWork.StockPriceTaxInc - stockDetailWork.StockPriceTaxExc;

        //    // --- ADD 2009/01/16 �s��Ή�[10145] --------------------------------------------------------->>>>>
        //    // �����i�̗p���A��֕i���̗p���Ȃ�
        //    if (this._stockBlnktPrtNoDiv != 0)
        //    {
        //        return stockDetailWork;
        //    }
        //    // --- ADD 2009/01/16 �s��Ή�[10145] ---------------------------------------------------------<<<<<

        //    // ��֕i����̏ꍇ�A�Đݒ�
        //    if (string.IsNullOrEmpty(uoeOrderDtlWork.SubstPartsNo.TrimEnd()) == false)
        //    {
        //        // ���i�}�X�^�ǂݍ���
        //        List<GoodsUnitData> goodsUnitDataList = this.GetGoodsUnitDataList(stockDetailWork.GoodsMakerCd, uoeOrderDtlWork.SubstPartsNo);
        //        if (goodsUnitDataList != null)              //ADD 2009/01/19 �s��Ή�[10178]
        //        {                                           //ADD 2009/01/19 �s��Ή�[10178]
        //            GoodsUnitData goodsUnitData = goodsUnitDataList[0];

        //            stockDetailWork.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                  // ���i���[�J�[�R�[�h
        //            stockDetailWork.MakerName = goodsUnitData.MakerName;                        // ���[�J�[����
        //            stockDetailWork.MakerKanaName = goodsUnitData.MakerKanaName;                // ���[�J�[�J�i����
        //            stockDetailWork.CmpltMakerKanaName = string.Empty;                          // ���[�J�[�J�i���́i�ꎮ�j
        //            stockDetailWork.GoodsNo = goodsUnitData.GoodsNo;                            // ���i�ԍ�
        //            stockDetailWork.GoodsName = goodsUnitData.GoodsName;                        // ���i����
        //            stockDetailWork.GoodsNameKana = goodsUnitData.GoodsNameKana;                // ���i���̃J�i
        //            stockDetailWork.GoodsLGroup = goodsUnitData.GoodsLGroup;                    // ���i�啪�ރR�[�h
        //            stockDetailWork.GoodsLGroupName = goodsUnitData.GoodsLGroupName;            // ���i�啪�ޖ���
        //            stockDetailWork.GoodsMGroup = goodsUnitData.GoodsMGroup;                    // ���i�����ރR�[�h
        //            stockDetailWork.GoodsMGroupName = goodsUnitData.GoodsMGroupName;            // ���i�����ޖ���
        //            stockDetailWork.BLGroupCode = goodsUnitData.BLGroupCode;                    // BL�O���[�v�R�[�h
        //            stockDetailWork.BLGroupName = goodsUnitData.BLGroupName;                    // BL�O���[�v�R�[�h����
        //            stockDetailWork.BLGoodsCode = goodsUnitData.BLGoodsCode;                    // BL���i�R�[�h
        //            stockDetailWork.BLGoodsFullName = goodsUnitData.BLGoodsFullName;            // BL���i�R�[�h���́i�S�p�j
        //            stockDetailWork.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;    // ���Е��ރR�[�h
        //            stockDetailWork.EnterpriseGanreName = goodsUnitData.EnterpriseGanreName;    // ���Е��ޖ���
        //        }                                           //ADD 2009/01/19 �s��Ή�[10178]
        //    }

        //    return stockDetailWork;
        //}
        #endregion
        // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] --------------------------------------->>>>>
        #region ��GetStockDetailWorkNoUpdate(�X�V��d�����׃f�[�^�擾)
        /// <summary>
        /// �X�V�O�d�����׃f�[�^�擾
        /// </summary>
        /// <param name="stockSlipDtlNumSrc">�d�����גʔ�</param>
        /// <returns>�X�V�O�d�����׃f�[�^</returns>
        /// <remarks>
        /// <br>Note       : �d�����גʔԂ�����HashTable����X�V�O�̎d�����׃f�[�^���擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/02/17</br>
        /// </remarks>
        private StockDetailWork GetStockDetailWorkNoUpdate(long stockSlipDtlNumSrc)
        {
            if (this._stockDetailWorkHTable.ContainsKey(stockSlipDtlNumSrc.ToString()) == false)
            {
                return null;
            }

            return ((StockDetailWork)this._stockDetailWorkHTable[stockSlipDtlNumSrc.ToString()]).Clone();
        }
        #endregion

        #region ��GetStockDetailWorkUpdate(�v��f�[�^�p���쐬)
        /// <summary>
        /// �v��f�[�^�p���쐬
        /// </summary>
        /// <param name="mainRow">�O���b�h���C��(�X�V���)�f�[�^</param>
        /// <returns>�X�V��d�����׃f�[�^</returns>
        /// <remarks>
        /// <br>Note       : �X�V�O�d�����׃f�[�^���x�[�X�Ɋe���ڂ��X�V���ĕԂ��܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>UpdateNote : 2013/05/16 �����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2013/06/18�z�M��</br>
        /// <br>              Redmine#35459 #42�̑Ή�</br>
        /// </remarks>
        private StockDetailWork GetStockDetailWorkUpdate(GridMainDataSet.GridMainTableRow mainRow)
        {
            // �d�����׃f�[�^�擾
            StockDetailWork stockDetailWork = this.GetStockDetailWorkNoUpdate(mainRow.StockSlipDtlNumSrc);
            if (stockDetailWork == null)
            {
                return null;
            }

            // UOE�����f�[�^�擾
            //UOEOrderDtlWork uoeOrderDtlWork = this.GetUOEOrderDtlWork(mainRow.StockSlipDtlNumSrc);  //  DEL ����� 2013/05/16 Redmine#35459
            UOEOrderDtlWork uoeOrderDtlWork = this.GetUOEOrderDtlWork(mainRow.StockSlipDtlNumSrc, mainRow.SlipNo);  //  ADD ����� 2013/05/16 Redmine#35459

            if (this._supplierHTable.ContainsKey(stockDetailWork.SupplierCd) == false)
            {
                // �d���悪����
                return null;
            }
            // �d������Œ[�������R�[�h
            int stockCnsTaxFrcProcCd = ((Supplier)this._supplierHTable[stockDetailWork.SupplierCd]).StockCnsTaxFrcProcCd;
            // �d�����z�[�������R�[�h
            int stockMoneyFrcProcCd = ((Supplier)this._supplierHTable[stockDetailWork.SupplierCd]).StockMoneyFrcProcCd;

            stockDetailWork.SupplierFormalSrc = stockDetailWork.SupplierFormal;         // �d���`��(��)                 [�v�㌳�̎d���`��]
            stockDetailWork.StockSlipDtlNumSrc = stockDetailWork.StockSlipDtlNum;       // �d�����גʔ�(��)             [�v�㌳�̖��גʔ�]

            stockDetailWork.CreateDateTime = DateTime.MinValue;                         // �쐬����                     [������]
            stockDetailWork.UpdateDateTime = DateTime.MinValue;                         // �X�V����                     [������]
            stockDetailWork.EnterpriseCode = this._enterpriseCode;                      // ��ƃR�[�h
            stockDetailWork.FileHeaderGuid = Guid.Empty;                                // GUID                         [������]
            stockDetailWork.UpdEmployeeCode = string.Empty;                             // �X�V�]�ƈ��R�[�h             [������]
            stockDetailWork.UpdAssemblyId1 = string.Empty;                              // �X�V�A�Z���u��ID1            [������]
            stockDetailWork.UpdAssemblyId2 = string.Empty;                              // �X�V�A�Z���u��ID2            [������]
            stockDetailWork.LogicalDeleteCode = 0;                                      // �_���폜�敪                 [������]
            stockDetailWork.AcceptAnOrderNo = 0;                                        // �󒍔ԍ�                     [������]
            stockDetailWork.SupplierFormal = 0;                                         // �d���`��                     [0�F�d��]
            stockDetailWork.SupplierSlipNo = 0;                                         // �d���`�[�ԍ�                 [������]
            stockDetailWork.CommonSeqNo = 0;                                            // ���ʒʔ�                     [������]
            stockDetailWork.StockSlipDtlNum = 0;                                        // �d�����גʔ�                 [������]
            stockDetailWork.ListPriceTaxExcFl = uoeOrderDtlWork.AnswerListPrice;        // �艿(�Ŕ��C����)             [UOE�����f�[�^�̉񓚒艿]
            stockDetailWork.RateSectStckUnPrc = string.Empty;                           // �|���ݒ苒�_(�d���P��)       [���ݒ�]
            stockDetailWork.RateDivStckUnPrc = string.Empty;                            // �|���ݒ�敪(�d���P��)       [���ݒ�]
            stockDetailWork.UnPrcCalcCdStckUnPrc = 0;                                   // �P���Z�o�敪(�d���P��)       [���ݒ�]
            stockDetailWork.PriceCdStckUnPrc = 0;                                       // ���i�敪(�d���P��)           [���ݒ�]
            stockDetailWork.StdUnPrcStckUnPrc = 0;                                      // ��P��(�d���P��)           [���ݒ�]
            stockDetailWork.FracProcUnitStcUnPrc = 0;                                   // �[�������P��(�d���P��)       [���ݒ�]
            stockDetailWork.FracProcStckUnPrc = 0;                                      // �[������(�d���P��)           [���ݒ�]
            stockDetailWork.StockUnitPriceFl = mainRow.InputAnswerSalesUnitCost;        // �d���P��(�Ŕ��C����)         [��ʂ̓��͒l(���P��)]
            stockDetailWork.RateBLGoodsCode = 0;                                        // BL���i�R�[�h(�|��)		    [���ݒ�]
            stockDetailWork.RateBLGoodsName = string.Empty;                             // BL���i�R�[�h����(�|��)		[���ݒ�]
            stockDetailWork.RateGoodsRateGrpCd = 0;                                     // ���i�|���O���[�v�R�[�h(�|��)	[���ݒ�]
            stockDetailWork.RateGoodsRateGrpNm = string.Empty;                          // ���i�|���O���[�v����(�|��)	[���ݒ�]
            stockDetailWork.RateBLGroupCode = 0;                                        // BL�O���[�v�R�[�h(�|��)		[���ݒ�]
            stockDetailWork.RateBLGroupName = string.Empty;                             // BL�O���[�v����(�|��)		    [���ݒ�]
            stockDetailWork.StockCount = mainRow.InputEnterCnt;                         // �d����		                [��ʂ̓��͒l(����)]
            /* �������ʂ͂��̂܂܂̒l 2009/02/17 DEL �s��Ή�[10140][10177][10529] ------------------------------------------------->>>>>
            //stockDetailWork.OrderCnt = 0;                                               // ��������		                [���ݒ�]        //DEL 2009/02/04
            //// ---ADD 2009/02/04 ��֕i�ȊO�̎��̂ݔ������ʂ�[���ݒ�]�Ƃ��� --------------------------------------------------->>>>>
            //if (string.IsNullOrEmpty(uoeOrderDtlWork.SubstPartsNo.TrimEnd()) == true)
            //{
            //    stockDetailWork.OrderCnt = 0;                                           // ��������		                [���ݒ�]
            //}
            //// ---ADD 2009/02/04 ----------------------------------------------------------------------------------------------<<<<<
               �������ʂ͂��̂܂܂̒l 2009/02/17 DEL �s��Ή�[10140][10177][10529] -------------------------------------------------<<<<< */

            stockDetailWork.OrderAdjustCnt = 0;                                         // ����������		            [���ݒ�]
            stockDetailWork.OrderRemainCnt = 0;                                         // �����c��		                [���ݒ�]
            stockDetailWork.StockCountDifference = 0;                                   // �d��������                   [���ݒ�]

            // �艿(�ō��C����)
            stockDetailWork.ListPriceTaxIncFl = this._uoeOrderDtlAcs.GetStockPriceTaxInc(stockDetailWork.ListPriceTaxExcFl, stockDetailWork.TaxationCode, stockCnsTaxFrcProcCd);

            // �d���P��(�ō��C����)
            stockDetailWork.StockUnitTaxPriceFl = this._uoeOrderDtlAcs.GetStockPriceTaxInc(stockDetailWork.StockUnitPriceFl, stockDetailWork.TaxationCode, stockCnsTaxFrcProcCd);

            // �d���P���ύX�敪
            if (stockDetailWork.StockUnitPriceFl == stockDetailWork.BfStockUnitPriceFl)
            {
                stockDetailWork.StockUnitChngDiv = 0;       // �ύX�Ȃ�
            }
            else
            {
                stockDetailWork.StockUnitChngDiv = 1;       // �ύX����
            }

            // �d�����z(�Ŕ����A�ō���)
            long stockPriceTaxInc = 0;
            long stockPriceTaxExc = 0;
            long stockPriceConsTax = 0;

            bool bStatus = this._uoeOrderDtlAcs.CalculationStockPrice(
                stockDetailWork.StockCount,
                stockDetailWork.StockUnitPriceFl,
                stockDetailWork.TaxationCode,
                stockMoneyFrcProcCd,
                stockCnsTaxFrcProcCd,
                out stockPriceTaxInc,
                out stockPriceTaxExc,
                out stockPriceConsTax);

            if (bStatus == true)
            {
                stockDetailWork.StockPriceTaxExc = stockPriceTaxExc;    //�d�����z�i�Ŕ����j
                stockDetailWork.StockPriceTaxInc = stockPriceTaxInc;    //�d�����z�i�ō��݁j
            }
            else
            {
                stockDetailWork.StockPriceTaxExc = 0;                   //�d�����z�i�Ŕ����j
                stockDetailWork.StockPriceTaxInc = 0;                   //�d�����z�i�ō��݁j
            }

            // �d�����z����Ŋz(�d�����z�ō���-�d�����z�Ŕ���)
            stockDetailWork.StockPriceConsTax = stockDetailWork.StockPriceTaxInc - stockDetailWork.StockPriceTaxExc;

            // --- ADD 2009/01/16 �s��Ή�[10145] --------------------------------------------------------->>>>>
            // �����i�̗p���A��֕i���̗p���Ȃ�
            if (this._stockBlnktPrtNoDiv != 0)
            {
                return stockDetailWork;
            }
            // --- ADD 2009/01/16 �s��Ή�[10145] ---------------------------------------------------------<<<<<

            // ��֕i����̏ꍇ�A�Đݒ�
            if (string.IsNullOrEmpty(uoeOrderDtlWork.SubstPartsNo.TrimEnd()) == false)
            {
                // ���i�}�X�^�ǂݍ���
                List<GoodsUnitData> goodsUnitDataList = this.GetGoodsUnitDataList(stockDetailWork.GoodsMakerCd, uoeOrderDtlWork.SubstPartsNo);
                if (goodsUnitDataList != null)              //ADD 2009/01/19 �s��Ή�[10178]
                {                                           //ADD 2009/01/19 �s��Ή�[10178]
                    GoodsUnitData goodsUnitData = goodsUnitDataList[0];

                    stockDetailWork.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                  // ���i���[�J�[�R�[�h
                    stockDetailWork.MakerName = goodsUnitData.MakerName;                        // ���[�J�[����
                    stockDetailWork.MakerKanaName = goodsUnitData.MakerKanaName;                // ���[�J�[�J�i����
                    stockDetailWork.CmpltMakerKanaName = string.Empty;                          // ���[�J�[�J�i���́i�ꎮ�j
                    stockDetailWork.GoodsNo = goodsUnitData.GoodsNo;                            // ���i�ԍ�
                    stockDetailWork.GoodsName = goodsUnitData.GoodsName;                        // ���i����
                    stockDetailWork.GoodsNameKana = goodsUnitData.GoodsNameKana;                // ���i���̃J�i
                    stockDetailWork.GoodsLGroup = goodsUnitData.GoodsLGroup;                    // ���i�啪�ރR�[�h
                    stockDetailWork.GoodsLGroupName = goodsUnitData.GoodsLGroupName;            // ���i�啪�ޖ���
                    stockDetailWork.GoodsMGroup = goodsUnitData.GoodsMGroup;                    // ���i�����ރR�[�h
                    stockDetailWork.GoodsMGroupName = goodsUnitData.GoodsMGroupName;            // ���i�����ޖ���
                    stockDetailWork.BLGroupCode = goodsUnitData.BLGroupCode;                    // BL�O���[�v�R�[�h
                    stockDetailWork.BLGroupName = goodsUnitData.BLGroupName;                    // BL�O���[�v�R�[�h����
                    stockDetailWork.BLGoodsCode = goodsUnitData.BLGoodsCode;                    // BL���i�R�[�h
                    stockDetailWork.BLGoodsFullName = goodsUnitData.BLGoodsFullName;            // BL���i�R�[�h���́i�S�p�j
                    stockDetailWork.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;    // ���Е��ރR�[�h
                    stockDetailWork.EnterpriseGanreName = goodsUnitData.EnterpriseGanreName;    // ���Е��ޖ���
                }                                           //ADD 2009/01/19 �s��Ή�[10178]
            }

            return stockDetailWork;
        }
        #endregion
        // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] ---------------------------------------<<<<<

        #region ��CreateSlipDetailAddInfoWork(�X�V�p�d�����וt���f�[�^�쐬)
        /// <summary>
        /// �X�V�p�d�����וt���f�[�^�쐬
        /// </summary>
        /// <param name="mainRow">�O���b�h���C��(�X�V���)�f�[�^</param>
        /// <param name="splitFlg">���[�L��(True�F����AFalse�F�Ȃ�)</param>
        /// <returns>�X�V�p�d�����וt���f�[�^</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h���C��(�X�V���)�f�[�^�����ɍX�V�p�d�����וt���f�[�^���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        //private SlipDetailAddInfoWork CreateSlipDetailAddInfoWork(GridMainDataSet.GridMainTableRow mainRow)           //DEL 2009/02/17 �s��Ή�[10140][10177][10529]
        private SlipDetailAddInfoWork CreateSlipDetailAddInfoWork(GridMainDataSet.GridMainTableRow mainRow,bool splitFlg)
        {
            SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();

            slipDetailAddInfoWork.GoodsEntryDiv = 0;                                    // ���i�o�^�敪                 [0�F�Ȃ�]
            slipDetailAddInfoWork.GoodsOfferDate = DateTime.MinValue;                   // ���i�񋟓��t
            slipDetailAddInfoWork.PriceUpdateDiv = 0;                                   // ���i�X�V�敪                 [0�F�Ȃ�]
            slipDetailAddInfoWork.PriceStartDate = DateTime.MinValue;                   // ���i�J�n���t
            slipDetailAddInfoWork.PriceOfferDate = DateTime.MinValue;                   // ���i�񋟓��t
            slipDetailAddInfoWork.CarRelationGuid = Guid.Empty;                         // �ԗ��֘A�t��GUID

            //�v��c�敪
            /* ---DEL 2009/02/17 �s��Ή�[10140][10177][10529] ------------------------------->>>>>
            if (mainRow.DivCd == PMUOE01202EA.DIVCD_DELETE)
            {
                // ��������
                slipDetailAddInfoWork.AddUpRemDiv = 2;      // 2�F�c���Ȃ�
            }
            else
            {
                // ���̑�
                slipDetailAddInfoWork.AddUpRemDiv = 1;      // 1�F�c��
            }
               ---DEL 2009/02/17 �s��Ή�[10140][10177][10529] -------------------------------<<<<< */
            // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] ------------------------------->>>>>
            if (splitFlg)
            {
                // ���[���莞
                slipDetailAddInfoWork.AddUpRemDiv = 1;                                                      // 1�F�c��
                slipDetailAddInfoWork.OrderRemainAdjustCnt = mainRow.EnterCnt - mainRow.InputEnterCnt;      // ����(�C�����̔����c�����p)
            }
            else
            {
                // ���[�Ȃ���
                slipDetailAddInfoWork.AddUpRemDiv = 2;                                                      // 2�F�c���Ȃ�
                slipDetailAddInfoWork.OrderRemainAdjustCnt = 0;                                             // ����(�C�����̔����c�����p)
            }
            // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] -------------------------------<<<<<

            return slipDetailAddInfoWork;
        }
        #endregion

        // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] --------------------------------------->>>>>
        #region CreateGridMainWorkTable(�X�V�σf�[�^���܂ރO���b�h���C���f�[�^�쐬)
        /// <summary>
        /// �X�V�σf�[�^���܂ރO���b�h���C���f�[�^�쐬
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �X�V�σf�[�^���܂ރO���b�h���C���f�[�^���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br></br>
        /// <br>Update Note: 2012/02/08 �����x</br>
        /// <br>#Redmine28282 �݌ɓ��ɍX�V�̃G���[���C������</br>
        /// </remarks>
        private GridMainDataSet.GridMainWorkTableDataTable CreateGridMainWorkTable()
        {
            GridMainDataSet.GridMainWorkTableDataTable gridMainTable = new GridMainDataSet.GridMainWorkTableDataTable();
            GridMainDataSet.GridMainWorkTableRow gridMainRow = null;
            UOEOrderDtlWork uoeOrderDtlWork = null;

            foreach (string key in this._uoeOrderDtlWorkHTable.Keys)
            {
                uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[key];

                // ���_
                //if (uoeOrderDtlWork.UOESectOutGoodsCnt > 0) //DEL BY �����x on 2012/02/08 for Redmine#28282
                if (uoeOrderDtlWork.UOESectOutGoodsCnt != 0) // ADD BY�@�����x on 2012/02/08 for Redmine#28282
                {
                    gridMainRow = this.CreateGridMainWorkDataRow(gridMainTable, uoeOrderDtlWork);       //����
                    gridMainRow.ColumnDiv = PMUOE01203AA.COLUMNDIV_SECTION;                              // ��敪
                    gridMainRow.SlipNo = uoeOrderDtlWork.UOESectionSlipNo;                  // �`�[�ԍ�
                    gridMainRow.UOESectOutGoodsCnt = uoeOrderDtlWork.UOESectOutGoodsCnt;    // UOE���_�o�ɐ�
                    gridMainRow.BOShipmentCnt = 0;                                          // BO�o�ɐ�
                    gridMainRow.EnterCnt = uoeOrderDtlWork.UOESectOutGoodsCnt;              // ���ɐ�
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.UOESectOutGoodsCnt;         // ���ɐ�(���͗p)

                    gridMainTable.AddGridMainWorkTableRow(gridMainRow);
                }
                // BO1
                if (uoeOrderDtlWork.BOShipmentCnt1 > 0)
                {
                    gridMainRow = this.CreateGridMainWorkDataRow(gridMainTable, uoeOrderDtlWork);       //����
                    gridMainRow.ColumnDiv = PMUOE01203AA.COLUMNDIV_BO1;                                  // ��敪
                    gridMainRow.SlipNo = uoeOrderDtlWork.BOSlipNo1;                         // �`�[�ԍ�
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE���_�o�ɐ�
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.BOShipmentCnt1;             // BO�o�ɐ�
                    gridMainRow.EnterCnt = uoeOrderDtlWork.BOShipmentCnt1;                  // ���ɐ�
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.BOShipmentCnt1;             // ���ɐ�(���͗p)
                    gridMainTable.AddGridMainWorkTableRow(gridMainRow);
                }
                // BO2
                if (uoeOrderDtlWork.BOShipmentCnt2 > 0)
                {
                    gridMainRow = this.CreateGridMainWorkDataRow(gridMainTable, uoeOrderDtlWork);       //����
                    gridMainRow.ColumnDiv = PMUOE01203AA.COLUMNDIV_BO2;                                  // ��敪
                    gridMainRow.SlipNo = uoeOrderDtlWork.BOSlipNo2;                         // �`�[�ԍ�
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE���_�o�ɐ�
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.BOShipmentCnt2;             // BO�o�ɐ�
                    gridMainRow.EnterCnt = uoeOrderDtlWork.BOShipmentCnt2;                  // ���ɐ�
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.BOShipmentCnt2;             // ���ɐ�(���͗p)
                    gridMainTable.AddGridMainWorkTableRow(gridMainRow);
                }
                // BO3
                if (uoeOrderDtlWork.BOShipmentCnt3 > 0)
                {
                    gridMainRow = this.CreateGridMainWorkDataRow(gridMainTable, uoeOrderDtlWork);       //����
                    gridMainRow.ColumnDiv = PMUOE01203AA.COLUMNDIV_BO3;                                  // ��敪
                    gridMainRow.SlipNo = uoeOrderDtlWork.BOSlipNo3;                         // �`�[�ԍ�
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE���_�o�ɐ�
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.BOShipmentCnt3;             // BO�o�ɐ�
                    gridMainRow.EnterCnt = uoeOrderDtlWork.BOShipmentCnt3;                  // ���ɐ�
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.BOShipmentCnt3;             // ���ɐ�(���͗p)
                    gridMainTable.AddGridMainWorkTableRow(gridMainRow);
                }
                // MF
                if (uoeOrderDtlWork.MakerFollowCnt > 0)
                {
                    gridMainRow = this.CreateGridMainWorkDataRow(gridMainTable, uoeOrderDtlWork);       //����
                    gridMainRow.ColumnDiv = PMUOE01203AA.COLUMNDIV_MAKER;                                // ��敪
                    gridMainRow.SlipNo = "";                                                // �`�[�ԍ�(�X�y�[�X)
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE���_�o�ɐ�
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.MakerFollowCnt;             // BO�o�ɐ�
                    gridMainRow.EnterCnt = uoeOrderDtlWork.MakerFollowCnt;                  // ���ɐ�
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.MakerFollowCnt;             // ���ɐ�(���͗p)
                    gridMainTable.AddGridMainWorkTableRow(gridMainRow);
                }
                // EO
                if (uoeOrderDtlWork.EOAlwcCount > 0)
                {
                    gridMainRow = this.CreateGridMainWorkDataRow(gridMainTable, uoeOrderDtlWork);       //����
                    gridMainRow.ColumnDiv = PMUOE01203AA.COLUMNDIV_EO;                                   // ��敪
                    gridMainRow.SlipNo = "";                                                // �`�[�ԍ�(�X�y�[�X)
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE���_�o�ɐ�
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.EOAlwcCount;                // BO�o�ɐ�
                    gridMainRow.EnterCnt = uoeOrderDtlWork.EOAlwcCount;                     // ���ɐ�
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.EOAlwcCount;                // ���ɐ�(���͗p)
                    gridMainTable.AddGridMainWorkTableRow(gridMainRow);
                }
            }

            return gridMainTable;
        }
        #endregion

        #region CreateGridMainWorkDataRow(�X�V�σf�[�^���܂ރO���b�h���C���f�[�^�̍s�쐬)
        /// <summary>
        /// �X�V�σf�[�^���܂ރO���b�h���C���f�[�^�̍s�쐬
        /// </summary>
        /// <param name="gridMainWorkTable">�O���b�h���C���i�X�V�σf�[�^���܂ށj</param>
        /// <param name="uoeOrderDtlWork">UOE�����f�[�^</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �X�V�σf�[�^���܂ރO���b�h���C���f�[�^�̍s���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/02/17</br>
        /// </remarks>
        private GridMainDataSet.GridMainWorkTableRow CreateGridMainWorkDataRow(GridMainDataSet.GridMainWorkTableDataTable gridMainWorkTable
                                                                         , UOEOrderDtlWork uoeOrderDtlWork)
        {
            GridMainDataSet.GridMainWorkTableRow gridMainRow = gridMainWorkTable.NewGridMainWorkTableRow();

            gridMainRow.DivCd = PMUOE01202EA.DIVCD_NOCHANGE;                            // �敪(" "�F�������A"1"�F���ׁA"2"�F�����ׁA"3"�F�C���A"9"�F������)
            gridMainRow.GoodsMakerCd = uoeOrderDtlWork.GoodsMakerCd;                 // ���[�J�[�R�[�h
            gridMainRow.GoodsNo = uoeOrderDtlWork.GoodsNo;                           // �i��
            gridMainRow.GoodsName = uoeOrderDtlWork.GoodsName;                       // �i��
            gridMainRow.UOESalesOrderNo = uoeOrderDtlWork.UOESalesOrderNo;           // UOE�����ԍ�
            gridMainRow.UOESalesOrderRowNo = uoeOrderDtlWork.UOESalesOrderRowNo;     // UOE�����s�ԍ�
            gridMainRow.OnlineNo = uoeOrderDtlWork.OnlineNo;                         // �I�����C���ԍ�
            gridMainRow.OnlineRowNo = uoeOrderDtlWork.OnlineRowNo;                   // �I�����C���s�ԍ�
            gridMainRow.WarehouseCode = uoeOrderDtlWork.WarehouseCode;               // �q�ɃR�[�h
            gridMainRow.WarehouseShelfNo = uoeOrderDtlWork.WarehouseShelfNo;         // �I��
            gridMainRow.SalesUnitCost = uoeOrderDtlWork.SalesUnitCost;               // �����P��
            gridMainRow.AnswerSalesUnitCost = uoeOrderDtlWork.AnswerSalesUnitCost;   // �񓚌����P��
            gridMainRow.AnswerPartsNo = uoeOrderDtlWork.AnswerPartsNo;               // �񓚕i��
            gridMainRow.UOERemark1 = uoeOrderDtlWork.UoeRemark1;                     // ���}�[�N1
            gridMainRow.UOERemark2 = uoeOrderDtlWork.UoeRemark2;                     // ���}�[�N2
            gridMainRow.SupplierCd = uoeOrderDtlWork.SupplierCd;                     // �d����R�[�h
            gridMainRow.SubstPartsNo = uoeOrderDtlWork.SubstPartsNo;                 // ��֕i��
            gridMainRow.SupplierSlipNo = uoeOrderDtlWork.SupplierSlipNo;             // �d���`�[�ԍ�
            gridMainRow.StockSlipDtlNumSrc = uoeOrderDtlWork.StockSlipDtlNum;        // �d�����גʔ�
            gridMainRow.HeaderGridRowNo = 0;                                            // UOE���ɍX�V�w�b�_�[�O���b�h�p�s�ԍ�
            gridMainRow.DetailGridRowNo = 0;                                            // UOE���ɍX�V���׃O���b�h�p�s�ԍ�
            gridMainRow.InputAnswerSalesUnitCost = uoeOrderDtlWork.AnswerSalesUnitCost;   // �񓚌����P��
            gridMainRow.AnswerMakerCd = uoeOrderDtlWork.AnswerMakerCd;               // �񓚃��[�J�[�R�[�h
            gridMainRow.UOESupplierCd = uoeOrderDtlWork.UOESupplierCd;               // UOE������R�[�h          //ADD 2009/01/19 �s��Ή�[10063]

            return gridMainRow;
        }
        #endregion

        // �����E�v��f�[�^�쐬�֘A
        #region ��CreateOrderDtlArrayList(�����E�v��f�[�^�Q�쐬)
        /// <summary>
        /// �����E�v��f�[�^�Q�쐬
        /// </summary>
        /// <param name="uoeStcUpdDataList"></param>
        /// <remarks>
        /// <br>Note       : �O���b�h���C��(�X�V���)�f�[�^�A�d���f�[�^�A�d�����׃f�[�^�AUOE�����f�[�^�����ɔ����f�[�^</br>
        /// <br>             �y�ьv��f�[�^���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>UpdateNote : 2012/08/30 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 20120912�z�M��</br>
        /// <br>             redmine #31885:�g�c����@�݌ɓ��ɍX�V�����̑Ή�</br>
        /// <br>             ����̃I�����C���ԍ��ł����Ă��قȂ�d���`�[�ɐ�������Ă��܂��̏�Q�̑Ή�</br>
        /// <br>UpdateNote : 2013/05/16 �����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2013/06/18�z�M��</br>
        /// <br>              Redmine#35459 #42�̑Ή�</br>
        /// </remarks>
        private void CreateOrderDtlArrayList(ref CustomSerializeArrayList uoeStcUpdDataList)
        {
            // ----- ADD 2012/08/30 ���N�n��  redmine#31885----->>>>>
            int nextSupplierSlipNo = 0;
            int nowSupplierSlipNo = 0;
            // ----- ADD 2012/08/30 ���N�n��  redmine#31885-----<<<<<
            string columnDiv = string.Empty;
            int gridMainWorkRowCount = 0;
            int supplierSlipNo = 0;
            long stockSlipDtlNum = 0;
            int deleteCount = 0;                                            // ���ו��[�폜��
            double deleteStockCount = 0;
            double orderCount = 0;
            bool substPartsNoIsExists = false;                              // ��֗L��
            bool stockSlipIsUpdate = false;         //True�F�X�V����AFalse�F�X�V�Ȃ�
            int substPartsNoCount = 0;
            GridMainDataSet.GridMainTableRow gridMainRow = null;            // ��ʏ��
            GridMainDataSet.GridMainTableRow gridMainRowBackUp = null;      // ��ʏ��o�b�N�A�b�v
            GridMainDataSet.GridMainTableRow gridMainRowWork = null;
            Hashtable updateSlipNoHTable = new Hashtable();                       // �X�V�Ώۂ̓`�[�ԍ�
            StockSlipListInfo stockSlipListInfo = new StockSlipListInfo();  // �����E�v��f�[�^���ߍ��ݗp�N���X
            StockSlipListInfo stockSlipListInfoWork = new StockSlipListInfo();      //�v��f�[�^�ĕҐ��p���ߍ��݃N���X
            StockSlipWork stockSlipWork = null;                             // �d���f�[�^
            StockDetailWork stockDetailWork = null;                         // �d�����׃f�[�^
            SlipDetailAddInfoWork slipDetailAddInfoWork = null;             // �d�����ג����f�[�^
            IOWriteMASIRDeleteWork deleteWork = null;                       // �����`�[�폜���
            List<StockDetailWork> stockDetailWorkList = null;               // �v�㖾�׃��X�g
            List<StockDetailWork> stockDetailWorkBfList = null;             // �������׃��X�g
            List<IOWriteMASIRDeleteWork> deleteWorkList = new List<IOWriteMASIRDeleteWork>();       //�����`�[�폜���X�g

            HeaderNoAndGuidJoin.HeaderNoAndGuidJoinTableDataTable headerNoAndGuidJoinTable = null;      //�v�㖾�ׂƃw�b�_�[�R�t���e�[�u��
            HeaderNoAndGuidJoin.HeaderNoAndGuidJoinTableRow headerNoAndGuidJoinRow = null;
            HeaderNoAndGuidJoin.HeaderNoAndGuidJoinTableRow headerNoAndGuidJoinRowBf = null;
            int headerGridRowNo = 0;

            // UOE�����𕪔[�P�ʂɂ�������
            GridMainDataSet.GridMainWorkTableDataTable gridMainWorkTable = this.CreateGridMainWorkTable();
            GridMainDataSet.GridMainWorkTableRow gridMainWorkRow = null;

            // �d���Ǝd�����ׂ̕R�t�����擾
            StockSlipAndDetailJoin.JoinTableDataTable slipJoinTable = this.CreateSlipJoinTable();

            // ��ʂɕ\������Ă��āA�X�V�Ώۂ̓`�[�ԍ����擾
            #region ��ʂɕ\������Ă��āA�X�V�Ώۂ̓`�[�ԍ����擾
            DataRow[] dataRows = this.GetGridMainDataRows();
            for (int i = 0; i<= dataRows.Length - 1; i++)
            {
                supplierSlipNo = int.Parse(dataRows[i][this._gridMainDataTable.SupplierSlipNoColumn.ColumnName].ToString());

                if (updateSlipNoHTable.ContainsKey(supplierSlipNo) == true)
                {
                    continue;
                }

                updateSlipNoHTable.Add(supplierSlipNo, supplierSlipNo);
            }
            #endregion

            // ----- DEL 2012/08/30 ���N�n��  redmine#31885----->>>>>
            //�X�V�Ώۂ̓`�[�ԍ��P�ʂɏ������s��
            //foreach (int key in updateSlipNoHTable.Keys)
            //{
            // ----- DEL 2012/08/30 ���N�n��  redmine#31885-----<<<<<
                substPartsNoCount = 0;      //��֌���
                stockSlipIsUpdate = false;

                // ----- DEL 2012/08/30 ���N�n��  redmine#31885----->>>>>
                // 1�`�[�ɕR�t���d�����׎擾
                //supplierSlipNo = (int)updateSlipNoHTable[key];
                // ----- DEL 2012/08/30 ���N�n��  redmine#31885-----<<<<<

                // 1�`�[���̌v��w�b�_�[�E���וR�t�����// DEL 2012/08/30 ���N�n��  redmine#31885
                //�`�[���̌v��w�b�_�[�E���וR�t�����// ADD 2012/08/30 ���N�n��  redmine#31885
                headerNoAndGuidJoinTable = new HeaderNoAndGuidJoin.HeaderNoAndGuidJoinTableDataTable();
                //string slipJoinFilter = string.Format("({0}={1})", slipJoinTable.SupplierSlipNoColumn.ColumnName, supplierSlipNo);// DEL 2012/08/30 ���N�n��  redmine#31885
                // ----- ADD 2012/08/30 ���N�n��  redmine#31885----->>>>>
                string slipJoinFilter = string.Empty;
                foreach (int key in updateSlipNoHTable.Keys)
                {
                    supplierSlipNo = (int)updateSlipNoHTable[key];
                    if (string.IsNullOrEmpty(slipJoinFilter))
                    {
                        slipJoinFilter = string.Format("({0}={1})", _gridMainDataTable.SupplierSlipNoColumn.ColumnName, supplierSlipNo);
                    }
                    else
                    {
                        slipJoinFilter = slipJoinFilter + " OR " + string.Format("({0}={1})", _gridMainDataTable.SupplierSlipNoColumn.ColumnName, supplierSlipNo);
                    }
                }
                DataRow[] slipJoinRows = slipJoinTable.Select(slipJoinFilter, _gridMainDataTable.SupplierSlipNoColumn.ColumnName + " ASC");
                // ----- ADD 2012/08/30 ���N�n��  redmine#31885-----<<<<<
                //DataRow[] slipJoinRows = slipJoinTable.Select(slipJoinFilter);//DEL 2012/08/30 ���N�n��  redmine#31885
                for (int j = 0; j <= slipJoinRows.Length - 1; j++)
                {
                    //�����������d������1���ɑ΂��鏈������������

                    //���גʔԎ擾
                    stockSlipDtlNum = (long)slipJoinRows[j][slipJoinTable.StockSlipDtlNumSrcColumn.ColumnName];

                    //��֗L���擾
                    substPartsNoIsExists = this.CheckSubstPartsNoIsExists(stockSlipDtlNum);
                    if (substPartsNoIsExists)
                    {
                        stockSlipIsUpdate = true;
                        substPartsNoCount++;
                    }

                    // �d�����ׂɕR�t����ʂ̖��ׂ��擾(���[������ׁA2���ȏ�ƂȂ鎖������)
                    string gridMainWorkFilter = string.Format("({0}={1})", this._gridMainDataTable.StockSlipDtlNumSrcColumn.ColumnName, stockSlipDtlNum);
                    DataRow[] gridMainWorkRows = gridMainWorkTable.Select(gridMainWorkFilter);
                    gridMainWorkRowCount = gridMainWorkRows.Length;
                    // ��������
                    if (gridMainWorkRowCount == 0)
                    {
                        #region 1�d��0����
                        gridMainRow = null;

                        //�v�㖾�׃f�[�^�Ȃ�

                        //���גǉ����Ȃ�

                        //�������׃f�[�^�X�V�Ȃ�(��֕i�ł����Ă��\������Ă��Ȃ����͍̂X�V���Ȃ�)
                        stockSlipListInfo.StockDetailWorkBf = this.GetStockDetailWorkNoUpdate(stockSlipDtlNum);

                        //UOE�����f�[�^�X�V�Ȃ�
                        #endregion
                    }
                    // 1�d��1����
                    //else if (gridMainRowCount == 1)
                    else if (gridMainWorkRowCount == 1)
                    {
                        #region 1�d��1����
                        //gridMainRowCount = 1;
                        gridMainWorkRow = (GridMainDataSet.GridMainWorkTableRow)gridMainWorkRows[0];

                        // ------------DEL ����� 2013/05/16 FOR Redmine#35459--------->>>>
                        //���[���܂ޑS�Ẵf�[�^�̒������ʂɕ\������Ă�����̂������o
                        //string gridMainFilter = string.Format("({0}={1}) AND ({2}='{3}')",
                        //                            this._gridMainDataTable.StockSlipDtlNumSrcColumn.ColumnName, gridMainWorkRow.StockSlipDtlNumSrc,
                        //                            this._gridMainDataTable.ColumnDivColumn.ColumnName, gridMainWorkRow.ColumnDiv);
                        // ------------DEL ����� 2013/05/16 FOR Redmine#35459---------<<<<

                        // ------------ADD ����� 2013/05/16 FOR Redmine#35459--------->>>>
                        string gridMainFilter = string.Empty;
                        if (!this._meiJiDiv || string.Empty.Equals(gridMainWorkRow.SlipNo))
                        {
                            gridMainFilter = string.Format("({0}={1}) AND ({2}='{3}')",
                                                        this._gridMainDataTable.StockSlipDtlNumSrcColumn.ColumnName, gridMainWorkRow.StockSlipDtlNumSrc,
                                                        this._gridMainDataTable.ColumnDivColumn.ColumnName, gridMainWorkRow.ColumnDiv);
                        }
                        else
                        {
                            gridMainFilter = string.Format("({0}={1}) AND ({2}='{3}' AND {4}='{5}')",
                                                        this._gridMainDataTable.StockSlipDtlNumSrcColumn.ColumnName, gridMainWorkRow.StockSlipDtlNumSrc,
                                                        this._gridMainDataTable.ColumnDivColumn.ColumnName, gridMainWorkRow.ColumnDiv,
                                                        this._gridMainDataTable.SlipNoColumn, gridMainWorkRow.SlipNo);
                        }

                        // ------------ADD ����� 2013/05/16 FOR Redmine#35459---------<<<<
                        DataRow[] gridMainRows = this._gridMainDataTable.Select(gridMainFilter);
                        gridMainRow = (GridMainDataSet.GridMainTableRow)gridMainRows[0];

                        if (gridMainRow.DivCd == PMUOE01202EA.DIVCD_DELETE)
                        {
                            //�v�㖾�׃f�[�^�Ȃ�

                            //���גǉ����Ȃ�

                            //�������׃f�[�^�Ȃ�

                            //UOE�����f�[�^�X�V
                            //this.UpdateUOEOrderDtlWork(stockSlipDtlNum, gridMainRow.ColumnDiv, ENTERUPDDIV_ENTER, Guid.Empty, substPartsNoIsExists);                      // DEL ����� 2013/05/16 Redmine#35459
                            this.UpdateUOEOrderDtlWork(stockSlipDtlNum, gridMainRow.ColumnDiv, ENTERUPDDIV_ENTER, Guid.Empty, substPartsNoIsExists, gridMainRow.SlipNo);    // ADD ����� 2013/05/16 Redmine#35459

                            stockSlipIsUpdate = true;       // �X�V����
                        }
                        else if ((gridMainRow.DivCd == PMUOE01202EA.DIVCD_NOCHANGE) ||
                                 (gridMainRow.DivCd == PMUOE01202EA.DIVCD_NOTENTER))
                        {
                            //�v�㖾�׃f�[�^�Ȃ�

                            //���גǉ����Ȃ�

                            //�������׃f�[�^
                            stockSlipListInfo.StockDetailWorkBf = this.GetStockDetailWorkNoUpdate(stockSlipDtlNum);

                            //UOE�����f�[�^�X�V�Ȃ�
                        }
                        else
                        {
                            //GUID�̔�
                            stockSlipListInfo.DtlRelationGuid = Guid.NewGuid();

                            //�v�㖾�׃f�[�^
                            stockSlipListInfo.StockDetailWork = this.GetStockDetailWorkUpdate(gridMainRow);

                            // �v��w�b�_�[�E���וR�t�����
                            headerNoAndGuidJoinTable.AddHeaderNoAndGuidJoinTableRow(gridMainRow.HeaderGridRowNo
                                                                                    ,gridMainRow.DetailGridRowNo
                                                                                    ,stockSlipListInfo.DtlRelationGuid);

                            //���גǉ����
                            slipDetailAddInfoWork = this.CreateSlipDetailAddInfoWork(gridMainRow,false);
                            stockSlipListInfo.SlipDetailAddInfoWork = slipDetailAddInfoWork;

                            //�������׃f�[�^
                            stockDetailWork = this.GetStockDetailWorkNoUpdate(stockSlipDtlNum);

                            if (substPartsNoIsExists)
                            {
                                //��֕i���A�X�V����
                                this.SetSubstPartsInfo(ref stockDetailWork);
                            }
                            else
                            {
                                // �X�V�Ȃ�
                            }
                            stockSlipListInfo.StockDetailWorkBf = stockDetailWork;

                            //UOE�����f�[�^�X�V
                            //this.UpdateUOEOrderDtlWork(stockSlipDtlNum, gridMainRow.ColumnDiv, ENTERUPDDIV_ENTER, stockSlipListInfo.DtlRelationGuid, substPartsNoIsExists);                   // DEL ����� 2013/05/16 Redmine#35459
                            this.UpdateUOEOrderDtlWork(stockSlipDtlNum, gridMainRow.ColumnDiv, ENTERUPDDIV_ENTER, stockSlipListInfo.DtlRelationGuid, substPartsNoIsExists, gridMainRow.SlipNo); // ADD ����� 2013/05/16 Redmine#35459
                        }

                        // �����w�b�_�[�擾�p�ɕێ����Ă���
                        if (gridMainRow != null)
                        {
                            gridMainRowBackUp = gridMainRow;
                        }
                        #endregion
                    }
                    // 1�d��2���׈ȏ�
                    else
                    {
                        #region 1�d��2���׈ȏ�
                        deleteCount = 0;            //�폜���א�
                        deleteStockCount = 0;       //�폜�d����
                        for (int k = 0; k <= gridMainWorkRowCount - 1; k++)
                        {
                            gridMainWorkRow = (GridMainDataSet.GridMainWorkTableRow)gridMainWorkRows[k];

                            // ------------DEL ����� 2013/05/16 FOR Redmine#35459--------->>>>
                            //���[���܂ޑS�Ẵf�[�^�̒����獡��X�V�Ώۂ̂��̂𒊏o
                            //string gridMainFilter = string.Format("({0}={1}) AND ({2}='{3}')",
                            //                                this._gridMainDataTable.StockSlipDtlNumSrcColumn.ColumnName, gridMainWorkRow.StockSlipDtlNumSrc,
                            //                                this._gridMainDataTable.ColumnDivColumn.ColumnName, gridMainWorkRow.ColumnDiv);
                            // ------------DEL ����� 2013/05/16 FOR Redmine#35459---------<<<<
                            // ------------ADD ����� 2013/05/16 FOR Redmine#35459--------->>>>
                            string gridMainFilter = string.Empty;
                            if (!this._meiJiDiv || string.Empty.Equals(gridMainWorkRow.SlipNo))
                            {
                                gridMainFilter = string.Format("({0}={1}) AND ({2}='{3}')",
                                                                this._gridMainDataTable.StockSlipDtlNumSrcColumn.ColumnName, gridMainWorkRow.StockSlipDtlNumSrc,
                                                                this._gridMainDataTable.ColumnDivColumn.ColumnName, gridMainWorkRow.ColumnDiv);
                            }
                            else
                            {
                                gridMainFilter = string.Format("({0}={1}) AND ({2}='{3}' AND {4}='{5}')",
                                        this._gridMainDataTable.StockSlipDtlNumSrcColumn.ColumnName, gridMainWorkRow.StockSlipDtlNumSrc,
                                        this._gridMainDataTable.ColumnDivColumn.ColumnName, gridMainWorkRow.ColumnDiv,
                                        this._gridMainDataTable.SlipNoColumn, gridMainWorkRow.SlipNo);
                            }

                            // ------------ADD ����� 2013/05/16 FOR Redmine#35459---------<<<<
                            DataRow[] gridMainRows = this._gridMainDataTable.Select(gridMainFilter);
                            if (gridMainRows.Length == 0)
                            {
                                continue;
                            }

                            gridMainRow = (GridMainDataSet.GridMainTableRow)gridMainRows[0];


                            if (gridMainRow.DivCd == PMUOE01202EA.DIVCD_DELETE)
                            {
                                //�v�㖾�׃f�[�^�Ȃ�

                                //���גǉ����Ȃ�

                                deleteStockCount = deleteStockCount + gridMainRow.EnterCnt;     //�폜�d���������Z

                                deleteCount++;                                                  //�폜���J�E���g�A�b�v

                                //UOE�����f�[�^�X�V
                                //this.UpdateUOEOrderDtlWork(stockSlipDtlNum, gridMainRow.ColumnDiv, ENTERUPDDIV_ENTER, Guid.Empty, substPartsNoIsExists);                   // DEL ����� 2013/05/16 Redmine#35459
                                this.UpdateUOEOrderDtlWork(stockSlipDtlNum, gridMainRow.ColumnDiv, ENTERUPDDIV_ENTER, Guid.Empty, substPartsNoIsExists, gridMainRow.SlipNo); // ADD ����� 2013/05/16 Redmine#35459
                            }
                            else if ((gridMainRow.DivCd == PMUOE01202EA.DIVCD_NOCHANGE) ||
                                     (gridMainRow.DivCd == PMUOE01202EA.DIVCD_NOTENTER))
                            {
                                //�v�㖾�׃f�[�^�Ȃ�

                                //���גǉ����Ȃ�

                                //�폜�d�����̉��Z�Ȃ�

                                //�폜���J�E���g�A�b�v�Ȃ�

                                //UOE�����f�[�^�X�V�Ȃ�
                            }
                            else
                            {
                                //GUID�̔�
                                stockSlipListInfo.DtlRelationGuid = Guid.NewGuid();

                                //�v�㖾�׃f�[�^
                                stockSlipListInfo.StockDetailWork = this.GetStockDetailWorkUpdate(gridMainRow);

                                // �v��w�b�_�[�E���וR�t�����
                                headerNoAndGuidJoinTable.AddHeaderNoAndGuidJoinTableRow(gridMainRow.HeaderGridRowNo
                                                                                        ,gridMainRow.DetailGridRowNo
                                                                                        ,stockSlipListInfo.DtlRelationGuid);

                                //���גǉ����
                                stockSlipListInfo.SlipDetailAddInfoWork = this.CreateSlipDetailAddInfoWork(gridMainRow,true);

                                //UOE�����f�[�^�X�V
                                //this.UpdateUOEOrderDtlWork(stockSlipDtlNum, gridMainRow.ColumnDiv, ENTERUPDDIV_ENTER, stockSlipListInfo.DtlRelationGuid, substPartsNoIsExists);                   // DEL ����� 2013/05/16 Redmine#35459
                                this.UpdateUOEOrderDtlWork(stockSlipDtlNum, gridMainRow.ColumnDiv, ENTERUPDDIV_ENTER, stockSlipListInfo.DtlRelationGuid, substPartsNoIsExists, gridMainRow.SlipNo); // ADD ����� 2013/05/16 Redmine#35459
                            }

                            // �����w�b�_�[�擾�p�ɕێ����Ă���
                            if (gridMainRow != null)
                            {
                                // InputSlipNo������(��ʂɕ\������Ă��Ȃ�)���̂͑ΏۂƂ��Ȃ�
                                try
                                {
                                    if (gridMainRow.InputSlipNo != null)
                                    {
                                        gridMainRowBackUp = gridMainRow;
                                    }
                                }
                                catch (StrongTypingException)
                                {
                                }
                            }
                        }

                        //�������׃f�[�^
                        #region �������׃f�[�^�쐬
                        if (deleteCount == 0)
                        {
                            //����Ȃ�

                            stockDetailWork = this.GetStockDetailWorkNoUpdate(stockSlipDtlNum);
                            if (substPartsNoIsExists)
                            {
                                // ��֗p���ڍX�V
                                this.SetSubstPartsInfo(ref stockDetailWork);
                            }
                            else
                            {
                                // �X�V�Ȃ�
                            }
                            stockSlipListInfo.StockDetailWorkBf = stockDetailWork;
                        }
                        else if (gridMainWorkRowCount.Equals(deleteCount))
                        {
                            //�S�Ď��

                            //�������׃f�[�^�Ȃ�
                        }
                        else
                        {
                            //�ꕔ����F�����̐��ʂ��炠�炩���ߍ폜���������Ă���

                            //�������׃f�[�^�X�V����
                            stockDetailWork = this.GetStockDetailWorkNoUpdate(stockSlipDtlNum);
                            orderCount = stockDetailWork.OrderCnt;

                            stockDetailWork.StockCount = orderCount - deleteStockCount;         //�d����
                            stockDetailWork.OrderCnt = orderCount - deleteStockCount;           //������
                            stockDetailWork.OrderRemainCnt = orderCount - deleteStockCount;     //�����c��

                            if (substPartsNoIsExists)
                            {
                                // ��֗p���ڍX�V
                                this.SetSubstPartsInfo(ref stockDetailWork);
                            }
                            else
                            {
                                // �X�V�Ȃ�
                            }
                            // ����������ʎc���������Ȃ�ꍇ�͖��׍폜�Ƃ݂Ȃ�
                            if (stockDetailWork.OrderRemainCnt > 0)
                            {
                                stockSlipListInfo.StockDetailWorkBf = stockDetailWork;
                            }
                            stockSlipIsUpdate = true;
                        }
                        #endregion
                        #endregion
                    }
                    // ----- ADD 2012/08/30 ���N�n��  redmine#31885----->>>>>
                    //����f�[�^�̎d���`�[�ԍ��̎擾
                    nowSupplierSlipNo = (int)slipJoinRows[j][slipJoinTable.SupplierSlipNoColumn.ColumnName];
                    //�Ō�̃f�[�^�̈ȊO�̏ꍇ�A���̃f�[�^�d���`�[�ԍ��̎擾
                    if (slipJoinRows.Length - 1 != j)
                    {
                        nextSupplierSlipNo = (int)slipJoinRows[j + 1][slipJoinTable.SupplierSlipNoColumn.ColumnName];
                    }
                    //����f�[�^�̎d���`�[�ԍ��Ǝ��̃f�[�^�̎d���`�[�ԍ��͈Ⴂ�̏ꍇ�A�����́A�Ō�̃f�[�^�̏ꍇ�B
                    if (nowSupplierSlipNo != nextSupplierSlipNo || slipJoinRows.Length - 1 == j)
                    {
                        // �����f�[�^�쐬
                        #region �����f�[�^�쐬
                        // �������׃f�[�^�擾
                        stockDetailWorkBfList = stockSlipListInfo.StockDetailWorkBfList;

                        if (stockDetailWorkBfList.Count == 0)
                        {
                            stockSlipWork = this.GetStockSlipWorkNoUpdate(nowSupplierSlipNo);

                            // �S���׍폜
                            deleteWork = new IOWriteMASIRDeleteWork();
                            deleteWork.DebitNoteDiv = stockSlipWork.DebitNoteDiv;

                            deleteWork.EnterpriseCode = this._enterpriseCode;
                            deleteWork.SupplierFormal = stockSlipWork.SupplierFormal;
                            deleteWork.SupplierSlipNo = stockSlipWork.SupplierSlipNo;
                            deleteWork.UpdateDateTime = stockSlipWork.UpdateDateTime;

                            deleteWorkList.Add(deleteWork);
                        }
                        else if (stockSlipIsUpdate == false)
                        {
                            // �������ׂ̍X�V�Ȃ�(��ցA�폜������)�@���@�����f�[�^�͕K�v�Ȃ�
                        }
                        else
                        {
                            //�������׃f�[�^�擾
                            stockDetailWorkBfList = stockSlipListInfo.StockDetailWorkBfList;

                            //�����f�[�^
                            stockSlipListInfo.StockSlipWorkBf = this.SetOrderInfo(gridMainRowBackUp, stockDetailWorkBfList);

                            //�����f�[�^�Q���܂Ƃ߂�uoeStcUpdDataList�ɒǉ�
                            uoeStcUpdDataList.Add(stockSlipListInfo.StockSlipBfList);
                        }
                        #endregion
                        substPartsNoCount = 0;      //��֌���
                        stockSlipIsUpdate = false;
                        // ���ߍ���1�`�[���̏����폜
                        stockSlipListInfo.ClearBfItem();
                    }
                    // ----- ADD 2012/08/30 ���N�n��  redmine#31885-----<<<<<
                }

                // �v��f�[�^�쐬
                #region �v��f�[�^�쐬
                // �v�㖾�׃f�[�^�擾
                stockDetailWorkList = stockSlipListInfo.StockDetailWorkList;

                if (stockDetailWorkList.Count == 0)
                {
                    // ��ʂɒl�Ȃ��@���@�v��f�[�^�Ȃ�
                }
                else
                {
                    #region �v��w�b�_�[�E���וR�t���e�[�u�������ɂ��Ė��ׂ��w�b�_�[���ɂ܂Ƃ߂�B�܂Ƃ߂���uoeStcUpdDataList�ɒǉ�
                    stockSlipListInfoWork = new StockSlipListInfo();

                    headerGridRowNo = -1;
                    string headerNoAndJoinSort = string.Format("{0},{1}",headerNoAndGuidJoinTable.HeaderGridRowNoColumn.ColumnName
                                                                        ,headerNoAndGuidJoinTable.DetailGridRowNoColumn.ColumnName);
                    DataRow[] headerNoAndGuidJoinRows = headerNoAndGuidJoinTable.Select(string.Empty, headerNoAndJoinSort);
                    for (int idx = 0; idx <= headerNoAndGuidJoinRows.Length - 1; idx++)
                    {
                        headerNoAndGuidJoinRow = (HeaderNoAndGuidJoin.HeaderNoAndGuidJoinTableRow)headerNoAndGuidJoinRows[idx];
                        if ((idx > 0) && (headerGridRowNo != headerNoAndGuidJoinRow.HeaderGridRowNo))
                        {
                            //�O���b�h���C���̏��擾
                            string filter = string.Format("({0}={1}) AND ({2}={3})"
                                                        , this._gridMainDataTable.HeaderGridRowNoColumn.ColumnName, headerNoAndGuidJoinRowBf.HeaderGridRowNo
                                                        , this._gridMainDataTable.DetailGridRowNoColumn.ColumnName, headerNoAndGuidJoinRowBf.DetailGridRowNo);

                            DataRow[] gridMainRowsWork = this._gridMainDataTable.Select(filter);
                            gridMainRowWork = (GridMainDataSet.GridMainTableRow)gridMainRowsWork[0];     

                            // �w�b�_�[���擾
                            stockSlipListInfoWork.StockSlipWork = this.GetStockSlipWorkUpdate(gridMainRowWork, stockSlipListInfoWork.StockDetailWorkList).Clone();

                            // �v��f�[�^�Q���܂Ƃ߂�uoeStcUpdDataList�ɒǉ�
                            uoeStcUpdDataList.Add(stockSlipListInfoWork.StockSlipList);

                            stockSlipListInfoWork.ClearItem();
                        }

                        //GUID
                        stockSlipListInfoWork.DtlRelationGuid = headerNoAndGuidJoinRow.Guid;

                        // ����
                        stockSlipListInfoWork.StockDetailWork = stockSlipListInfo.GetStockDetailWork(headerNoAndGuidJoinRow.Guid).Clone();
                        // ���וt�����
                        stockSlipListInfoWork.SlipDetailAddInfoWork = stockSlipListInfo.GetSlipDetailAddInfoWork(headerNoAndGuidJoinRow.Guid);

                        headerGridRowNo = headerNoAndGuidJoinRow.HeaderGridRowNo;
                        headerNoAndGuidJoinRowBf = headerNoAndGuidJoinRow;
                    }


                    //�O���b�h���C���̏��擾
                    string filter2 = string.Format("({0}={1}) AND ({2}={3})"
                                                , this._gridMainDataTable.HeaderGridRowNoColumn.ColumnName, headerNoAndGuidJoinRowBf.HeaderGridRowNo
                                                , this._gridMainDataTable.DetailGridRowNoColumn.ColumnName, headerNoAndGuidJoinRowBf.DetailGridRowNo);

                    DataRow[] gridMainRowsWork2 = this._gridMainDataTable.Select(filter2);
                    gridMainRowWork = (GridMainDataSet.GridMainTableRow)gridMainRowsWork2[0];

                    // �w�b�_�[���擾
                    stockSlipListInfoWork.StockSlipWork = this.GetStockSlipWorkUpdate(gridMainRowWork, stockSlipListInfoWork.StockDetailWorkList).Clone();

                    // �v��f�[�^�Q���܂Ƃ߂�uoeStcUpdDataList�ɒǉ�
                    CustomSerializeArrayList csList = stockSlipListInfoWork.StockSlipList;
                    uoeStcUpdDataList.Add(csList);


                    // �v��f�[�^
                    //stockSlipListInfo.StockSlipWork = this.GetStockSlipWorkUpdate(gridMainRowBackUp, stockDetailWorkList);

                    // �v��f�[�^�Q���܂Ƃ߂�uoeStcUpdDataList�ɒǉ�
                    //uoeStcUpdDataList.Add(stockSlipListInfo.StockSlipList);
                    #endregion
                }
                #endregion

                // ----- DEL 2012/08/30 ���N�n��  redmine#31885----->>>>>
                // �����f�[�^�쐬
                #region �����f�[�^�쐬
                //// �������׃f�[�^�擾
                //stockDetailWorkBfList = stockSlipListInfo.StockDetailWorkBfList;

                //if (stockDetailWorkBfList.Count == 0)
                //{
                //    stockSlipWork = this.GetStockSlipWorkNoUpdate(supplierSlipNo);

                //    // �S���׍폜
                //    deleteWork = new IOWriteMASIRDeleteWork();
                //    deleteWork.DebitNoteDiv = stockSlipWork.DebitNoteDiv;

                //    deleteWork.EnterpriseCode = this._enterpriseCode;
                //    deleteWork.SupplierFormal = stockSlipWork.SupplierFormal;
                //    deleteWork.SupplierSlipNo = stockSlipWork.SupplierSlipNo;
                //    deleteWork.UpdateDateTime = stockSlipWork.UpdateDateTime;

                //    deleteWorkList.Add(deleteWork);
                //}
                //else if (stockSlipIsUpdate == false)
                //{
                //    // �������ׂ̍X�V�Ȃ�(��ցA�폜������)�@���@�����f�[�^�͕K�v�Ȃ�
                //}
                //else
                //{
                //    //�������׃f�[�^�擾
                //    stockDetailWorkBfList = stockSlipListInfo.StockDetailWorkBfList;

                //    //�����f�[�^
                //    stockSlipListInfo.StockSlipWorkBf = this.SetOrderInfo(gridMainRowBackUp, stockDetailWorkBfList);

                //    //�����f�[�^�Q���܂Ƃ߂�uoeStcUpdDataList�ɒǉ�
                //    uoeStcUpdDataList.Add(stockSlipListInfo.StockSlipBfList);
                //}
                #endregion
                // ----- DEL 2012/08/30 ���N�n��  redmine#31885-----<<<<<
                // ���ߍ���1�`�[���̏����폜
                stockSlipListInfo.ClearItem();
            //}//DEL 2012/08/30 ���N�n��  redmine#31885

            // �`�[�폜�p�f�[�^�쐬
            #region �`�[�폜�p�f�[�^�쐬
            for (int i = 0; i <= deleteWorkList.Count - 1; i++)
            {
                uoeStcUpdDataList.Add(deleteWorkList[i]);
            }
            #endregion
        }
        #endregion

        #region ��CheckSubstPartsNoIsExists(��֕i�̗p�`�F�b�N)
        /// <summary>
        /// ��֕i�̗p�`�F�b�N
        /// </summary>
        /// <param name="stockSlipDtlNumSrc">���גʔ�</param>
        /// <returns>True:��֕i�̗p�AFalse:��֕i�̗p���Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : ��֕i���̗p���邩�ǂ����̔�����s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>UpdateNote : 2013/05/16 �����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2013/06/18�z�M��</br>
        /// <br>              Redmine#35459 #42�̑Ή�</br>        /// </remarks>
        private bool CheckSubstPartsNoIsExists(long stockSlipDtlNumSrc)
        {
            // ------------DEL ����� 2013/05/16 FOR Redmine#35459--------->>>>
            //if (this._uoeOrderDtlWorkHTable.ContainsKey(stockSlipDtlNumSrc.ToString()) == false)
            //{
            //    return false;
            //}

            ////��֕i�̗p�ő�֕i������ꍇ
            //if (this._stockBlnktPrtNoDiv == 0)
            //{
            //    UOEOrderDtlWork uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()];
            //    if (string.IsNullOrEmpty(uoeOrderDtlWork.SubstPartsNo.TrimEnd()) == false)
            //    {
            //        return true;
            //    }
            //}
            // ------------DEL ����� 2013/05/16 FOR Redmine#35459---------<<<<

            // ------------ADD ����� 2013/05/16 FOR Redmine#35459--------->>>>
            if (!this._meiJiDiv)
            {
                if (this._uoeOrderDtlWorkHTable.ContainsKey(stockSlipDtlNumSrc.ToString()) == false)
                {
                    return false;
                }

                //��֕i�̗p�ő�֕i������ꍇ
                if (this._stockBlnktPrtNoDiv == 0)
                {
                    UOEOrderDtlWork uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()];
                    if (string.IsNullOrEmpty(uoeOrderDtlWork.SubstPartsNo.TrimEnd()) == false)
                    {
                        return true;
                    }
                }
            }
            else 
            {
                //��֕i�̗p�ő�֕i������ꍇ
                if (this._stockBlnktPrtNoDiv == 0)
                {
                    UOEOrderDtlWork uoeOrderDtlWork = GetUOEOrderDtlWorkFromTable(this._uoeOrderDtlWorkHTable, stockSlipDtlNumSrc);

                    if (null != uoeOrderDtlWork && string.IsNullOrEmpty(uoeOrderDtlWork.SubstPartsNo.TrimEnd()) == false)
                    {
                        return true;
                    }
                }
            }
            // ------------ADD ����� 2013/05/16 FOR Redmine#35459---------<<<<

            return false;
        }
        #endregion

        #region SetOrderInfo(�������擾)
        /// <summary>
        /// �������擾
        /// </summary>
        /// <param name="mainRow">�X�V�f�[�^</param>
        /// <param name="stockDetailWorkList">�d��(�v��E����)���׃f�[�^���X�g</param>
        /// <returns>�����f�[�^</returns>
        /// <remarks>
        /// <br>Note       : ���������Z�b�g���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>UpdateNote  : 2012/10/10 �� ��</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00 20120917�z�M��</br>
        /// <br>              Redmine#32625 ����Ōv�Z�s���̑Ή��B</br>
        /// </remarks>
        private StockSlipWork SetOrderInfo(GridMainDataSet.GridMainTableRow mainRow, List<StockDetailWork> stockDetailWorkList)
        {
            // �d���f�[�^�擾
            StockSlipWork stockSlipWork = this.GetStockSlipWorkNoUpdate(mainRow.SupplierSlipNo);
            if (stockSlipWork == null)
            {
                return null;
            }

            // �d������Œ[�������R�[�h
            int stockCnsTaxFrcProcCd = ((Supplier)this._supplierHTable[stockSlipWork.SupplierCd]).StockCnsTaxFrcProcCd;

            stockSlipWork.DetailRowCount = stockDetailWorkList.Count;                   // ���א�                       [���ߍ��񂾖��א�]

            // ----- ADD 2012/10/10 �� �� Redmine#32625 ----->>>>>
            //�d���[�������敪�ƒ[�������P�ʂ̎擾
            //1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj
            StockProcMoney stockProcMoney = this._uoeOrderDtlAcs.GetStockProcMoney(
                                                        1,
                                                        stockCnsTaxFrcProcCd,
                                                        999999999);

            stockSlipWork.StockFractionProcCd = stockProcMoney.FractionProcCd;
            // ----- ADD 2012/10/10 �� �� Redmine#32625 -----<<<<<

            // �d���f�[�^�̏��Z�o(������d���A�d�����׃��X�g�A�d���[�������敪�A�d������Œ[�������R�[�h)
            //StockSlipPriceCalculator.TotalPriceSetting(ref stockSlipWork, stockDetailWorkList, stockSlipWork.StockFractionProcCd, stockCnsTaxFrcProcCd); // DEL 2012/10/10 �� �� Redmine#32625
            StockSlipPriceCalculator.TotalPriceSetting(ref stockSlipWork, stockDetailWorkList, stockProcMoney.FractionProcUnit, stockProcMoney.FractionProcCd); // ADD 2012/10/10 �� �� Redmine#32625
            //---TotalPriceSetting�ł͈ȉ��̍��ڂ��X�V�����(���ɂ����邩���H)---
            //stockSlipWork.StockTotalPrice;          // �d�����z���v
            //stockSlipWork.StockSubttlPrice;         // �d�����z���v
            //stockSlipWork.StockTtlPricTaxInc;       // �d�����z�v(�ō���)
            //stockSlipWork.StockTtlPricTaxExc;       // �d�����z�v(�Ŕ���)
            //stockSlipWork.StockNetPrice;            // �d���������z
            //stockSlipWork.StockPriceConsTax;        // �d�����z����Ŋz
            //stockSlipWork.TtlItdedStcOutTax;        // �d���O�őΏۊz���v
            //stockSlipWork.TtlItdedStcInTax;         // �d�����őΏۊz���v
            //stockSlipWork.TtlItdedStcTaxFree;       // �d����ېőΏۊz���v
            //stockSlipWork.StockOutTax;              // �d�����z����Ŋz(�O��)
            //stockSlipWork.StckPrcConsTaxInclu;      // �d�����z����Ŋz(����)
            //stockSlipWork.StckDisTtlTaxExc;         // �d���l�����z�v(�Ŕ���)
            //stockSlipWork.ItdedStockDisOutTax;      // �d���l���O�őΏۊz���v
            //stockSlipWork.ItdedStockDisInTax;       // �d���l�����őΏۊz���v
            //stockSlipWork.ItdedStockDisTaxFre;      // �d���l����ېőΏۊz���v
            //stockSlipWork.StockDisOutTax;           // �d���l������Ŋz(�O��)
            //stockSlipWork.StckDisTtlTaxInclu;       // �d���l������Ŋz(����)

            return stockSlipWork;
        }
        #endregion

        #region ��SetSubstPartsInfo(�����f�[�^�p��֕i���Z�b�g)
        /// <summary>
        /// �����f�[�^�p��֕i���Z�b�g
        /// </summary>
        /// <param name="uoeOrderDtlWork">UOE�����f�[�^</param>
        /// <param name="stockDetailWork">�d��(�v��E����)���׃f�[�^</param>
        /// <remarks>
        /// <br>Note       : ��֕i�����Z�b�g���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>UpdateNote : 2013/05/16 �����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2013/06/18�z�M��</br>
        /// <br>              Redmine#35459 #42�̑Ή�</br>
        /// </remarks>
        private void SetSubstPartsInfo(ref StockDetailWork stockDetailWork)
        {
            long stockSlipDtlNum = stockDetailWork.StockSlipDtlNum;

            // ------------DEL ����� 2013/05/16 FOR Redmine#35459--------->>>>
            //if (this._uoeOrderDtlWorkHTable.ContainsKey(stockSlipDtlNum.ToString()) == false)
            //{
            //    return;
            //}
            // ------------DEL ����� 2013/05/16 FOR Redmine#35459---------<<<<

            /*
            // �w�b�_�[������
            stockDetailWork.CreateDateTime = DateTime.MinValue;                         // �쐬����                     [������]
            stockDetailWork.UpdateDateTime = DateTime.MinValue;                         // �X�V����                     [������]
            stockDetailWork.EnterpriseCode = this._enterpriseCode;                      // ��ƃR�[�h
            stockDetailWork.FileHeaderGuid = Guid.Empty;                                // GUID                         [������]
            stockDetailWork.UpdEmployeeCode = string.Empty;                             // �X�V�]�ƈ��R�[�h             [������]
            stockDetailWork.UpdAssemblyId1 = string.Empty;                              // �X�V�A�Z���u��ID1            [������]
            stockDetailWork.UpdAssemblyId2 = string.Empty;                              // �X�V�A�Z���u��ID2            [������]
            stockDetailWork.LogicalDeleteCode = 0;                                      // �_���폜�敪                 [������]
            stockDetailWork.AcceptAnOrderNo = 0;                                        // �󒍔ԍ�                     [������]
            //stockDetailWork.StockSlipDtlNum = 0;                                        // �d�����גʔ�
            stockDetailWork.SupplierFormalSrc = 0;                                      // �d���`��(��)
            stockDetailWork.StockSlipDtlNumSrc = 0;                                     // �d�����גʔ�(��)
            */
            //stockDetailWork.AcceptAnOrderNo = 0;                                        // �󒍔ԍ�                     [������]
            //stockDetailWork.StockSlipDtlNum = 0;                                        // �d�����גʔ�

            // UOE�����f�[�^�擾
            //UOEOrderDtlWork uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNum.ToString()];  // DEL ����� 2013/05/16 Redmine#35459

            // ------------ADD ����� 2013/05/16 FOR Redmine#35459--------->>>>
            UOEOrderDtlWork uoeOrderDtlWork = null;
            if (!this._meiJiDiv)
            {
                if (this._uoeOrderDtlWorkHTable.ContainsKey(stockSlipDtlNum.ToString()) == false)
                {
                    return;
                }

                // UOE�����f�[�^�擾
                uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNum.ToString()];
            }
            else
            {
                // UOE�����f�[�^�擾
                uoeOrderDtlWork = GetUOEOrderDtlWorkFromTable(this._uoeOrderDtlWorkHTable, stockSlipDtlNum);

                if (null == uoeOrderDtlWork) return;
            }
            // ------------ADD ����� 2013/05/16 FOR Redmine#35459---------<<<<

            // ���i�}�X�^�ǂݍ���
            List<GoodsUnitData> goodsUnitDataList = this.GetGoodsUnitDataList(stockDetailWork.GoodsMakerCd, uoeOrderDtlWork.SubstPartsNo);
            if (goodsUnitDataList != null) 
            {
                GoodsUnitData goodsUnitData = goodsUnitDataList[0];

                stockDetailWork.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                  // ���i���[�J�[�R�[�h
                stockDetailWork.MakerName = goodsUnitData.MakerName;                        // ���[�J�[����
                stockDetailWork.MakerKanaName = goodsUnitData.MakerKanaName;                // ���[�J�[�J�i����
                stockDetailWork.CmpltMakerKanaName = string.Empty;                          // ���[�J�[�J�i���́i�ꎮ�j
                stockDetailWork.GoodsNo = goodsUnitData.GoodsNo;                            // ���i�ԍ�
                stockDetailWork.GoodsName = goodsUnitData.GoodsName;                        // ���i����
                stockDetailWork.GoodsNameKana = goodsUnitData.GoodsNameKana;                // ���i���̃J�i
                stockDetailWork.GoodsLGroup = goodsUnitData.GoodsLGroup;                    // ���i�啪�ރR�[�h
                stockDetailWork.GoodsLGroupName = goodsUnitData.GoodsLGroupName;            // ���i�啪�ޖ���
                stockDetailWork.GoodsMGroup = goodsUnitData.GoodsMGroup;                    // ���i�����ރR�[�h
                stockDetailWork.GoodsMGroupName = goodsUnitData.GoodsMGroupName;            // ���i�����ޖ���
                stockDetailWork.BLGroupCode = goodsUnitData.BLGroupCode;                    // BL�O���[�v�R�[�h
                stockDetailWork.BLGroupName = goodsUnitData.BLGroupName;                    // BL�O���[�v�R�[�h����
                stockDetailWork.BLGoodsCode = goodsUnitData.BLGoodsCode;                    // BL���i�R�[�h
                stockDetailWork.BLGoodsFullName = goodsUnitData.BLGoodsFullName;            // BL���i�R�[�h���́i�S�p�j
                stockDetailWork.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;    // ���Е��ރR�[�h
                stockDetailWork.EnterpriseGanreName = goodsUnitData.EnterpriseGanreName;    // ���Е��ޖ���
            }
        }
        #endregion

        #region ��CreateSlipJoinTable(�d���E�d�����׃f�[�^�R�t���e�[�u���쐬)
        /// <summary>
        /// �d���E�d�����׃f�[�^�R�t���e�[�u���쐬
        /// </summary>
        /// <returns>�d���E�d�����וR�t������</returns>
        /// <remarks>
        /// <br>Note       : �d���f�[�^�Ǝd�����ׂ�R�t����ׂ̃e�[�u�����쐬���܂��B(HashTable�ł͒��o������̂�DataTable�Œ��o���s����)</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/02/17</br>
        /// </remarks>
        private StockSlipAndDetailJoin.JoinTableDataTable CreateSlipJoinTable()
        {
            StockSlipAndDetailJoin.JoinTableDataTable dataTable = new StockSlipAndDetailJoin.JoinTableDataTable();

            foreach (string key in this._stockDetailWorkHTable.Keys)
            {
                StockDetailWork stockDetailWork = (StockDetailWork)this._stockDetailWorkHTable[key];

                StockSlipAndDetailJoin.JoinTableRow dataRow = dataTable.NewJoinTableRow();
                dataRow[dataTable.SupplierSlipNoColumn.ColumnName] = stockDetailWork.SupplierSlipNo;
                dataRow[dataTable.StockSlipDtlNumSrcColumn.ColumnName] = stockDetailWork.StockSlipDtlNum;

                dataTable.AddJoinTableRow(dataRow);
            }

            return dataTable;
        }
        #endregion

        #region ��GetStockSlipWorkNoUpdateList(�X�V�O�d�����׃��X�g�擾)
        /// <summary>
        /// �X�V�O�d�����׃��X�g�擾
        /// </summary>
        /// <returns>�X�V�O�d�����׃��X�g</returns>
        /// <remarks>
        /// <br>Note       : HashTable����X�V�O�̎d�����ׂ�S�Ď擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/02/17</br>
        /// </remarks>
        private List<StockDetailWork> GetStockDetailWorkNoUpdateList()
        {
            List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>();
            for (int i = 0; i <= this._stockDetailWorkHTable.Count - 1; i++)
            {
                stockDetailWorkList.Add(((StockDetailWork)this._stockDetailWorkHTable[i]).Clone());
            }

            return stockDetailWorkList;
        }
        #endregion
        // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] ---------------------------------------<<<<<

        // �݌ɒ����f�[�^�쐬�֘A
        #region ��CreateStockAdjustArrayList(�݌ɒ����f�[�^�Q�쐬)
        /// <summary>
        /// �݌ɒ����f�[�^�Q�쐬
        /// </summary>
        /// <param name="uoeStcUpdDataList">�X�V�p�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �O���b�h���C��(�X�V���)�f�[�^�A�d���f�[�^�A�d�����׃f�[�^�AUOE�����f�[�^�����ɍX�V�f�[�^���쐬���܂��B</br>
        /// <br>             �܂��AUOE�����f�[�^�̓��ɋ敪���X�V���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void CreateStockAdjustArrayList(ref CustomSerializeArrayList uoeStcUpdDataList)
        {
            StockAdjustListInfo stockAdjustListInfo = new StockAdjustListInfo();    // �݌ɒ����f�[�^���ߍ��ݗp�N���X
            GridMainDataSet.GridMainTableRow mainRow = null;                        // �O���b�h���̓f�[�^(���ݒl)
            GridMainDataSet.GridMainTableRow mainRowBf = null;                      // �O���b�h���̓f�[�^(�O��l)
            CustomSerializeArrayList customSArrayList = new CustomSerializeArrayList();     //ADD 2009/02/25
            int dtlCount = 0;                                                               //ADD 2009/02/25

            // �X�V�Ώۃf�[�^�擾
            //DataRow[] dataRows = this.GetGridMainDataRows();              //DEL 2009/02/25
            // ---ADD 2009/02/25 ------------------------------------------------->>>>>
            DataRow[] dataRows = this.GetGridMainDataRowsStockAdjust();
            if (dataRows.Length == 0)
            {
                return;
            }
            // ---ADD 2009/02/25 -------------------------------------------------<<<<<

            long stockSubttlPrice = 0;   // 2010/11/01 Add

            for (int index = 0; index <= dataRows.Length - 1; index++)
            {
                mainRow = (GridMainDataSet.GridMainTableRow)dataRows[index];

                // ---ADD 2009/02/25 --------------------------------------------->>>>>
                // �q�ɂȂ��͏������Ȃ�
                if (string.IsNullOrEmpty(mainRow.WarehouseCode.TrimEnd()))
                {
                    mainRowBf = mainRow;
                    continue;
                }
                // ---ADD 2009/02/25 ---------------------------------------------<<<<<

                // �w�b�_�[���قȂ�ꍇ�ɍ݌ɒ����f�[�^�쐬
                //if ((mainRowBf != null) && (mainRowBf.HeaderGridRowNo != mainRow.HeaderGridRowNo))                                    //DEL 2009/02/25
                if ((mainRowBf != null) &&
                    ((mainRowBf.HeaderGridRowNo != mainRow.HeaderGridRowNo) || (mainRowBf.WarehouseCode != mainRow.WarehouseCode)))     //ADD 2009/02/25
                {
                    if (stockAdjustListInfo.StockAdjustDtlCount > 0)                            //ADD 2009/02/25
                    {                                                                           //ADD 2009/02/25
                        // �݌ɒ����f�[�^���ߍ���
                        // 2010/11/01 >>>
                        //stockAdjustListInfo.StockAdjustWork = this.CreateStockAdjustWork(mainRowBf);
                        stockAdjustListInfo.StockAdjustWork = this.CreateStockAdjustWork(mainRowBf, stockSubttlPrice);
                        // 2010/11/01 <<<

                        // ���ߍ��񂾍݌ɒ����A�݌ɒ������׃f�[�^���܂Ƃ߂�uoeStcUpdDataList�ɒǉ�
                        //uoeStcUpdDataList.Add(stockAdjustListInfo.StockAdjustList);           //DEL 2009/02/25
                        customSArrayList.Add(stockAdjustListInfo.StockAdjustList);              //ADD 2009/02/25
                    }                                                                           //ADD 2009/02/25
                    stockAdjustListInfo.ClearItem();
                    stockSubttlPrice = 0;   // 2010/11/01 Add
                }

                // �݌ɒ������׃f�[�^���ߍ���
                // 2010/11/01 >>>
                //stockAdjustListInfo.StockAdjustDtlWork = this.CreateStockAdjustDtlWork(mainRow);
                StockAdjustDtlWork stockAdjustDtlWork = this.CreateStockAdjustDtlWork(mainRow);
                stockSubttlPrice += stockAdjustDtlWork.StockPriceTaxExc;

                stockAdjustListInfo.StockAdjustDtlWork = stockAdjustDtlWork;
                // 2010/11/01 <<<
                dtlCount++;

                // UOE�����f�[�^�X�V
                //this.UpdateUOEOrderDtlWork(mainRow.StockSlipDtlNumSrc, mainRow.ColumnDiv, ENTERUPDDIV_ENTER, Guid.Empty);         //DEL 2009/02/25

                mainRowBf = mainRow;
            }

            // �ȉ��A�Ō�̃f�[�^������

            // �݌ɒ����f�[�^���ߍ���
            // 2010/11/01 >>>
            //stockAdjustListInfo.StockAdjustWork = this.CreateStockAdjustWork(mainRowBf);
            stockAdjustListInfo.StockAdjustWork = this.CreateStockAdjustWork(mainRowBf, stockSubttlPrice);
            // 2010/11/01 <<<

            // ���ߍ��񂾍݌ɒ����A�݌ɒ������׃f�[�^���܂Ƃ߂�uoeStcUpdDataList�ɒǉ�
            if (stockAdjustListInfo.StockAdjustDtlCount > 0)                            //ADD 2009/02/25
            {                                                                           //ADD 2009/02/25
                //uoeStcUpdDataList.Add(stockAdjustListInfo.StockAdjustList);           //DEL 2009/02/25
                customSArrayList.Add(stockAdjustListInfo.StockAdjustList);              //ADD 2009/02/25
            }                                                                           //ADD 2009/02/25

            if (dtlCount > 0)
            {
                CustomSerializeArrayList customList = customSArrayList;
                uoeStcUpdDataList.Add(customList);                                      //ADD 2009/02/25
            }
        }
        #endregion

        #region ��CreateStockAdjustWork(�X�V�p�݌ɒ����f�[�^�쐬)
        /// <summary>
        /// �X�V�p�݌ɒ����f�[�^�쐬
        /// </summary>
        /// <param name="mainRow">�O���b�h���C��(�X�V���)�f�[�^</param>
        /// <param name="stockSubttlPrice">�d�����z���v</param>
        /// <returns>�X�V�p�݌ɒ����f�[�^</returns>
        /// <remarks>
        /// <br>Note       : �d���f�[�^�A�O���b�h���C��(�X�V���)�f�[�^�����ɍX�V�p�݌ɒ����f�[�^���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        // 2010/11/01 >>>
        //private StockAdjustWork CreateStockAdjustWork(GridMainDataSet.GridMainTableRow mainRow)
        private StockAdjustWork CreateStockAdjustWork(GridMainDataSet.GridMainTableRow mainRow, long stockSubttlPrice)
        // 2010/11/01 <<<
        {
            StockAdjustWork stockAdjustWork = new StockAdjustWork();
            StockSlipWork stockSlipWork = (StockSlipWork)this._stockSlipWorkHTable[mainRow.SupplierSlipNo.ToString()];

            stockAdjustWork.CreateDateTime = DateTime.MinValue;                         // �쐬����                     [������]
            stockAdjustWork.UpdateDateTime = DateTime.MinValue;                         // �X�V����                     [������]
            stockAdjustWork.EnterpriseCode = this._enterpriseCode;                      // ��ƃR�[�h
            stockAdjustWork.FileHeaderGuid = Guid.Empty;                                // GUID                         [������]
            stockAdjustWork.UpdEmployeeCode = string.Empty;                             // �X�V�]�ƈ��R�[�h             [������]
            stockAdjustWork.UpdAssemblyId1 = string.Empty;                              // �X�V�A�Z���u��ID1            [������]
            stockAdjustWork.UpdAssemblyId2 = string.Empty;                              // �X�V�A�Z���u��ID2            [������]
            stockAdjustWork.LogicalDeleteCode = 0;                                      // �_���폜�敪                 [������]
            stockAdjustWork.SectionCode = stockSlipWork.SectionCode;	                // ���_�R�[�h                   [�v�㌳�̋��_�R�[�h]
            stockAdjustWork.StockAdjustSlipNo = 0;                                      // �݌ɒ����`�[�ԍ�             [������]
            stockAdjustWork.AcPaySlipCd = 13;                                           // �󕥌��`�[�敪               [13�F�݌Ɏd��]
            stockAdjustWork.AcPayTransCd = 30;                                          // �󕥌�����敪               [30�F�݌ɐ�����]
            stockAdjustWork.AdjustDate = DateTime.Today;                                // �������t
            stockAdjustWork.InputDay = DateTime.Today;	                                // ���͓��t
            stockAdjustWork.StockSectionCd = stockSlipWork.StockSectionCd;	            // �d�����_�R�[�h               [�v�㌳�̎d�����_�R�[�h]
            stockAdjustWork.StockInputCode = stockSlipWork.StockInputCode;	            // �d�����͎҃R�[�h             [�v�㌳�̎d�����͎҃R�[�h]
            stockAdjustWork.StockInputName = stockSlipWork.StockInputName;	            // �d�����͎Җ���               [�v�㌳�̎d�����͎Җ���]
            stockAdjustWork.StockAgentCode = stockSlipWork.StockAgentCode;	            // �d���S���҃R�[�h             [�v�㌳�̎d���S���҃R�[�h]
            stockAdjustWork.StockAgentName = stockSlipWork.StockAgentName;	            // �d���S���Җ���               [�v�㌳�̎d���S���Җ���]
            // 2010/11/01 >>>
            //stockAdjustWork.StockSubttlPrice = stockSlipWork.StockSubttlPrice;	        // �d�����z���v                 [�v�㌳�̎d�����z���v]
            stockAdjustWork.StockSubttlPrice = stockSubttlPrice;                        // �d�����z���v                 [�v�㌳�̎d�����z���v]
            // 2010/11/01 <<<
            stockAdjustWork.SlipNote = string.Empty;                                    // �`�[���l                     [������]

            return stockAdjustWork;
        }
        #endregion

        #region ��CreateStockAdjustDtlWork(�X�V�p�݌ɒ������׃f�[�^�쐬)
        /// <summary>
        /// �X�V�p�݌ɒ������׃f�[�^�쐬
        /// </summary>
        /// <param name="mainRow">�O���b�h���C��(�X�V���)�f�[�^</param>
        /// <returns>�X�V�p�݌ɒ������׃f�[�^</returns>
        /// <remarks>
        /// <br>Note       : �d�����׃f�[�^�AUOE�����f�[�^�A�O���b�h���C��(�X�V���)�f�[�^�����ɍX�V�p�݌ɒ������׃f�[�^���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>UpdateNote : 2013/05/16 �����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2013/06/18�z�M��</br>
        /// <br>              Redmine#35459 #42�̑Ή�</br>
        /// </remarks>
        private StockAdjustDtlWork CreateStockAdjustDtlWork(GridMainDataSet.GridMainTableRow mainRow)
        {
            StockAdjustDtlWork stockAdjustDtlWork = new StockAdjustDtlWork();
            StockDetailWork stockDetailWork = (StockDetailWork)this._stockDetailWorkHTable[mainRow.StockSlipDtlNumSrc.ToString()];  // �d�����׃f�[�^
            //UOEOrderDtlWork uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[mainRow.StockSlipDtlNumSrc.ToString()];  // UOE�����f�[�^  // DEL ����� 2013/05/16 Redmine#35459
            // ------------ADD ����� 2013/05/16 FOR Redmine#35459--------->>>>
            string uoeOrderDtlKey = this.GetOrderDtlKey(mainRow.StockSlipDtlNumSrc.ToString(), mainRow.SlipNo);
            UOEOrderDtlWork uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[uoeOrderDtlKey];  // UOE�����f�[�^
            // ------------ADD ����� 2013/05/16 FOR Redmine#35459---------<<<<<

            stockAdjustDtlWork.CreateDateTime = DateTime.MinValue;                      // �쐬����                     [������]
            stockAdjustDtlWork.UpdateDateTime = DateTime.MinValue;                      // �X�V����                     [������]
            stockAdjustDtlWork.EnterpriseCode = this._enterpriseCode;                   // ��ƃR�[�h
            stockAdjustDtlWork.FileHeaderGuid = Guid.Empty;                             // GUID                         [������]
            stockAdjustDtlWork.UpdEmployeeCode = string.Empty;                          // �X�V�]�ƈ��R�[�h             [������]
            stockAdjustDtlWork.UpdAssemblyId1 = string.Empty;                           // �X�V�A�Z���u��ID1            [������]
            stockAdjustDtlWork.UpdAssemblyId2 = string.Empty;                           // �X�V�A�Z���u��ID2            [������]
            stockAdjustDtlWork.LogicalDeleteCode = 0;                                   // �_���폜�敪                 [������]
            stockAdjustDtlWork.SectionCode = stockDetailWork.SectionCode;	            // ���_�R�[�h                   [�v�㌳�̋��_�R�[�h]
            stockAdjustDtlWork.StockAdjustSlipNo = 0;	                                // �݌ɒ����`�[�ԍ�             [������]
            //stockAdjustDtlWork.SupplierFormalSrc = stockDetailWork.SupplierFormalSrc;	// �d���`��(��)                 [�v�㌳�̎d���`��]          //DEL 2009/01/14
            //stockAdjustDtlWork.StockSlipDtlNumSrc = stockDetailWork.StockSlipDtlNumSrc;	// �d�����גʔ�(��)             [�v�㌳�̎d�����גʔ�]  //DEL 2009/01/14
            stockAdjustDtlWork.SupplierFormalSrc = stockDetailWork.SupplierFormal;	    // �d���`��(��)                 [�v�㌳�̎d���`��]          //ADD 2009/01/14
            stockAdjustDtlWork.StockSlipDtlNumSrc = stockDetailWork.StockSlipDtlNum;	// �d�����גʔ�(��)             [�v�㌳�̎d�����גʔ�]      //ADD 2009/01/14
            // 2010/11/01 >>>
            //stockAdjustDtlWork.AcPaySlipCd = stockDetailWork.StockSlipCdDtl;	        // �󕥌��`�[�敪               [�v�㌳�̎d���`�[�敪]
            //stockAdjustDtlWork.AcPayTransCd = 10;	                                    // �󕥌�����敪               [10�F�ʏ�`�[]
            stockAdjustDtlWork.AcPaySlipCd = 13;                                        // �󕥌��`�[�敪               [13:�݌Ɏd��]
            stockAdjustDtlWork.AcPayTransCd = 30;	                                    // �󕥌�����敪               [30:�݌ɐ�����]
            // 2010/11/01 <<<
            stockAdjustDtlWork.AdjustDate = DateTime.Today;	                            // �������t
            stockAdjustDtlWork.InputDay = DateTime.Today;	                            // ���͓��t
            stockAdjustDtlWork.GoodsMakerCd = stockDetailWork.GoodsMakerCd;	            // ���i���[�J�[�R�[�h           [�v�㌳�̏��i���[�J�[�R�[�h]
            stockAdjustDtlWork.MakerName = stockDetailWork.MakerName;	                // ���[�J�[����                 [�v�㌳�̃��[�J�[����]
            stockAdjustDtlWork.GoodsNo = stockDetailWork.GoodsNo;	                    // ���i�ԍ�                     [�v�㌳�̏��i�ԍ�]
            stockAdjustDtlWork.GoodsName = stockDetailWork.GoodsName;	                // ���i����                     [�v�㌳�̏��i����]
            stockAdjustDtlWork.StockUnitPriceFl = mainRow.InputAnswerSalesUnitCost;	    // �d���P��(�Ŕ�,����)          [��ʂ̓��͒l(���P��)]
            stockAdjustDtlWork.BfStockUnitPriceFl = stockDetailWork.BfStockUnitPriceFl;	// �ύX�O�d���P��(����)         [�v�㌳�̕ύX�O�d���P��(����)]
            stockAdjustDtlWork.AdjustCount = mainRow.InputEnterCnt;	                    // ������                       [��ʂ̓��͒l(����)]
            stockAdjustDtlWork.DtlNote = string.Empty;	                                // ���ה��l                     [������]
            stockAdjustDtlWork.WarehouseCode = stockDetailWork.WarehouseCode;	        // �q�ɃR�[�h                   [�v�㌳�̑q�ɃR�[�h]
            stockAdjustDtlWork.WarehouseName = stockDetailWork.WarehouseName;	        // �q�ɖ���                     [�v�㌳�̑q�ɖ���]
            stockAdjustDtlWork.BLGoodsCode = stockDetailWork.BLGoodsCode;	            // BL���i�R�[�h                 [�v�㌳��BL���i�R�[�h]
            stockAdjustDtlWork.BLGoodsFullName = stockDetailWork.BLGoodsFullName;	    // BL���i�R�[�h����(�S�p)       [�v�㌳��BL���i�R�[�h����(�S�p)]
            stockAdjustDtlWork.WarehouseShelfNo = stockDetailWork.WarehouseShelfNo;	    // �q�ɒI��                     [�v�㌳�̑q�ɒI��]
            stockAdjustDtlWork.ListPriceFl = uoeOrderDtlWork.AnswerListPrice;	        // �艿(����)                   [UOE�����f�[�^�̉񓚒艿]
            //stockAdjustDtlWork.OpenPriceDiv = 0;	                                    // �I�[�v�����i�敪             [0�F�ʏ�] //DEL chenw 2013/03/07 Redmine#34989
            // ------ ADD chenw 2013/03/07 Redmine#34989 ------------>>>>>
            if (OPENFLAG.Equals(uoeOrderDtlWork.LineErrorMassage.Trim()))
            {
                stockAdjustDtlWork.OpenPriceDiv = 1;
            }
            else
            {
                stockAdjustDtlWork.OpenPriceDiv = 0;
            }
            // ------ ADD chenw 2013/03/07 Redmine#34989 ------------<<<<<
            // 	�d�����z(�Ŕ���)
            stockAdjustDtlWork.StockPriceTaxExc = (long)Math.Round(stockAdjustDtlWork.StockUnitPriceFl * stockAdjustDtlWork.AdjustCount,0);
            
            return stockAdjustDtlWork;
        }
        #endregion

        // UOE�����f�[�^�쐬�֘A
        #region ��CreateUOEOrderDtlWorkList(�X�V�pUOE�����f�[�^�쐬)
        /// <summary>
        /// �X�V�pUOE�����f�[�^�쐬
        /// </summary>
        /// <returns>�X�V�pUOE�����f�[�^</returns>
        /// <remarks>
        /// <br>Note       : UOE�����f�[�^�̂����X�V�t���O�������Ă�����̂𒊏o���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
//        private ArrayList CreateUOEOrderDtlWorkList()
        private CustomSerializeArrayList CreateUOEOrderDtlWorkList()
        {
            UOEOrderDtlWork uoeOrderDtlWork = null;

            ArrayList arrayList = new ArrayList();
            CustomSerializeArrayList customArrayList = new CustomSerializeArrayList();
//            foreach(string key in this._uoeOrderDtlWorkHTable.Keys)
            for (int idx = 0; idx <= this._uoeOrderDtlWorkUpdateList.Count - 1; idx++)
            {
                //uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[key];

                // �X�V�̂������Ă�����̂̂ݓo�^
                //if ((uoeOrderDtlWork.EnterUpdDivSec == ENTERUPDDIV_ENTER) ||
                //    (uoeOrderDtlWork.EnterUpdDivBO1 == ENTERUPDDIV_ENTER) ||
                //    (uoeOrderDtlWork.EnterUpdDivBO2 == ENTERUPDDIV_ENTER) ||
                //    (uoeOrderDtlWork.EnterUpdDivBO3 == ENTERUPDDIV_ENTER) ||
                //    (uoeOrderDtlWork.EnterUpdDivMaker == ENTERUPDDIV_ENTER) ||
                //    (uoeOrderDtlWork.EnterUpdDivEO == ENTERUPDDIV_ENTER))
                //{
                //    arrayList.Add(this._uoeOrderDtlWorkHTable[key]);
                //}
                uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[this._uoeOrderDtlWorkUpdateList[idx]];

                arrayList.Add(uoeOrderDtlWork);
            }

            customArrayList.Add(arrayList);
//            return arrayList;
            return customArrayList;
        }
        #endregion

        #region ��UpdateUOEOrderDtlWork(UOE�����f�[�^�X�V)
        // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] ----------------------------------------------------->>>>>
        /// <summary>
        /// UOE�����f�[�^�X�V
        /// </summary>
        /// <param name="stockSlipDtlNumSrc">�d�����גʔ�</param>
        /// <param name="columnDiv">��敪(���_�ABO1�ABO2�ABO3�A���[�J�[�AEO)</param>
        /// <param name="value">�X�V�l(0�F�����ɁA1�F���ɍ�)</param>
        /// <param name="guid">GUID</param>
        /// <param name="substPartsNoIsExists">��֗L��(True�F����AFalse�Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : UOE�����f�[�^�̓��ɍX�V�敪���X�V���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>UpdateNote : 2013/05/16 �����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2013/06/18�z�M��</br>
        /// <br>              Redmine#35459 #42�̑Ή�</br>
        /// </remarks>
        //private void UpdateUOEOrderDtlWork(long stockSlipDtlNumSrc, string columnDiv, int value, Guid guid, bool substPartsNoIsExists)  //  DEL ����� 2013/05/16 Redmine#35459
        private void UpdateUOEOrderDtlWork(long stockSlipDtlNumSrc, string columnDiv, int value, Guid guid, bool substPartsNoIsExists, string slipNo)   //  ADD ����� 2013/05/16 Redmine#35459
        {
            //this.UpdateUOEOrderDtlWork(stockSlipDtlNumSrc, columnDiv, value, guid);        //  DEL ����� 2013/05/16 Redmine#35459
            this.UpdateUOEOrderDtlWork(stockSlipDtlNumSrc, columnDiv, value, guid, slipNo);  //  ADD ����� 2013/05/16 Redmine#35459
            if (substPartsNoIsExists)
            {
                //((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()]).DtlRelationGuid = Guid.Empty;  // DEL ����� 2013/05/16 Redmine#35459
                // ------------ADD ����� 2013/05/16 FOR Redmine#35459--------->>>>
                string uoeOrderDtlKey = this.GetOrderDtlKey(stockSlipDtlNumSrc.ToString(), slipNo);
                ((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[uoeOrderDtlKey]).DtlRelationGuid = Guid.Empty;
                // ------------ADD ����� 2013/05/16 FOR Redmine#35459--------->>>>
            }
        }
        // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] -----------------------------------------------------<<<<<

        /// <summary>
        /// UOE�����f�[�^�X�V
        /// </summary>
        /// <param name="stockSlipDtlNumSrc">�d�����גʔ�</param>
        /// <param name="columnDiv">��敪(���_�ABO1�ABO2�ABO3�A���[�J�[�AEO)</param>
        /// <param name="value">�X�V�l(0�F�����ɁA1�F���ɍ�)</param>
        /// <param name="guid">GUID</param>
        /// <remarks>
        /// <br>Note       : UOE�����f�[�^�̓��ɍX�V�敪���X�V���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>UpdateNote : 2013/05/16 �����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2013/06/18�z�M��</br>
        /// <br>              Redmine#35459 #42�̑Ή�</br>
        /// </remarks>
        //private void UpdateUOEOrderDtlWork(long stockSlipDtlNumSrc, string columnDiv, int value, Guid guid)                // DEL ����� 2013/05/16 Redmine#35459
        private void UpdateUOEOrderDtlWork(long stockSlipDtlNumSrc, string columnDiv, int value, Guid guid, string slipNo)   // ADD ����� 2013/05/16 Redmine#35459
        {
            string uoeOrderDtlKey = this.GetOrderDtlKey(stockSlipDtlNumSrc.ToString(), slipNo); // ADD ����� 2013/05/16 Redmine#35459

            // HashTable�ɖ����ꍇ�͏������Ȃ�
            //if (this._uoeOrderDtlWorkHTable.ContainsKey(stockSlipDtlNumSrc.ToString()) == false)  // DEL ����� 2013/05/16 Redmine#35459
            if (this._uoeOrderDtlWorkHTable.ContainsKey(uoeOrderDtlKey) == false)                   // ADD ����� 2013/05/16 Redmine#35459
            {
                return;
            }

            // GUID
            if (guid != Guid.Empty)
            {
                //((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()]).DtlRelationGuid = guid; // DEL ����� 2013/05/16 Redmine#35459
                ((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[uoeOrderDtlKey]).DtlRelationGuid = guid;                  // ADD ����� 2013/05/16 Redmine#35459
            }

            switch (columnDiv)
            {
                case PMUOE01203AA.COLUMNDIV_SECTION:
                    {
                        // ���ɍX�V�敪(���_)
                        //((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()]).EnterUpdDivSec = value; // DEL ����� 2013/05/16 Redmine#35459
                        ((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[uoeOrderDtlKey]).EnterUpdDivSec = value;                  // ADD ����� 2013/05/16 Redmine#35459
                        break;
                    }
                case PMUOE01203AA.COLUMNDIV_BO1:
                    {
                        // ���ɍX�V�敪(BO1)
                        //((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()]).EnterUpdDivBO1 = value; // DEL ����� 2013/05/16 Redmine#35459
                        ((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[uoeOrderDtlKey]).EnterUpdDivBO1 = value;                  // ADD ����� 2013/05/16 Redmine#35459
                        break;
                    }
                case PMUOE01203AA.COLUMNDIV_BO2:
                    {
                        // ���ɍX�V�敪(BO2)
                        //((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()]).EnterUpdDivBO2 = value; // DEL ����� 2013/05/16 Redmine#35459
                        ((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[uoeOrderDtlKey]).EnterUpdDivBO2 = value;                  // ADD ����� 2013/05/16 Redmine#35459
                        break;      
                    }
                case PMUOE01203AA.COLUMNDIV_BO3:
                    {
                        // ���ɍX�V�敪(BO3)
                        //((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()]).EnterUpdDivBO3 = value; // DEL ����� 2013/05/16 Redmine#35459
                        ((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[uoeOrderDtlKey]).EnterUpdDivBO3 = value;                  // ADD ����� 2013/05/16 Redmine#35459
                        break;
                    }
                case PMUOE01203AA.COLUMNDIV_MAKER:
                    {
                        // ���ɍX�V�敪(���[�J�[)
                        //((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()]).EnterUpdDivMaker = value;   // DEL ����� 2013/05/16 Redmine#35459
                        ((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[uoeOrderDtlKey]).EnterUpdDivMaker = value;                    // ADD ����� 2013/05/16 Redmine#35459
                        break;
                    }
                case PMUOE01203AA.COLUMNDIV_EO:
                    {
                        // ���ɍX�V�敪(EO)
                        //((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()]).EnterUpdDivEO = value;      // DEL ����� 2013/05/16 Redmine#35459
                        ((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[uoeOrderDtlKey]).EnterUpdDivEO = value;                       // ADD ����� 2013/05/16 Redmine#35459
                        break;
                    }
                default:
                    return;
            }

            if (this._uoeOrderDtlWorkUpdateList == null)
            {
                this._uoeOrderDtlWorkUpdateList = new List<string>();
            }

            //if (this._uoeOrderDtlWorkUpdateList.Contains(stockSlipDtlNumSrc.ToString()) == false)     // DEL ����� 2013/05/16 Redmine#35459
            if (this._uoeOrderDtlWorkUpdateList.Contains(uoeOrderDtlKey) == false)                      // ADD ����� 2013/05/16 Redmine#35459
            {
                //this._uoeOrderDtlWorkUpdateList.Add(stockSlipDtlNumSrc.ToString() + slipNo);          // DEL ����� 2013/05/16 Redmine#35459
                this._uoeOrderDtlWorkUpdateList.Add(uoeOrderDtlKey);                                    // ADD ����� 2013/05/16 Redmine#35459
            }


        }
        #endregion

        // HashTable�f�[�^�擾
        // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] --------------------------------------->>>>>
        #region ��GetUOEOrderDtlWork(UOE�����f�[�^�擾)
        /// <summary>
        /// UOE�����f�[�^�擾
        /// </summary>
        /// <param name="stockSlipDtlNumSrc">�d�����גʔ�</param>
        /// <returns>UOE�����f�[�^</returns>
        /// <remarks>
        /// <br>Note       : �d�����גʔԂ�����HashTable����UOE�����f�[�^���擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>UpdateNote : 2013/05/16 �����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2013/06/18�z�M��</br>
        /// <br>              Redmine#35459 #42�̑Ή�</br>
        /// </remarks>
        //private UOEOrderDtlWork GetUOEOrderDtlWork(long stockSlipDtlNumSrc)  // DEL ����� 2013/05/16 Redmine#35459
        private UOEOrderDtlWork GetUOEOrderDtlWork(long stockSlipDtlNumSrc, string slipNo)  // ADD ����� 2013/05/16 Redmine#35459
        {
            // ------------DEL ����� 2013/05/16 FOR Redmine#35459--------->>>>
            //if (this._uoeOrderDtlWorkHTable.ContainsKey(stockSlipDtlNumSrc.ToString()) == false)
            //{
            //    return null;
            //}

            //return (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()];
            // ------------DEL ����� 2013/05/16 FOR Redmine#35459---------<<<<

            // ------------ADD ����� 2013/05/16 FOR Redmine#35459--------->>>>
            string key = this.GetOrderDtlKey(stockSlipDtlNumSrc.ToString(), slipNo);
            if (this._uoeOrderDtlWorkHTable.ContainsKey(key) == false)
            {
                return null;
            }

            return (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[key];
            // ------------ADD ����� 2013/05/16 FOR Redmine#35459---------<<<<
        }
        #endregion
        // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] ---------------------------------------<<<<<

        // ------------ADD ����� 2013/05/16 FOR Redmine#35459--------->>>>
        /// <summary>
        /// �L�[�̔��f
        /// </summary>
        /// <param name="stockSlipDtlNum">�d�����גʔ�</param>
        /// <param name="slipNo">�`�[�ԍ�</param>
        /// <returns>�L�[</returns>
        /// <remarks>
        /// <br>Note       : �L�[���擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2013/05/16</br>
        /// </remarks>
        private string GetOrderDtlKey(string stockSlipDtlNum, string slipNo)
        {
            // �����Y�Ǝ�
            if (_meiJiDiv)
            {
                int slipNoInt = 0;
                Int32.TryParse(slipNo, out slipNoInt);
                return stockSlipDtlNum + slipNoInt.ToString().PadLeft(6, '0');
            }
            else
            {
                return stockSlipDtlNum;
            }
        }

        /// <summary>
        /// UOE�����f�[�^�擾
        /// </summary>
        /// <param name="uoeOrderDtlWorkHTable">HashTable</param>
        /// <param name="stockSlipDtlNum">�d�����גʔ�</param>
        /// <returns>UOE�����f�[�^</returns>
        /// <remarks>
        /// <br>Note       : �d�����גʔԂ�����HashTable����UOE�����f�[�^���擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2013/05/16</br>
        /// </remarks>
        private UOEOrderDtlWork GetUOEOrderDtlWorkFromTable(Hashtable uoeOrderDtlWorkHTable, long stockSlipDtlNum)
        {
            UOEOrderDtlWork uOEOrderDtlWork = null;

            foreach (string key in _uoeOrderDtlWorkHTable.Keys)
            {
                // �����גʔԂ��g�p
                string newStockSlipDtlNum = string.Empty;
                
                if (_meiJiDiv)
                {
                    // �����Y�Ǝ�
                    newStockSlipDtlNum = key.Substring(0, key.Length - 6);
                }
                else
                {
                    newStockSlipDtlNum = key;
                }
                 
                if (newStockSlipDtlNum.Equals(stockSlipDtlNum.ToString()))
                {
                    uOEOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[key];
                    break;
                }
            }

            return uOEOrderDtlWork;
        }
        // ------------ADD ����� 2013/05/16 FOR Redmine#35459---------<<<<

        // ===================================================================================== //
        // �N���X
        // ===================================================================================== //
        #region ���d���f�[�^��񒙂ߍ��ݗp�N���X
        /// <summary>
        /// �d���f�[�^��񒙂ߍ��ݗp�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �@�X�V��d���f�[�^�́u�d�����z���v�v�u�d�����z�v�u���׍s���v�͂��̃N���X���ŋ��߂�</br>
        /// <br>             �A�X�V��d�����׃f�[�^�́u�d���s�ԍ��v�͂��̃N���X���ŋ��߂�</br>
        /// <br>             �B�X�V��d�����ׁA�d�����וt���f�[�^�́u���׊֘A�t��GUID�v�͈����n���ꂽ�l�����̃N���X���ŃZ�b�g����</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private class StockSlipListInfo
        {
            #region ���ϐ�
            // ��֕i�p���
            private CustomSerializeArrayList _stockSlipBfList = null;   // ��֕i�X�V�f�[�^�Q
            private StockSlipWork _stockSlipWorkBf = null;              //  L�X�V�O�d��(��֕i�ԍX�V�p)     ���v���p�e�B�œn�����
            private ArrayList _stockDetailWorkBfList = null;            //  L�X�V�O�d�����׃��X�g(��֕i�ԍX�V�p)
            // StockDetailWork�^                                        //    L�X�V�O�d�����ׁ@���v���p�e�B�œn����A���X�g�Ɋi�[

            // �����v��d���p���
            private CustomSerializeArrayList _stockSlipList = null;     // �����v��d���Q(�d���`�[�ԍ��P��)
            private StockSlipWork _stockSlipWork = null;                //  L�d��                           ���v���p�e�B�œn�����
            private ArrayList _stockDetailWorkList = null;              //  L�d�����׃��X�g
            // StockDetailWork�^                                        //    L�d�����ׁ@�@�@�@���v���p�e�B�œn����A���X�g�Ɋi�[
            private ArrayList _slipDetailAddInfoWorkList = null;        //  L���וt����񃊃X�g
            // SlipDetailAddInfoWork�^                                  //    L���וt�����@�@���v���p�e�B�œn����A���X�g�Ɋi�[

            // ���̑��ϐ�
            private long _stockTotalPrice = 0;                          // ���ׂ̎d�����z(�Ŕ���)�̍��v
            private long _stockSubttlPrice = 0;                         // ���ׂ̎d�����z(�ō���)�̍��v
            private Guid _dtlRelationGuid = Guid.Empty;                 // ���׊֘A�t��GUID

            private Hashtable _slipDetailAddInfoHTable = new Hashtable();       //ADD 2009/02/17 �s��Ή�[10140][10177][10529]
            private Hashtable _stockDetailWorkHTable = new Hashtable();         //ADD 2009/02/17 �s��Ή�[10140][10177][10529]
            #endregion

            #region ���R���X�g���N�^
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : �N���X�̐V�����C���X�^���X�����������܂��B</br>
            /// <br>Programmer : �Ɠc �M�u</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            public StockSlipListInfo()
            {
                this.InitializeItem();          // �����v��p�d����񏉊���
                this.InitializeBfItem();        // ��֕i�p�d����񏉊���
            }
            #endregion

            // �v���p�e�B
            #region ���v���p�e�B(Get)
            /// <summary> �����v��d���Q </summary>
            public CustomSerializeArrayList StockSlipList { get { return this.GetStockSlipList(); } }
            /// <summary> ��֕i�X�V�f�[�^�Q </summary>
            public CustomSerializeArrayList StockSlipBfList { get { return this.GetStockSlipBfList(); } }
            /* ---DEL 2009/02/17 �s��Ή�[10140][10177][10529] -------------------------------------------------------------->>>>>
            /// <summary> ��֕i�X�V�f�[�^�Q���݃t���O(True�F��֕i����AFalse�F��֕i�Ȃ�) </summary>
            public bool StockDetailWorkBfListDataIsExists { get { return this._stockDetailWorkBfList.Count != 0 ? true : false; } }
               ---DEL 2009/02/17 �s��Ή�[10140][10177][10529] --------------------------------------------------------------<<<<< */
            /// <summary> �d�����׃��X�g </summary>
            public List<StockDetailWork> StockDetailWorkList { get { return this.GetStockDetailWorkList(); } }
            // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] -------------------------------------------------------------->>>>>
            public List<StockDetailWork> StockDetailWorkBfList { get { return this.GetStockDetailWorkBfList(); } }
            // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] --------------------------------------------------------------<<<<<
            #endregion

            #region ���v���p�e�B(Set)
            /// <summary> �d���f�[�^ </summary>
            public StockSlipWork StockSlipWork { set { this._stockSlipWork = value; } }
            /// <summary> �d�����׃f�[�^ </summary>
            public StockDetailWork StockDetailWork { set { this.AddStockDetailWorkList(value); } }
            /// <summary> �d�����וt����� </summary>
            public SlipDetailAddInfoWork SlipDetailAddInfoWork { set { this.AddSlipDetailAddInfoWorkList(value); } }
            /// <summary> �X�V�O�d���f�[�^ </summary>
            public StockSlipWork StockSlipWorkBf { set { this._stockSlipWorkBf = value; } }
            /// <summary> �X�V�O�d�����׃f�[�^ </summary>
            public StockDetailWork StockDetailWorkBf { set { this._stockDetailWorkBfList.Add(value); } }
            #endregion

            #region ���v���p�e�B(Get�ASet)
            /// <summary> ���׊֘A�t��GUID </summary>
            public Guid DtlRelationGuid
            {
                get { return this._dtlRelationGuid; }
                set { this._dtlRelationGuid = value; }
            }
            #endregion

            // �p�u���b�N���\�b�h
            #region ��ClearItem(�擾�A�C�e���̏�����)
            /// <summary>
            /// �擾�A�C�e���̏�����
            /// </summary>
            /// <remarks>
            /// <br>Note       : ����܂łɒ��ߍ��񂾃A�C�e�������������܂��B</br>
            /// <br>Programmer : �Ɠc �M�u</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            public void ClearItem()
            {
                // �����v��p�d����񏉊���
                this.InitializeItem();

                /* ---DEL 2009/02/17 �s��Ή�[10140][10177][10529] --------------->>>>>
                // ��֕i�p�d����񏉊���
                if (this.StockDetailWorkBfListDataIsExists)
                {
                    this.InitializeBfItem();
                }
                   ---DEL 2009/02/17 �s��Ή�[10140][10177][10529] ---------------<<<<< */
                this.InitializeBfItem();        //ADD 2009/02/17
            }
            // ----- ADD 2012/08/30 ���N�n��  redmine#31885----->>>>>
            /// <summary>
            /// �擾�A�C�e���̏�����
            /// </summary>
            /// <remarks>
            /// <br>Note       : ����܂łɒ��ߍ��񂾃A�C�e�������������܂��B</br>
            /// <br>Programmer : ���N�n��</br>
            /// <br>Date       : 2009/02/17</br>
            /// <br>�Ǘ��ԍ�   : 10801804-00 20120912�z�M��</br>
            /// <br>             redmine #31885:�g�c����@�݌ɓ��ɍX�V�����̑Ή�</br>
            /// <br>             ����̃I�����C���ԍ��ł����Ă��قȂ�d���`�[�ɐ�������Ă��܂��̏�Q�̑Ή�</br>
            /// </remarks>
            public void ClearBfItem()
            {
                this.InitializeBfItem();      
            }
            // ----- ADD 2012/08/30 ���N�n��  redmine#31885-----<<<<<
            #endregion


            // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] -------------------------------------------------------------->>>>>
            public SlipDetailAddInfoWork GetSlipDetailAddInfoWork(Guid guid)
            {
                if (guid == Guid.Empty)
                {
                    return null;
                }

                return (SlipDetailAddInfoWork)this._slipDetailAddInfoHTable[guid];
            }
            public StockDetailWork GetStockDetailWork(Guid guid)
            {
                if (guid == Guid.Empty)
                {
                    return null;
                }

                return (StockDetailWork)this._stockDetailWorkHTable[guid];
            }
            // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] --------------------------------------------------------------<<<<<

            // �v���C�x�[�g���\�b�h
            #region ��InitializeItem(�����v��p�d����񏉊���)
            /// <summary>
            /// �����v��p�d����񏉊���
            /// </summary>
            /// <remarks>
            /// <br>Note       : �����v��p�d���������������܂��B</br>
            /// <br>Programmer : �Ɠc �M�u</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private void InitializeItem()
            {
                // ������
                this._stockSlipList = new CustomSerializeArrayList();       // �����v��d���Q(�d���`�[�ԍ��P��)
                this._stockSlipWork = new StockSlipWork();                  //  L�d��
                this._stockDetailWorkList = new ArrayList();                //  L�d�����׃��X�g
                                                                            //    L�d������
                this._slipDetailAddInfoWorkList = new ArrayList();          //  L���וt����񃊃X�g
                                                                            //    L���וt�����
                this._stockTotalPrice = 0;
                this._stockSubttlPrice = 0;

                this._stockDetailWorkHTable = new Hashtable();      //ADD 2009/02/17 �s��Ή�[10140][10177][10529]
                this._slipDetailAddInfoHTable = new Hashtable();    //ADD 2009/02/17 �s��Ή�[10140][10177][10529]
            }
            #endregion

            #region ��InitializeBfItem(��֕i�p�d����񏉊���)
            /// <summary>
            /// ��֕i�p�d����񏉊���
            /// </summary>
            /// <remarks>
            /// <br>Note       : ��֕i�p�d���������������܂��B</br>
            /// <br>Programmer : �Ɠc �M�u</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private void InitializeBfItem()
            {
                // ������
                this._stockSlipBfList = new CustomSerializeArrayList();     // ��֕i�X�V�f�[�^�Q
                this._stockSlipWorkBf = new StockSlipWork();                //  L�X�V�O�d��(��֕i�ԍX�V�p)
                this._stockDetailWorkBfList = new ArrayList();              //  L�X�V�O�d�����׃��X�g(��֕i�ԍX�V�p)
                                                                            //    L�X�V�O�d������
            }
            #endregion

            #region ��GetStockSlipList(�����v��d���Q�擾)
            /// <summary>
            /// �����v��d���Q�擾
            /// </summary>
            /// <returns>�����v��d���Q(���ߍ��񂾃f�[�^�����W��������)</returns>
            /// <remarks>
            /// <br>Note       : ���ߍ��񂾎d���A�d�����׃��X�g�A���וt����񃊃X�g�����ɔ����v��d���Q���쐬���ĕԂ��܂��B</br>
            /// <br>Programmer : �Ɠc �M�u</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private CustomSerializeArrayList GetStockSlipList()
            {
                this._stockSlipList.Add(this._stockSlipWork);
                this._stockSlipList.Add(this._stockDetailWorkList);
                this._stockSlipList.Add(this._slipDetailAddInfoWorkList);

                return this._stockSlipList;
            }
            #endregion

            #region ��GetStockSlipBfList(��֕i�X�V�f�[�^�Q�擾)
            /// <summary>
            /// ��֕i�X�V�f�[�^�Q�擾
            /// </summary>
            /// <returns>��֕i�X�V�f�[�^�Q(���ߍ��񂾃f�[�^�����W��������)</returns>
            /// <remarks>
            /// <br>Note       : ���ߍ��񂾍X�V�O�d���A�X�V�O�d�����׃��X�g�����ɑ�֕i�X�V�f�[�^�Q���쐬���ĕԂ��܂��B</br>
            /// <br>Programmer : �Ɠc �M�u</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private CustomSerializeArrayList GetStockSlipBfList()
            {
                this._stockSlipBfList.Add(this._stockSlipWorkBf);
                this._stockSlipBfList.Add(this._stockDetailWorkBfList);

                return this._stockSlipBfList;
            }
            #endregion

            #region ��GetStockDetailWorkList(�d�����׃��X�g�擾)
            /// <summary>
            /// �d�����׃��X�g�擾
            /// </summary>
            /// <returns>�^�ϊ����ꂽ�d�����׃��X�g</returns>
            /// <remarks>
            /// <br>Note       : ���ߍ���ArrayList�^�̎d�����ׂ�List��StockDetailWork>�^�ɕϊ����Ė߂��܂��B</br>
            /// <br>Programmer : �Ɠc �M�u</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private List<StockDetailWork> GetStockDetailWorkList()
            {
                // �^�ϊ��FArrayList��List<StockDetailWork>
                List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>();
                for (int idx = 0; idx <= this._stockDetailWorkList.Count - 1; idx++)
                {
                    stockDetailWorkList.Add((StockDetailWork)this._stockDetailWorkList[idx]);
                }

                return stockDetailWorkList;
            }
            #endregion

            // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] -------------------------------------------------------------->>>>>
            #region ��GetStockDetailWorkBfList(�d�����׃��X�g�擾)
            /// <summary>
            /// �d�����׃��X�g�擾
            /// </summary>
            /// <returns>�^�ϊ����ꂽ�d�����׃��X�g</returns>
            /// <remarks>
            /// <br>Note       : ���ߍ���ArrayList�^�̎d�����ׂ�List��StockDetailWork>�^�ɕϊ����Ė߂��܂��B</br>
            /// <br>Programmer : �Ɠc �M�u</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private List<StockDetailWork> GetStockDetailWorkBfList()
            {
                // �^�ϊ��FArrayList��List<StockDetailWork>
                List<StockDetailWork> stockDetailWorkBfList = new List<StockDetailWork>();
                for (int idx = 0; idx <= this._stockDetailWorkBfList.Count - 1; idx++)
                {
                    stockDetailWorkBfList.Add((StockDetailWork)this._stockDetailWorkBfList[idx]);
                }

                return stockDetailWorkBfList;
            }
            #endregion
            // ---ADD 2009/02/17 �s��Ή�[10140][10177][10529] --------------------------------------------------------------<<<<<

            #region ��AddStockDetailWorkList(�d�����גǉ�)
            /// <summary>
            /// �d�����גǉ�
            /// </summary>
            /// <param name="stockDetailWork">�d������</param>
            /// <remarks>
            /// <br>Note       : �d�����ׂ�GUID�A�s�ԍ���t�����Ďd�����׃��X�g�ւ̒ǉ����s���܂��B</br>
            /// <br>Programmer : �Ɠc �M�u</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private void AddStockDetailWorkList(StockDetailWork stockDetailWork)
            {
                this._stockTotalPrice = this._stockTotalPrice + stockDetailWork.StockPriceTaxExc;
                this._stockSubttlPrice = this._stockSubttlPrice + stockDetailWork.StockPriceTaxInc;

                // �s�ԍ����̔�(�`�[�P�ʂ�1����J�n)
                stockDetailWork.StockRowNo = this._stockDetailWorkList.Count + 1;

                // ���׊֘A�t��GUID
                stockDetailWork.DtlRelationGuid = this._dtlRelationGuid;

                this._stockDetailWorkList.Add(stockDetailWork);
                this._stockDetailWorkHTable.Add(stockDetailWork.DtlRelationGuid, stockDetailWork);
            }
            #endregion

            #region ��AddSlipDetailAddInfoWorkList(���וt�����ǉ�)
            /// <summary>
            /// ���וt�����ǉ�
            /// </summary>
            /// <param name="slipDetailAddInfoWork">���וt�����</param>
            /// <remarks>
            /// <br>Note       : ���וt������GUID�A�ԍ���t�����Ė��וt����񃊃X�g�ւ̒ǉ����s���܂��B</br>
            /// <br>Programmer : �Ɠc �M�u</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private void AddSlipDetailAddInfoWorkList(SlipDetailAddInfoWork slipDetailAddInfoWork)
            {
                // ���׊֘A�t��GUID
                slipDetailAddInfoWork.DtlRelationGuid = this._dtlRelationGuid;

                // �ԍ����̔�(�����P�ʂ�1����J�n)
                slipDetailAddInfoWork.SlipDtlRegOrder = this._slipDetailAddInfoWorkList.Count + 1;

                this._slipDetailAddInfoWorkList.Add(slipDetailAddInfoWork);
                this._slipDetailAddInfoHTable.Add(slipDetailAddInfoWork.DtlRelationGuid, slipDetailAddInfoWork);        //ADD 2009/02/17 �s��Ή�[10140][10177][10529]
            }
            #endregion
        }
        #endregion

        #region ���݌ɒ����f�[�^��񒙂ߍ��ݗp�N���X
        /// <summary>
        /// �݌ɒ����f�[�^��񒙂ߍ��ݗp�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �@�݌ɒ������׃f�[�^�́u�s�ԍ��v�͂��̃N���X���ŋ��߂�</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private class StockAdjustListInfo
        {
            #region ���ϐ�
            // �݌ɒ����p���
            CustomSerializeArrayList _stockAdjustList = null;   // �݌ɒ����f�[�^�Q
            ArrayList _stockAdjustWorkList = null;              //  L�݌ɒ������X�g
            // StockAdjustWork�^                                //    L�݌ɒ����@�@�@���v���p�e�B�œn����A���X�g�Ɋi�[
            ArrayList _stockAdjustDtlWorkList = null;           //  L�݌ɒ������׃��X�g
            // StockAdjustDtlWork�^                             //    L�݌ɒ������ׁ@���v���p�e�B�œn����A���X�g�Ɋi�[
            #endregion

            #region ���R���X�g���N�^
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : �N���X�̐V�����C���X�^���X�����������܂��B</br>
            /// <br>Programmer : �Ɠc �M�u</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            public StockAdjustListInfo()
            {
                this.InitializeItem();          // �݌ɒ����p��񏉊���
            }
            #endregion

            // �v���p�e�B
            #region ���v���p�e�B(Get)
            /// <summary> �݌ɒ����f�[�^�Q </summary>
            public CustomSerializeArrayList StockAdjustList { get {return this.GetStockAdjustList(); } }
            /// <summary> ���׌��� </summary>
            public int StockAdjustDtlCount { get { return this._stockAdjustDtlWorkList.Count; } }
            #endregion

            #region ���v���p�e�B(Set)
            /// <summary> �݌ɒ����f�[�^ </summary>
            public StockAdjustWork StockAdjustWork { set { this._stockAdjustWorkList.Add(value); } }
            /// <summary> �݌ɒ������׃f�[�^ </summary>
            public StockAdjustDtlWork StockAdjustDtlWork { set { this.AddStockAdjustDtlWork(value); } }
            #endregion

            // �p�u���b�N���\�b�h
            #region ��ClearItem(�擾�A�C�e���̏�����)
            /// <summary>
            /// �擾�A�C�e���̏�����
            /// </summary>
            /// <remarks>
            /// <br>Note       : ����܂łɒ��ߍ��񂾃A�C�e�������������܂��B</br>
            /// <br>Programmer : �Ɠc �M�u</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            public void ClearItem()
            {
                // �݌ɒ����p��񏉊���
                this.InitializeItem();
            }
            #endregion

            // �v���C�x�[�g���\�b�h
            #region ��InitializeItem(�݌ɒ����p��񏉊���)
            /// <summary>
            /// �݌ɒ����p��񏉊���
            /// </summary>
            /// <remarks>
            /// <br>Note       : �݌ɒ����p�������������܂��B</br>
            /// <br>Programmer : �Ɠc �M�u</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private void InitializeItem()
            {
                // ������
                this._stockAdjustList = new CustomSerializeArrayList();     // �݌ɒ����f�[�^�Q
                this._stockAdjustWorkList = new ArrayList();                //  L�݌ɒ������X�g
                                                                            //    L�݌ɒ���
                this._stockAdjustDtlWorkList = new ArrayList();             //  L�݌ɒ������׃��X�g
                                                                            //    L�݌ɒ�������
            }
            #endregion

            #region ��GetStockAdjustList(�݌ɒ����f�[�^�Q�擾)
            /// <summary>
            /// �݌ɒ����f�[�^�Q�擾
            /// </summary>
            /// <returns>�݌ɒ����f�[�^�Q(���ߍ��񂾃f�[�^�����W��������)</returns>
            /// <remarks>
            /// <br>Note       : ���ߍ��񂾍݌ɒ������X�g�A�݌ɒ������׃��X�g�����ɍ݌ɒ����f�[�^�Q���쐬���ĕԂ��܂��B</br>
            /// <br>Programmer : �Ɠc �M�u</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private CustomSerializeArrayList GetStockAdjustList()
            {
                this._stockAdjustList.Add(this._stockAdjustWorkList);
                this._stockAdjustList.Add(this._stockAdjustDtlWorkList);

                return this._stockAdjustList;
            }
            #endregion

            #region ��AddStockAdjustDtlWork(�݌ɒ������גǉ�)
            /// <summary>
            /// �݌ɒ������גǉ�
            /// </summary>
            /// <param name="stockAdjustDtlWork">�݌ɒ�������</param>
            /// <remarks>
            /// <br>Note       : �݌ɒ������ׂɍs�ԍ���t�����č݌ɒ������׃��X�g�ւ̒ǉ����s���܂��B</br>
            /// <br>Programmer : �Ɠc �M�u</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private void AddStockAdjustDtlWork(StockAdjustDtlWork stockAdjustDtlWork)
            {
                // �s�ԍ����̔�(�`�[�P�ʂ�1����J�n)
                stockAdjustDtlWork.StockAdjustRowNo = this._stockAdjustDtlWorkList.Count + 1;

                this._stockAdjustDtlWorkList.Add(stockAdjustDtlWork);
            }
            #endregion
        }
        #endregion
    }
}