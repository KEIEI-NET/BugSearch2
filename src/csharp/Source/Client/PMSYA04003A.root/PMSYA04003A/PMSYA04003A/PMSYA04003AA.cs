//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�o�ו��i�\��
// �v���O�����T�v   : ���q�o�ו��i�\�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/09/10  �C�����e : �V�K�쐬
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


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���q�o�ו��i�\�������X�N���X
    /// </summary>
    /// <remarks>
    /// Note       : ���q�o�ו��i�\�������ł��B<br />
    /// Programmer : 杍^<br />
    /// Date       : 2009.09.10<br />
    /// </remarks>
    public class CarPartDisplayAcs
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private CarPartDisplayAcs()
        {

        }
        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region ��Properties
        /// <summary>
        /// ���q�o�ו��i�\������
        /// </summary>
        /// <returns>�d����ϊ��ݒ�A�N�Z�X�N���X �C���X�^���X</returns>
        /// <remarks>
        /// Note       : ���q�o�ו��i�\�������ł��B<br />
        /// Programmer : 杍^<br />
        /// Date       : 2009.09.10<br />
        /// </remarks>
        public static CarPartDisplayAcs GetInstance()
        {
            if (_carPartDisplayAcs == null)
            {
                _carPartDisplayAcs = new CarPartDisplayAcs();
            }

            return _carPartDisplayAcs;
        }
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members
        private static CarPartDisplayAcs _carPartDisplayAcs;
        ICarManagementDB _iCarManagementDB;
        ICarShipmentPartsDispDB _iCarShipmentPartsDispDB;
        # endregion

        // ===================================================================================== //
        // �p�u���b�N�C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��public Methods
        /// <summary>
        /// ���q�����\������
        /// </summary>
        /// <param name="carMngWorkObj">��������</param>
        /// <param name="carMngWorkListObj">��������</param>
        /// <returns>STATUS</returns>
        /// <remarks>		
        /// <br>Note		: ���q�����\���������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.09.10</br>
        /// </remarks>
        public int CarInfoSearch(object carMngWorkObj, ref object carMngWorkListObj)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            if (this._iCarManagementDB == null)
            {
                this._iCarManagementDB = MediationCarManagementDB.GetCarManagementDB();
            }

            status = this._iCarManagementDB.Search(ref carMngWorkListObj, carMngWorkObj, 0, ConstantManagement.LogicalMode.GetData0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        /// <summary>
        /// ���q���i�����\������
        /// </summary>
        /// <param name="carInfoConditionWorkWorkObj">��������</param>
        /// <param name="carMngWorkList">��������</param>
        /// <returns>STATUS</returns>
        /// <remarks>		
        /// <br>Note		: ���q���i�����\���������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.09.10</br>
        /// </remarks>
        public int CarPartsInfoSearch(object carInfoConditionWorkWorkObj, ref ArrayList carMngWorkList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            if (this._iCarShipmentPartsDispDB == null)
            {
                this._iCarShipmentPartsDispDB = MediationCarShipmentPartsDispDB.GetCarShipmentPartsDispDB();
            }

            status = this._iCarShipmentPartsDispDB.CarInfoSearch(ref carMngWorkList, carInfoConditionWorkWorkObj);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }
        #endregion
    }
}
