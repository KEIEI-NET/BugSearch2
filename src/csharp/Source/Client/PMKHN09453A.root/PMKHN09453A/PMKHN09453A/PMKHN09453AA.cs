//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ڕW�����ݒ�
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��  2009/07/07  �C�����e : PVCS#263 �Ώۊ��̓K�p���Z�o���@�s��                     
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �ڕW�����ݒ菈���X�N���X
    /// </summary>
    /// <remarks>
    /// Note       : �ڕW�����ݒ菈���ł��B<br />
    /// Programmer : 杍^<br />
    /// Date       : 2009.04.02<br />
    /// </remarks>
    public class ObjAutoSetAcs
    {
        #region �� Const Memebers ��
        private const string ALL_SECTIONCODE = "00";
        #endregion

        # region �� Constructor ��
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private ObjAutoSetAcs()
        {
            this._companyInfAcs = new CompanyInfAcs();
            _dateGet = DateGetAcs.GetInstance();
            _totalDayCalculator = TotalDayCalculator.GetInstance();
            this._objAutoSetControlDB = ObjAutoSetDB.GetObjAutoSetControlDB();
        }
        # endregion

        # region �� Private Members ��
        private static ObjAutoSetAcs _objAutoSetAcs;
        private CompanyInfAcs _companyInfAcs;
        private DateGetAcs _dateGet;
        private IObjAutoSetControlDB _objAutoSetControlDB;
        private TotalDayCalculator _totalDayCalculator;
        # endregion

        #region �� �ڕW�����ݒ�A�N�Z�X�N���X �C���X�^���X�擾���� ��
        /// <summary>
        /// �ڕW�����ݒ�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�ڕW�����ݒ�A�N�Z�X�N���X �C���X�^���X</returns>
        public static ObjAutoSetAcs GetInstance()
        {
            if (_objAutoSetAcs == null)
            {
                _objAutoSetAcs = new ObjAutoSetAcs();
            }

            return _objAutoSetAcs;
        }
        #endregion �� �ڕW�����ݒ�A�N�Z�X�N���X �C���X�^���X�擾���� ��

        #region �� �I�t���C����ԃ`�F�b�N���� ��

        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        public bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ���[�J���G���A�ڑ���Ԃɂ��I�����C������
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// �����[�g�ڑ��\����
        /// </summary>
        /// <returns>���茋��</returns>
        private bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // �C���^�[�l�b�g�ڑ��s�\���
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion �� �I�t���C����ԃ`�F�b�N���� ��

        #region �� ���s���� ��
        /// <summary>
        /// ��v�N�x�擾����
        /// <param name="yearMonth">��v�N�x</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��v�N�x�̎擾�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        public void GetCompanyInf(out List<DateTime> yearMonth)
        {
            List<DateTime> startMonthDate;
            List<DateTime> endMonthDate;
            // ���N �� 0 ���N��v�N�x�擾
            _dateGet.GetFinancialYearTable(0, out startMonthDate, out endMonthDate, out yearMonth);
        }

        /// <summary>
        /// ���ݏ����N���擾����
        /// <param name="yearMonth">���ݏ����N��</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       :���ݏ����N���̎擾�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        public void GetThisYearMonth(out DateTime yearMonth)
        {
            DateTime prevTotalDay = new DateTime();
            DateTime currentTotalDay = new DateTime();
            // MOD 杍^ 2009/07/07 --->>>
            //_dateGet.GetThisYearMonth(out yearMonth);
            // ������������擾
            _totalDayCalculator.InitializeHisMonthlyAccRec();
            // MOD 杍^ 2009/07/09 --->>>
            _totalDayCalculator.GetHisTotalDayMonthlyAccRec(string.Empty, out prevTotalDay, out currentTotalDay);
            // MOD 杍^ 2009/07/09 ---<<<
            if (currentTotalDay != DateTime.MinValue)
            {
                yearMonth = currentTotalDay;
            }
            else
            {
                // ���ݏ����N���擾
                DateTime nowYearMonth;
                _dateGet.GetThisYearMonth(out nowYearMonth);
                yearMonth = nowYearMonth;
            }
            // MOD 杍^ 2009/07/07 ---<<<
        }

        /// <summary>
        /// ���s����
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="objAutoSetWork">�h���b�v�_�E���f�[�^</param>
        /// <param name="yearMonth">��v�N�x</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���s�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>���s���ʃX�e�[�^�X</returns>
        public int ObjAutoSetProc(string enterpriseCode, string baseCode, ObjAutoSetWork objAutoSetWork, List<DateTime> yearMonth)
        {
            List<DateTime> pastStartMonthDate;
            List<DateTime> pastEndMonthDate;
            List<DateTime> pastYearMonth;

            List<DateTime> nowStartMonthDate;
            List<DateTime> nowEndMonthDate;
            List<DateTime> nowYearMonth;

            DateTime nowYearMonthDate = new DateTime();

            // �O����v�N�x������x�擾����B
            _dateGet.GetFinancialYearTable(-1, out pastStartMonthDate, out pastEndMonthDate, out pastYearMonth);
            // ������v�N�x������x�擾����B
            _dateGet.GetFinancialYearTable(0, out nowStartMonthDate, out nowEndMonthDate, out nowYearMonth);
            // ���ݏ����N���擾
            // MOD 杍^ 2009/07/07 --->>>
            //_dateGet.GetThisYearMonth(out nowYearMonthDate);
            this.GetThisYearMonth(out nowYearMonthDate);
            // MOD 杍^ 2009/07/07 ---<<<

            // ���Џ��ǂݍ���
            int status = this._objAutoSetControlDB.ObjAutoSetProc(enterpriseCode, baseCode, pastStartMonthDate, pastEndMonthDate, pastYearMonth,
                nowStartMonthDate, nowEndMonthDate, nowYearMonth, nowYearMonthDate, objAutoSetWork);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //CompanyBiginMonth = this._companyInf.CompanyBiginMonth;
            }
            return status;
        }
        #endregion
    }
}
