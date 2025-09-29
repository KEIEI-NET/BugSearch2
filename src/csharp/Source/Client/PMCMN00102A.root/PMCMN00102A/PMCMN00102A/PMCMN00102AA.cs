using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;

using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Controller;


namespace Broadleaf.Application.Common
{
    /// <summary>
    /// �����Z�o���W���[��
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����E�����X�V�̒������擾����N���X�ł��B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2008.07.31</br>
    /// <br></br>
    /// <br>UpdateNote : 2009/01/21 22018 ��� ���b</br>
    /// <br>           : �@�����`�F�b�N�����̏ꍇ�A�����O�ɃL���b�V�����N���A���ĕK��DB����擾����悤�ύX�B</br>
    /// <br></br>
    /// <br>UpdateNote : 2009/03/09 22018 ��� ���b</br>
    /// <br>           : �@�S���_�ň�Ԑi��ł��錎���X�V���̎擾�@�\��ǉ�</br>
    /// <br>           :   �i���_=String.Empty�Ŏw��j</br>
    /// <br></br>
    /// <br>UpdateNote : 2009/03/11 22018 ��� ���b</br>
    /// <br>           : �@���������̋��_�Ŏ擾�������̕s����C��</br>
    /// <br>           :   �i2009/03/09�ύX�������j</br>
    /// <br></br>
    /// <br>UpdateNote : 2009/04/07 22018 ��� ���b</br>
    /// <br>           : �@�S���_�ň�Ԑi��ł��锄��/�d�������̎擾�@�\��ǉ�</br>
    /// <br>           :   2009/03/09�ύX�Ɠ��l�A���𐿋�/�����x���ɂ��ꂼ��g�ݍ���</br>
    /// <br></br>
    /// <br>UpdateNote : 2009/04/16 22018 ��� ���b</br>
    /// <br>           : �@���𐿋�/�����x���̎�������Z�o��</br>
    /// <br>           :   ��ɁA�����S�̐ݒ��00:�S�Ђ̃��R�[�h���g�p����悤�ύX�B</br>
    /// <br></br>
    /// </remarks>
    /// <example>�C���X�^���X�̎擾���@<br/>
    /// TotalDayCalculator ttlDayCalc = TotalDayCalculator.GetInstance();<br/>
    /// </example>
    public class TotalDayCalculator
    {
        // ===================================================================================== //
        // static private�t�B�[���h
        // ===================================================================================== //
        // Singleton�C���X�^���X
        static private TotalDayCalculator stc_totalDayCalculator;

        // ===================================================================================== //
        // private�萔
        // ===================================================================================== //
        # region [private�萔]
        // �S�Ўw�苒�_�R�[�h
        private const string ct_AllSectionCode = "00";
        # endregion

        // ===================================================================================== //
        // private�t�B�[���h
        // ===================================================================================== //
        # region [private �t�B�[���h]
        // �f�[�^�e�[�u��
        private DataTable _tableOfHisMonthly;    // �����E����
        private DataTable _tableOfHisDmdC;       // �����E����
        private DataTable _tableOfHisPayment;    // �����E�x��
        private DataTable _tableOfPrcAccRec;     // ���z�E�������|
        private DataTable _tableOfPrcAccPay;     // ���z�E�������|
        private DataTable _tableOfPrcDmdC;       // ���z�E����
        private DataTable _tableOfPrcPayment;    // ���z�E�x��

        // �����[�g
        private ITtlDayCalcDB _iTtlDayCalcDB;

        // ��ƃR�[�h
        private string _enterpriseCode;

        // �}�X�^�����擾�敪
        private int _withMasterDiv;

        // �L�惊���[�g�擾�� �J�n���t
        private int _startDate;

        // �����E�����@���������ς݃t���O
        private bool _extractedHisMonthly;
        // �����E�����@���������ς݃t���O
        private bool _extractedHisDmdC;
        // �����E�x���@���������ς݃t���O
        private bool _extractedHisPayment;

        // ��v�N�x�e�[�u���擾���i
        private FinYearTableGenerator _finYearTableGenerator;

        // ���Џ��}�X�^
        private CompanyInfWork _companyInfWork;
        // �����S�̐ݒ�}�X�^���X�g
        private List<BillAllStWork> _billAllStWorkList;

        // ���|�I�v�V�����t���O�ifalse:���|�Ȃ��^true:���|����j
        private bool _enableOptionAccPay;

        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region [private �v���p�e�B]
        /// <summary>
        /// �}�X�^�����擾�敪�@�v���p�e�B
        /// </summary>
        private int WithMasterDiv
        {
            set { _withMasterDiv = value; }
            get 
            {
                // get����Ǝ���̓[���ɂȂ��Ă���B
                int div = _withMasterDiv;
                _withMasterDiv = 0;

                return div;
            }
        }
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region [private �R���X�g���N�^]
        /// <summary>
        /// private �R���X�g���N�^
        /// </summary>
        private TotalDayCalculator()
        {
            // �����[�g�I�u�W�F�N�g�擾
            _iTtlDayCalcDB = MediationTtlDayCalcDB.GetTtlDayCalcDB();

            // ��ƃR�[�h
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �}�X�^�����擾�敪
            this.WithMasterDiv = 1; // 1:�擾����

            // �L�惊���[�g�擾�J�n���t�i�V�X�e�����t�̂U�����O���w��j
            _startDate = TotalDayCalculator.GetLongDate( DateTime.Today.AddMonths( -6 ) );

            // �����n���o�ς݃t���O
            _extractedHisMonthly = false;
            _extractedHisDmdC = false;
            _extractedHisPayment = false;

            // ���|�I�v�V�����t���O
            _enableOptionAccPay = true;
        }
        # endregion

        // ===================================================================================== //
        // static �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region [�C���X�^���X�擾]
        /// <summary>
        /// �C���X�^���X�擾����
        /// </summary>
        /// <returns>TotalDayCalculator�C���X�^���X</returns>
        ///
        /// <remarks>�����Z�o���W���[���N���X�̃C���X�^���X���擾���܂��B<br/>
        /// ���̃N���X��singleton�ł���Anew�L�[���[�h�ɂ��O���ŃC���X�^���X�������邱�Ƃ͏o���܂���B<br/>
        /// </remarks>
        /// <example>�C���X�^���X�擾���@<br/>
        /// TotalDayCalculator ttlDayCalc = TotalDayCalculator.GetInstance();
        /// </example>
        public static TotalDayCalculator GetInstance()
        {
            if (stc_totalDayCalculator == null)
            {
                stc_totalDayCalculator = new TotalDayCalculator();
            }
            return stc_totalDayCalculator;
        }
        # endregion

        // ===================================================================================== //
        // public ���\�b�h
        // ===================================================================================== //

