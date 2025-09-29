using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockMonthYearReportResultDB ����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IStockMonthYearReportResultDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���StockMonthYearReportResultDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���쏹��</br>
    /// <br>Date       : 2007.11.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockMonthYearReportResultDB
    {
        /// <summary>
        /// StockMonthYearReportResultDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.21</br>
        /// </remarks>
        public MediationStockMonthYearReportResultDB()
        {
        }
        /// <summary>
        /// IStockMonthYearReportResultDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IStockMonthYearReportResultDB�I�u�W�F�N�g</returns>
        public static IStockMonthYearReportResultDB GetStockMonthYearReportResultDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:8008";
#endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IStockMonthYearReportResultDB)Activator.GetObject(typeof(IStockMonthYearReportResultDB), string.Format("{0}/MyAppStockMonthYearReportResult", wkStr));
        }
    }
}
