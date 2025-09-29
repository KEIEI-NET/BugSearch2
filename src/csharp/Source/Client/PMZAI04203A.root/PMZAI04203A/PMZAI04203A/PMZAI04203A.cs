using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �I���\���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �I���\���A�N�Z�X�N���X</br>
    /// <br>Programmer  : 30350 �N��@����</br>
    /// <br>Date        : 2008/11/17</br>
    /// <br>Update Note : 2014/03/05 �c����</br>
    /// <br>            : Redmine#42247 ����@�\�̒ǉ�</br>
    /// </remarks>
    public class InventoryDataDspAcs
    {
        #region Private Members

        private string _enterpriseCode;

        private IInventoryDtDspDB _iInventoryDtDspDB;

        #endregion Private Members


        #region Constructor

        /// <summary>
        /// �I���\���A�N�Z�X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �I���\���A�N�Z�X�N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : 30350 �N�� ����</br>
        /// <br>Date        : 2008/11/17</br>
        /// </remarks>
        public InventoryDataDspAcs()
		{
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iInventoryDtDspDB = (IInventoryDtDspDB)MediationInventoryDtDspDB.GetInventoryDtDspDB();

            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iInventoryDtDspDB = null;
            }

            // ��ƃR�[�h���擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="extrInfo">��������</param>
        /// <param name="updHisDspWorkList">�������ʃ��X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        public int Search(InventoryDataDspParam extrInfo, out List<InventoryDataDspResult> inventoryDataDspResultList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            inventoryDataDspResultList = new List<InventoryDataDspResult>();

            // �N���X�����o�R�s�[����(E��D)
            InventoryDataDspParamWork paraWork = CopyToInventoryDataDspParamWorkFromInventoryDataDspParam(extrInfo);
            
            ArrayList retList;
            object paraObj = paraWork;
            object retObj;

            try
            {
                status = this._iInventoryDtDspDB.Search(out retObj, paraObj);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    foreach (InventoryDataDspResultWork retWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        inventoryDataDspResultList.Add(CopyToInventoryDataDspResultFromInventoryDataDspResultWork(retWork));
                    }
                }
            }
            catch
            {
                status = -1;
                inventoryDataDspResultList = new List<InventoryDataDspResult>();
            }

            return (status);
        }

        #endregion Public Methods


        #region Private Methods

        /// <summary>
        /// �N���X�����o�R�s�[����(E��D)
        /// </summary>
        /// <param name="para">�o�ו��i�\�������N���X</param>
        /// <returns>�o�ו��i�\���������[�N�N���X</returns>
        private InventoryDataDspParamWork CopyToInventoryDataDspParamWorkFromInventoryDataDspParam(InventoryDataDspParam para)
        {
            InventoryDataDspParamWork paraWork = new InventoryDataDspParamWork();

            paraWork.EnterpriseCode = para.EnterpriseCode;
            paraWork.GoodsMakerCd = para.GoodsMakerCd;
            paraWork.WarehouseDiv = para.WarehouseDiv;
            paraWork.StWarehouseCode = para.StWarehouseCode;
            paraWork.EdWarehouseCode = para.EdWarehouseCode;
            paraWork.WarehouseCd01 = para.WarehouseCd01;
            paraWork.WarehouseCd02 = para.WarehouseCd02;
            paraWork.WarehouseCd03 = para.WarehouseCd03;
            paraWork.WarehouseCd04 = para.WarehouseCd04;
            paraWork.WarehouseCd05 = para.WarehouseCd05;
            paraWork.WarehouseCd06 = para.WarehouseCd06;
            paraWork.WarehouseCd07 = para.WarehouseCd07;
            paraWork.WarehouseCd08 = para.WarehouseCd08;
            paraWork.WarehouseCd09 = para.WarehouseCd09;
            paraWork.WarehouseCd10 = para.WarehouseCd10;
            paraWork.ListDiv = para.ListDiv2;
            paraWork.ListTypeDiv = para.ListTypeDiv;

            return paraWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(D��E)
        /// </summary>
        /// <param name="retWork">�o�ו��i�\�����ʃ��[�N�N���X</param>
        /// <returns>�o�ו��i�\�����ʃN���X</returns>
        /// <remarks>
        /// <br>Update Note : 2014/03/05 �c����</br>
        /// <br>            : Redmine#42247 ����@�\�̒ǉ�</br>
        /// </remarks>
        private InventoryDataDspResult CopyToInventoryDataDspResultFromInventoryDataDspResultWork(InventoryDataDspResultWork retWork)
        {
            InventoryDataDspResult ret = new InventoryDataDspResult();

            ret.EnterpriseCode = retWork.EnterpriseCode;
            ret.WarehouseName = retWork.WarehouseName;
            ret.InventoryItemCnt = retWork.InventoryItemCnt;
            ret.InventoryMony = retWork.InventoryMoney;
            ret.MaximuminventoryMony = retWork.MaximumInventoryMoney;
            ret.WarehouseCode = retWork.WarehouseCode; // ADD 2014/03/05 �c���� Redmine#42247

            return ret;
        }

        #endregion Private Methods
    }
}
