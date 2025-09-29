using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ShipmGoodsOdrReportResultDB ����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IShipmGoodsOdrReportResultDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���ShipmGoodsOdrReportResultDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���쏹��</br>
    /// <br>Date       : 2007.11.30</br>
    /// <br></br>
    /// <br>Update Note: PM.NS�Ή�</br>
    /// <br>           : 23015 �X�{ ��P</br>
    /// <br>           : 2008.08.25</br>
    /// </remarks>
    public class MediationShipmGoodsOdrReportResultDB
    {
        /// <summary>
        /// ShipmGoodsOdrReportResultDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.21</br>
        /// </remarks>
        public MediationShipmGoodsOdrReportResultDB()
        {
        }
        /// <summary>
        /// IShipmGoodsOdrReportResultDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IShipmGoodsOdrReportResultDB�I�u�W�F�N�g</returns>
        public static IShipmGoodsOdrReportResultDB GetShipmGoodsOdrReportResultDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IShipmGoodsOdrReportResultDB)Activator.GetObject(typeof(IShipmGoodsOdrReportResultDB), string.Format("{0}/MyAppShipmGoodsOdrReportResult", wkStr));
        }
    }
}
