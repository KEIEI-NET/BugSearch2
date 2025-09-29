//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �D�ǃf�[�^�폜����
// �v���O�����T�v   : �D�ǃf�[�^�폜����
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : ���X��
// �� �� ��  2011/07/13  �C�����e : �A��No.2 �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : caohh
// �C �� ��  2011/07/21  �C�����e : �A��No.2 �D�ǃf�[�^�폜�`�F�b�N���X�g�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11100068-00 �쐬�S�� : ���t
// �C �� ��  2015/06/08  �C�����e : REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
//----------------------------------------------------------------------------//
//****************************************************************************//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Data;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �D�ǃf�[�^�폜�����A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �D�ǃf�[�^�폜�����Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer	: ���X��</br>
    /// <br>Date		: 2011/07/13</br>
    /// <br>Update Nota : 2011/07/21 caohh</br>
    /// <br>            : �D�ǃf�[�^�폜�`�F�b�N���X�g�Ή�</br>
    /// <br>Update Note : 2015/06/08 ���t</br>
    /// <br>�Ǘ��ԍ�    : 11100068-00 </br>
    /// <br>            : REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��</br>    
    /// </remarks>
    public class DeleteConditionAcs
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        /// <remarks>
        /// <br>Programmer	: ���X��</br>
        /// <br>Date		: 2011/07/13</br>
        /// </remarks>
        public DeleteConditionAcs()
        {
            this._yuuRyouDataDelDB = MediationYuuRyouDataDelDB.GetYuuRyouDataDelDB();
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members
        private IYuuRyouDataDelDB _yuuRyouDataDelDB = null;
        private static DeleteConditionAcs _deleteConditionAcs = null;
        // ---- ADD caohh 2011/07/21 ---->>>>
        private DataTable _deleteListDt;			// ���DataTable
        private DataView _deleteListDataView;	    // ���DataView
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			// ���[�o�͐ݒ�f�[�^�N���X
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// ���[�o�͐ݒ�A�N�Z�X�N���X
        // ---- ADD caohh 2011/07/21 ----<<<<
        #endregion

        // ---- ADD caohh 2011/07/21 ---->>>>
        #region �� Public Property
        /// <summary>
        /// ����f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataView DeleteListDataView
        {
            get { return this._deleteListDataView; }
        }
        #endregion �� Public Property
        // ---- ADD caohh 2011/07/21 ----<<<<

        /// <summary>
        /// �A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�A�N�Z�X�N���X �C���X�^���X</returns>
        /// <remarks>
        /// <br>Programmer	: ���X��</br>
        /// <br>Date		: 2011/07/13</br>
        /// </remarks>
        public static DeleteConditionAcs GetInstance()
        {
            // ---- ADD caohh 2011/07/21 ---->>>>
            stc_Employee = null;
            stc_PrtOutSet = null;					// ���[�o�͐ݒ�f�[�^�N���X
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X

            // ���O�C�����_�擾
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }
            // ---- ADD caohh 2011/07/21 ----<<<<

            if (_deleteConditionAcs == null)
            {
                _deleteConditionAcs = new DeleteConditionAcs();
            }

            return _deleteConditionAcs;
        }

        #region �폜����
        /// <summary>
        /// �폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �폜�������s���B</br>
        /// <br>Programmer	: ���X��</br>
        /// <br>Date		: 2011/07/13</br>
        /// <br>Update Note : 2015/06/08 ���t</br>
        /// <br>�Ǘ��ԍ�    : 11100068-00 </br>
        /// <br>            : REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��</br>    
        /// </remarks>
        public int DeleteData(ref string errMsg, ref DeleteCondition deleteCondition)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            try
            {
                DeleteConditionWork deleteConditionWork = new DeleteConditionWork();
                //��ƃR�[�h
                deleteConditionWork.EnterpriseCode = deleteCondition.EnterpriseCode;
                //�폜�敪
                deleteConditionWork.DeleteCode = deleteCondition.DeleteCode;
                //���_
                deleteConditionWork.SectionCode = deleteCondition.SectionCode;
                //���[�J�[
                if (deleteCondition.GoodsMakerCode != 0)
                {
                    deleteConditionWork.GoodsMakerCode = deleteCondition.GoodsMakerCode;
                }
                // ���̓R�[�h1
                deleteConditionWork.Code1 = deleteCondition.Code1;
                // ���̓R�[�h2
                if (deleteCondition.Code2 != 0)
                {
                    deleteConditionWork.Code2 = deleteCondition.Code2;
                }
                // ���̓R�[�h3
                if (deleteCondition.Code3 != 0)
                {
                    deleteConditionWork.Code3 = deleteCondition.Code3;
                }
                // ���̓R�[�h4
                if (deleteCondition.Code4 != 0)
                {
                    deleteConditionWork.Code4 = deleteCondition.Code4;
                }
                //���i�݌ɍ폜�敪
                if (deleteCondition.GoodsDeleteCode != 0)
                {
                    deleteConditionWork.GoodsDeleteCode = deleteCondition.GoodsDeleteCode;
                }
                //�����݌ɍ폜�敪
                if (deleteCondition.JoinDeleteCode != 0)
                {
                    deleteConditionWork.JoinDeleteCode = deleteCondition.JoinDeleteCode;
                }
                // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ---->>>>>
                //�|���}�X�^�폜�敪
                if (deleteCondition.RateDeleteCode != 0)
                {
                    deleteConditionWork.RateDeleteCode = deleteCondition.RateDeleteCode;
                }
                // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----<<<<<
                object objDeletePara = (object)deleteConditionWork;
                status = this._yuuRyouDataDelDB.Delete(ref objDeletePara);

                // ����ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    deleteConditionWork = new DeleteConditionWork();
                    deleteConditionWork = objDeletePara as DeleteConditionWork;
                    deleteCondition = new DeleteCondition();
                    deleteCondition.GoodsDeleteCnt = deleteConditionWork.GoodsDeleteCnt;
                    deleteCondition.GoodsNotDeleteCnt = deleteConditionWork.GoodsNotDeleteCnt;
                    deleteCondition.JoinDeleteCnt = deleteConditionWork.JoinDeleteCnt;
                    deleteCondition.JoinNotDeleteCnt = deleteConditionWork.JoinNotDeleteCnt;
                    deleteCondition.StockDeleteCnt = deleteConditionWork.StockDeleteCnt;
                    deleteCondition.StockNotDeleteCnt = deleteConditionWork.StockNotDeleteCnt;
                    // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ---->>>>>
                    deleteCondition.RateDeleteCnt = deleteConditionWork.RateDeleteCnt;
                    deleteCondition.RateNotDeleteCnt = deleteConditionWork.RateNotDeleteCnt;
                    // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----<<<<<
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = ex.Message;
            }
            return status;
        }
        #endregion

        // ---- ADD caohh 2011/07/21 ---->>>>
        #region �f�[�^�擾����
        /// <summary>
        /// �f�[�^�擾����
        /// </summary>
        /// <param name="errMsg">errMsg</param>
        /// <param name="deleteCondition">UI���o�����N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�擾�������s���B</br>
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/07/21</br>
        /// </remarks>
        public int SearchMain(ref string errMsg, ref DeleteCondition deleteCondition)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            try
            {
                // DataTable Create ----------------------------------------------------------
                PMKHN01505EA.CreateDataTable(ref this._deleteListDt);

                DeleteConditionWork deleteConditionWork = new DeleteConditionWork();
                #region ���o�����W�J
                //��ƃR�[�h
                deleteConditionWork.EnterpriseCode = deleteCondition.EnterpriseCode;
                //�폜�敪
                deleteConditionWork.DeleteCode = deleteCondition.DeleteCode;
                //���_
                deleteConditionWork.SectionCode = deleteCondition.SectionCode;
                //���[�J�[
                if (deleteCondition.GoodsMakerCode != 0)
                {
                    deleteConditionWork.GoodsMakerCode = deleteCondition.GoodsMakerCode;
                }
                // ���̓R�[�h1
                deleteConditionWork.Code1 = deleteCondition.Code1;
                // ���̓R�[�h2
                if (deleteCondition.Code2 != 0)
                {
                    deleteConditionWork.Code2 = deleteCondition.Code2;
                }
                // ���̓R�[�h3
                if (deleteCondition.Code3 != 0)
                {
                    deleteConditionWork.Code3 = deleteCondition.Code3;
                }
                // ���̓R�[�h4
                if (deleteCondition.Code4 != 0)
                {
                    deleteConditionWork.Code4 = deleteCondition.Code4;
                }
                //���i�݌ɍ폜�敪
                if (deleteCondition.GoodsDeleteCode != 0)
                {
                    deleteConditionWork.GoodsDeleteCode = deleteCondition.GoodsDeleteCode;
                }
                //�����݌ɍ폜�敪
                if (deleteCondition.JoinDeleteCode != 0)
                {
                    deleteConditionWork.JoinDeleteCode = deleteCondition.JoinDeleteCode;
                }
                #endregion
                object objDeletePara = (object)deleteConditionWork;
                // �f�[�^�擾  ----------------------------------------------------------------
                object deleteData = null;
                status = this._yuuRyouDataDelDB.Search(out deleteData, objDeletePara, 0, ConstantManagement.LogicalMode.GetData0);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DeleteListData(deleteCondition, (ArrayList)deleteData);

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if (this._deleteListDataView.Count == 0)
                        {
                            // ����f�[�^�����݂��Ȃ�
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        this._deleteListDataView = new DataView();
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "�D�ǃf�[�^�̎擾�Ɏ��s���܂����B";
                        break;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = ex.Message;
            }
            return status;
        }
        #endregion

        #region �擾�f�[�^�W�J����
        /// <summary>
        /// �擾�f�[�^�W�J����
        /// </summary>
        /// <param name="deleteCondition">UI���o�����N���X</param>
        /// <param name="deleteData">�擾�f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/07/21</br>
        /// </remarks>
        private void DeleteListData(DeleteCondition deleteCondition, ArrayList deleteData)
        {
            DataRow dr;
            foreach (DeleteResultWork deleteResultWork in deleteData)
            {
                dr = this._deleteListDt.NewRow();
                // �擾�f�[�^�W�J
                #region �擾�f�[�^�W�J
                dr[PMKHN01505EA.ct_Col_GoodsMakerCd] = deleteResultWork.GoodsMakerCd;                // ���i���[�J�[�R�[�h
                dr[PMKHN01505EA.ct_Col_MakerName] = deleteResultWork.MakerName;                      // ���[�J�[����
                dr[PMKHN01505EA.ct_Col_GoodsNo] = deleteResultWork.GoodsNo;                          // ���i�ԍ�
                dr[PMKHN01505EA.ct_Col_BLGoodsCode] = deleteResultWork.BLGoodsCode;                  // BL���i�R�[�h
                dr[PMKHN01505EA.ct_Col_GoodsName] = deleteResultWork.GoodsName;                      // ���i����
                dr[PMKHN01505EA.ct_Col_WarehouseCode] = deleteResultWork.WarehouseCode;              // �q�ɃR�[�h
                dr[PMKHN01505EA.ct_Col_WarehouseName] = deleteResultWork.WarehouseName;              // �q�ɖ���
                dr[PMKHN01505EA.ct_Col_WarehouseShelfNo] = deleteResultWork.WarehouseShelfNo;        // �q�ɒI��
                dr[PMKHN01505EA.ct_Col_SalesOrderCount] = deleteResultWork.SalesOrderCount;          // �󒍐�(�����c)
                dr[PMKHN01505EA.ct_Col_ShipmentPosCnt] = deleteResultWork.ShipmentPosCnt;            // �o�׉\��
               
                #endregion

                // Table��Add
                this._deleteListDt.Rows.Add(dr);
            }

            if (this._deleteListDt.Rows.Count == 0)
            {
                // �Ώۃf�[�^���[����
                this._deleteListDataView = new DataView();
                return;
            }

            // DataView�쐬
            this._deleteListDataView = new DataView(this._deleteListDt, "", "", DataViewRowState.CurrentRows);
        }
        #endregion

        #region ���[�o�͐ݒ�擾����
        /// <summary>
        /// ���[�o�͐ݒ�Ǎ�
        /// </summary>
        /// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/07/21</br>
        /// </remarks>
        public static int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                // �f�[�^�͓Ǎ��ς݂��H
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion 
        // ---- ADD caohh 2011/07/21 ----<<<<
    }
}
