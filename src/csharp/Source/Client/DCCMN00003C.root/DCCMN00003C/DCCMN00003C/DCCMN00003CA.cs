using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting.ParamData;


namespace Broadleaf.Application.Common
{
    /// <summary>
    /// ���t�擾���i�i���t�擾�A�N�Z�X�N���X�j
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Аݒ�}�X�^���A�e����t���擾����N���X�ł��B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2008.01.23</br>
    /// <br></br>
    /// <br>Update Note: 2008.05.30 ��� ���b</br>
    /// <br>               �@PM.NS�����ύX�B</br>
    /// <br>                 �����̃R�A�@�\��PMCMN00006C�Ɉڂ��A�{���i��UI�����@�\�Ɍ��肷��B</br>
    /// <br>                 �{���i�������[�gPG����Ăяo�����͋֎~����B</br>
    /// </remarks>
    public class DateGetAcs
    {
        /// <summary>
        /// singleton �C���X�^���X
        /// </summary>
        private static DateGetAcs stc_DateGetAcs;

        /// <summary>
        /// ��v�N�x�e�[�u���擾����
        /// </summary>
        private FinYearTableGenerator _finYearTableGenerator;

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        private DateGetAcs()
        {
            // ��ƃR�[�h�擾
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���Аݒ�}�X�^�ǂݍ���
            CompanyInfAcs companyInfAcs = new CompanyInfAcs();
            companyInfAcs.Read( out _companyInf, _enterpriseCode );
            _finYearTableGenerator = new FinYearTableGenerator( CopyToWorkFromCompanyInf( _companyInf ) );

            // �N�����̋敪���X�g
            _yearOnlyList = new List<emDateFormat>();
            _yearOnlyList.AddRange( new emDateFormat[] { emDateFormat.df2Y, emDateFormat.df4Y, emDateFormat.dfG2Y } );
            // �N�������̋敪���X�g
            _monthOnlyList = new List<emDateFormat>();
            _monthOnlyList.AddRange( new emDateFormat[] { emDateFormat.df2M, emDateFormat.df2Y2M, emDateFormat.df4Y2M, emDateFormat.dfG2Y2M } );
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>���Аݒ�N���X</summary>
        private CompanyInf _companyInf;
        /// <summary>�N�����̋敪���X�g</summary>
        List<emDateFormat> _yearOnlyList;
        /// <summary>�N�������̋敪���X�g</summary>
        List<emDateFormat> _monthOnlyList;
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        #endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region Public Methods

        # region [���t�擾����]

        # region �� �C���X�^���X�擾���� ��
        /// <summary>
        /// �C���X�^���X�擾����
        /// </summary>
        /// <returns>DateGetAcs��singleton�̃C���X�^���X</returns>
        public static DateGetAcs GetInstance()
        {
            if ( stc_DateGetAcs == null )
            {
                stc_DateGetAcs = new DateGetAcs();
            }
            return stc_DateGetAcs;
        }
        # endregion �� �C���X�^���X�擾���� ��


        # region �� ���Аݒ�N���X�擾 ��
        /// <summary>
        /// ���Аݒ�N���X�擾����
        /// </summary>
        /// <returns>���t�擾���i���g�p���Ă��鎩�Аݒ�N���X�C���X�^���X</returns>
        public CompanyInf GetCompanyInf()
        {
            return _companyInf;
        }
        # endregion �� ���Аݒ�N���X�擾 ��

        # region �� ���Аݒ�}�X�^�Ď擾���� ��
        /// <summary>
        /// ���Аݒ�}�X�^�Ď擾����
        /// </summary>
        /// <remarks>�����[�g�Ăяo���ɂ��A���Аݒ�}�X�^���ēx�擾���܂��B</remarks>
        public void ReloadCompanyInf()
        {
            // ���Аݒ�}�X�^�ǂݍ���
            CompanyInfAcs companyInfAcs = new CompanyInfAcs();
            companyInfAcs.Read( out _companyInf, _enterpriseCode );

            _finYearTableGenerator = new FinYearTableGenerator( CopyToWorkFromCompanyInf( _companyInf ) );
        }
        # endregion �� ���Аݒ�}�X�^�Ď擾���� ��


        # region �� ��v�N�x�e�[�u���擾 ��
        /// <summary>
        /// ��v�N�x�e�[�u���擾����
        /// </summary>
        /// <param name="startMonthDate">(�o��)���x�J�n�����X�g</param>
        /// <param name="endMonthDate">(�o��)���x�I�������X�g</param>
        /// <remarks>���N�̌��x�J�n���E�I���������擾���܂��B</remarks>
        public void GetFinancialYearTable( out List<DateTime> startMonthDate, out List<DateTime> endMonthDate )
        {
            _finYearTableGenerator.GetFinancialYearTable( out startMonthDate, out endMonthDate );
        }
        /// <summary>
        /// ��v�N�x�e�[�u���擾����
        /// </summary>
        /// <param name="startMonthDate">(�o��)���x�J�n�����X�g</param>
        /// <param name="endMonthDate">(�o��)���x�I�������X�g</param>
        /// <param name="yearMonth">(�o��)���x���X�g</param>
        /// <remarks>���N�̌��x�J�n���E�I�����E�N���x�����擾���܂��B</remarks>
        public void GetFinancialYearTable( out List<DateTime> startMonthDate, out List<DateTime> endMonthDate, out List<DateTime> yearMonth )
        {
            _finYearTableGenerator.GetFinancialYearTable( out startMonthDate, out endMonthDate, out yearMonth );
        }
        /// <summary>
        /// ��v�N�x�e�[�u���擾����
        /// </summary>
        /// <param name="addYearFromThis">���N����̔N�x����</param>
        /// <param name="startMonthDate">(�o��)���x�J�n�����X�g</param>
        /// <param name="endMonthDate">(�o��)���x�I�������X�g</param>
        /// <param name="yearMonth">(�o��)���x���X�g</param>
        /// <remarks>���N����w��N����̌��x�J�n���E�I�����E�N���x�����擾���܂��B</remarks>
        public void GetFinancialYearTable( int addYearFromThis, out List<DateTime> startMonthDate, out List<DateTime> endMonthDate, out List<DateTime> yearMonth )
        {
            _finYearTableGenerator.GetFinancialYearTable( addYearFromThis, out startMonthDate, out endMonthDate, out yearMonth );
        }
        /// <summary>
        /// ��v�N�x�e�[�u���擾����
        /// </summary>
        /// <param name="addYearFromThis">���N����̔N�x����</param>
        /// <param name="startMonthDate">(�o��)���x�J�n�����X�g</param>
        /// <param name="endMonthDate">(�o��)���x�I�������X�g</param>
        /// <param name="yearMonth">(�o��)���x���X�g</param>
        /// <param name="year">(�o��)�Ώ۔N�x</param>
        /// <remarks>���N����w��N����̌��x�J�n���E�I�����E�N���x���ƔN�x���擾���܂��B</remarks>
        public void GetFinancialYearTable( int addYearFromThis, out List<DateTime> startMonthDate, out List<DateTime> endMonthDate, out List<DateTime> yearMonth, out int year )
        {
            _finYearTableGenerator.GetFinancialYearTable( addYearFromThis, out startMonthDate, out endMonthDate, out yearMonth, out year );
        }
        /// <summary>
        /// ��v�N�x�e�[�u���擾����
        /// </summary>
        /// <param name="year">�w��N�x</param>
        /// <param name="startMonthDate">(�o��)���x�J�n�����X�g</param>
        /// <param name="endMonthDate">(�o��)���x�I�������X�g</param>
        /// <param name="yearMonth">(�o��)���x���X�g</param>
        /// <remarks>�w��N�x�̌��x�J�n���E�I�����E�N���x�����擾���܂��B</remarks>
        public void GetFinancialYearTable( DateTime year, out List<DateTime> startMonthDate, out List<DateTime> endMonthDate, out List<DateTime> yearMonth )
        {
            _finYearTableGenerator.GetFinancialYearTable( year, out startMonthDate, out endMonthDate, out yearMonth );
        }
        # endregion �� ��v�N�x�e�[�u���擾 ��

        # region �� ��v�N�x�����擾 ��
        /// <summary>
        /// ��v�N�x�����擾
        /// </summary>
        /// <param name="startMonthDate">(�o��)���x�J�n��</param>
        /// <param name="endMonthDate">(�o��)���x�I����</param>
        /// <remarks>���N�̉�v�N�x�������̊J�n���E�I�������擾���܂��B</remarks>
        public void GetLastMonth( out DateTime startMonthDate, out DateTime endMonthDate )
        {
            _finYearTableGenerator.GetLastMonth( out startMonthDate, out endMonthDate );
        }
        /// <summary>
        /// ��v�N�x�����擾
        /// </summary>
        /// <param name="startMonthDate">(�o��)���x�J�n��</param>
        /// <param name="endMonthDate">(�o��)���x�I����</param>
        /// <param name="yearMonth">(�o��)�N���x</param>
        /// <remarks>���N�̉�v�N�x�������̊J�n���E�I�����E�N���x���擾���܂��B</remarks>
        public void GetLastMonth( out DateTime startMonthDate, out DateTime endMonthDate, out DateTime yearMonth )
        {
            _finYearTableGenerator.GetLastMonth( out startMonthDate, out endMonthDate, out yearMonth );
        }
        /// <summary>
        /// ��v�N�x�����擾
        /// </summary>
        /// <param name="addYearFromThis">���N����̔N�x����</param>
        /// <param name="startMonthDate">(�o��)���x�J�n��</param>
        /// <param name="endMonthDate">(�o��)���x�I����</param>
        /// <param name="yearMonth">(�o��)�N���x</param>
        /// <remarks>���N����w��N����̉�v�N�x�������̊J�n���E�I�����E�N���x���擾���܂��B</remarks>
        public void GetLastMonth( int addYearFromThis, out DateTime startMonthDate, out DateTime endMonthDate, out DateTime yearMonth )
        {
            _finYearTableGenerator.GetLastMonth( addYearFromThis, out startMonthDate, out endMonthDate, out yearMonth );
        }
        /// <summary>
        /// ��v�N�x�����擾
        /// </summary>
        /// <param name="addYearFromThis">���N����̔N�x����</param>
        /// <param name="startMonthDate">(�o��)���x�J�n��</param>
        /// <param name="endMonthDate">(�o��)���x�I����</param>
        /// <param name="yearMonth">(�o��)�N���x</param>
        /// <param name="year">(�o��)�N�x</param>
        /// <remarks>���N����w��N����̉�v�N�x�������̊J�n���E�I�����E�N���x����єN�x���擾���܂��B</remarks>
        public void GetLastMonth( int addYearFromThis, out DateTime startMonthDate, out DateTime endMonthDate, out DateTime yearMonth, out int year )
        {
            _finYearTableGenerator.GetLastMonth( addYearFromThis, out startMonthDate, out endMonthDate, out yearMonth, out year );
        }
        # endregion �� ��v�N�x�����擾 ��

        # region �� �w����t���܂ޔN�x�E�N���x�̎擾 ��
        /// <summary>
        /// �w����t���܂ޔN�x�E�N���x�̎擾
        /// </summary>
        /// <param name="dateTime">�w����t</param>
        /// <param name="yearMonth">(�o��)�N���x</param>
        /// <remarks>�w����t���܂ޔN���x���擾���܂��B</remarks>
        public void GetYearMonth( DateTime dateTime, out DateTime yearMonth )
        {
            _finYearTableGenerator.GetYearMonth( dateTime, out yearMonth );
        }
        /// <summary>
        /// �w����t���܂ޔN�x�E�N���x�̎擾
        /// </summary>
        /// <param name="dateTime">�w����t</param>
        /// <param name="yearMonth">(�o��)�N���x</param>
        /// <param name="year">(�o��)�N�x</param>
        /// <remarks>�w����t���܂ޔN���x�E�N�x���擾���܂��B</remarks>
        public void GetYearMonth( DateTime dateTime, out DateTime yearMonth, out int year )
        {
            _finYearTableGenerator.GetYearMonth( dateTime, out yearMonth, out year );
        }
        /// <summary>
        /// �w����t���܂ޔN�x�E�N���x�̎擾
        /// </summary>
        /// <param name="dateTime">�w����t</param>
        /// <param name="yearMonth">(�o��)�N���x</param>
        /// <param name="year">(�o��)�N�x</param>
        /// <param name="startMonthDate">(�o��)�N���x�J�n��</param>
        /// <param name="endMonthDate">(�o��)�N���x�I����</param>
        /// <remarks>�w����t���܂ޔN���x�E�N�x�E�N���x�J�n���E�N���x�I�������擾���܂��B</remarks>
        public void GetYearMonth( DateTime dateTime, out DateTime yearMonth, out int year, out DateTime startMonthDate, out DateTime endMonthDate )
        {
            _finYearTableGenerator.GetYearMonth( dateTime, out yearMonth, out year, out startMonthDate, out endMonthDate );
        }
        /// <summary>
        /// �w����t���܂ޔN�x�E�N���x�̎擾
        /// </summary>
        /// <param name="dateTime">�w����t</param>
        /// <param name="yearMonth">(�o��)�N���x</param>
        /// <param name="year">(�o��)�N�x</param>
        /// <param name="startMonthDate">(�o��)�N���x�J�n��</param>
        /// <param name="endMonthDate">(�o��)�N���x�I����</param>
        /// <param name="startYearDate">(�o��)�N�x�J�n��</param>
        /// <param name="endYearDate">(�o��)�N�x�I����</param>
        /// <remarks>�w����t���܂ޔN���x�E�N�x�E���x�J�n���E���x�I�����E�N�x�J�n���E�N�x�I�������擾���܂��B</remarks>
        public void GetYearMonth( DateTime dateTime, out DateTime yearMonth, out int year, out DateTime startMonthDate, out DateTime endMonthDate, out DateTime startYearDate, out DateTime endYearDate )
        {
            _finYearTableGenerator.GetYearMonth( dateTime, out yearMonth, out year, out startMonthDate, out endMonthDate, out startYearDate, out endYearDate );
        }
        # endregion �� �w����t���܂ޔN�x�E�N���x�̎擾 ��

        # region �� ���ݏ����N���̎擾 ��
        /// <summary>
        /// ���ݏ����N���̎擾
        /// </summary>
        /// <param name="yearMonth">(�o��)�N���x</param>
        /// <remarks>���ݏ����N���x���擾���܂��B</remarks>
        public void GetThisYearMonth( out DateTime yearMonth )
        {
            _finYearTableGenerator.GetThisYearMonth( out yearMonth );
        }
        /// <summary>
        /// ���ݏ����N���̎擾
        /// </summary>
        /// <param name="yearMonth">(�o��)�N���x</param>
        /// <param name="year">(�o��)�N�x</param>
        /// <remarks>���ݏ����N���̔N���x�E�N�x���擾���܂��B</remarks>
        public void GetThisYearMonth( out DateTime yearMonth, out int year )
        {
            _finYearTableGenerator.GetThisYearMonth( out yearMonth, out year );
        }
        /// <summary>
        /// ���ݏ����N���̎擾
        /// </summary>
        /// <param name="yearMonth">(�o��)�N���x</param>
        /// <param name="year">(�o��)�N�x</param>
        /// <param name="startMonthDate">(�o��)�N���x�J�n��</param>
        /// <param name="endMonthDate">(�o��)�N���x�I����</param>
        /// <remarks>���ݏ����N���̔N���x�E�N�x�E���x�J�n���E���x�I�������擾���܂��B</remarks>
        public void GetThisYearMonth( out DateTime yearMonth, out int year, out DateTime startMonthDate, out DateTime endMonthDate )
        {
            _finYearTableGenerator.GetThisYearMonth( out yearMonth, out year, out startMonthDate, out endMonthDate );
        }
        /// <summary>
        /// ���ݏ����N���̎擾
        /// </summary>
        /// <param name="yearMonth">(�o��)�N���x</param>
        /// <param name="year">(�o��)�N�x</param>
        /// <param name="startMonthDate">(�o��)�N���x�J�n��</param>
        /// <param name="endMonthDate">(�o��)�N���x�I����</param>
        /// <param name="startYearDate">(�o��)�N�x�J�n��</param>
        /// <param name="endYearDate">(�o��)�N�x�I����</param>
        /// <remarks>���ݏ����N���̔N���x�E�N�x�E���x�J�n���E���x�I�����E�N�x�J�n���E�N�x�I�������擾���܂��B</remarks>
        public void GetThisYearMonth( out DateTime yearMonth, out int year, out DateTime startMonthDate, out DateTime endMonthDate, out DateTime startYearDate, out DateTime endYearDate )
        {
            _finYearTableGenerator.GetThisYearMonth( out yearMonth, out year, out startMonthDate, out endMonthDate, out startYearDate, out endYearDate );
        }
        # endregion �� ���ݏ����N���̎擾 ��


        # region �� �W�v���Ԏ擾 ��
        /// <summary>
        /// �W�v���Ԏ擾
        /// </summary>
        /// <param name="procModeDiv">�����敪</param>
        /// <param name="ymdRange">����܂߂��͈�</param>
        /// <param name="startDate">(�o��)�J�n�@���t/���x/�N�x</param>
        /// <param name="endDate">(�o��)�I���@���t/���x/�N�x</param>
        /// <remarks>
        /// �����敪�Ɣ͈͂ɏ]���A�J�n���t�E�I�����t���擾���܂��B<br/>
        /// �EprocModeDiv = PastYears : �ߋ����N�i�J�n�N�`�I���N�j<br/>
        /// �EprocModeDiv = PastMonth : �ߋ����J���i�J�n���`�I�����j<br/>
        /// �EprocModeDiv = PastDays  : �ߋ������i�J�n���`�I�����j<br/>
        /// �EprocModeDiv = PastYears : ���㐔�N�i�J�n�N�`�I���N�j<br/>
        /// �EprocModeDiv = PastMonth : ���㐔�J���i�J�n���`�I�����j<br/>
        /// �EprocModeDiv = PastDays  : ���㐔���i�J�n���`�I�����j<br/>
        /// </remarks>
        public void GetPeriod( ProcModeDivState procModeDiv, int ymdRange, out DateTime startDate, out DateTime endDate )
        {
            // �w�肷�����t(baseDate)
            DateTime baseDate;

            // �����N�����擾
            DateTime yearMonth;
            int year;
            GetThisYearMonth( out yearMonth, out year );

            if ( procModeDiv == ProcModeDivState.PastYears || procModeDiv == ProcModeDivState.FutureYears )
            {
                // ���N�x
                baseDate = new DateTime( year, 1, 1 );
            }
            else if ( procModeDiv == ProcModeDivState.PastMonths || procModeDiv == ProcModeDivState.FutureMonths )
            {
                // �����x
                baseDate = yearMonth;
            }
            else
            {
                // �����F�V�X�e�����t
                baseDate = DateTime.Today;
            }

            // �W�v���Ԏ擾
            GetPeriod( procModeDiv, baseDate, ymdRange, out startDate, out endDate );
        }
        /// <summary>
        /// �W�v���Ԏ擾
        /// </summary>
        /// <param name="procModeDiv">�����敪</param>
        /// <param name="baseDate">��@���t/���x/�N�x</param>
        /// <param name="ymdRange">����܂߂��͈�</param>
        /// <param name="startDate">(�o��)�J�n�@���t/���x/�N�x</param>
        /// <param name="endDate">(�o��)�I���@���t/���x/�N�x</param>
        /// <remarks>
        /// �����敪�Ɣ͈͂ɏ]���A�J�n���t�E�I�����t���擾���܂��B<br/>
        /// �EprocModeDiv = PastYears : �ߋ����N�i�J�n�N�`�I���N�j<br/>
        /// �EprocModeDiv = PastMonth : �ߋ����J���i�J�n���`�I�����j<br/>
        /// �EprocModeDiv = PastDays  : �ߋ������i�J�n���`�I�����j<br/>
        /// �EprocModeDiv = PastYears : ���㐔�N�i�J�n�N�`�I���N�j<br/>
        /// �EprocModeDiv = PastMonth : ���㐔�J���i�J�n���`�I�����j<br/>
        /// �EprocModeDiv = PastDays  : ���㐔���i�J�n���`�I�����j<br/>
        /// </remarks>
        public void GetPeriod( ProcModeDivState procModeDiv, DateTime baseDate, int ymdRange, out DateTime startDate, out DateTime endDate )
        {
            // ������
            startDate = DateTime.MinValue;
            endDate = DateTime.MinValue;


            // �����敪�ɏ]����������
            # region [�����敪���̏���]
            switch ( procModeDiv )
            {
                // �ߋ����N
                case ProcModeDivState.PastYears:
                    {
                        // �I���N
                        endDate = new DateTime( baseDate.Year, 1, 1 );

                        // �J�n�N
                        startDate = endDate.AddYears( -1 * (ymdRange - 1) );
                    }
                    break;
                // �ߋ�����
                case ProcModeDivState.PastMonths:
                    {
                        // �I����
                        endDate = new DateTime( baseDate.Year, baseDate.Month, 1 );

                        // �J�n��
                        startDate = endDate.AddMonths( -1 * (ymdRange - 1) );
                    }
                    break;
                // �ߋ�����
                case ProcModeDivState.PastDays:
                    {
                        // �I����
                        endDate = baseDate.Date;

                        // �J�n��
                        startDate = endDate.AddDays( -1 * (ymdRange - 1) );
                    }
                    break;
                // ���㐔�N
                case ProcModeDivState.FutureYears:
                    {
                        // �J�n�N
                        startDate = new DateTime( baseDate.Year, 1, 1 );

                        // �I���N
                        endDate = startDate.AddYears( (ymdRange - 1) );
                    }
                    break;
                // ���㐔��
                case ProcModeDivState.FutureMonths:
                    {
                        // �J�n��
                        startDate = new DateTime( baseDate.Year, baseDate.Month, 1 );

                        // �I����
                        endDate = startDate.AddMonths( (ymdRange - 1) );
                    }
                    break;
                // ���㐔��
                case ProcModeDivState.FutureDays:
                    {
                        // �J�n��
                        startDate = baseDate.Date;

                        // �I����
                        endDate = startDate.AddDays( (ymdRange - 1) );
                    }
                    break;
            }
            # endregion
        }
        # endregion �� �W�v���Ԏ擾 ��


        # region �� �N���x����̔N�x���̎擾 ��
        /// <summary>
        /// �N���x����̔N�x���̎擾
        /// </summary>
        /// <param name="yearMonth">�N���x</param>
        /// <param name="year">(�o��)�N�x</param>
        /// <param name="addYearsFromThis">(�o��)���N����̔N�x����</param>
        /// <remarks>
        /// �w��N���x���܂ޔN�x�ƁA���̔N�x�̓��N����̍������擾���܂��B<br/>
        /// </remarks>
        public void GetYearFromMonth( DateTime yearMonth, out int year, out int addYearsFromThis )
        {
            _finYearTableGenerator.GetYearFromMonth( yearMonth, out year, out addYearsFromThis );
        }
        /// <summary>
        /// �N���x����̔N�x���̎擾
        /// </summary>
        /// <param name="yearMonth">�N���x</param>
        /// <param name="year">(�o��)�N�x</param>
        /// <param name="addYearsFromThis">(�o��)���N����̔N�x����</param>
        /// <param name="startYearMonth">(�o��)�N�x�@�J�n�N���x</param>
        /// <param name="endYearMonth">(�o��)�N�x�@�I���N���x</param>
        /// <remarks>
        /// �w��N���x���܂ޔN�x�E�N�x�̓��N����̍����E�N�x�J�n���x�E�N�x�I�����x���擾���܂��B<br/>
        /// </remarks>
        public void GetYearFromMonth( DateTime yearMonth, out int year, out int addYearsFromThis, out DateTime startYearMonth, out DateTime endYearMonth )
        {
            _finYearTableGenerator.GetYearFromMonth( yearMonth, out year, out addYearsFromThis, out startYearMonth, out endYearMonth );
        }
        # endregion �� �N���x����̔N�x���̎擾 ��

        # region �� �N���x����̓��t�͈͂̎擾 ��
        /// <summary>
        /// �N���x����̓��t�͈͂̎擾
        /// </summary>
        /// <param name="yearMonth">�N���x</param>
        /// <param name="startMonthDate">(�o��)���x�J�n��</param>
        /// <param name="endMonthDate">(�o��)���x�I����</param>
        /// <remarks>
        /// �w��N���x�̌��x�J�n���E���x�I�������擾���܂��B<br/>
        /// </remarks>
        public void GetDaysFromMonth( DateTime yearMonth, out DateTime startMonthDate, out DateTime endMonthDate )
        {
            _finYearTableGenerator.GetDaysFromMonth( yearMonth, out startMonthDate, out endMonthDate );
        }
        # endregion �� �N���x����̓��t�͈͂̎擾 ��

        # endregion

        # region [���t�`�F�b�N����]

        # region �� ���t�͈͓��̓`�F�b�N���� ��
        /// <summary>
        /// ���t�͈͓��̓`�F�b�N����
        /// </summary>
        /// <param name="rangeType">�͈͎w��^�C�v</param>
        /// <param name="ymdRange">�͈�</param>
        /// <param name="inputType">���̓^�C�v</param>
        /// <param name="startDate">�J�n��</param>
        /// <param name="endDate">�I����</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// �J�n���t�E�I�����t�̑召�`�F�b�N�E�w��͈͊O�`�F�b�N���s���܂��B<br/>
        /// </remarks>
        public CheckPeriodResult CheckPeriod( YmdType rangeType, int ymdRange, YmdType inputType, DateTime startDate, DateTime endDate )
        {
            return (CheckPeriodResult)(int)_finYearTableGenerator.CheckPeriod( (FinYearTableGenerator.YmdTypeCmn)(int)rangeType, ymdRange, (FinYearTableGenerator.YmdTypeCmn)(int)inputType, startDate, endDate );
        }
        # endregion �� ���t�͈͓��̓`�F�b�N���� ��
        # region �� ���t�͈͓��̓`�F�b�N�����i�@�\����j ��
        /// <summary>
        /// �J�n�`�I�����t��(���В��ߊ֌W�Ȃ�)�w�茎�����Ɏ��܂��Ă��邩����
        /// </summary>
        /// <param name="months">����</param>
        /// <param name="startDate">�J�n���t</param>
        /// <param name="endDate">�I�����t</param>
        /// <returns>true:�͈͓� / false:�͈͊O</returns>
        /// <remarks>
        /// �J�n�`�I�����t��(���В��ߊ֌W�Ȃ�)�w�茎�����Ɏ��܂��Ă��邩���肵�܂��B<br/>
        /// </remarks>
        public bool CheckPeriodDaysOnMonths( int months, DateTime startDate, DateTime endDate )
        {
            return _finYearTableGenerator.CheckPeriodDaysOnMonths( months, startDate, endDate );
        }
        /// <summary>
        /// �J�n�`�I���N����(���В��ߊ֌W�Ȃ�)�w�茎�����Ɏ��܂��Ă��邩����
        /// </summary>
        /// <param name="months">����</param>
        /// <param name="startMonth">�J�n�N��</param>
        /// <param name="endMonth">�I���N��</param>
        /// <returns>true:�͈͓� / false:�͈͊O</returns>
        /// <remarks>
        /// �J�n�`�I������(���В��ߊ֌W�Ȃ�)�w�茎�����Ɏ��܂��Ă��邩���肵�܂��B<br/>
        /// </remarks>
        public bool CheckPeriodMonthsOnMonths( int months, DateTime startMonth, DateTime endMonth )
        {
            return _finYearTableGenerator.CheckPeriodMonthsOnMonths( months, startMonth, endMonth );
        }
        /// <summary>
        /// �J�n�`�I���N�x��(���В��ߊ֌W�Ȃ�)�w��N�����Ɏ��܂��Ă��邩����
        /// </summary>
        /// <param name="years">����</param>
        /// <param name="startYear">�J�n�N�x</param>
        /// <param name="endYear">�I���N�x</param>
        /// <returns>true:�͈͓� / false:�͈͊O</returns>
        /// <remarks>
        /// �J�n�`�I���N��(���В��ߊ֌W�Ȃ�)�w�茎�����Ɏ��܂��Ă��邩���肵�܂��B<br/>
        /// </remarks>
        public bool CheckPeriodYearsOnYears( int years, DateTime startYear, DateTime endYear )
        {
            return _finYearTableGenerator.CheckPeriodYearsOnYears( years, startYear, endYear );
        }
        # endregion �� ���t�͈͓��̓`�F�b�N�����i�@�\����j ��


        # region �� ���t���ړ��̓`�F�b�N���� ��
        /// <summary>
        /// ���t���ړ��̓`�F�b�N����
        /// </summary>
        /// <param name="targetDateEdit">�Ώۓ��tEdit</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>���t�̖����́E�����`�F�b�N���s���܂��B</remarks>
        public CheckDateResult CheckDate( ref TDateEdit targetDateEdit )
        {
            return CheckDate( ref targetDateEdit, false );
        }
        /// <summary>
        /// ���t���ړ��̓`�F�b�N����
        /// </summary>
        /// <param name="targetDateEdit">�Ώۓ��tEdit</param>
        /// <param name="allowNoInput">�����͋��t���O</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>���t�̖����́E�����`�F�b�N���s���܂��B</remarks>
        public CheckDateResult CheckDate( ref TDateEdit targetDateEdit, bool allowNoInput )
        {
            //---------------------------------------------------
            // �����̓`�F�b�N
            //---------------------------------------------------
            if ( !allowNoInput )
            {
                if ( DateEditNoInputCheck( targetDateEdit ) )
                {
                    return CheckDateResult.ErrorOfNoInput;
                }
            }

            //---------------------------------------------------
            // �����`�F�b�N�O�̕␳����
            //---------------------------------------------------
            if ( _yearOnlyList.Contains( targetDateEdit.DateFormat ) )
            {
                // �N���� (yyyy/01/01)
                targetDateEdit.SetLongDate( (targetDateEdit.GetLongDate() / 10000) * 10000 + 101 );
            }
            else if ( _monthOnlyList.Contains( targetDateEdit.DateFormat ) )
            {
                // �N������ (yyyy/mm/01)
                targetDateEdit.SetLongDate( (targetDateEdit.GetLongDate() / 100) * 100 + 1 );
            }

            //---------------------------------------------------
            // �����`�F�b�N����
            //---------------------------------------------------
            if ( targetDateEdit.CheckInputData() != null ) return CheckDateResult.ErrorOfInvalid;
            if ( !DateEditInputCheck( targetDateEdit, allowNoInput ) ) return CheckDateResult.ErrorOfInvalid;

            //---------------------------------------------------
            // �G���[�Ȃ�
            //---------------------------------------------------
            return CheckDateResult.OK;
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 ADD
        /// <summary>
        /// ���t�`�F�b�N�����i�N���p�j������`�[���́E�������ϔ��s�Ŏg�p
        /// </summary>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        public CheckDateResult CheckDateForFirstEntryDate( ref TDateEdit targetDateEdit )
        {
            // �N���p�Ȃ̂ŁA�f�t�H���g�͖����͉�
            return CheckDateForFirstEntryDate( ref targetDateEdit, true );
        }
        /// <summary>
        /// ���t�`�F�b�N�����i�N���p�j������`�[���́E�������ϔ��s�Ŏg�p
        /// </summary>
        /// <param name="targetDateEdit"></param>
        /// <param name="allowNoInput"></param>
        /// <returns></returns>
        public CheckDateResult CheckDateForFirstEntryDate( ref TDateEdit targetDateEdit, bool allowNoInput )
        {
            int yy = targetDateEdit.GetDateYear();
            int mm = targetDateEdit.GetDateMonth();

            if ( yy!= 0)
            {
                if ( mm != 0)
                {
                    // �N����E������

                    // �V�X�e���T�|�[�g�`�F�b�N
                    if ( yy < 1900 )
                    {
                        return CheckDateResult.ErrorOfInvalid;
                    }
                    // ���͈̓`�F�b�N
                    if ( mm < 1 || 12 < mm )
                    {
                        return CheckDateResult.ErrorOfInvalid;
                    }

                    targetDateEdit.LongDate = (yy * 10000) + (mm * 100) + 0;
                    return CheckDateResult.OK;
                }
                else
                {
                    // �N����E���Ȃ�

                    // �V�X�e���T�|�[�g�`�F�b�N
                    if ( yy < 1900 )
                    {
                        return CheckDateResult.ErrorOfInvalid;
                    }

                    targetDateEdit.LongDate = (yy * 10000) + 0 + 0;
                    return CheckDateResult.OK;
                }
            }
            else
            {
                if ( mm != 0 )
                {
                    // �N�Ȃ��E������
                    return CheckDateResult.ErrorOfInvalid; // �G���[
                }
                else
                {
                    // �N�Ȃ��E���Ȃ�
                    if ( allowNoInput )
                    {
                        return CheckDateResult.OK; // ������OK
                    }
                    else
                    {
                        return CheckDateResult.ErrorOfNoInput; // ������NG
                    }
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 ADD
        # endregion �� ���t���ړ��̓`�F�b�N���� ��


        # region �� ���В��ߓ���N�x�`�F�b�N���� ��
        /// <summary>
        /// ���В��ߓ���N�x�`�F�b�N����
        /// </summary>
        /// <param name="startYearMonth">�J�n��</param>
        /// <param name="endYearMonth">�I����</param>
        /// <returns>true:����N�x�� / false:����N�x���ɂȂ�</returns>
        /// <remarks>
        /// �N���x���Q�w�肵�āA����N�x�����`�F�b�N���܂��B<br/>
        /// </remarks>
        public bool CheckMonthsOnYear( DateTime startYearMonth, DateTime endYearMonth )
        {
            return _finYearTableGenerator.CheckMonthsOnYear( startYearMonth, endYearMonth );
        }
        /// <summary>
        /// ���В��ߓ���N�x�`�F�b�N����
        /// </summary>
        /// <param name="startDate">�J�n��</param>
        /// <param name="endDate">�I����</param>
        /// <returns>true:����N�x�� / false:����N�x���ɂȂ�</returns>
        /// <remarks>
        /// �N�������Q�w�肵�āA����N�x�����`�F�b�N���܂��B<br/>
        /// </remarks>
        public bool CheckDaysOnYear( DateTime startDate, DateTime endDate )
        {
            return _finYearTableGenerator.CheckDaysOnYear( startDate, endDate );
        }
        # endregion �� ���В��ߓ���N�x�`�F�b�N���� ��

        # region �� ���В��ߓ���N���x�`�F�b�N���� ��
        /// <summary>
        /// ���В��ߓ���N���x�`�F�b�N����
        /// </summary>
        /// <param name="startMonthDate">�J�n��</param>
        /// <param name="endMonthDate">�I����</param>
        /// <returns>true:���ꌎ�x�� / false:���ꌎ�x���ɂȂ�</returns>
        /// <remarks>
        /// �N�������Q�w�肵�āA����N���x���`�F�b�N���܂��B<br/>
        /// </remarks>
        public bool CheckDaysOnMonth( DateTime startMonthDate, DateTime endMonthDate )
        {
            return _finYearTableGenerator.CheckDaysOnMonth( startMonthDate, endMonthDate );
        }
        # endregion �� ���В��ߓ���N���x�`�F�b�N���� ��


        # region �� ���t�͈͔ėp�`�F�b�N���� ��
        /// <summary>
        /// ���t�͈͔ėp�`�F�b�N����
        /// </summary>
        /// <param name="rangeType">�͈͎w��^�C�v</param>
        /// <param name="ymdRange">�͈͎w��</param>
        /// <param name="startDateEdit">�J�n���tEdit</param>
        /// <param name="endDateEdit">�I�����tEdit</param>
        /// <param name="allowNoInput">�����͋��� (true:������/false:�����Ȃ�)</param>
        /// <returns>���t�͈̓`�F�b�N����</returns>
        /// <remarks>
        /// �J�n���t�`�F�b�N�A�I�����t�`�F�b�N�A���t�͈̓`�F�b�N�A���В��ߓ���N�x�`�F�b�N���s���܂��B<br/>
        /// <br></br>
        /// <br>�ȉ���public���\�b�h���g�p���܂��B</br>
        /// <br>�@�E���t�`�F�b�N�@�@�@�@�@�@�@�FCheckDate</br>
        /// <br>�@�E���В��ߓ���N�x�`�F�b�N�@�FCheckMonthsOnYear / CheckDaysOnYear</br>
        /// <br>  �E���В��ߓ���N���x�`�F�b�N�FCheckDaysOnMonth</br>
        /// <br>�@�E���t�͈̓`�F�b�N�@�@�@�@�@�FCheckPeriod</br>
        /// </remarks>
        public CheckDateRangeResult CheckDateRange( YmdType rangeType, int ymdRange, ref TDateEdit startDateEdit, ref TDateEdit endDateEdit, bool allowNoInput )
        {
            return CheckDateRange( rangeType, ymdRange, ref startDateEdit, ref endDateEdit, allowNoInput, false, false );
        }
        /// <summary>
        /// ���t�͈͔ėp�`�F�b�N����
        /// </summary>
        /// <param name="rangeType">�͈͎w��^�C�v</param>
        /// <param name="ymdRange">�͈͎w��</param>
        /// <param name="startDateEdit">�J�n���tEdit</param>
        /// <param name="endDateEdit">�I�����tEdit</param>
        /// <param name="allowNoInput">�����͋��� (true:������/false:�����Ȃ�)</param>
        /// <param name="checkOnYear">���В��ߓ���N�x�`�F�b�N�itrue:����/false:���Ȃ��j</param>
        /// <returns>���t�͈̓`�F�b�N����</returns>
        /// <remarks>
        /// �J�n���t�`�F�b�N�A�I�����t�`�F�b�N�A���t�͈̓`�F�b�N�A���В��ߓ���N�x�`�F�b�N���s���܂��B<br/>
        /// <br></br>
        /// <br>�ȉ���public���\�b�h���g�p���܂��B</br>
        /// <br>�@�E���t�`�F�b�N�@�@�@�@�@�@�@�FCheckDate</br>
        /// <br>�@�E���В��ߓ���N�x�`�F�b�N�@�FCheckMonthsOnYear / CheckDaysOnYear</br>
        /// <br>  �E���В��ߓ���N���x�`�F�b�N�FCheckDaysOnMonth</br>
        /// <br>�@�E���t�͈̓`�F�b�N�@�@�@�@�@�FCheckPeriod</br>
        /// </remarks>
        public CheckDateRangeResult CheckDateRange( YmdType rangeType, int ymdRange, ref TDateEdit startDateEdit, ref TDateEdit endDateEdit, bool allowNoInput, bool checkOnYear )
        {
            return CheckDateRange( rangeType, ymdRange, ref startDateEdit, ref endDateEdit, allowNoInput, checkOnYear, false );
        }
        /// <summary>
        /// ���t�͈͔ėp�`�F�b�N����
        /// </summary>
        /// <param name="rangeType">�͈͎w��^�C�v</param>
        /// <param name="ymdRange">�͈͎w��</param>
        /// <param name="startDateEdit">�J�n���tEdit</param>
        /// <param name="endDateEdit">�I�����tEdit</param>
        /// <param name="allowNoInput">�����͋��� (true:������/false:�����Ȃ�)</param>
        /// <param name="checkOnYear">���В��ߓ���N�x�`�F�b�N�itrue:����/false:���Ȃ��j</param>
        /// <param name="checkOnMonth">���В��ߓ���N���x�`�F�b�N (true:����/false:���Ȃ�)</param>
        /// <returns>���t�͈̓`�F�b�N����</returns>
        /// <remarks>
        /// �J�n���t�`�F�b�N�A�I�����t�`�F�b�N�A���t�͈̓`�F�b�N�A���В��ߓ���N�x�`�F�b�N���s���܂��B<br/>
        /// <br>�i���t�h�d�l�œ��t�͈͂ɐ���������ꍇ�Ɏg�p���ĉ������B�����������ꍇ�͑���public���\�b�h���ʂɎg�p���ĉ������B�j</br>
        /// <br></br>
        /// <br>�ȉ���public���\�b�h���g�p���܂��B</br>
        /// <br>�@�E���t�`�F�b�N�@�@�@�@�@�@�@�FCheckDate</br>
        /// <br>�@�E���В��ߓ���N�x�`�F�b�N�@�FCheckMonthsOnYear / CheckDaysOnYear</br>
        /// <br>  �E���В��ߓ���N���x�`�F�b�N�FCheckDaysOnMonth</br>
        /// <br>�@�E���t�͈̓`�F�b�N�@�@�@�@�@�FCheckPeriod</br>
        /// </remarks>
        public CheckDateRangeResult CheckDateRange( YmdType rangeType, int ymdRange, ref TDateEdit startDateEdit, ref TDateEdit endDateEdit, bool allowNoInput, bool checkOnYear, bool checkOnMonth )
        {
            //--------------------------------------------------------------
            // �G���[�̗D�揇�͈ȉ��̒ʂ�ł��B
            //--------------------------------------------------------------
            // 
            // �@�@( �J�n������ )
            // �A�@�J�n�s��
            // �B�@( �I�������� )
            // �C�@�I���s��
            // �D�@( �I������E�J�n�̂ݖ����� )
            // �E�@( �J�n����E�I���̂ݖ����� )
            // �F�@�t�]�G���[
            // �G�@( ����N���x�`�F�b�N�G���[ )
            // �H�@( ����N�x�`�F�b�N�G���[ )
            // �I�@�͈͊O�G���[
            // 
            //--------------------------------------------------------------

            # region [inputType����]
            // ���͌`���́A�J�n���tEdit�̃^�C�v�����Ɍ���
            YmdType inputType;
            if ( _yearOnlyList.Contains( startDateEdit.DateFormat ) )
            {
                inputType = YmdType.Year;
            }
            else if ( _monthOnlyList.Contains( startDateEdit.DateFormat ) )
            {
                inputType = YmdType.YearMonth;
            }
            else
            {
                inputType = YmdType.YearMonthDay;
            }
            # endregion

            //-------------------------------------
            // ���̓`�F�b�N����
            //-------------------------------------
            # region [�J�n���E�I�����̓��̓`�F�b�N]
            CheckDateResult cdResult;

            // �J�n
            bool stNoInput = false;
            cdResult = CheckDate( ref startDateEdit, false );
            switch ( cdResult )
            {
                case CheckDateResult.ErrorOfNoInput:
                    if ( allowNoInput )
                    {
                        stNoInput = true;
                    }
                    else
                    {
                        return CheckDateRangeResult.ErrorOfStartNoInput;
                    }
                    break;
                case CheckDateResult.ErrorOfInvalid:
                    return CheckDateRangeResult.ErrorOfStartInvalid;
            }

            // �I��
            bool edNoInput = false;
            cdResult = CheckDate( ref endDateEdit, false );
            switch ( cdResult )
            {
                case CheckDateResult.ErrorOfNoInput:
                    if ( allowNoInput )
                    {
                        edNoInput = true;
                    }
                    else
                    {
                        return CheckDateRangeResult.ErrorOfEndNoInput;
                    }
                    break;
                case CheckDateResult.ErrorOfInvalid:
                    return CheckDateRangeResult.ErrorOfEndInvalid;
            }

            // �Е����������͂̃`�F�b�N 
            // �� �Е������͍ς݂Ȃ�΂����Е��̖����͂������Ȃ� (allowNoInput�ɂ��Ȃ�)
            if ( stNoInput == true && edNoInput == false )
            {
                // �J�n�̂ݖ�����
                return CheckDateRangeResult.ErrorOfStartNoInput;
            }
            else if ( stNoInput == false && edNoInput == true )
            {
                // �I���̂ݖ�����
                return CheckDateRangeResult.ErrorOfEndNoInput;
            }
            else if ( stNoInput == true && edNoInput == true )
            {
                // �ǂ���������͂Ȃ�΂����Ő���I��
                return CheckDateRangeResult.OK;
            }

            # endregion [�J�n���E�I�����̓��̓`�F�b�N]

            //-------------------------------------
            // �͈͓��`�F�b�N
            //-------------------------------------
            # region [�͈͓��`�F�b�N]
            bool rangeOver = false;
            CheckPeriodResult cpResult = CheckPeriod( rangeType, ymdRange, inputType, startDateEdit.GetDateTime(), endDateEdit.GetDateTime() );

            switch ( cpResult )
            {
                case CheckPeriodResult.ErrorOfReverse:
                    {
                        return CheckDateRangeResult.ErrorOfReverse; // �t�]�G���[��Ԃ�
                    }
                case CheckPeriodResult.ErrorOfRangeOver:
                    {
                        // �͈͂��[���ȉ��Ȃ�΁A�������Ƃ݂Ȃ�
                        if ( ymdRange > 0 )
                        {
                            rangeOver = true;   // �͈̓G���[�͑��Ԃ����A����N���x�E����N�x�`�F�b�NOK�̏ꍇ�ɕԂ�
                        }
                    }
                    break;
            }
            # endregion

            //-------------------------------------
            // ����N���x�`�F�b�N
            //-------------------------------------
            # region [����N���x�`�F�b�N]
            if ( checkOnMonth )
            {
                bool onMonth = true;

                switch ( inputType )
                {
                    case YmdType.Year:
                        {
                            // �`�F�b�N���Ȃ�
                        }
                        break;
                    case YmdType.YearMonth:
                        {
                            onMonth = (startDateEdit.GetDateTime().Year == endDateEdit.GetDateTime().Year) &&
                                      (startDateEdit.GetDateTime().Month == endDateEdit.GetDateTime().Month);
                        }
                        break;
                    case YmdType.YearMonthDay:
                        {
                            onMonth = CheckDaysOnMonth( startDateEdit.GetDateTime(), endDateEdit.GetDateTime() );
                        }
                        break;
                }
                if ( !onMonth )
                {
                    return CheckDateRangeResult.ErrorOfNotOnMonth;
                }
            }
            # endregion

            //-------------------------------------
            // ����N�x�`�F�b�N
            //-------------------------------------
            # region [����N�x�`�F�b�N]
            if ( checkOnYear )
            {
                bool onYear = true;
                switch ( inputType )
                {
                    case YmdType.Year:
                        {
                            // �N�̂�
                            onYear = (startDateEdit.GetDateTime().Year == endDateEdit.GetDateTime().Year);
                        }
                        break;
                    case YmdType.YearMonth:
                        {
                            // �N���x
                            onYear = CheckMonthsOnYear( startDateEdit.GetDateTime(), endDateEdit.GetDateTime() );
                        }
                        break;
                    case YmdType.YearMonthDay:
                        {
                            // �N����
                            onYear = CheckDaysOnYear( startDateEdit.GetDateTime(), endDateEdit.GetDateTime() );
                        }
                        break;
                }
                if ( !onYear )
                {
                    return CheckDateRangeResult.ErrorOfNotOnYear;
                }
            }
            # endregion


            # region [�͈͊O�G���[�ԋp]
            // �͈̓`�F�b�N�G���[�Ȃ�΂��̃^�C�~���O�ŕԂ�
            if ( rangeOver )
            {
                return CheckDateRangeResult.ErrorOfRangeOver;
            }
            # endregion [�͈͊O�G���[�ԋp]

            // ���ʂn�j
            return CheckDateRangeResult.OK;
        }
        # endregion �� ���t�͈͔ėp�`�F�b�N���� ��

        # endregion

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region Private Methods

        # region [���ʏ���]
        /// <summary>
        /// ���t�擾�iDateTime �� int�j
        /// </summary>
        /// <param name="longDate"></param>
        /// <returns></returns>
        private static DateTime DateTimeFromLongDate( int longDate )
        {
            return new DateTime( (longDate / 10000), ((longDate / 100) % 100), (longDate % 100) );
        }
        /// <summary>
        /// ���������擾
        /// </summary>
        /// <param name="currentDate"></param>
        /// <param name="totalDay"></param>
        /// <returns></returns>
        private static DateTime GetEndDate( DateTime currentDate, int totalDay)
        {
            // �� > ����
            if ( currentDate.Day > totalDay )
            {
                // ���̌��ɐi�߂�
                currentDate = currentDate.AddMonths( 1 );
            }

            // ���̌��̖����Ŋۂ߂�
            int maxDay = DateTime.DaysInMonth( currentDate.Year, currentDate.Month );
            if ( totalDay > maxDay )
            {
                totalDay = maxDay;
            }

            // �������Z�b�g���ĕԂ�
            return (new DateTime( currentDate.Year, currentDate.Month, totalDay ));
        }
        /// <summary>
        /// ���t���̓`�F�b�N����
        /// </summary>
        /// <param name="targetDateEdit">�`�F�b�N�ΏۃR���g���[��</param>
        /// <param name="allowNoInput">�����͋���</param>
        /// <returns>�`�F�b�N����(true/false)</returns>
        /// <remarks>
        /// </remarks>
        private bool DateEditInputCheck( TDateEdit targetDateEdit, bool allowNoInput )
        {
            bool status = true;

            // ���͓��t�𐔒l�^�Ŏ擾
            int date = targetDateEdit.GetLongDate();
            int yy = date / 10000;
            int mm = (date / 100) % 100;
            int dd = date % 100;

            // ���̃^�C�~���O�Ŗ����͂Ȃ�΃`�F�b�N���Ȃ�
            if ( DateEditNoInputCheck(targetDateEdit) )
            {
                if ( allowNoInput )
                {
                    // �����Ă��関���͂Ȃ̂�OK
                    status = true;
                }
                else
                {
                    // �����Ă��Ȃ������͂Ȃ̂�NG
                    status = false;
                }
            }
            else
            // �V�X�e���T�|�[�g�`�F�b�N
            if ( yy < 1900 )
            {
                status = false;
            }
            // �N�����ʓ��̓`�F�b�N
            else if ( (yy == 0) || (mm == 0) || (dd == 0) )
            {
                status = false;
            }
            // �P�����t�Ó����`�F�b�N
            else if ( TDateTime.IsAvailableDate( targetDateEdit.GetDateTime() ) == false )
            {
                status = false;
            }

            return status;
        }
        /// <summary>
        /// ���tEdit �����̓`�F�b�N
        /// </summary>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        private bool DateEditNoInputCheck( TDateEdit targetDateEdit )
        {
            int date = targetDateEdit.GetLongDate();
            int yy = date / 10000;
            int mm = (date / 100) % 100;
            int dd = date % 100;

            if ( _yearOnlyList.Contains( targetDateEdit.DateFormat ) )
            {
                // �N�̂�
                if ( yy == 0 ) return true;
            }
            else if ( _monthOnlyList.Contains( targetDateEdit.DateFormat ) )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 DEL
                ////if ( yy == 0 && mm == 0 ) return true;
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 DEL
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                //if ( yy == 0 || mm == 0 ) return true;
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
                if ( yy == 0 && mm == 0 ) return true;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            }
            else
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 DEL
                ////if ( yy == 0 && mm == 0 && dd == 0 ) return true;
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 DEL
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                //if ( yy == 0 || mm == 0 || dd == 0 ) return true;
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
                if ( yy == 0 && mm == 0 && dd == 0 ) return true;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            }

            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyInf"></param>
        /// <returns></returns>
        private CompanyInfWork CopyToWorkFromCompanyInf( CompanyInf companyInf )
        {
            CompanyInfWork work = new CompanyInfWork();

            work.CreateDateTime = companyInf.CreateDateTime; // �쐬����
            work.UpdateDateTime = companyInf.UpdateDateTime; // �X�V����
            work.EnterpriseCode = companyInf.EnterpriseCode; // ��ƃR�[�h
            work.FileHeaderGuid = companyInf.FileHeaderGuid; // GUID
            work.UpdEmployeeCode = companyInf.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            work.UpdAssemblyId1 = companyInf.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            work.UpdAssemblyId2 = companyInf.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            work.LogicalDeleteCode = companyInf.LogicalDeleteCode; // �_���폜�敪
            work.CompanyCode = companyInf.CompanyCode; // ���ЃR�[�h
            work.CompanyTotalDay = companyInf.CompanyTotalDay; // ���В���
            work.FinancialYear = companyInf.FinancialYear; // ��v�N�x
            work.CompanyBiginMonth = companyInf.CompanyBiginMonth; // ����
            work.CompanyBiginMonth2 = companyInf.CompanyBiginMonth2; // ����2
            work.CompanyBiginDate = companyInf.CompanyBiginDate; // ����N����
            work.StartYearDiv = companyInf.StartYearDiv; // �J�n�N�敪
            work.StartMonthDiv = companyInf.StartMonthDiv; // �J�n���敪
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/25 DEL
            //work.CompanyName1 = companyInf.CompanyName1; // ���Ж���1
            //work.CompanyName2 = companyInf.CompanyName2; // ���Ж���2
            //work.PostNo = companyInf.PostNo; // �X�֔ԍ�
            //work.Address1 = companyInf.Address1; // �Z��1�i�s���{���s��S�E�����E���j
            //work.Address2 = companyInf.Address2; // �Z��2�i���ځj
            //work.Address3 = companyInf.Address3; // �Z��3�i�Ԓn�j
            //work.Address4 = companyInf.Address4; // �Z��4�i�A�p�[�g���́j
            //work.CompanyTelNo1 = companyInf.CompanyTelNo1; // ���Гd�b�ԍ�1
            //work.CompanyTelNo2 = companyInf.CompanyTelNo2; // ���Гd�b�ԍ�2
            //work.CompanyTelNo3 = companyInf.CompanyTelNo3; // ���Гd�b�ԍ�3
            //work.CompanyTelTitle1 = companyInf.CompanyTelTitle1; // ���Гd�b�ԍ��^�C�g��1
            //work.CompanyTelTitle2 = companyInf.CompanyTelTitle2; // ���Гd�b�ԍ��^�C�g��2
            //work.CompanyTelTitle3 = companyInf.CompanyTelTitle3; // ���Гd�b�ԍ��^�C�g��3
            //work.SecMngDiv = companyInf.SecMngDiv; // �����Ǘ��敪
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/25 DEL

            return work;
        }
        # endregion
        
        #endregion

        // ===================================================================================== //
        // ���̑�
        // ===================================================================================== //

        # region �� �����敪�񋓌^ ��
        /// <summary>
        /// �����敪�@�񋓌^
        /// </summary>
        /// <remarks>
        /// �W�v���Ԏ擾(GetPeriod)�̏����敪��\���܂��B<br/>
        /// </remarks>
        public enum ProcModeDivState
        {
            /// <summary>�ߋ��@�N�x</summary>
            PastYears = 0,
            /// <summary>�ߋ��@���x</summary>
            PastMonths = 1,
            /// <summary>�ߋ��@���t</summary>
            PastDays = 2,
            /// <summary>����@�N�x</summary>
            FutureYears = 3,
            /// <summary>����@���x</summary>
            FutureMonths = 4,
            /// <summary>����@���t</summary>
            FutureDays = 5,
        }
        # endregion �� �����敪�񋓌^ ��

        # region �� �N�����w��^�C�v�񋓌^ ��
        /// <summary>
        /// �N�����w��^�C�v�@�񋓌^
        /// </summary>
        /// <remarks>�N�E���E���̋敪��\���܂��B</remarks>
        public enum YmdType
        {
            /// <summary>�N</summary>
            Year = 0,
            /// <summary>�N��</summary>
            YearMonth = 1,
            /// <summary>�N����</summary>
            YearMonthDay = 2,
        }
        # endregion �� �N�����w��^�C�v�񋓌^ ��

        # region �� ���t�͈̓`�F�b�N�ԋp�l�񋓌^ ��
        /// <summary>
        /// ���t�͈̓`�F�b�N�ԋp�l�@�񋓌^
        /// </summary>
        /// <remarks>CheckPeriod�̃`�F�b�N���ʂ�\���܂��B</remarks>
        public enum CheckPeriodResult
        {
            /// <summary>�n�j�i�G���[�Ȃ��j</summary>
            OK = 0,
            /// <summary>�t�]�G���[�i�J�n���I���ɂȂ��Ă���j</summary>
            ErrorOfReverse = 1,
            /// <summary>�͈̓G���[�i�J�n�`�I�����w��͈͂𒴂��Ă���j</summary>
            ErrorOfRangeOver = 2,
        }
        # endregion �� ���t�͈̓`�F�b�N�ԋp�l�񋓌^ ��

        # region �� ���t���̓`�F�b�N�ԋp�l�񋓌^ ��
        /// <summary>
        /// ���t���̓`�F�b�N�ԋp�l�@�񋓌^
        /// </summary>
        /// <remarks>CheckDate�̃`�F�b�N���ʂ�\���܂��B</remarks>
        public enum CheckDateResult
        {
            /// <summary>�n�j�i�G���[�Ȃ��j</summary>
            OK = 0,
            /// <summary>�����̓G���[�iyyyy,mm,dd�S�Ė����́j</summary>
            ErrorOfNoInput = 1,
            /// <summary>�������t�G���[�i2008/99/99�̂悤�Ȗ����ȓ��t�j</summary>
            ErrorOfInvalid = 2,
        }
        # endregion �� ���t���̓`�F�b�N�ԋp�l�񋓌^ ��

        # region �� ���t�͈̓t���`�F�b�N�ԋp�l�񋓌^ ��
        /// <summary>
        /// ���t�͈̓t���`�F�b�N�ԋp�l�@�񋓌^
        /// </summary>
        /// <remarks>CheckDateRange�̃`�F�b�N���ʂ�\���܂��B</remarks>
        public enum CheckDateRangeResult
        {
            /// <summary>�n�j�i�G���[�Ȃ��j</summary>
            OK = 0,
            /// <summary>�t�]�G���[�i�J�n���I���ɂȂ��Ă���j</summary>
            ErrorOfReverse = 1,
            /// <summary>�͈̓G���[�i�J�n�`�I�����w��͈͂𒴂��Ă���j</summary>
            ErrorOfRangeOver = 2,
            /// <summary>�J�n�����̓G���[�i�J�n���t�������́j</summary>
            ErrorOfStartNoInput = 3,
            /// <summary>�J�n�����G���[�i�J�n���t�������j</summary>
            ErrorOfStartInvalid = 4,
            /// <summary>�I�������̓G���[�i�I�����t�������́j</summary>
            ErrorOfEndNoInput = 5,
            /// <summary>�I�������G���[�i�I�����t�������j</summary>
            ErrorOfEndInvalid = 6,
            /// <summary>�N�x�܂����G���[�i�J�n�`�I��������N�x���łȂ��j</summary>
            ErrorOfNotOnYear = 7,
            /// <summary>�N���x�܂����G���[�i�J�n�`�I��������N���x���łȂ��j</summary>
            ErrorOfNotOnMonth = 8,
        }
        # endregion �� ���t�͈̓t���`�F�b�N�ԋp�l�񋓌^ ��
    }

}
