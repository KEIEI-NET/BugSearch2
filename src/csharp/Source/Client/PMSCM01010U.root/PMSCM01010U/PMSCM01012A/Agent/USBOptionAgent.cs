//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/06/29  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11170206-00 �쐬�S�� : �ړ�
// �� �� ��  2016/01/13  �C�����e : Redmine#47845��Redmine#47847 2016�N2���z�M��
//                                : �t�^�o�q�Ɉ����ăI�v�V����  �i�ʁj�FOPT-CPM0100��ǉ�����
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// USB�̃I�v�V�����A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public sealed class USBOptionAgent
    {
        /// <summary>
        /// �I�v�V�����L���L���񋓌^
        /// </summary>
        public enum OptionFlag : int
        {
            /// <summary>����</summary>
            OFF = 0,
            /// <summary>�L��</summary>
            ON = 1,
        }

        // --- ADD 2016/01/13 �ړ� Redmine#47845��Redmine#47847 �t�^�o�q�Ɉ����ăI�v�V����  �i�ʁj�FOPT-CPM0100��ǉ����� ----->>>>>
        #region <�t�^�o�q�Ɉ����ăI�v�V����>

        /// <summary>�t�^�o�q�Ɉ����ăI�v�V����</summary>
        private int _futabaWarehAlloc = -1;
        /// <summary>�t�^�o�q�Ɉ����ăI�v�V�������擾���܂��B</summary>
        public int FutabaWarehAllocOption
        {
            get
            {
                if (_futabaWarehAlloc < 0)
                {
                    _futabaWarehAlloc = GetFutabaWarehAllocOption();
                }
                return _futabaWarehAlloc;
            }
        }

        /// <summary>
        /// �t�^�o�q�Ɉ����ăI�v�V�������L�������肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�L���ł��B<br/>
        /// <c>false</c>:�����ł��B
        /// </returns>
        public bool EnabledFutabaWarehAllocOption()
        {
            return FutabaWarehAllocOption.Equals((int)OptionFlag.ON);
        }

        /// <summary>
        /// �t�^�o�q�Ɉ����ăI�v�V�������擾���܂��B
        /// </summary>
        /// <returns>�t�^�o�q�Ɉ����ăI�v�V����</returns>
        private static int GetFutabaWarehAllocOption()
        {
            PurchaseStatus status = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaWarehAlloc
           );
            return status.Equals(PurchaseStatus.Contract) ? (int)OptionFlag.ON : (int)OptionFlag.OFF;
        }

        #endregion // </�t�^�o�q�Ɉ����ăI�v�V����>
        // --- ADD 2016/01/13 �ړ� Redmine#47845��Redmine#47847 �t�^�o�q�Ɉ����ăI�v�V����  �i�ʁj�FOPT-CPM0100��ǉ����� -----<<<<<

        #region <�ԗ��Ǘ��I�v�V����>

        /// <summary>�ԗ��Ǘ��I�v�V����</summary>
        private int _carManagementOption = -1;
        /// <summary>�ԗ��Ǘ��I�v�V�������擾���܂��B</summary>
        public int CarManagementOption
        {
            get
            {
                if (_carManagementOption < 0)
                {
                    _carManagementOption = GetCarManagementOption();
                }
                return _carManagementOption;
            }
        }

        /// <summary>
        /// �ԗ��Ǘ��I�v�V�������L�������肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�L���ł��B<br/>
        /// <c>false</c>:�����ł��B
        /// </returns>
        public bool EnabledCarManagementOption()
        {
            return CarManagementOption.Equals((int)OptionFlag.ON);
        }

        /// <summary>
        /// �ԗ��Ǘ��I�v�V�������擾���܂��B
        /// </summary>
        /// <remarks>MAHNB01012AD.cs SalesSlipInitDataAcs.CacheOptionInfo() 1886�s�ڂ��ڐA</remarks>
        /// <returns>�ԗ��Ǘ��I�v�V����</returns>
        private static int GetCarManagementOption()
        {
             PurchaseStatus status = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                 ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_CarMng
            );
            return status.Equals(PurchaseStatus.Contract) ? (int)OptionFlag.ON : (int)OptionFlag.OFF;
        }

        #endregion // </�ԗ��Ǘ��I�v�V����>

        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
        #region <BLP�Q�Ƒq�ɒǉ��I�v�V����>

        /// <summary>BLP�Q�Ƒq�ɒǉ��I�v�V����</summary>
        private int _BLPPriWarehouseOption = -1;
        /// <summary>BLP�Q�Ƒq�ɒǉ��I�v�V�������擾���܂��B</summary>
        public int BLPPriWarehouseOption
        {
            get
            {
                _BLPPriWarehouseOption = GetBLPPriWarehouseOption();
                return _BLPPriWarehouseOption;
            }
        }

        /// <summary>
        /// BLP�Q�Ƒq�ɒǉ��I�v�V�������L�������肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�L���ł��B<br/>
        /// <c>false</c>:�����ł��B
        /// </returns>
        public bool EnabledBLPPriWarehouseOption()
        {
            return BLPPriWarehouseOption.Equals((int)OptionFlag.ON);
        }
        /// <summary>
        /// BLP�Q�Ƒq�ɒǉ��I�v�V�������擾���܂��B
        /// </summary>
        /// <remarks></remarks>
        /// <returns>BLP�Q�Ƒq�ɒǉ��I�v�V����</returns>
        private static int GetBLPPriWarehouseOption()
        {
            PurchaseStatus status = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_BLPRefWarehouse
           );
            return status.Equals(PurchaseStatus.Contract) ? (int)OptionFlag.ON : (int)OptionFlag.OFF;
        }

        #endregion // </BLP�Q�Ƒq�ɒǉ��I�v�V����>

        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public USBOptionAgent() { }

        #endregion // </Constructor>
    }
}
