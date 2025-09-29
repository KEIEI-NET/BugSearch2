//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �a�k�R�[�h�w�ʕϊ�����
// �v���O�����T�v   : �a�k�R�[�h�w�ʕϊ�����DB ����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2010/01/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// DataBLGoodsRateRankConvertDB ����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IDataBLGoodsRateRankConvertDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���DataBLGoodsRateRankConvertDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2010/01/12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationDataBLGoodsRateRankConvertDB
    {
        /// <summary>
        /// DataBLGoodsRateRankConvertDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        public MediationDataBLGoodsRateRankConvertDB()
        {
        }
        /// <summary>
        /// IDataBLGoodsRateRankConvertDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IDataBLGoodsRateRankConvertDB�I�u�W�F�N�g</returns>
        public static IDataBLGoodsRateRankConvertDB GetDataBLGoodsRateRankConvertDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IDataBLGoodsRateRankConvertDB)Activator.GetObject(typeof(IDataBLGoodsRateRankConvertDB), string.Format("{0}/MyAppDataBLGoodsRateRankConvert", wkStr));
        }
    }
}
