//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �����_�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/03/31  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����_�ݒ�}�X�^�����e�i���X�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����_�ݒ�}�X�^�����e�i���X�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.03.31</br>
    /// <br></br>
    /// <br>Update Note :</br>
    /// </remarks>
    public class OrderPointStAcs
    {
        # region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
        private IOrderPointStDB _iOrderPointStDB = null;
        # endregion

        # region -- �R���X�g���N�^ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�t���C���Ή�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.31</br>
        /// </remarks>
        public OrderPointStAcs()
        {
            // �����[�g�I�u�W�F�N�g�擾
            this._iOrderPointStDB = (IOrderPointStDB)MediationOrderPointStDB.GetOrderPointStDB();
        }
        # endregion

        # region -- �������� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="patterNo">�ݒ�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.31</br>
        /// </remarks>
        public int Search(out List<OrderPointSt> retList, int patterNo, string enterpriseCode)
        {
            OrderPointStWork orderPointStWork = new OrderPointStWork();

            orderPointStWork.PatterNo = patterNo;
            orderPointStWork.EnterpriseCode = enterpriseCode;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new List<OrderPointSt>();

            object paraobj = orderPointStWork;
            object retobj = null;

            ArrayList orderPointStWorkList = new ArrayList();
            orderPointStWorkList.Clear();

            status = this._iOrderPointStDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                orderPointStWorkList = retobj as ArrayList;

                foreach (OrderPointStWork orderPointStWorkTemp in orderPointStWorkList)
                {
                    retList.Add(CopyToOrderPointStFromOrderPointStWork(orderPointStWorkTemp));
                }
            }

            // STATUS ��ݒ�
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (retList.Count == 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }
        # endregion

        # region -- �o�^��X�V���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �o�^�E�X�V����
        /// </summary>
        /// <param name="orderPointStList">UI�f�[�^List</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.31</br>
        /// </remarks>
        public int Write(ref List<OrderPointSt> orderPointStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;;

            ArrayList orderPointStWorkList = new ArrayList();

            foreach (OrderPointSt orderPointSt in orderPointStList)
            {
                // UI�f�[�^�N���X�����[�N
                OrderPointStWork orderPointStWork = CopyToOrderPointStWorkFromOrderPointSt(orderPointSt);

                orderPointStWorkList.Add(orderPointStWork);
            }

            object paraObj = orderPointStWorkList;

            status = this._iOrderPointStDB.Write(ref paraObj);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                orderPointStWorkList = paraObj as ArrayList;

                orderPointStList.Clear();
                foreach (OrderPointStWork orderPointStWork in orderPointStWorkList)
                {
                    // ���[�N��UI�f�[�^�N���X
                    OrderPointSt orderPointSt = CopyToOrderPointStFromOrderPointStWork(orderPointStWork);

                    orderPointStList.Add(orderPointSt);
                }
            }

            return status;
        }
        # endregion

        #region �_���폜����
        /// <summary>
        /// �_���폜����(�����_�ݒ�}�X�^)
        /// </summary>
        /// <param name="orderPointStList">�����_�ݒ�}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����_�ݒ�}�X�^��_���폜���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/04/23</br>
        /// </remarks>
        public int LogicalDelete(ref List<OrderPointSt> orderPointStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList orderPointStWorkList = new ArrayList();

                foreach (OrderPointSt orderPointSt in orderPointStList)
                {
                    // UI�f�[�^�N���X�����[�N
                    OrderPointStWork orderPointStWork = CopyToOrderPointStWorkFromOrderPointSt(orderPointSt);

                    orderPointStWorkList.Add(orderPointStWork);
                }

                object paraObj = orderPointStWorkList;

                // �_���폜����
                status = this._iOrderPointStDB.LogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    orderPointStWorkList = paraObj as ArrayList;

                    orderPointStList.Clear();
                    foreach (OrderPointStWork orderPointStWork in orderPointStWorkList)
                    {
                        // ���[�N��UI�f�[�^�N���X
                        OrderPointSt orderPointSt = CopyToOrderPointStFromOrderPointStWork(orderPointStWork);

                        orderPointStList.Add(orderPointSt);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        # endregion

        #region �����폜����
        /// <summary>
        /// �����폜����(�����_�ݒ�}�X�^)
        /// </summary>
        /// <param name="orderPointStList">�����_�ݒ�}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����_�ݒ�}�X�^���X�g�𕨗��폜���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/04/23</br>
        /// </remarks>
        public int Delete(List<OrderPointSt> orderPointStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList orderPointStWorkList = new ArrayList();

                foreach (OrderPointSt orderPointSt in orderPointStList)
                {
                    // UI�f�[�^�N���X�����[�N
                    OrderPointStWork orderPointStWork = CopyToOrderPointStWorkFromOrderPointSt(orderPointSt);

                    orderPointStWorkList.Add(orderPointStWork);
                }

                object paraObj = orderPointStWorkList;

                // �����폜����
                status = this._iOrderPointStDB.Delete(ref paraObj);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        # endregion

        #region ��������
        /// <summary>
        /// ��������(�����_�ݒ�}�X�^)
        /// </summary>
        /// <param name="orderPointStList">�����_�ݒ�}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����_�ݒ�}�X�^�𕜊����܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/04/23</br>
        /// </remarks>
        public int Revival(ref List<OrderPointSt> orderPointStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList orderPointStWorkList = new ArrayList();

                foreach (OrderPointSt orderPointSt in orderPointStList)
                {
                                        // UI�f�[�^�N���X�����[�N
                    OrderPointStWork orderPointStWork = CopyToOrderPointStWorkFromOrderPointSt(orderPointSt);

                    orderPointStWorkList.Add(orderPointStWork);
                }

                object paraObj = orderPointStWorkList;

                // �_���폜����
                status = this._iOrderPointStDB.RevivalLogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    orderPointStWorkList = paraObj as ArrayList;

                    orderPointStList.Clear();
                    foreach (OrderPointStWork orderPointStWork in orderPointStWorkList)
                    {
                        // ���[�N��UI�f�[�^�N���X
                        OrderPointSt orderPointSt = CopyToOrderPointStFromOrderPointStWork(orderPointStWork);

                        orderPointStList.Add(orderPointSt);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        # endregion

        # region -- �N���X�����o�[�R�s�[���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�����_�ݒ�}�X�^���[�N�N���X�˔����_�ݒ�}�X�^�N���X�j
        /// </summary>
        /// <param name="orderPointStWork">�����_�ݒ�}�X�^���[�N�N���X</param>
        /// <returns>�����_�ݒ�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �����_�ݒ�}�X�^���[�N�N���X���甭���_�ݒ�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.31</br>
        /// </remarks>
        private OrderPointSt CopyToOrderPointStFromOrderPointStWork(OrderPointStWork orderPointStWork)
        {
            OrderPointSt orderPointSt = new OrderPointSt();

            orderPointSt.CreateDateTime = orderPointStWork.CreateDateTime;
            orderPointSt.UpdateDateTime = orderPointStWork.UpdateDateTime;
            orderPointSt.EnterpriseCode = orderPointStWork.EnterpriseCode;
            orderPointSt.FileHeaderGuid = orderPointStWork.FileHeaderGuid;
            orderPointSt.UpdEmployeeCode = orderPointStWork.UpdEmployeeCode;
            orderPointSt.UpdAssemblyId1 = orderPointStWork.UpdAssemblyId1;
            orderPointSt.UpdAssemblyId2 = orderPointStWork.UpdAssemblyId2;
            orderPointSt.LogicalDeleteCode = orderPointStWork.LogicalDeleteCode;
            orderPointSt.PatterNo = orderPointStWork.PatterNo;
            orderPointSt.PatternNoDerivedNo = orderPointStWork.PatternNoDerivedNo;
            orderPointSt.WarehouseCode = orderPointStWork.WarehouseCode;
            orderPointSt.SupplierCd = orderPointStWork.SupplierCd;
            orderPointSt.GoodsMakerCd = orderPointStWork.GoodsMakerCd;
            orderPointSt.GoodsMGroup = orderPointStWork.GoodsMGroup;
            orderPointSt.BLGroupCode = orderPointStWork.BLGroupCode;
            orderPointSt.BLGoodsCode = orderPointStWork.BLGoodsCode;
            orderPointSt.StckShipMonthSt = orderPointStWork.StckShipMonthSt;
            orderPointSt.StckShipMonthEd = orderPointStWork.StckShipMonthEd;
            orderPointSt.OrderApplyDiv = orderPointStWork.OrderApplyDiv;
            orderPointSt.StockCreateDate = orderPointStWork.StockCreateDate;
            orderPointSt.ShipScopeMore = orderPointStWork.ShipScopeMore;
            orderPointSt.ShipScopeLess = orderPointStWork.ShipScopeLess;
            orderPointSt.MinimumStockCnt = orderPointStWork.MinimumStockCnt;
            orderPointSt.MaximumStockCnt = orderPointStWork.MaximumStockCnt;
            orderPointSt.SalesOrderUnit = orderPointStWork.SalesOrderUnit;
            orderPointSt.OrderPProcUpdFlg = orderPointStWork.OrderPProcUpdFlg;


            return orderPointSt;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�����_�ݒ�}�X�^�N���X�˔����_�ݒ�}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="orderPointSt">�����_�ݒ�}�X�^�N���X</param>
        /// <returns>�����_�ݒ�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �����_�ݒ�}�X�^�N���X���甭���_�ݒ�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.31</br>
        /// </remarks>
        private OrderPointStWork CopyToOrderPointStWorkFromOrderPointSt(OrderPointSt orderPointSt)
        {
            OrderPointStWork orderPointStWork = new OrderPointStWork();

            orderPointStWork.CreateDateTime = orderPointSt.CreateDateTime;
            orderPointStWork.UpdateDateTime = orderPointSt.UpdateDateTime;
            orderPointStWork.EnterpriseCode = orderPointSt.EnterpriseCode;
            orderPointStWork.FileHeaderGuid = orderPointSt.FileHeaderGuid;
            orderPointStWork.UpdEmployeeCode = orderPointSt.UpdEmployeeCode;
            orderPointStWork.UpdAssemblyId1 = orderPointSt.UpdAssemblyId1;
            orderPointStWork.UpdAssemblyId2 = orderPointSt.UpdAssemblyId2;
            orderPointStWork.LogicalDeleteCode = orderPointSt.LogicalDeleteCode;
            orderPointStWork.PatterNo = orderPointSt.PatterNo;
            orderPointStWork.PatternNoDerivedNo = orderPointSt.PatternNoDerivedNo;
            orderPointStWork.WarehouseCode = orderPointSt.WarehouseCode;
            orderPointStWork.SupplierCd = orderPointSt.SupplierCd;
            orderPointStWork.GoodsMakerCd = orderPointSt.GoodsMakerCd;
            orderPointStWork.GoodsMGroup = orderPointSt.GoodsMGroup;
            orderPointStWork.BLGroupCode = orderPointSt.BLGroupCode;
            orderPointStWork.BLGoodsCode = orderPointSt.BLGoodsCode;
            orderPointStWork.StckShipMonthSt = orderPointSt.StckShipMonthSt;
            orderPointStWork.StckShipMonthEd = orderPointSt.StckShipMonthEd;
            orderPointStWork.OrderApplyDiv = orderPointSt.OrderApplyDiv;
            orderPointStWork.StockCreateDate = orderPointSt.StockCreateDate;
            orderPointStWork.ShipScopeMore = orderPointSt.ShipScopeMore;
            orderPointStWork.ShipScopeLess = orderPointSt.ShipScopeLess;
            orderPointStWork.MinimumStockCnt = orderPointSt.MinimumStockCnt;
            orderPointStWork.MaximumStockCnt = orderPointSt.MaximumStockCnt;
            orderPointStWork.SalesOrderUnit = orderPointSt.SalesOrderUnit;
            orderPointStWork.OrderPProcUpdFlg = orderPointSt.OrderPProcUpdFlg;

            return orderPointStWork;
        }
        # endregion
    }
}
