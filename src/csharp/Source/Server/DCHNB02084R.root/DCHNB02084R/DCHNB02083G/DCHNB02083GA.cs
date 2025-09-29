using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SalesMonthYearReportResultDB ����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISalesMonthYearReportResulttDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SalesMonthYearReportResultDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���쏹��</br>
    /// <br>Date       : 2007.11.21</br>
    /// <br></br>
    /// <br>Update Note: PM.NS�Ή�</br>
    /// <br>           : 23015 �X�{ ��P</br>
    /// <br>           : 2008.08.06</br>
    /// </remarks>
    public class MediationSalesMonthYearReportResultDB
    {
        /// <summary>
        /// SalesMonthYearReportResultDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.21</br>
        /// <br></br>
        /// <br>Update Note: PM.NS�Ή�</br>
        /// <br>           : 23015 �X�{ ��P</br>
        /// <br>           : 2008.08.06</br>
        /// </remarks>
        public MediationSalesMonthYearReportResultDB()
        {
        }
        /// <summary>
        /// ISalesMonthYearReportResultDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISalesMonthYearReportResultDB�I�u�W�F�N�g</returns>
        public static ISalesMonthYearReportResultDB GetSalesMonthYearReportResultDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISalesMonthYearReportResultDB)Activator.GetObject(typeof(ISalesMonthYearReportResultDB), string.Format("{0}/MyAppSalesMonthYearReportResult", wkStr));
        }
    }
}

