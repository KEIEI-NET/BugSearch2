using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting;   //.ParamData;
using Broadleaf.Application.Resources;



namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �������͐ݒ�nDB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������͐ݒ�nDB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 90027�@�����@��</br>
    /// <br>Date       : 2005.08.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��

    public interface IDepBillMonSecDB 
    {

        /// <summary>
        /// �������͐ݒ�nLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retTotalCnt">�������ʌ���</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="priseCd">��ƃR�[�h</param>
        /// <param name="depositStWorkList">��������(�����ݒ�)</param>
        /// <param name="billAllStWorkList">��������(�����S�̐ݒ�)</param>
        /// <param name="moneyKindWorkList">��������(���z���)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 90027�@�����@��</br>
        /// <br>Date       : 2005.08.17</br>
        int Search(
            out int retTotalCnt, 
            int readMode, 
            string priseCd, 
            out byte[] depositStWorkList, 
            out byte[] billAllStWorkList, 
            out byte[] moneyKindWorkList);


        /// <summary>
        /// �������͐ݒ�nLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retTotalCnt">�������ʌ���</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="priseCd">��ƃR�[�h</param>
        /// <param name="depositStWorkList">��������(�����ݒ�)</param>
        /// <param name="billAllStWorkList">��������(�����S�̐ݒ�)</param>
        /// <param name="moneyKindWorkList">��������(���z���)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 90027�@�����@��</br>
        /// <br>Date       : 2005.08.17</br>
        int Search(
            out int retTotalCnt, 
            int readMode, 
            string priseCd, 
            out byte[] depositStWorkList, 
            out byte[] billAllStWorkList, 
            [CustomSerializationMethodParameterAttribute("SFUKK09046D","Broadleaf.Application.Remoting.ParamData.MoneyKindWork")]
            out object moneyKindWorkList);

    }

}



