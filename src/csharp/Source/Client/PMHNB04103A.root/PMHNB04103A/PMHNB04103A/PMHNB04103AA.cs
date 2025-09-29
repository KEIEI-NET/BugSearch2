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
    /// �o�ו��i�\���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �o�ו��i�\���A�N�Z�X�N���X</br>
    /// <br>Programmer  : 30414 �E �K�j</br>
    /// <br>Date        : 2008/11/10</br>
    /// </remarks>
    public class ShipmentPartsDspAcs
    {
        #region Private Members

        private string _enterpriseCode;

        private ISPartsDspDB _iSPartsDspDB;

        #endregion Private Members


        #region Constructor

        /// <summary>
        /// �o�ו��i�\���A�N�Z�X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �o�ו��i�\���A�N�Z�X�N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        public ShipmentPartsDspAcs()
		{
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iSPartsDspDB = (ISPartsDspDB)MediationSPartsDspDB.GetSPartsDspDB();

            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iSPartsDspDB = null;
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
        public int Search(ShipmentPartsDspParam extrInfo, out List<ShipmentPartsDspResult> shipmentPartsDspResultList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            shipmentPartsDspResultList = new List<ShipmentPartsDspResult>();

            // �N���X�����o�R�s�[����(E��D)
            ShipmentPartsDspParamWork paraWork = CopyToShipmentPartsDspParamWorkFromShipmentPartsDspParam(extrInfo);
            
            ArrayList retList;
            object paraObj = paraWork;
            object retObj;

            try
            {
                status = this._iSPartsDspDB.Search(out retObj, paraObj);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    foreach (ShipmentPartsDspResultWork retWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        shipmentPartsDspResultList.Add(CopyToShipmentPartsDspResultFromShipmentPartsDspResultWork(retWork));
                    }
                }
            }
            catch
            {
                status = -1;
                shipmentPartsDspResultList = new List<ShipmentPartsDspResult>();
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
        private ShipmentPartsDspParamWork CopyToShipmentPartsDspParamWorkFromShipmentPartsDspParam(ShipmentPartsDspParam para)
        {
            ShipmentPartsDspParamWork paraWork = new ShipmentPartsDspParamWork();

            paraWork.EnterpriseCode = para.EnterpriseCode;
            paraWork.SectionCode = para.SectionCode;
            paraWork.StAddUpYearMonth = TDateTime.DateTimeToLongDate("YYYYMM", para.StAddUpYearMonth);
            paraWork.EdAddUpYearMonth = TDateTime.DateTimeToLongDate("YYYYMM", para.EdAddUpYearMonth);

            return paraWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(D��E)
        /// </summary>
        /// <param name="retWork">�o�ו��i�\�����ʃ��[�N�N���X</param>
        /// <returns>�o�ו��i�\�����ʃN���X</returns>
        private ShipmentPartsDspResult CopyToShipmentPartsDspResultFromShipmentPartsDspResultWork(ShipmentPartsDspResultWork retWork)
        {
            ShipmentPartsDspResult ret = new ShipmentPartsDspResult();

            ret.EnterpriseCode = retWork.EnterpriseCode;
            ret.RsltTtlDivCd = retWork.RsltTtlDivCd;
            ret.SalesTimes = retWork.SalesTimes;
            ret.SalesMoney = retWork.SalesMoney;
            ret.GrossProfit = retWork.GrossProfit;

            return ret;
        }

        #endregion Private Methods
    }
}