        # region [�@�����E�������|]
        /// <summary>
        /// ���������y�����E�������|�z
        /// </summary>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>GetHisTotalDayMonthlyAccRec�̏����������s���܂��B<br/>
        /// ���̏������s��Ȃ������ꍇ���AGetHisTotalDayMonthlyAccRec���œ��l�̏��������s����܂��B<br/>
        /// ������s���̃I�[�o�[�w�b�h�����P�������ꍇ�ɂ́A���炩���߂��̏������������s���ĉ������B<br/>
        /// </remarks>
        /// <example>int status = ttlDayCalc.InitializeHisMonthlyAccRec();</example>
        public int InitializeHisMonthlyAccRec()
        {
            return InitializeHisMonthlyProc();
        }
        /// <summary>
        /// �����擾�����y�����E�������|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�������X�V�����}�X�^�����ɁA���_���̔��|�̑O������������Z�o���܂��B<br/>
        /// </remarks>
        /// <example>�����X�V�t�h�A�������Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayMonthlyAccRec( "01", out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayMonthlyAccRec( string sectionCode, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int convertProcessDivCd;
            return GetHisTotalDayMonthlyAccRecProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        /// <summary>
        /// �����擾�����y�����E�������|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�������X�V�����}�X�^�����ɁA���_���̔��|�̑O����������E��������������Z�o���܂��B<br/>
        /// </remarks>
        /// <example>�����X�V�t�h�A�������Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayMonthlyAccRec( "01", out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayMonthlyAccRec( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int convertProcessDivCd;
            return GetHisTotalDayMonthlyAccRecProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        /// <summary>
        /// �����擾�����y�����E�������|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <param name="prevTotalMonth">(�o��)�O���������</param>
        /// <param name="currentTotalMonth">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�������X�V�����}�X�^�����ɁA���_���̔��|�̑O����������E������������E�O����������E��������������Z�o���܂��B<br/>
        /// </remarks>
        /// <example>�����X�V�t�h�A�������Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// DateTime stMonth;<br/>
        /// DateTime edMonth;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayMonthlyAccRec( "01", out stDate, out edDate, out stMonth, out edMonth );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayMonthlyAccRec( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth )
        {
            int convertProcessDivCd;
            return GetHisTotalDayMonthlyAccRecProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        /// <summary>
        /// �����擾�����y�����E�������|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <param name="prevTotalMonth">(�o��)�O���������</param>
        /// <param name="currentTotalMonth">(�o��)�����������</param>
        /// <param name="convertProcessDivCd">(�o��)�R���o�[�g�����敪</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�������X�V�����}�X�^�����ɁA���_���̔��|�̑O����������E������������E�O����������E��������������Z�o���܂��B<br/>
        /// </remarks>
        /// <example>�����X�V�t�h�A�������Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// DateTime stMonth;<br/>
        /// DateTime edMonth;<br/>
        /// int convert;
        /// int status = ttlDayCalc.GetHisTotalDayMonthlyAccRec( "01", out stDate, out edDate, out stMonth, out edMonth, out convert );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayMonthlyAccRec( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth, out int convertProcessDivCd )
        {
            return GetHisTotalDayMonthlyAccRecProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        # endregion

        # region [�A�����E�������|]
        /// <summary>
        /// ���������y�����E�������|�z
        /// </summary>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>GetHisTotalDayMonthlyAccPay�̏����������s���܂��B<br/>
        /// ���̏������s��Ȃ������ꍇ���AGetHisTotalDayMonthlyAccPay���œ��l�̏��������s����܂��B<br/>
        /// ������s���̃I�[�o�[�w�b�h�����P�������ꍇ�ɂ́A���炩���߂��̏������������s���ĉ������B<br/>
        /// </remarks>
        /// <example>int status = ttlDayCalc.InitializeHisMonthlyAccPay();</example>
        public int InitializeHisMonthlyAccPay()
        {
            return InitializeHisMonthlyProc();
        }
        /// <summary>
        /// �����擾�����y�����E�������|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�������X�V�����}�X�^�����ɁA���_���̔��|�̑O������������Z�o���܂��B<br/>
        /// </remarks>
        /// <example>�����X�V�t�h�A�������Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayMonthlyAccPay( "01", out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayMonthlyAccPay( string sectionCode, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int convertProcessDivCd;
            return GetHisTotalDayMonthlyAccPayProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        /// <summary>
        /// �����擾�����y�����E�������|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�������X�V�����}�X�^�����ɁA���_���̔��|�̑O����������E��������������Z�o���܂��B<br/>
        /// </remarks>
        /// <example>�����X�V�t�h�A�������Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayMonthlyAccPay( "01", out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayMonthlyAccPay( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int convertProcessDivCd;
            return GetHisTotalDayMonthlyAccPayProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        /// <summary>
        /// �����擾�����y�����E�������|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <param name="prevTotalMonth">(�o��)�O���������</param>
        /// <param name="currentTotalMonth">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�������X�V�����}�X�^�����ɁA���_���̔��|�̑O����������E������������E�O����������E��������������Z�o���܂��B<br/>
        /// </remarks>
        /// <example>�����X�V�t�h�A�������Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// DateTime stMonth;<br/>
        /// DateTime edMonth;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayMonthlyAccPay( "01", out stDate, out edDate, out stMonth, out edMonth );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayMonthlyAccPay( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth )
        {
            int convertProcessDivCd;
            return GetHisTotalDayMonthlyAccPayProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        /// <summary>
        /// �����擾�����y�����E�������|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <param name="prevTotalMonth">(�o��)�O���������</param>
        /// <param name="currentTotalMonth">(�o��)�����������</param>
        /// <param name="convertProcessDivCd">(�o��)�R���o�[�g�����敪</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�������X�V�����}�X�^�����ɁA���_���̔��|�̑O����������E������������E�O����������E��������������Z�o���܂��B<br/>
        /// </remarks>
        /// <example>�����X�V�t�h�A�������Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// DateTime stMonth;<br/>
        /// DateTime edMonth;<br/>
        /// int convert;
        /// int status = ttlDayCalc.GetHisTotalDayMonthlyAccPay( "01", out stDate, out edDate, out stMonth, out edMonth, out convert );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayMonthlyAccPay( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth, out int convertProcessDivCd )
        {
            return GetHisTotalDayMonthlyAccPayProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        # endregion

        # region [�B�����E�������|�����|]
        /// <summary>
        /// ���������y�������|�����|�z
        /// </summary>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>GetHisTotalDayMonthly�̏����������s���܂��B<br/>
        /// ���̏������s��Ȃ������ꍇ���AGetHisTotalDayMonthly���œ��l�̏��������s����܂��B<br/>
        /// ������s���̃I�[�o�[�w�b�h�����P�������ꍇ�ɂ́A���炩���߂��̏������������s���ĉ������B<br/>
        /// </remarks>
        /// <example>int status = ttlDayCalc.InitializeHisMonthly();</example>
        public int InitializeHisMonthly()
        {
            return InitializeHisMonthlyProc();
        }
        /// <summary>
        /// �����擾�����y�����E�������|�����|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�������X�V�����}�X�^�����ɁA���_���̔��|�����|�̑O������������Z�o���܂��B<br/>
        /// ���|�Ɣ��|�Œ����������قȂ�ꍇ�A�Â����̓��t��Ԃ��܂��B<br/>
        /// </remarks>
        /// <example>�����X�V�t�h�A�������Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayMonthly( "01", out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayMonthly( string sectionCode, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int convertProcessDivCd;
            return GetHisTotalDayMonthlyProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        /// <summary>
        /// �����擾�����y�����E�������|�����|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�������X�V�����}�X�^�����ɁA���_���̔��|�����|�̑O����������E��������������Z�o���܂��B<br/>
        /// ���|�Ɣ��|�Œ����������قȂ�ꍇ�A�Â����̓��t��Ԃ��܂��B<br/>
        /// </remarks>
        /// <example>�����X�V�t�h�A�������Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayMonthly( "01", out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayMonthly( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int convertProcessDivCd;
            return GetHisTotalDayMonthlyProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        /// <summary>
        /// �����擾�����y�����E�������|�����|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <param name="prevTotalMonth">(�o��)�O���������</param>
        /// <param name="currentTotalMonth">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�������X�V�����}�X�^�����ɁA���_���̔��|�����|�̑O����������E������������E�O����������E��������������Z�o���܂��B<br/>
        /// ���|�Ɣ��|�Œ����������قȂ�ꍇ�A�Â����̓��t��Ԃ��܂��B<br/>
        /// </remarks>
        /// <example>�����X�V�t�h�A�������Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// DateTime stMonth;<br/>
        /// DateTime edMonth;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayMonthly( "01", out stDate, out edDate, out stMonth, out edMonth );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayMonthly( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth )
        {
            int convertProcessDivCd;
            return GetHisTotalDayMonthlyProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        /// <summary>
        /// �����擾�����y�����E�������|�����|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <param name="prevTotalMonth">(�o��)�O���������</param>
        /// <param name="currentTotalMonth">(�o��)�����������</param>
        /// <param name="convertProcessDivCd">(�o��)�R���o�[�g�����敪</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�������X�V�����}�X�^�����ɁA���_���̔��|�����|�̑O����������E������������E�O����������E��������������Z�o���܂��B<br/>
        /// ���|�Ɣ��|�Œ����������قȂ�ꍇ�A�Â����̓��t��Ԃ��܂��B<br/>
        /// </remarks>
        /// <example>�����X�V�t�h�A�������Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// DateTime stMonth;<br/>
        /// DateTime edMonth;<br/>
        /// int convert;
        /// int status = ttlDayCalc.GetHisTotalDayMonthly( "01", out stDate, out edDate, out stMonth, out edMonth, out convert );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayMonthly( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth, out int convertProcessDivCd )
        {
            return GetHisTotalDayMonthlyProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        # endregion

        # region [�C�����E����]
        /// <summary>
        /// ���������y�����E�����z
        /// </summary>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>GetHisTotalDayDmdC�̏����������s���܂��B<br/>
        /// ���̏������s��Ȃ������ꍇ���AGetHisTotalDayDmdC���œ��l�̏��������s����܂��B<br/>
        /// ������s���̃I�[�o�[�w�b�h�����P�������ꍇ�ɂ́A���炩���߂��̏������������s���ĉ������B<br/>
        /// </remarks>
        /// <example>int status = ttlDayCalc.InitializeHisDmdC();</example>
        public int InitializeHisDmdC()
        {
            return InitializeHisDmdCProc();
        }
        /// <summary>
        /// �����擾�����y�����E�����z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�������X�V�����}�X�^�����ɁA���_���̑O������������Z�o���܂��B<br/>
        /// </remarks>
        /// <example>���X�V�t�h�A�������Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayDmdC( "01", out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayDmdC( string sectionCode, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            int convertProcessDivCd;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 DEL
            //return GetHisTotalDayDmdCProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            DateTime startCAddUpUpdDate;
            return GetHisTotalDayDmdCProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd, out startCAddUpUpdDate );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        }
        /// <summary>
        /// �����擾�����y�����E�����z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�������X�V�����}�X�^�����ɁA���_���̑O����������E��������������Z�o���܂��B<br/>
        /// ������������̎Z�o�ɂ́A�����S�̐ݒ�}�X�^�̓o�^���e���g�p���܂��B�i��F15��,20��,31���Ń��[�e�[�V�����j<br/>
        /// </remarks>
        /// <example>���X�V�t�h�A�������Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayDmdC( "01", out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayDmdC( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            int convertProcessDivCd;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 DEL
            //return GetHisTotalDayDmdCProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            DateTime startCAddUpUpdDate;
            return GetHisTotalDayDmdCProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd, out startCAddUpUpdDate );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        }
        /// <summary>
        /// �����擾�����y�����E�����z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <param name="convertProcessDivCd">(�o��)�R���o�[�g�����敪</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�������X�V�����}�X�^�����ɁA���_���̑O����������E��������������Z�o���܂��B<br/>
        /// ������������̎Z�o�ɂ́A�����S�̐ݒ�}�X�^�̓o�^���e���g�p���܂��B�i��F15��,20��,31���Ń��[�e�[�V�����j<br/>
        /// </remarks>
        /// <example>���X�V�t�h�A�������Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int convert;
        /// int status = ttlDayCalc.GetHisTotalDayDmdC( "01", out stDate, out edDate, out convert );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayDmdC( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out int convertProcessDivCd )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 DEL
            //return GetHisTotalDayDmdCProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            DateTime startCAddUpUpdDate;
            return GetHisTotalDayDmdCProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd, out startCAddUpUpdDate );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
        /// <summary>
        /// �����擾�����y�����E�����z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <param name="convertProcessDivCd">(�o��)�R���o�[�g�����敪</param>
        /// <param name="startCAddUpUpdDate">(�o��)���X�V�J�n��</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�������X�V�����}�X�^�����ɁA���_���̑O����������E��������������Z�o���܂��B<br/>
        /// ������������̎Z�o�ɂ́A�����S�̐ݒ�}�X�^�̓o�^���e���g�p���܂��B�i��F15��,20��,31���Ń��[�e�[�V�����j<br/>
        /// </remarks>
        /// <example>���X�V�t�h�A�������Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int convert;
        /// int status = ttlDayCalc.GetHisTotalDayDmdC( "01", out stDate, out edDate, out convert );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayDmdC( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out int convertProcessDivCd, out DateTime startCAddUpUpdDate )
        {
            return GetHisTotalDayDmdCProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd, out startCAddUpUpdDate );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        # endregion

        # region [�D�����E�x��]
        /// <summary>
        /// ���������y�����E�x���z
        /// </summary>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>GetHisTotalDayPayment�̏����������s���܂��B<br/>
        /// ���̏������s��Ȃ������ꍇ���AGetHisTotalDayPayment���œ��l�̏��������s����܂��B<br/>
        /// ������s���̃I�[�o�[�w�b�h�����P�������ꍇ�ɂ́A���炩���߂��̏������������s���ĉ������B<br/>
        /// </remarks>
        /// <example>int status = ttlDayCalc.InitializeHisPayment();</example>
        public int InitializeHisPayment()
        {
            return InitializeHisPaymentProc();
        }
        /// <summary>
        /// �����擾�����y�����E�x���z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�x�����X�V�����}�X�^�����ɁA���_���̑O������������Z�o���܂��B<br/>
        /// </remarks>
        /// <example>���X�V�t�h�A�x�����Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayPayment( "01", out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayPayment( string sectionCode, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            int convertProcessDivCd;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 DEL
            //return GetHisTotalDayPaymentProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            DateTime startCAddUpUpdDate;
            return GetHisTotalDayPaymentProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd, out startCAddUpUpdDate );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        }
        /// <summary>
        /// �����擾�����y�����E�x���z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�x�����X�V�����}�X�^�����ɁA���_���̑O����������E��������������Z�o���܂��B<br/>
        /// ������������̎Z�o�ɂ́A�����S�̐ݒ�}�X�^�̓o�^���e���g�p���܂��B�i��F15��,20��,31���Ń��[�e�[�V�����j<br/>
        /// </remarks>
        /// <example>���X�V�t�h�A�x�����Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayPayment( "01", out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayPayment( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            int convertProcessDivCd;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 DEL
            //return GetHisTotalDayPaymentProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            DateTime startCAddUpUpdDate;
            return GetHisTotalDayPaymentProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd, out startCAddUpUpdDate );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        }
        /// <summary>
        /// �����擾�����y�����E�x���z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <param name="convertProcessDivCd">(�o��)�R���o�[�g�����敪</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�x�����X�V�����}�X�^�����ɁA���_���̑O����������E��������������Z�o���܂��B<br/>
        /// ������������̎Z�o�ɂ́A�����S�̐ݒ�}�X�^�̓o�^���e���g�p���܂��B�i��F15��,20��,31���Ń��[�e�[�V�����j<br/>
        /// </remarks>
        /// <example>���X�V�t�h�A�x�����Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int convert;
        /// int status = ttlDayCalc.GetHisTotalDayPayment( "01", out stDate, out edDate, out convert );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayPayment( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out int convertProcessDivCd )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 DEL
            //return GetHisTotalDayPaymentProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            DateTime startCAddUpUpdDate;
            return GetHisTotalDayPaymentProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd, out startCAddUpUpdDate );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
        /// <summary>
        /// �����擾�����y�����E�x���z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <param name="convertProcessDivCd">(�o��)�R���o�[�g�����敪</param>
        /// <param name="startCAddUpUpdDate">(�o��)���X�V�J�n��</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�x�����X�V�����}�X�^�����ɁA���_���̑O����������E��������������Z�o���܂��B<br/>
        /// ������������̎Z�o�ɂ́A�����S�̐ݒ�}�X�^�̓o�^���e���g�p���܂��B�i��F15��,20��,31���Ń��[�e�[�V�����j<br/>
        /// </remarks>
        /// <example>���X�V�t�h�A�x�����Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int convert;
        /// int status = ttlDayCalc.GetHisTotalDayPayment( "01", out stDate, out edDate, out convert );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetHisTotalDayPayment( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out int convertProcessDivCd, out DateTime startCAddUpUpdDate )
        {
            return GetHisTotalDayPaymentProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd, out startCAddUpUpdDate );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        # endregion

        # region [�E���z�E�������|]
        # region (���_�w��)
        /// <summary>
        /// �����擾�����y���z�E�������|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>���Ӑ攄�|���z�}�X�^�����ɁA���Ӑ斈�̔��|�̑O������������Z�o���܂��B<br/>
        /// </remarks>
        /// <example>���ʏ�͂��̏����͎g�p���܂���B�i�����̒��͋��_���̍X�V�ׁ̈j<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccRec( 12345678, out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayMonthlyAccRec( string sectionCode, int customerCode, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            return GetTotalDayMonthlyAccRecProc( sectionCode, customerCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// �����擾�����y���z�E�������|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>���Ӑ攄�|���z�}�X�^�����ɁA���Ӑ斈�̔��|�̑O����������E��������������Z�o���܂��B<br/>
        /// ������������́A��ɑO����������̂P�������Ԃ��܂��B<br/>
        /// </remarks>
        /// <example>���ʏ�͂��̏����͎g�p���܂���B�i�����̒��͋��_���̍X�V�ׁ̈j<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccRec( 12345678, out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayMonthlyAccRec( string sectionCode, int customerCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            return GetTotalDayMonthlyAccRecProc( sectionCode, customerCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// �����擾�����y���z�E�������|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <param name="prevTotalMonth">(�o��)�O���������</param>
        /// <param name="currentTotalMonth">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>���Ӑ攄�|���z�}�X�^�����ɁA���Ӑ斈�̔��|�̑O����������E������������E�O����������E��������������Z�o���܂��B<br/>
        /// ������������́A��ɑO����������̂P�������Ԃ��܂��B<br/>
        /// </remarks>
        /// <example>���ʏ�͂��̏����͎g�p���܂���B�i�����̒��͋��_���̍X�V�ׁ̈j<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// DateTime stMonth;<br/>
        /// DateTime edMonth;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccRec( 12345678, out stDate, out edDate, out stMonth, out edMonth );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayMonthlyAccRec( string sectionCode, int customerCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth )
        {
            return GetTotalDayMonthlyAccRecProc( sectionCode, customerCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����y���z�E�������|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="date">���t</param>
        /// <returns>true:���ς�, false:������</returns>
        /// 
        /// <remarks>���Ӑ攄�|���z�}�X�^�����ɁA�w�蓾�Ӑ�Ɋւ��āA�w����t�̒��X�V�ς݃`�F�b�N���s���܂��B<br/>
        /// </remarks>
        /// <example>�e��G���g���Ȃ�<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckMonthlyAccRec( 12345678, date );<br/>
        /// </example>
        public bool CheckMonthlyAccRec( string sectionCode, int customerCode, DateTime date )
        {
            DateTime prevTotalDay;
            return CheckMonthlyAccRecProc( sectionCode, customerCode, date, out prevTotalDay );
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����y���z�E�������|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="date">���t</param>
        /// <param name="prevTotalDay">�O���������</param>
        /// <returns>true:���ς�, false:������</returns>
        /// 
        /// <remarks>���Ӑ攄�|���z�}�X�^�����ɁA�w�蓾�Ӑ�Ɋւ��āA�w����t�̒��X�V�ς݃`�F�b�N���s���܂��B<br/>
        /// </remarks>
        /// <example>�e��G���g���Ȃ�<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckMonthlyAccRec( 12345678, date );<br/>
        /// </example>
        public bool CheckMonthlyAccRec( string sectionCode, int customerCode, DateTime date, out DateTime prevTotalDay )
        {
            return CheckMonthlyAccRecProc( sectionCode, customerCode, date, out prevTotalDay );
        }
        # endregion
        # region (���_�w��Ȃ�)
        /// <summary>
        /// �����擾�����y���z�E�������|�z
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>���Ӑ攄�|���z�}�X�^�����ɁA���Ӑ斈�̔��|�̑O������������Z�o���܂��B<br/>
        /// </remarks>
        /// <example>���ʏ�͂��̏����͎g�p���܂���B�i�����̒��͋��_���̍X�V�ׁ̈j<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccRec( 12345678, out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayMonthlyAccRec( int customerCode, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            return GetTotalDayMonthlyAccRecProc( string.Empty, customerCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// �����擾�����y���z�E�������|�z
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>���Ӑ攄�|���z�}�X�^�����ɁA���Ӑ斈�̔��|�̑O����������E��������������Z�o���܂��B<br/>
        /// ������������́A��ɑO����������̂P�������Ԃ��܂��B<br/>
        /// </remarks>
        /// <example>���ʏ�͂��̏����͎g�p���܂���B�i�����̒��͋��_���̍X�V�ׁ̈j<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccRec( 12345678, out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayMonthlyAccRec( int customerCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            return GetTotalDayMonthlyAccRecProc( string.Empty, customerCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// �����擾�����y���z�E�������|�z
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <param name="prevTotalMonth">(�o��)�O���������</param>
        /// <param name="currentTotalMonth">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>���Ӑ攄�|���z�}�X�^�����ɁA���Ӑ斈�̔��|�̑O����������E������������E�O����������E��������������Z�o���܂��B<br/>
        /// ������������́A��ɑO����������̂P�������Ԃ��܂��B<br/>
        /// </remarks>
        /// <example>���ʏ�͂��̏����͎g�p���܂���B�i�����̒��͋��_���̍X�V�ׁ̈j<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// DateTime stMonth;<br/>
        /// DateTime edMonth;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccRec( 12345678, out stDate, out edDate, out stMonth, out edMonth );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayMonthlyAccRec( int customerCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth )
        {
            return GetTotalDayMonthlyAccRecProc( string.Empty, customerCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����y���z�E�������|�z
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="date">���t</param>
        /// <returns>true:���ς�, false:������</returns>
        /// 
        /// <remarks>���Ӑ攄�|���z�}�X�^�����ɁA�w�蓾�Ӑ�Ɋւ��āA�w����t�̒��X�V�ς݃`�F�b�N���s���܂��B<br/>
        /// </remarks>
        /// <example>�e��G���g���Ȃ�<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckMonthlyAccRec( 12345678, date );<br/>
        /// </example>
        public bool CheckMonthlyAccRec( int customerCode, DateTime date)
        {
            DateTime prevTotalDay;
            return CheckMonthlyAccRecProc( string.Empty, customerCode, date, out prevTotalDay );
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����y���z�E�������|�z
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="date">���t</param>
        /// <param name="prevTotalDay">�O���������</param>
        /// <returns>true:���ς�, false:������</returns>
        /// 
        /// <remarks>���Ӑ攄�|���z�}�X�^�����ɁA�w�蓾�Ӑ�Ɋւ��āA�w����t�̒��X�V�ς݃`�F�b�N���s���܂��B<br/>
        /// </remarks>
        /// <example>�e��G���g���Ȃ�<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckMonthlyAccRec( 12345678, date );<br/>
        /// </example>
        public bool CheckMonthlyAccRec( int customerCode, DateTime date, out DateTime prevTotalDay )
        {
            return CheckMonthlyAccRecProc( string.Empty, customerCode, date, out prevTotalDay );
        }
        # endregion
        # endregion

        # region [�F���z�E�������|]
        # region (���_�w��)
        /// <summary>
        /// �����擾�����y���z�E�������|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�d���攃�|���z�}�X�^�����ɁA�d���斈�̔��|�̑O������������Z�o���܂��B<br/>
        /// </remarks>
        /// <example>���ʏ�͂��̏����͎g�p���܂���B�i�����̒��͋��_���̍X�V�ׁ̈j<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccPay( 123456, out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayMonthlyAccPay( string sectionCode, int supplierCd, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            return GetTotalDayMonthlyAccPayProc( sectionCode, supplierCd, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// �����擾�����y���z�E�������|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�d���攃�|���z�}�X�^�����ɁA�d���斈�̔��|�̑O����������E��������������Z�o���܂��B<br/>
        /// ������������́A��ɑO����������̂P�������Ԃ��܂��B<br/>
        /// </remarks>
        /// <example>���ʏ�͂��̏����͎g�p���܂���B�i�����̒��͋��_���̍X�V�ׁ̈j<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccPay( 123456, out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayMonthlyAccPay( string sectionCode, int supplierCd, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            return GetTotalDayMonthlyAccPayProc( sectionCode, supplierCd, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// �����擾�����y���z�E�������|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <param name="prevTotalMonth">(�o��)�O���������</param>
        /// <param name="currentTotalMonth">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�d���攃�|���z�}�X�^�����ɁA�d���斈�̔��|�̑O����������E������������E�O����������E��������������Z�o���܂��B<br/>
        /// ������������́A��ɑO����������̂P�������Ԃ��܂��B<br/>
        /// </remarks>
        /// <example>���ʏ�͂��̏����͎g�p���܂���B�i�����̒��͋��_���̍X�V�ׁ̈j<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccPay( 123456, out stDate, out edDate, out stMonth, out edMonth );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayMonthlyAccPay( string sectionCode, int supplierCd, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth )
        {
            return GetTotalDayMonthlyAccPayProc( sectionCode, supplierCd, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����y���z�E�������|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="date">���t</param>
        /// <returns>true:���ς�, false:������</returns>
        /// 
        /// <remarks>�d���攃�|���z�}�X�^�����ɁA�w��d����Ɋւ��āA�w����t�̒��X�V�ς݃`�F�b�N���s���܂��B<br/>
        /// </remarks>
        /// <example>�e��G���g���Ȃ�<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckMonthlyAccPay( 123456, date );<br/>
        /// </example>
        public bool CheckMonthlyAccPay( string sectionCode, int supplierCd, DateTime date )
        {
            DateTime prevTotalDay;
            return CheckMonthlyAccPayProc( sectionCode, supplierCd, date, out prevTotalDay );
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����y���z�E�������|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="date">���t</param>
        /// <param name="prevTotalDay">�O���������</param>
        /// <returns>true:���ς�, false:������</returns>
        /// 
        /// <remarks>�d���攃�|���z�}�X�^�����ɁA�w��d����Ɋւ��āA�w����t�̒��X�V�ς݃`�F�b�N���s���܂��B<br/>
        /// </remarks>
        /// <example>�e��G���g���Ȃ�<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckMonthlyAccPay( 123456, date );<br/>
        /// </example>
        public bool CheckMonthlyAccPay( string sectionCode, int supplierCd, DateTime date, out DateTime prevTotalDay )
        {
            return CheckMonthlyAccPayProc( sectionCode, supplierCd, date, out prevTotalDay );
        }
        # endregion
        # region (���_�w��Ȃ�)
        /// <summary>
        /// �����擾�����y���z�E�������|�z
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�d���攃�|���z�}�X�^�����ɁA�d���斈�̔��|�̑O������������Z�o���܂��B<br/>
        /// </remarks>
        /// <example>���ʏ�͂��̏����͎g�p���܂���B�i�����̒��͋��_���̍X�V�ׁ̈j<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccPay( 123456, out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayMonthlyAccPay( int supplierCd, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            return GetTotalDayMonthlyAccPayProc( string.Empty, supplierCd, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// �����擾�����y���z�E�������|�z
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�d���攃�|���z�}�X�^�����ɁA�d���斈�̔��|�̑O����������E��������������Z�o���܂��B<br/>
        /// ������������́A��ɑO����������̂P�������Ԃ��܂��B<br/>
        /// </remarks>
        /// <example>���ʏ�͂��̏����͎g�p���܂���B�i�����̒��͋��_���̍X�V�ׁ̈j<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccPay( 123456, out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayMonthlyAccPay( int supplierCd, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            return GetTotalDayMonthlyAccPayProc( string.Empty, supplierCd, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// �����擾�����y���z�E�������|�z
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <param name="prevTotalMonth">(�o��)�O���������</param>
        /// <param name="currentTotalMonth">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�d���攃�|���z�}�X�^�����ɁA�d���斈�̔��|�̑O����������E������������E�O����������E��������������Z�o���܂��B<br/>
        /// ������������́A��ɑO����������̂P�������Ԃ��܂��B<br/>
        /// </remarks>
        /// <example>���ʏ�͂��̏����͎g�p���܂���B�i�����̒��͋��_���̍X�V�ׁ̈j<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccPay( 123456, out stDate, out edDate, out stMonth, out edMonth );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayMonthlyAccPay( int supplierCd, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth )
        {
            return GetTotalDayMonthlyAccPayProc( string.Empty, supplierCd, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����y���z�E�������|�z
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="date">���t</param>
        /// <returns>true:���ς�, false:������</returns>
        /// 
        /// <remarks>�d���攃�|���z�}�X�^�����ɁA�w��d����Ɋւ��āA�w����t�̒��X�V�ς݃`�F�b�N���s���܂��B<br/>
        /// </remarks>
        /// <example>�e��G���g���Ȃ�<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckMonthlyAccPay( 123456, date );<br/>
        /// </example>
        public bool CheckMonthlyAccPay( int supplierCd, DateTime date )
        {
            DateTime prevTotalDay;
            return CheckMonthlyAccPayProc( string.Empty, supplierCd, date, out prevTotalDay );
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����y���z�E�������|�z
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="date">���t</param>
        /// <param name="prevTotalDay">�O���������</param>
        /// <returns>true:���ς�, false:������</returns>
        /// 
        /// <remarks>�d���攃�|���z�}�X�^�����ɁA�w��d����Ɋւ��āA�w����t�̒��X�V�ς݃`�F�b�N���s���܂��B<br/>
        /// </remarks>
        /// <example>�e��G���g���Ȃ�<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckMonthlyAccPay( 123456, date );<br/>
        /// </example>
        public bool CheckMonthlyAccPay( int supplierCd, DateTime date, out DateTime prevTotalDay )
        {
            return CheckMonthlyAccPayProc( string.Empty, supplierCd, date, out prevTotalDay );
        }
        # endregion
        # endregion

        # region [�G���z�E����]
        # region (���_�w��)
        /// <summary>
        /// �����擾�����y���z�E�����z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>���Ӑ搿�����z�}�X�^�����ɁA���Ӑ斈�̑O������������Z�o���܂��B<br/>
        /// </remarks>
        /// <example>�������߂Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayDmdC( 12345678, out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayDmdC( string sectionCode, int customerCode, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            return GetTotalDayDmdCProc( sectionCode, customerCode, out prevTotalDay, out currentTotalDay );
        }
        /// <summary>
        /// �����擾�����y���z�E�����z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>���Ӑ搿�����z�}�X�^�����ɁA���Ӑ斈�̑O����������E��������������Z�o���܂��B<br/>
        /// ������������́A��ɑO����������̂P�������Ԃ��܂��B<br/>
        /// </remarks>
        /// <example>�������߂Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayDmdC( 12345678, out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayDmdC( string sectionCode, int customerCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            return GetTotalDayDmdCProc( sectionCode, customerCode, out prevTotalDay, out currentTotalDay );
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����y���z�E�����z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="date">���t</param>
        /// <returns>true:���ς�, false:������</returns>
        /// 
        /// <remarks>���Ӑ搿�����z�}�X�^�����ɁA�w�蓾�Ӑ�Ɋւ��āA�w����t�̒��X�V�ς݃`�F�b�N���s���܂��B<br/>
        /// </remarks>
        /// <example>�e��G���g���Ȃ�<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckDmdC( 12345678, date );<br/>
        /// </example>
        public bool CheckDmdC( string sectionCode, int customerCode, DateTime date )
        {
            DateTime prevTotalDay;
            return CheckDmdCProc( sectionCode, customerCode, date, out prevTotalDay );
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����y���z�E�����z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="date">���t</param>
        /// <param name="prevTotalDay">�O���������</param>
        /// <returns>true:���ς�, false:������</returns>
        /// 
        /// <remarks>���Ӑ搿�����z�}�X�^�����ɁA�w�蓾�Ӑ�Ɋւ��āA�w����t�̒��X�V�ς݃`�F�b�N���s���܂��B<br/>
        /// </remarks>
        /// <example>�e��G���g���Ȃ�<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckDmdC( 12345678, date );<br/>
        /// </example>
        public bool CheckDmdC( string sectionCode, int customerCode, DateTime date, out DateTime prevTotalDay )
        {
            return CheckDmdCProc( sectionCode, customerCode, date, out prevTotalDay );
        }
        # endregion
        # region (���_�w��Ȃ�)
        /// <summary>
        /// �����擾�����y���z�E�����z
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>���Ӑ搿�����z�}�X�^�����ɁA���Ӑ斈�̑O������������Z�o���܂��B<br/>
        /// </remarks>
        /// <example>�������߂Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayDmdC( 12345678, out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayDmdC( int customerCode, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            return GetTotalDayDmdCProc( string.Empty, customerCode, out prevTotalDay, out currentTotalDay );
        }
        /// <summary>
        /// �����擾�����y���z�E�����z
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>���Ӑ搿�����z�}�X�^�����ɁA���Ӑ斈�̑O����������E��������������Z�o���܂��B<br/>
        /// ������������́A��ɑO����������̂P�������Ԃ��܂��B<br/>
        /// </remarks>
        /// <example>�������߂Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayDmdC( 12345678, out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayDmdC( int customerCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            return GetTotalDayDmdCProc( string.Empty, customerCode, out prevTotalDay, out currentTotalDay );
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����y���z�E�����z
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="date">���t</param>
        /// <returns>true:���ς�, false:������</returns>
        /// 
        /// <remarks>���Ӑ搿�����z�}�X�^�����ɁA�w�蓾�Ӑ�Ɋւ��āA�w����t�̒��X�V�ς݃`�F�b�N���s���܂��B<br/>
        /// </remarks>
        /// <example>�e��G���g���Ȃ�<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckDmdC( 12345678, date );<br/>
        /// </example>
        public bool CheckDmdC( int customerCode, DateTime date )
        {
            DateTime prevTotalDay;
            return CheckDmdCProc( string.Empty, customerCode, date, out prevTotalDay );
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����y���z�E�����z
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="date">���t</param>
        /// <param name="prevTotalDay">�O���������</param>
        /// <returns>true:���ς�, false:������</returns>
        /// 
        /// <remarks>���Ӑ搿�����z�}�X�^�����ɁA�w�蓾�Ӑ�Ɋւ��āA�w����t�̒��X�V�ς݃`�F�b�N���s���܂��B<br/>
        /// </remarks>
        /// <example>�e��G���g���Ȃ�<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckDmdC( 12345678, date );<br/>
        /// </example>
        public bool CheckDmdC( int customerCode, DateTime date, out DateTime prevTotalDay )
        {
            return CheckDmdCProc( string.Empty, customerCode, date, out prevTotalDay );
        }
        # endregion
        # endregion

        # region [�H���z�E�x��]
        # region (���_�w��)
        /// <summary>
        /// �����擾�����y���z�E�x���z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�d����x�����z�}�X�^�����ɁA�d���斈�̑O������������Z�o���܂��B<br/>
        /// </remarks>
        /// <example>�x�����߂Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayPayment( 123456, out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayPayment( string sectionCode, int supplierCd, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            return GetTotalDayPaymentProc( sectionCode, supplierCd, out prevTotalDay, out currentTotalDay );
        }
        /// <summary>
        /// �����擾�����y���z�E�x���z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�d����x�����z�}�X�^�����ɁA�d���斈�̑O����������E��������������Z�o���܂��B<br/>
        /// ������������́A��ɑO����������̂P�������Ԃ��܂��B<br/>
        /// </remarks>
        /// <example>�x�����߂Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayPayment( 123456, out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayPayment( string sectionCode, int supplierCd, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            return GetTotalDayPaymentProc( sectionCode, supplierCd, out prevTotalDay, out currentTotalDay );
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����y���z�E�x���z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="date">���t</param>
        /// <returns>true:���ς�, false:������</returns>
        /// 
        /// <remarks>�d����x�����z�}�X�^�����ɁA�w��d����Ɋւ��āA�w����t�̒��X�V�ς݃`�F�b�N���s���܂��B<br/>
        /// </remarks>
        /// <example>�e��G���g���Ȃ�<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckPayment( 123456, date );<br/>
        /// </example>
        public bool CheckPayment( string sectionCode, int supplierCd, DateTime date )
        {
            DateTime prevTotalDay;
            return CheckPaymentProc( sectionCode, supplierCd, date, out prevTotalDay );
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����y���z�E�x���z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="date">���t</param>
        /// <param name="prevTotalDay">�O���������</param>
        /// <returns>true:���ς�, false:������</returns>
        /// 
        /// <remarks>�d����x�����z�}�X�^�����ɁA�w��d����Ɋւ��āA�w����t�̒��X�V�ς݃`�F�b�N���s���܂��B<br/>
        /// </remarks>
        /// <example>�e��G���g���Ȃ�<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckPayment( 123456, date );<br/>
        /// </example>
        public bool CheckPayment( string sectionCode, int supplierCd, DateTime date, out DateTime prevTotalDay )
        {
            return CheckPaymentProc( sectionCode, supplierCd, date, out prevTotalDay );
        }
        # endregion
        # region (���_�w��Ȃ�)
        /// <summary>
        /// �����擾�����y���z�E�x���z
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�d����x�����z�}�X�^�����ɁA�d���斈�̑O������������Z�o���܂��B<br/>
        /// </remarks>
        /// <example>�x�����߂Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayPayment( 123456, out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayPayment( int supplierCd, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            return GetTotalDayPaymentProc( string.Empty, supplierCd, out prevTotalDay, out currentTotalDay );
        }
        /// <summary>
        /// �����擾�����y���z�E�x���z
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>�d����x�����z�}�X�^�����ɁA�d���斈�̑O����������E��������������Z�o���܂��B<br/>
        /// ������������́A��ɑO����������̂P�������Ԃ��܂��B<br/>
        /// </remarks>
        /// <example>�x�����߂Ɋւ��钠�[�E�Ɖ�Ȃ�<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayPayment( 123456, out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // �O����̗���<br/>
        /// </example>
        public int GetTotalDayPayment( int supplierCd, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            return GetTotalDayPaymentProc( string.Empty, supplierCd, out prevTotalDay, out currentTotalDay );
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����y���z�E�x���z
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="date">���t</param>
        /// <returns>true:���ς�, false:������</returns>
        /// 
        /// <remarks>�d����x�����z�}�X�^�����ɁA�w��d����Ɋւ��āA�w����t�̒��X�V�ς݃`�F�b�N���s���܂��B<br/>
        /// </remarks>
        /// <example>�e��G���g���Ȃ�<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckPayment( 123456, date );<br/>
        /// </example>
        public bool CheckPayment( int supplierCd, DateTime date )
        {
            DateTime prevTotalDay;
            return CheckPaymentProc( string.Empty, supplierCd, date, out prevTotalDay );
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����y���z�E�x���z
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="date">���t</param>
        /// <param name="prevTotalDay">�O���������</param>
        /// <returns>true:���ς�, false:������</returns>
        /// 
        /// <remarks>�d����x�����z�}�X�^�����ɁA�w��d����Ɋւ��āA�w����t�̒��X�V�ς݃`�F�b�N���s���܂��B<br/>
        /// </remarks>
        /// <example>�e��G���g���Ȃ�<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckPayment( 123456, date );<br/>
        /// </example>
        public bool CheckPayment( int supplierCd, DateTime date, out DateTime prevTotalDay )
        {
            return CheckPaymentProc( string.Empty, supplierCd, date, out prevTotalDay );
        }
        # endregion
        # endregion

        # region [�L���b�V���N���A����]
        /// <summary>
        /// �L���b�V���N���A����
        /// </summary>
        /// <remarks>�A�N�Z�X�N���X�����ŕێ����Ă��郊���[�g�擾�f�[�^�L���b�V�����N���A���܂��B<br/>
        /// �Ӑ}�I�Ƀ����[�g�Ăяo���ɂ��f�[�^�擾�������ꍇ�Ɏg�p���ĉ������B<br/>
        /// </remarks>
        public void ClearCache()
        {
            ClearCacheProc();
        }
        # endregion

        // ===================================================================================== //
        // private ���\�b�h
        // ===================================================================================== //

        # region [�@�����E�������|]
        /// <summary>
        /// ���������i�����E�������ʁj
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>���̏����́y�����E�������|�z�Ɓy�����E�������|�z�ŋ��ʂł��B</br>
        /// </remarks>
        private int InitializeHisMonthlyProc()
        {
            // ���������ς�
            if ( _extractedHisMonthly ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                //---------------------------------------------
                // ���_�͎w�肵�Ȃ����A���t�͐�������B
                // ( �L���󂭎�� )
                //---------------------------------------------

                // �����p�����[�^����
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.St_Date = _startDate;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // �����[�g�Ăяo��
                object retObj;
                status = _iTtlDayCalcDB.SearchHisMonthly( out retObj, paraWork );

                // ���ʂ̓W�J
                DevelopResultOfHisMonthly( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );
                _extractedHisMonthly = true;

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // �}�X�^�W�J
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
            }
            catch ( Exception )
            {
            }

            return status;
        }
        /// <summary>
        /// �W�J�����i�����E�������ʁj
        /// </summary>
        /// <param name="customSerializeArrayList"></param>
        /// <param name="paraWork"></param>
        /// <remarks>
        /// <br>���̏����́y�����E�������|�z�Ɓy�����E�������|�z�ŋ��ʂł��B</br>
        /// </remarks>
        private void DevelopResultOfHisMonthly( CustomSerializeArrayList customSerializeArrayList, TtlDayCalcParaWork paraWork )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/09 ADD
            // �S���_�̑O���������
            DateTime allSectionPrevDate = DateTime.MinValue;
            // �S���_�̃R���o�[�g�����敪
            int allSectionConvProcDivCd = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/09 ADD
            
            // �e�[�u������
            if ( _tableOfHisMonthly == null )
            {
                _tableOfHisMonthly = PMCMN00101EA.CreateTableOfHisMonthly();
            }

            for ( int index = 0; index < customSerializeArrayList.Count; index++ )
            {
                TtlDayCalcRetWork retWork = (customSerializeArrayList[index] as TtlDayCalcRetWork);

                // �d���`�F�b�N���ĂȂ���Βǉ�
                DataRow row = _tableOfHisMonthly.Rows.Find( new object[] { retWork.ProcDiv, retWork.SectionCode } );
                if ( row == null )
                {
                    row = _tableOfHisMonthly.NewRow();

                    row[PMCMN00101EA.ct_Col_ProcDiv] = retWork.ProcDiv;
                    row[PMCMN00101EA.ct_Col_SectionCode] = retWork.SectionCode;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/09 DEL
                    //row[PMCMN00101EA.ct_Col_PrevTotalDay] = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/09 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/09 ADD
                    DateTime prevTotalDay = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = prevTotalDay;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/09 ADD
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_PrevTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_CurrentTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_ConvertProcessDivCd] = retWork.ConvertProcessDivCd;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;

                    _tableOfHisMonthly.Rows.Add( row );

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/09 ADD
                    // �S�Ќ���(�S���_�ň�ԑ傫���l���g�p)
                    if ( allSectionPrevDate < prevTotalDay )
                    {
                        allSectionPrevDate = prevTotalDay;
                        allSectionConvProcDivCd = retWork.ConvertProcessDivCd;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/09 ADD
                }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/09 ADD
            // �S�Ќ���(�S���_�ň�ԑ傫���l���g�p)
            if ( allSectionPrevDate != DateTime.MinValue )
            {
                DateTime prevTotalDay = DateTime.MinValue;
                DataRow row = _tableOfHisMonthly.Rows.Find( new object[] { paraWork.ProcDiv, string.Empty } );
                if ( row == null )
                {
                    row = _tableOfHisMonthly.NewRow();
                    row[PMCMN00101EA.ct_Col_ProcDiv] = paraWork.ProcDiv;
                    row[PMCMN00101EA.ct_Col_SectionCode] = string.Empty;
                    _tableOfHisMonthly.Rows.Add( row );
                }
                else
                {
                    // �������R�[�h������Ό��ݒl��ޔ�
                    prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
                }

                // �������R�[�h������ꍇ�͑傫�������̗p
                if ( prevTotalDay < allSectionPrevDate )
                {
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = allSectionPrevDate;
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_PrevTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_CurrentTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_ConvertProcessDivCd] = allSectionConvProcDivCd;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/09 ADD
        }
        /// <summary>
        /// �����擾�����i�����E�������|�j
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="prevTotalDay"></param>
        /// <param name="currentTotalDay"></param>
        /// <param name="prevTotalMonth"></param>
        /// <param name="currentTotalMonth"></param>
        /// <param name="convertProcessDivCd"></param>
        /// <returns></returns>
        private int GetHisTotalDayMonthlyAccRecProc( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth, out int convertProcessDivCd )
        {
            // ���������Ăяo��
            InitializeHisMonthlyProc();


            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;
            currentTotalDay = DateTime.MinValue;
            prevTotalMonth = DateTime.MinValue;
            currentTotalMonth = DateTime.MinValue;
            convertProcessDivCd = 0;

            //--------------------------------------------
            // DataTable���猟���E������΃����[�g
            //--------------------------------------------
            DataRow row = _tableOfHisMonthly.Rows.Find( new object[] { PMCMN00101EA.ct_ProcDiv_AccRec, sectionCode } );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
            //// �S��
            //if ( row == null ) 
            //{
            //    row = _tableOfHisMonthly.Rows.Find( new object[] { PMCMN00101EA.ct_ProcDiv_AccRec, string.Empty } );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL

            // �ēx�����[�g
            if ( row == null )
            {
                # region [���������[�g���o]
                // �����p�����[�^����
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // �����[�g�Ăяo��
                object retObj;
                status = _iTtlDayCalcDB.SearchHisMonthly( out retObj, paraWork );

                // ���ʂ̓W�J
                DevelopResultOfHisMonthly( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // �}�X�^�W�J
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
                # endregion

                // �ēxDataTable���猟��
                row = _tableOfHisMonthly.Rows.Find( new object[] { PMCMN00101EA.ct_ProcDiv_AccRec, sectionCode } );
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
            //// �ēx�S��
            //if ( row == null )
            //{
            //    row = _tableOfHisMonthly.Rows.Find( new object[] { PMCMN00101EA.ct_ProcDiv_AccRec, string.Empty } );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL

            if ( row == null ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //--------------------------------------------
            // �e����t���Z�o
            //--------------------------------------------
            ReflectTotalDayForMonthly( ref row );

            //--------------------------------------------
            // �Z�o���ʂ��Z�b�g
            //--------------------------------------------
            prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
            currentTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalDay];
            prevTotalMonth = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalMonth];
            currentTotalMonth = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalMonth];
            convertProcessDivCd = (Int32)row[PMCMN00101EA.ct_Col_ConvertProcessDivCd];

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        /// <summary>
        /// ���������Ɋ�Â��e����t�Z�o�i�����p�j
        /// </summary>
        /// <param name="row"></param>
        /// <remarks>
        /// <br>���̏����́y�����E�������|�z�y�����E�������|�z�y���z�E�������|�z�y���z�E�������|�z�ŋ��ʂł��B</br>
        /// </remarks>
        private void ReflectTotalDayForMonthly( ref DataRow row )
        {
            if ( (int)row[PMCMN00101EA.ct_Col_CurrentCalcFlag] <= 0 )
            {
                //**********************************************************
                // ���Z�o�Ȃ�Z�o����
                //**********************************************************

                # region [�e����t�Z�o]
                // �O�񏈗���
                DateTime prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];

                // ���񏈗���
                row[PMCMN00101EA.ct_Col_CurrentTotalDay] = GetCurrentTotalDayOfNextMonth( prevTotalDay );

                // �O�񏈗������O�񏈗���
                DateTime outDate;
                _finYearTableGenerator.GetYearMonth( prevTotalDay, out outDate );
                row[PMCMN00101EA.ct_Col_PrevTotalMonth] = outDate;

                // ���񏈗��������񏈗���
                _finYearTableGenerator.GetYearMonth( (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalDay], out outDate );
                row[PMCMN00101EA.ct_Col_CurrentTotalMonth] = outDate;
                # endregion

                // �Z�o�ς݃t���O
                row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 1;
            }
        }
        /// <summary>
        /// ������������擾�����i�P���ȗ����擾�j
        /// </summary>
        /// <param name="prevTotalDay">�O���������</param>
        /// <returns>�����������</returns>
        private DateTime GetCurrentTotalDayOfNextMonth( DateTime prevTotalDay )
        {
            // �O�񏈗��������񏈗���
            if ( prevTotalDay.Day >= 28 )
            {
                //-----------------------------------
                // xxxx.08.31 31>=28�Ȃ̂Ŗ�������
                //  ��
                // xxxx.08.28 �Œ��28�ɂ���
                //  ��
                // xxxx.09.28 AddMonths�łP�����i�߂�
                //  ��
                // xxxx.09.30 DaysInMonth�Ŗ����ɂ���
                //-----------------------------------

                // ��������
                DateTime dateTime = (new DateTime( prevTotalDay.Year, prevTotalDay.Month, 28 )).AddMonths( 1 );
                return new DateTime( dateTime.Year, dateTime.Month, DateTime.DaysInMonth( dateTime.Year, dateTime.Month ) );
            }
            else
            {
                // �����ȊO
                return prevTotalDay.AddMonths( 1 );
            }
        }
        # endregion

        # region [�A�����E�������|]
        /// <summary>
        /// �����擾�����i�����E�������|�j
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="prevTotalDay"></param>
        /// <param name="currentTotalDay"></param>
        /// <param name="prevTotalMonth"></param>
        /// <param name="currentTotalMonth"></param>
        /// <param name="convertProcessDivCd"></param>
        /// <returns></returns>
        private int GetHisTotalDayMonthlyAccPayProc( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth, out int convertProcessDivCd )
        {
            // ���������Ăяo��
            InitializeHisMonthlyProc();


            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;
            currentTotalDay = DateTime.MinValue;
            prevTotalMonth = DateTime.MinValue;
            currentTotalMonth = DateTime.MinValue;
            convertProcessDivCd = 0;

            //--------------------------------------------
            // DataTable���猟���E������΃����[�g
            //--------------------------------------------
            DataRow row = _tableOfHisMonthly.Rows.Find( new object[] { PMCMN00101EA.ct_ProcDiv_AccPay, sectionCode } );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
            //// �S��
            //if ( row == null )
            //{
            //    row = _tableOfHisMonthly.Rows.Find( new object[] { PMCMN00101EA.ct_ProcDiv_AccPay, string.Empty } );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL

            // �ēx�����[�g
            if ( row == null )
            {
                # region [���������[�g���o]
                // �����p�����[�^����
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.WithMasterDiv = this.WithMasterDiv;
                paraWork.ProcDiv = PMCMN00101EA.ct_ProcDiv_AccPay; 

                // �����[�g�Ăяo��
                object retObj;
                status = _iTtlDayCalcDB.SearchHisMonthly( out retObj, paraWork );

                // ���ʂ̓W�J
                DevelopResultOfHisMonthly( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // �}�X�^�W�J
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
                # endregion

                // �ēxDataTable���猟��
                row = _tableOfHisMonthly.Rows.Find( new object[] { PMCMN00101EA.ct_ProcDiv_AccPay, sectionCode } );
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
            //// �ēx�S��
            //if ( row == null )
            //{
            //    row = _tableOfHisMonthly.Rows.Find( new object[] { PMCMN00101EA.ct_ProcDiv_AccPay, string.Empty } );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL

            if ( row == null ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //--------------------------------------------
            // �e����t���Z�o
            //--------------------------------------------
            ReflectTotalDayForMonthly( ref row );

            //--------------------------------------------
            // �Z�o���ʂ��Z�b�g
            //--------------------------------------------
            prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
            currentTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalDay];
            prevTotalMonth = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalMonth];
            currentTotalMonth = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalMonth];
            convertProcessDivCd = (Int32)row[PMCMN00101EA.ct_Col_ConvertProcessDivCd];

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        # endregion

        # region [�B�����E�������|�����|]
        /// <summary>
        /// �����擾�����y�����E�������|�����|�z
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <param name="prevTotalMonth">(�o��)�O���������</param>
        /// <param name="currentTotalMonth">(�o��)�����������</param>
        /// <param name="convertProcessDivCd">(�o��)�R���o�[�g�����敪</param>
        /// <returns></returns>
        private int GetHisTotalDayMonthlyProc( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth, out int convertProcessDivCd )
        {
            int status;

            if ( _enableOptionAccPay )
            {
                //--------------------------------------------
                // ���|�I�v�V�����F����
                //--------------------------------------------
                # region [���|����]
                // ������
                prevTotalDay = DateTime.MinValue;
                currentTotalDay = DateTime.MinValue;
                prevTotalMonth = DateTime.MinValue;
                currentTotalMonth = DateTime.MinValue;
                convertProcessDivCd = 0;

                DateTime[] retPrevTotalDay = new DateTime[2];
                DateTime[] retCurrentTotalDay = new DateTime[2];
                DateTime[] retPrevTotalMonth = new DateTime[2];
                DateTime[] retCurrentTotalMonth = new DateTime[2];
                int[] retConvertProcessDivCd = new int[2];

                // ���|
                status = GetHisTotalDayMonthlyAccRecProc( sectionCode, out retPrevTotalDay[0], out retCurrentTotalDay[0], out retPrevTotalMonth[0], out retCurrentTotalMonth[0], out retConvertProcessDivCd[0] );
                if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
                    return status;
                }

                // ���|
                status = GetHisTotalDayMonthlyAccPayProc( sectionCode, out retPrevTotalDay[1], out retCurrentTotalDay[1], out retPrevTotalMonth[1], out retCurrentTotalMonth[1], out retConvertProcessDivCd[1] );
                if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
                    return status;
                }

                //--------------------------------------
                // ���|�������Ɣ��|���������r�i�����������̗p�j
                //--------------------------------------
                if ( retPrevTotalDay[0] >= retPrevTotalDay[1] )
                {
                    // ���|�����|�@���@���|��Ԃ�
                    prevTotalDay = retPrevTotalDay[1];
                    currentTotalDay = retCurrentTotalDay[1];
                    prevTotalMonth = retPrevTotalMonth[1];
                    currentTotalMonth = retCurrentTotalMonth[1];
                    convertProcessDivCd = retConvertProcessDivCd[1];
                }
                else
                {
                    // ���|�����|�@���@���|��Ԃ�
                    prevTotalDay = retPrevTotalDay[0];
                    currentTotalDay = retCurrentTotalDay[0];
                    prevTotalMonth = retPrevTotalMonth[0];
                    currentTotalMonth = retCurrentTotalMonth[0];
                    convertProcessDivCd = retConvertProcessDivCd[0];
                }
                # endregion
            }
            else
            {
                //--------------------------------------------
                // ���|�I�v�V�����F�Ȃ�
                //--------------------------------------------
                # region [���|�Ȃ�]
                // ���|�̂݌Ăяo���̂Ɠ���
                status = GetHisTotalDayMonthlyAccRecProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
                # endregion
            }
            return status;
        }
        # endregion

        # region [�C�����E����]
        /// <summary>
        /// ���������i�����E�����j
        /// </summary>
        /// <returns>STATUS</returns>
        private int InitializeHisDmdCProc()
        {
            // ���������ς�
            if ( _extractedHisDmdC ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                //---------------------------------------------
                // ���_�͎w�肵�Ȃ����A���t�͐�������B
                // ( �L���󂭎�� )
                //---------------------------------------------

                // �����p�����[�^����
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.CustomerCode = 0;
                paraWork.St_Date = _startDate;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // �����[�g�Ăяo��
                object retObj;
                status = _iTtlDayCalcDB.SearchHisDmdC( out retObj, paraWork );

                // ���ʂ̓W�J
                DevelopResultOfHisDmdC( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );
                _extractedHisDmdC = true;

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // �}�X�^�W�J
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
            }
            catch ( Exception )
            {
            }

            return status;
        }
        /// <summary>
        /// �W�J�����i�����E�����j
        /// </summary>
        /// <param name="customSerializeArrayList"></param>
        /// <param name="paraWork"></param>
        private void DevelopResultOfHisDmdC( CustomSerializeArrayList customSerializeArrayList, TtlDayCalcParaWork paraWork )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 ADD
            // �S���_�̑O���������
            DateTime allSectionPrevDate = DateTime.MinValue;
            // �S���_�̃R���o�[�g�����敪
            int allSectionConvProcDivCd = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            // �S���_�̒������J�n��
            DateTime allSectionStartCAddUpUpdDate = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD

            // �e�[�u������
            if ( _tableOfHisDmdC == null )
            {
                _tableOfHisDmdC = PMCMN00101EA.CreateTableOfHisDmdC();
            }

            for ( int index = 0; index < customSerializeArrayList.Count; index++ )
            {
                TtlDayCalcRetWork retWork = (customSerializeArrayList[index] as TtlDayCalcRetWork);

                // �d���`�F�b�N���ĂȂ���Βǉ�
                DataRow row = _tableOfHisDmdC.Rows.Find( new object[] { retWork.SectionCode } );
                if ( row == null )
                {
                    row = _tableOfHisDmdC.NewRow();

                    row[PMCMN00101EA.ct_Col_SectionCode] = retWork.SectionCode;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 DEL
                    //row[PMCMN00101EA.ct_Col_PrevTotalDay] = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 ADD
                    DateTime prevTotalDay = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = prevTotalDay;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 ADD
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_ConvertProcessDivCd] = retWork.ConvertProcessDivCd;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
                    row[PMCMN00101EA.ct_Col_StartCAddUpUpdDate] = retWork.StartCAddUpUpdDate;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD

                    _tableOfHisDmdC.Rows.Add( row );

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 ADD
                    // �S�Ќ���(�S���_�ň�ԑ傫���l���g�p)
                    if ( allSectionPrevDate < prevTotalDay )
                    {
                        allSectionPrevDate = prevTotalDay;
                        allSectionConvProcDivCd = retWork.ConvertProcessDivCd;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
                        allSectionStartCAddUpUpdDate = retWork.StartCAddUpUpdDate;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 ADD
                }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 ADD
            // �S�Ќ���(�S���_�ň�ԑ傫���l���g�p)
            if ( allSectionPrevDate != DateTime.MinValue )
            {
                DateTime prevTotalDay = DateTime.MinValue;
                DataRow row = _tableOfHisDmdC.Rows.Find( new object[] { string.Empty } );
                if ( row == null )
                {
                    row = _tableOfHisDmdC.NewRow();
                    //row[PMCMN00101EA.ct_Col_ProcDiv] = paraWork.ProcDiv;
                    row[PMCMN00101EA.ct_Col_SectionCode] = string.Empty;
                    _tableOfHisDmdC.Rows.Add( row );
                }
                else
                {
                    // �������R�[�h������Ό��ݒl��ޔ�
                    prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
                }

                // �������R�[�h������ꍇ�͑傫�������̗p
                if ( prevTotalDay < allSectionPrevDate )
                {
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = allSectionPrevDate;
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    //row[PMCMN00101EA.ct_Col_PrevTotalMonth] = DateTime.MinValue;
                    //row[PMCMN00101EA.ct_Col_CurrentTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_ConvertProcessDivCd] = allSectionConvProcDivCd;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
                    row[PMCMN00101EA.ct_Col_StartCAddUpUpdDate] = allSectionStartCAddUpUpdDate;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 ADD
        }
        /// <summary>
        /// �����擾�����i�����E�������|�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <param name="convertProcessDivCd">(�o��)�R���o�[�g�����敪</param>
        /// <param name="startCAddUpUpdDate">(�o��)���X�V�J�n��</param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
        //private int GetHisTotalDayDmdCProc( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out int convertProcessDivCd )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
        private int GetHisTotalDayDmdCProc( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out int convertProcessDivCd, out DateTime startCAddUpUpdDate )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        {
            // ���������Ăяo��
            InitializeHisDmdCProc();


            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;
            currentTotalDay = DateTime.MinValue;
            convertProcessDivCd = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            startCAddUpUpdDate = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD

            //--------------------------------------------
            // DataTable���猟���E������΃����[�g
            //--------------------------------------------
            DataRow row = _tableOfHisDmdC.Rows.Find( new object[] { sectionCode } );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 DEL
            //// �S��
            //if ( row == null )
            //{
            //    row = _tableOfHisDmdC.Rows.Find( new object[] { string.Empty } );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 DEL

            // �ēx�����[�g
            if ( row == null )
            {
                # region [���������[�g���o]
                // �����p�����[�^����
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.CustomerCode = 0;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // �����[�g�Ăяo��
                object retObj;
                status = _iTtlDayCalcDB.SearchHisDmdC( out retObj, paraWork );

                // ���ʂ̓W�J
                DevelopResultOfHisDmdC( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // �}�X�^�W�J
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
                # endregion

                // �ēxDataTable���猟��
                row = _tableOfHisDmdC.Rows.Find( new object[] { sectionCode } );
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 DEL
            //// �ēx�S��
            //if ( row == null )
            //{
            //    row = _tableOfHisDmdC.Rows.Find( new object[] { string.Empty } );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 DEL

            if ( row == null ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //--------------------------------------------
            // �e����t���Z�o
            //--------------------------------------------
            ReflectTotalDayForHisDmdC( ref row );

            //--------------------------------------------
            // �Z�o���ʂ��Z�b�g
            //--------------------------------------------
            prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
            currentTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalDay];
            convertProcessDivCd = (Int32)row[PMCMN00101EA.ct_Col_ConvertProcessDivCd];
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            startCAddUpUpdDate = (DateTime)row[PMCMN00101EA.ct_Col_StartCAddUpUpdDate];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        /// <summary>
        /// ���������Ɋ�Â��e����t�Z�o�i���𐿋��p�j
        /// </summary>
        /// <param name="row"></param>
        private void ReflectTotalDayForHisDmdC( ref DataRow row )
        {
            if ( (int)row[PMCMN00101EA.ct_Col_CurrentCalcFlag] <= 0 )
            {
                //**********************************************************
                // ���Z�o�Ȃ�Z�o����
                //**********************************************************

                // �O���������
                DateTime prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];

                // �����S�̐ݒ�擾
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 DEL
                //BillAllStWork billAllSt = FindBillAllSt( _billAllStWorkList, (string)row[PMCMN00101EA.ct_Col_SectionCode] );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
                // �����擾�͏��00:�S�Ђ̃��R�[�h����
                BillAllStWork billAllSt = FindBillAllSt( _billAllStWorkList, ct_AllSectionCode );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD

                List<int> totalDay = new List<int>( new int[]{
                                        billAllSt.CustomerTotalDay1, billAllSt.CustomerTotalDay2, billAllSt.CustomerTotalDay3,
                                        billAllSt.CustomerTotalDay4, billAllSt.CustomerTotalDay5, billAllSt.CustomerTotalDay6,
                                        billAllSt.CustomerTotalDay7, billAllSt.CustomerTotalDay8, billAllSt.CustomerTotalDay9,
                                        billAllSt.CustomerTotalDay10, billAllSt.CustomerTotalDay11, billAllSt.CustomerTotalDay12
                                    } );

                // ��������������擾�i�����j
                row[PMCMN00101EA.ct_Col_CurrentTotalDay] = GetCurrentTotalDayOfDmd( totalDay, prevTotalDay );

                // �Z�o�ς݃t���O
                row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 1;
            }
        }

        /// <summary>
        /// ������������Z�o�����i�����E�x���p�j
        /// </summary>
        /// <param name="totalDayList">����("��")���X�g</param>
        /// <param name="prevTotalDay">�O���������(yyyy/mm/dd)</param>
        /// <returns>�����������</returns>
        private DateTime GetCurrentTotalDayOfDmd( List<int> totalDayList, DateTime prevTotalDay )
        {
            DateTime retCurrentTotalDay;

            //--------------------------------------------
            // �O�����������"��"���擾
            //--------------------------------------------
            int dayOfPrevTotalDay = prevTotalDay.Day;
            // �����擾
            if ( dayOfPrevTotalDay >= 28 )
            {
                dayOfPrevTotalDay = 31;
            }

            //--------------------------------------------
            // �������������"��"���擾
            //--------------------------------------------

            // �\�[�g����B
            // �itotalDayList�ɂ�"0"���܂܂��j
            totalDayList.Sort();

            int dayOfCurrentTotalDay = 0;
            for ( int index = 0; index < totalDayList.Count; index++ )
            {
                //-----------------------------------------------------------------
                // �yMEMO�z
                // 
                //   totalDayList�ɂ�"0"���܂܂��B
                //   ��Ƃ��� [ 15, 20, 31 ]�Ń��[�e�[�V��������ꍇ�A
                //
                //     0,0,0,0,0,0,0,0,0,15,20,31 
                //   
                //   �擪���猩�Ă����A0�Ŗ����ŏ��̒l��15��ޔ����Ă����B
                //   
                //   �O��̒���("��")
                //     15 �� 20���Z�b�g����break
                //     20 �� 31���Z�b�g����break
                //     31 �� ���[�v�𔲂��邪�A�ŏ���15���Z�b�g�ς݂Ȃ̂Ō��ʂn�j
                // 
                //   -------------------------------------------------
                //   ���Ȃ݂ɁA
                //     0,0,0,0,0,0,0,0,0,0,0,31�@�̏ꍇ
                //   
                //   �ŏ���31��ޔ��������_��continue���āA���̂܂܃��[�v�𔲂���B
                //-----------------------------------------------------------------

                // �[���ł͂Ȃ��ŏ��̒�����ޔ����Ă���
                if ( dayOfCurrentTotalDay == 0 && totalDayList[index] > 0 )
                {
                    dayOfCurrentTotalDay = totalDayList[index];
                    continue;
                }

                // �O�����������"��"�𒴂�����������������_�ŏI��
                if ( totalDayList[index] > dayOfPrevTotalDay )
                {
                    dayOfCurrentTotalDay = totalDayList[index];
                    break;
                }
            }

            //--------------------------------------------
            // ��������������Z�o
            //--------------------------------------------

            // �܂��A�O�������������yyyy/mm�����R�s�[����
            retCurrentTotalDay = new DateTime( prevTotalDay.Year, prevTotalDay.Month, 1 );

            // ��������i"��"���m�ő召��r����j
            //if ( dayOfPrevTotalDay > dayOfCurrentTotalDay )
            if ( dayOfPrevTotalDay >= dayOfCurrentTotalDay )
            {
                // �����ɐi�߂�
                retCurrentTotalDay = retCurrentTotalDay.AddMonths( 1 );
            }

            // ��������
            if ( dayOfCurrentTotalDay >= 28 )
            {
                // �����i"��"�͂��̌����̓����ɓ������j
                retCurrentTotalDay = new DateTime( retCurrentTotalDay.Year, retCurrentTotalDay.Month,
                                                    DateTime.DaysInMonth( retCurrentTotalDay.Year, retCurrentTotalDay.Month ) );
            }
            else
            {
                // �����ȊO�i"��"�͎擾���ʂ̂܂܁j
                retCurrentTotalDay = new DateTime( retCurrentTotalDay.Year, retCurrentTotalDay.Month, dayOfCurrentTotalDay );
            }

            return retCurrentTotalDay;
        }
        # endregion

        # region [�D�����E�x��]
        /// <summary>
        /// ���������i�����E�x���j
        /// </summary>
        /// <returns>STATUS</returns>
        private int InitializeHisPaymentProc()
        {
            // ���������ς�
            if ( _extractedHisPayment ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                //---------------------------------------------
                // ���_�͎w�肵�Ȃ����A���t�͐�������B
                // ( �L���󂭎�� )
                //---------------------------------------------

                // �����p�����[�^����
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.SupplierCd = 0;
                paraWork.St_Date = _startDate;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // �����[�g�Ăяo��
                object retObj;
                status = _iTtlDayCalcDB.SearchHisPayment( out retObj, paraWork );

                // ���ʂ̓W�J
                DevelopResultOfHisPayment( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );
                _extractedHisPayment = true;

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // �}�X�^�W�J
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
            }
            catch ( Exception )
            {
            }

            return status;
        }
        /// <summary>
        /// �W�J�����i�����E�x���j
        /// </summary>
        /// <param name="customSerializeArrayList"></param>
        /// <param name="paraWork"></param>
        private void DevelopResultOfHisPayment( CustomSerializeArrayList customSerializeArrayList, TtlDayCalcParaWork paraWork )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 ADD
            // �S���_�̑O���������
            DateTime allSectionPrevDate = DateTime.MinValue;
            // �S���_�̃R���o�[�g�����敪
            int allSectionConvProcDivCd = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            // �S���_�̒��X�V�J�n��
            DateTime allSectionStartCAddUpUpdDate = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD

            // �e�[�u������
            if ( _tableOfHisPayment == null )
            {
                _tableOfHisPayment = PMCMN00101EA.CreateTableOfHisPayment();
            }

            for ( int index = 0; index < customSerializeArrayList.Count; index++ )
            {
                TtlDayCalcRetWork retWork = (customSerializeArrayList[index] as TtlDayCalcRetWork);

                // �d���`�F�b�N���ĂȂ���Βǉ�
                DataRow row = _tableOfHisPayment.Rows.Find( new object[] { retWork.SectionCode } );
                if ( row == null )
                {
                    row = _tableOfHisPayment.NewRow();

                    row[PMCMN00101EA.ct_Col_SectionCode] = retWork.SectionCode;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 DEL
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 ADD
                    DateTime prevTotalDay = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = prevTotalDay;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 ADD
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_ConvertProcessDivCd] = retWork.ConvertProcessDivCd;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
                    row[PMCMN00101EA.ct_Col_StartCAddUpUpdDate] = retWork.StartCAddUpUpdDate;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD

                    _tableOfHisPayment.Rows.Add( row );

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 ADD
                    // �S�Ќ���(�S���_�ň�ԑ傫���l���g�p)
                    if ( allSectionPrevDate < prevTotalDay )
                    {
                        allSectionPrevDate = prevTotalDay;
                        allSectionConvProcDivCd = retWork.ConvertProcessDivCd;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
                        allSectionStartCAddUpUpdDate = retWork.StartCAddUpUpdDate;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 ADD
                }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 ADD
            // �S�Ќ���(�S���_�ň�ԑ傫���l���g�p)
            if ( allSectionPrevDate != DateTime.MinValue )
            {
                DateTime prevTotalDay = DateTime.MinValue;
                DataRow row = _tableOfHisPayment.Rows.Find( new object[] { string.Empty } );
                if ( row == null )
                {
                    row = _tableOfHisPayment.NewRow();
                    //row[PMCMN00101EA.ct_Col_ProcDiv] = paraWork.ProcDiv;
                    row[PMCMN00101EA.ct_Col_SectionCode] = string.Empty;
                    _tableOfHisPayment.Rows.Add( row );
                }
                else
                {
                    // �������R�[�h������Ό��ݒl��ޔ�
                    prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
                }

                // �������R�[�h������ꍇ�͑傫�������̗p
                if ( prevTotalDay < allSectionPrevDate )
                {
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = allSectionPrevDate;
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    //row[PMCMN00101EA.ct_Col_PrevTotalMonth] = DateTime.MinValue;
                    //row[PMCMN00101EA.ct_Col_CurrentTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_ConvertProcessDivCd] = allSectionConvProcDivCd;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
                    row[PMCMN00101EA.ct_Col_StartCAddUpUpdDate] = allSectionStartCAddUpUpdDate;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 ADD
        }
        /// <summary>
        /// �����擾�����i�����E�x�����|�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <param name="convertProcessDivCd">(�o��)�R���o�[�g�����敪</param>
        /// <param name="startCAddUpUpdDate">(�o��)���X�V�J�n��</param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 DEL
        //private int GetHisTotalDayPaymentProc( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out int convertProcessDivCd )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
        private int GetHisTotalDayPaymentProc( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out int convertProcessDivCd, out DateTime startCAddUpUpdDate )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        {
            // ���������Ăяo��
            InitializeHisPaymentProc();

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;
            currentTotalDay = DateTime.MinValue;
            convertProcessDivCd = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            startCAddUpUpdDate = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD

            //--------------------------------------------
            // DataTable���猟���E������΃����[�g
            //--------------------------------------------
            DataRow row = _tableOfHisPayment.Rows.Find( new object[] { sectionCode } );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 DEL
            //// �S��
            //if ( row == null )
            //{
            //    row = _tableOfHisPayment.Rows.Find( new object[] { string.Empty } );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 DEL

            // �ēx�����[�g
            if ( row == null )
            {
                # region [���������[�g���o]
                // �����p�����[�^����
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.SupplierCd = 0;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // �����[�g�Ăяo��
                object retObj;
                status = _iTtlDayCalcDB.SearchHisPayment( out retObj, paraWork );

                // ���ʂ̓W�J
                DevelopResultOfHisPayment( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // �}�X�^�W�J
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
                # endregion

                // �ēxDataTable���猟��
                row = _tableOfHisPayment.Rows.Find( new object[] { sectionCode } );
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 DEL
            //// �ēx�S��
            //if ( row == null )
            //{
            //    row = _tableOfHisPayment.Rows.Find( new object[] { string.Empty } );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 DEL

            if ( row == null ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //--------------------------------------------
            // �e����t���Z�o
            //--------------------------------------------
            ReflectTotalDayForHisPayment( ref row );

            //--------------------------------------------
            // �Z�o���ʂ��Z�b�g
            //--------------------------------------------
            prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
            currentTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalDay];
            convertProcessDivCd = (Int32)row[PMCMN00101EA.ct_Col_ConvertProcessDivCd];
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            startCAddUpUpdDate = (DateTime)row[PMCMN00101EA.ct_Col_StartCAddUpUpdDate];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        /// <summary>
        /// ���������Ɋ�Â��e����t�Z�o�i�����x���p�j
        /// </summary>
        /// <param name="row"></param>
        private void ReflectTotalDayForHisPayment( ref DataRow row )
        {
            if ( (int)row[PMCMN00101EA.ct_Col_CurrentCalcFlag] <= 0 )
            {
                //**********************************************************
                // ���Z�o�Ȃ�Z�o����
                //**********************************************************

                // �O���������
                DateTime prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];

                // �x���S�̐ݒ�擾
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 DEL
                //BillAllStWork billAllSt = FindBillAllSt( _billAllStWorkList, (string)row[PMCMN00101EA.ct_Col_SectionCode] );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
                // �����擾�͏��00:�S�Ђ̃��R�[�h����
                BillAllStWork billAllSt = FindBillAllSt( _billAllStWorkList, ct_AllSectionCode );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD

                List<int> totalDay = new List<int>( new int[]{
                                        billAllSt.SupplierTotalDay1, billAllSt.SupplierTotalDay2, billAllSt.SupplierTotalDay3,
                                        billAllSt.SupplierTotalDay4, billAllSt.SupplierTotalDay5, billAllSt.SupplierTotalDay6,
                                        billAllSt.SupplierTotalDay7, billAllSt.SupplierTotalDay8, billAllSt.SupplierTotalDay9,
                                        billAllSt.SupplierTotalDay10, billAllSt.SupplierTotalDay11, billAllSt.SupplierTotalDay12
                                    } );

                // ��������������擾�i�x���j
                row[PMCMN00101EA.ct_Col_CurrentTotalDay] = GetCurrentTotalDayOfDmd( totalDay, prevTotalDay );

                // �Z�o�ς݃t���O
                row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 1;
            }
        }
        # endregion

        # region [�E���z�E�������|]
        /// <summary>
        /// �����擾�����i���z�E�������|�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <param name="prevTotalMonth">(�o��)�O���������</param>
        /// <param name="currentTotalMonth">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        private int GetTotalDayMonthlyAccRecProc( string sectionCode, int customerCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth )
        {
            sectionCode = sectionCode.Trim();

            // �e�[�u������
            if ( _tableOfPrcAccRec == null )
            {
                _tableOfPrcAccRec = PMCMN00101EA.CreateTableOfPrcAccRec();
            }

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;
            currentTotalDay = DateTime.MinValue;
            prevTotalMonth = DateTime.MinValue;
            currentTotalMonth = DateTime.MinValue;

            //--------------------------------------------
            // DataTable���猟���E������΃����[�g
            //--------------------------------------------
            DataRow row = _tableOfPrcAccRec.Rows.Find( new object[] { sectionCode, customerCode } );
            if ( row == null )
            {
                # region [���������[�g���o]
                // �����p�����[�^����
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.CustomerCode = customerCode;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // �����[�g�Ăяo��
                object retObj;
                status = _iTtlDayCalcDB.SearchPrcMonthlyAccRec( out retObj, paraWork );

                // ���ʂ̓W�J
                DevelopResultOfAccRec( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // �}�X�^�W�J
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
                # endregion

                // �ēxDataTable���猟��
                row = _tableOfPrcAccRec.Rows.Find( new object[] { sectionCode, customerCode } );
            }
            if ( row == null ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //--------------------------------------------
            // �e����t���Z�o
            //--------------------------------------------
            ReflectTotalDayForMonthly( ref row );

            //--------------------------------------------
            // �Z�o���ʂ��Z�b�g
            //--------------------------------------------
            prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
            currentTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalDay];
            prevTotalMonth = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalMonth];
            currentTotalMonth = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalMonth];

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        /// <summary>
        /// �W�J�����i���z�E�������|�j
        /// </summary>
        /// <param name="customSerializeArrayList">�����[�g�擾�f�[�^</param>
        /// <param name="paraWork">���������p�����[�^</param>
        private void DevelopResultOfAccRec( CustomSerializeArrayList customSerializeArrayList, TtlDayCalcParaWork paraWork )
        {
            //// �e�[�u������
            //if ( _tableOfPrcAccRec == null )
            //{
            //    _tableOfPrcAccRec = PMCMN00101EA.CreateTableOfPrcAccRec();
            //}

            for ( int index = 0; index < customSerializeArrayList.Count; index++ )
            {
                TtlDayCalcRetWork retWork = (customSerializeArrayList[index] as TtlDayCalcRetWork);

                // �d���`�F�b�N���ĂȂ���Βǉ�
                DataRow row = _tableOfPrcAccRec.Rows.Find( new object[] { paraWork.SectionCode.Trim(), retWork.CustomerCode } );
                if ( row == null )
                {
                    row = _tableOfPrcAccRec.NewRow();

                    row[PMCMN00101EA.ct_Col_SectionCode] = paraWork.SectionCode.Trim();
                    row[PMCMN00101EA.ct_Col_CustomerCode] = retWork.CustomerCode;
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_PrevTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_CurrentTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;

                    _tableOfPrcAccRec.Rows.Add( row );
                }
            }
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����i���z�E�������|�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="date">���t</param>
        /// <param name="prevTotalDay">�O���������</param>
        /// <returns>true:���ς�, false:������</returns>
        private bool CheckMonthlyAccRecProc( string sectionCode, int customerCode, DateTime date, out DateTime prevTotalDay )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            // �L���b�V���N���A
            ClearCacheProc();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD

            prevTotalDay = DateTime.MinValue;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int status = GetTotalDayMonthlyAccRecProc( sectionCode, customerCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );

            // MinValue�Ȃ�Ζ�����
            if ( prevTotalDay == DateTime.MinValue )
            {
                return false;
            }
            // �G���[�Ȃ�΁A���͋����Ȃ��Ӗ��Œ��ς݂ɂ���
            if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                return true;
            }
            // true:���ς�, false:������
            return ( date <= prevTotalDay );
        }
        # endregion

        # region [�F���z�E�������|]
        /// <summary>
        /// �����擾�����i���z�E�������|�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <param name="prevTotalMonth">(�o��)�O���������</param>
        /// <param name="currentTotalMonth">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        private int GetTotalDayMonthlyAccPayProc( string sectionCode, int supplierCd, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth )
        {
            sectionCode = sectionCode.Trim();

            // �e�[�u������
            if ( _tableOfPrcAccPay == null )
            {
                _tableOfPrcAccPay = PMCMN00101EA.CreateTableOfPrcAccPay();
            }

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;
            currentTotalDay = DateTime.MinValue;
            prevTotalMonth = DateTime.MinValue;
            currentTotalMonth = DateTime.MinValue;

            //--------------------------------------------
            // DataTable���猟���E������΃����[�g
            //--------------------------------------------
            DataRow row = _tableOfPrcAccPay.Rows.Find( new object[] { sectionCode, supplierCd } );
            if ( row == null )
            {
                # region [���������[�g���o]
                // �����p�����[�^����
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.SupplierCd = supplierCd;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // �����[�g�Ăяo��
                object retObj;
                status = _iTtlDayCalcDB.SearchPrcMonthlyAccPay( out retObj, paraWork );

                // ���ʂ̓W�J
                DevelopResultOfAccPay( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // �}�X�^�W�J
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
                # endregion

                // �ēxDataTable���猟��
                row = _tableOfPrcAccPay.Rows.Find( new object[] { sectionCode, supplierCd } );
            }
            if ( row == null ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //--------------------------------------------
            // �e����t���Z�o
            //--------------------------------------------
            ReflectTotalDayForMonthly( ref row );

            //--------------------------------------------
            // �Z�o���ʂ��Z�b�g
            //--------------------------------------------
            prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
            currentTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalDay];
            prevTotalMonth = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalMonth];
            currentTotalMonth = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalMonth];

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        /// <summary>
        /// �W�J�����i���z�E�������|�j
        /// </summary>
        /// <param name="customSerializeArrayList">�����[�g�擾�f�[�^</param>
        /// <param name="paraWork">���������p�����[�^</param>
        private void DevelopResultOfAccPay( CustomSerializeArrayList customSerializeArrayList, TtlDayCalcParaWork paraWork )
        {
            //// �e�[�u������
            //if ( _tableOfPrcAccPay == null )
            //{
            //    _tableOfPrcAccPay = PMCMN00101EA.CreateTableOfPrcAccPay();
            //}

            for ( int index = 0; index < customSerializeArrayList.Count; index++ )
            {
                TtlDayCalcRetWork retWork = (customSerializeArrayList[index] as TtlDayCalcRetWork);

                // �d���`�F�b�N���ĂȂ���Βǉ�
                DataRow row = _tableOfPrcAccPay.Rows.Find( new object[] { paraWork.SectionCode.Trim(), retWork.SupplierCd } );
                if ( row == null )
                {
                    row = _tableOfPrcAccPay.NewRow();

                    row[PMCMN00101EA.ct_Col_SectionCode] = paraWork.SectionCode.Trim();
                    row[PMCMN00101EA.ct_Col_SupplierCd] = retWork.SupplierCd;
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_PrevTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_CurrentTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;

                    _tableOfPrcAccPay.Rows.Add( row );
                }
            }
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����i���z�E�������|�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="date">���t</param>
        /// <param name="prevTotalDay">�O���������</param>
        /// <returns>true:���ς�, false:������</returns>
        private bool CheckMonthlyAccPayProc( string sectionCode, int supplierCd, DateTime date, out DateTime prevTotalDay )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            // �L���b�V���N���A
            ClearCacheProc();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD

            prevTotalDay = DateTime.MinValue;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int status = GetTotalDayMonthlyAccPayProc( sectionCode, supplierCd, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );

            // MinValue�Ȃ�Ζ�����
            if ( prevTotalDay == DateTime.MinValue )
            {
                return false;
            }
            // �G���[�Ȃ�΁A���͋����Ȃ��Ӗ��Œ��ς݂ɂ���
            if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                return true;
            }
            // true:���ς�, false:������
            return (date <= prevTotalDay);
        }
        # endregion

        # region [�G���z�E����]
        /// <summary>
        /// �����擾�����i���z�E�������|�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        private int GetTotalDayDmdCProc( string sectionCode, int customerCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            sectionCode = sectionCode.Trim();

            // �e�[�u������
            if ( _tableOfPrcDmdC == null )
            {
                _tableOfPrcDmdC = PMCMN00101EA.CreateTableOfPrcDmdC();
            }

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;
            currentTotalDay = DateTime.MinValue;

            //--------------------------------------------
            // DataTable���猟���E������΃����[�g
            //--------------------------------------------
            DataRow row = _tableOfPrcDmdC.Rows.Find( new object[] { sectionCode, customerCode } );
            if ( row == null )
            {
                # region [���������[�g���o]
                // �����p�����[�^����
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.CustomerCode = customerCode;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // �����[�g�Ăяo��
                object retObj;
                status = _iTtlDayCalcDB.SearchPrcDmdC( out retObj, paraWork );

                // ���ʂ̓W�J
                DevelopResultOfDmdC( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // �}�X�^�W�J
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
                # endregion

                // �ēxDataTable���猟��
                row = _tableOfPrcDmdC.Rows.Find( new object[] { sectionCode, customerCode } );
            }
            if ( row == null ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //--------------------------------------------
            // �e����t���Z�o
            //--------------------------------------------
            ReflectTotalDayForPrcDmdC( ref row );

            //--------------------------------------------
            // �Z�o���ʂ��Z�b�g
            //--------------------------------------------
            prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
            currentTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalDay];

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        /// <summary>
        /// �W�J�����i���z�E�����j
        /// </summary>
        /// <param name="customSerializeArrayList"></param>
        /// <param name="paraWork"></param>
        private void DevelopResultOfDmdC( CustomSerializeArrayList customSerializeArrayList, TtlDayCalcParaWork paraWork )
        {
            //// �e�[�u������
            //if ( _tableOfPrcDmdC == null )
            //{
            //    _tableOfPrcDmdC = PMCMN00101EA.CreateTableOfPrcDmdC();
            //}

            for ( int index = 0; index < customSerializeArrayList.Count; index++ )
            {
                TtlDayCalcRetWork retWork = (customSerializeArrayList[index] as TtlDayCalcRetWork);

                // �d���`�F�b�N���ĂȂ���Βǉ�
                DataRow row = _tableOfPrcDmdC.Rows.Find( new object[] { paraWork.SectionCode.Trim(), retWork.CustomerCode } );
                if ( row == null )
                {
                    row = _tableOfPrcDmdC.NewRow();

                    row[PMCMN00101EA.ct_Col_SectionCode] = paraWork.SectionCode.Trim();
                    row[PMCMN00101EA.ct_Col_CustomerCode] = retWork.CustomerCode;
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;

                    _tableOfPrcDmdC.Rows.Add( row );
                }
            }
        }
        /// <summary>
        /// �e����t�Z�o����
        /// </summary>
        /// <param name="row"></param>
        private void ReflectTotalDayForPrcDmdC( ref DataRow row )
        {
            if ( (int)row[PMCMN00101EA.ct_Col_CurrentCalcFlag] <= 0 )
            {
                //**********************************************************
                // ���Z�o�Ȃ�Z�o����
                //**********************************************************

                // �����������
                row[PMCMN00101EA.ct_Col_CurrentTotalDay] = GetCurrentTotalDayOfNextMonth( (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay] );

                // �Z�o�ς݃t���O
                row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 1;
            }
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����i���z�E�������|�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="date">���t</param>
        /// <param name="prevTotalDay">�O���������</param>
        /// <returns>true:���ς�, false:������</returns>
        private bool CheckDmdCProc( string sectionCode, int customerCode, DateTime date, out DateTime prevTotalDay )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            // �L���b�V���N���A
            ClearCacheProc();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD

            prevTotalDay = DateTime.MinValue;
            DateTime currentTotalDay;
            int status = GetTotalDayDmdCProc( sectionCode, customerCode, out prevTotalDay, out currentTotalDay );

            // MinValue�Ȃ�Ζ�����
            if ( prevTotalDay == DateTime.MinValue )
            {
                return false;
            }
            // �G���[�Ȃ�΁A���͋����Ȃ��Ӗ��Œ��ς݂ɂ���
            if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                return true;
            }
            // true:���ς�, false:������
            return (date <= prevTotalDay);
        }
        # endregion

        # region [�H���z�E�x��]
        /// <summary>
        /// �����擾�����i���z�E�x�����|�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <param name="currentTotalDay">(�o��)�����������</param>
        /// <returns>STATUS</returns>
        private int GetTotalDayPaymentProc( string sectionCode, int supplierCd, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            sectionCode = sectionCode.Trim();

            // �e�[�u������
            if ( _tableOfPrcPayment == null )
            {
                _tableOfPrcPayment = PMCMN00101EA.CreateTableOfPrcPayment();
            }

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;
            currentTotalDay = DateTime.MinValue;

            //--------------------------------------------
            // DataTable���猟���E������΃����[�g
            //--------------------------------------------
            DataRow row = _tableOfPrcPayment.Rows.Find( new object[] { sectionCode, supplierCd } );
            if ( row == null )
            {
                # region [���������[�g���o]
                // �����p�����[�^����
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.SupplierCd = supplierCd;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // �����[�g�Ăяo��
                object retObj;
                status = _iTtlDayCalcDB.SearchPrcPayment( out retObj, paraWork );

                // ���ʂ̓W�J
                DevelopResultOfPayment( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // �}�X�^�W�J
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
                # endregion

                // �ēxDataTable���猟��
                row = _tableOfPrcPayment.Rows.Find( new object[] { sectionCode, supplierCd } );
            }
            if ( row == null ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //--------------------------------------------
            // �e����t���Z�o
            //--------------------------------------------
            ReflectTotalDayForPrcPayment( ref row );

            //--------------------------------------------
            // �Z�o���ʂ��Z�b�g
            //--------------------------------------------
            prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
            currentTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalDay];

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        /// <summary>
        /// �W�J�����i���z�E�x���j
        /// </summary>
        /// <param name="customSerializeArrayList"></param>
        /// <param name="paraWork"></param>
        private void DevelopResultOfPayment( CustomSerializeArrayList customSerializeArrayList, TtlDayCalcParaWork paraWork )
        {
            //// �e�[�u������
            //if ( _tableOfPrcPayment == null )
            //{
            //    _tableOfPrcPayment = PMCMN00101EA.CreateTableOfPrcPayment();
            //}

            for ( int index = 0; index < customSerializeArrayList.Count; index++ )
            {
                TtlDayCalcRetWork retWork = (customSerializeArrayList[index] as TtlDayCalcRetWork);

                // �d���`�F�b�N���ĂȂ���Βǉ�
                DataRow row = _tableOfPrcPayment.Rows.Find( new object[] { paraWork.SectionCode.Trim(), retWork.SupplierCd } );
                if ( row == null )
                {
                    row = _tableOfPrcPayment.NewRow();

                    row[PMCMN00101EA.ct_Col_SectionCode] = paraWork.SectionCode.Trim();
                    row[PMCMN00101EA.ct_Col_SupplierCd] = retWork.SupplierCd;
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;

                    _tableOfPrcPayment.Rows.Add( row );
                }
            }
        }
        /// <summary>
        /// �e����t�Z�o����
        /// </summary>
        /// <param name="row"></param>
        private void ReflectTotalDayForPrcPayment( ref DataRow row )
        {
            if ( (int)row[PMCMN00101EA.ct_Col_CurrentCalcFlag] <= 0 )
            {
                //**********************************************************
                // ���Z�o�Ȃ�Z�o����
                //**********************************************************

                // �����������
                row[PMCMN00101EA.ct_Col_CurrentTotalDay] = GetCurrentTotalDayOfNextMonth( (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay] );

                // �Z�o�ς݃t���O
                row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 1;
            }
        }
        /// <summary>
        /// ���X�V�σ`�F�b�N�����i���z�E�������|�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="supplierCd">���Ӑ�R�[�h</param>
        /// <param name="date">���t</param>
        /// <param name="prevTotalDay">�O���������</param>
        /// <returns>true:���ς�, false:������</returns>
        private bool CheckPaymentProc( string sectionCode, int supplierCd, DateTime date, out DateTime prevTotalDay )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            // �L���b�V���N���A
            ClearCacheProc();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD

            prevTotalDay = DateTime.MinValue;
            DateTime currentTotalDay;
            int status = GetTotalDayPaymentProc( sectionCode, supplierCd, out prevTotalDay, out currentTotalDay );

            // MinValue�Ȃ�Ζ�����
            if ( prevTotalDay == DateTime.MinValue )
            {
                return false;
            }
            // �G���[�Ȃ�΁A���͋����Ȃ��Ӗ��Œ��ς݂ɂ���
            if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                return true;
            }
            // true:���ς�, false:������
            return (date <= prevTotalDay);
        }
        # endregion

        # region [�L���b�V���N���A����]
        /// <summary>
        /// �L���b�V���N���A����
        /// </summary>
        private void ClearCacheProc()
        {
            // �����n�̒��o�ς݃t���O������
            _extractedHisMonthly = false;
            _extractedHisDmdC = false;
            _extractedHisPayment = false;

            // �f�[�^�e�[�u�����N���A
            _tableOfHisDmdC = null;
            _tableOfHisMonthly = null;
            _tableOfHisPayment = null;
            _tableOfPrcAccPay = null;
            _tableOfPrcAccRec = null;
            _tableOfPrcDmdC = null;
            _tableOfPrcPayment = null;

            // �}�X�^�����擾�t���O���Z�b�g
            this.WithMasterDiv = 1;     // 1:�擾����

            // �}�X�^�ޔ��t�B�[���h�N���A
            _companyInfWork = null;     // ���Џ��}�X�^
            _billAllStWorkList = null;  // �����S�̐ݒ�}�X�^���X�g
        }
        # endregion

        # region [�}�X�^�W�J����]
        /// <summary>
        /// �}�X�^�W�J����
        /// </summary>
        /// <param name="customSerializeArrayList"></param>
        /// <param name="paraWork"></param>
        private void DevelopResultOfMaster( CustomSerializeArrayList customSerializeArrayList, TtlDayCalcParaWork paraWork )
        {
            foreach ( object obj in customSerializeArrayList )
            {
                if ( obj is CompanyInfWork[] )
                {
                    // ���Џ��}�X�^
                    _companyInfWork = (obj as CompanyInfWork[])[0];

                    // ��v�N�x�e�[�u������
                    _finYearTableGenerator = new FinYearTableGenerator( _companyInfWork );
                }
                else if ( obj is BillAllStWork[] )
                {
                    // �����S�̐ݒ�}�X�^
                    _billAllStWorkList = new List<BillAllStWork>( (obj as BillAllStWork[]) );
                }
            }
        }
        # endregion

        # region [���ʏ���]
        /// <summary>
        /// LongDate�擾����(yyyy/mm/dd �� yyyymmdd)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static int GetLongDate( DateTime dt )
        {
            if ( dt == DateTime.MinValue )
            {
                return 0;
            }
            else
            {
                return ((dt.Year * 10000) + (dt.Month * 100) + dt.Day);
            }
        }
        /// <summary>
        /// DateTime�擾����(yyyymmdd �� yyyy/mm/dd)
        /// </summary>
        /// <param name="longDate"></param>
        /// <returns></returns>
        private static DateTime GetDateTime( int longDate )
        {
            if ( longDate == 0 )
            {
                return DateTime.MinValue;
            }
            else
            {
                try
                {
                    return new DateTime( longDate / 10000, (longDate / 100) % 100, longDate % 100 );
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
        }
        /// <summary>
        /// �����S�̐ݒ背�R�[�h�擾����
        /// </summary>
        /// <param name="billAllStWorkList"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private static BillAllStWork FindBillAllSt( List<BillAllStWork> billAllStWorkList, string sectionCode )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 DEL
            //// �����S�̐ݒ�擾
            //BillAllStWork billAllSt = billAllStWorkList.Find(
            //                                delegate( BillAllStWork work )
            //                                {
            //                                    return (work.SectionCode.TrimEnd() == sectionCode.TrimEnd());
            //                                } );
            //if ( billAllSt == null )
            //{
            //    // �S�Аݒ���Q�Ƃ���
            //    billAllSt = billAllStWorkList.Find(
            //                                delegate( BillAllStWork work )
            //                                {
            //                                    return (work.SectionCode.TrimEnd() == ct_AllSectionCode || work.SectionCode.TrimEnd() == string.Empty);
            //                                } );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
            // �����擾�͏��00:�S�Аݒ���Q�Ƃ���
            BillAllStWork billAllSt = billAllStWorkList.Find(
                                        delegate( BillAllStWork work )
                                        {
                                            return (work.SectionCode.TrimEnd() == ct_AllSectionCode || work.SectionCode.TrimEnd() == string.Empty);
                                        } );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD

            return billAllSt;
        }
        # endregion
    }
}
