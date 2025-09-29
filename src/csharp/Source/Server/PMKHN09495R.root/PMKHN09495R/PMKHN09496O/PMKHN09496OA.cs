//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ƀ}�X�^
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2010/08/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10806793-00  �쐬�S�� : �c����
// �C �� ��  2012/12/13  �C�����e : 2013/03/13�z�M��  Redmine#33835
//                                  �o�׉񐔂�ǉ�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌Ƀ}�X�^�����pDB Access RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ƀ}�X�^�����pDB Access RemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2010/08/11</br>
    /// <br>Update Note: 2012/12/13 �c����</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>             Redmine#33835 �o�׉񐔂�ǉ�����Ή�</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockMstDB
    {
        /// <summary>
        /// �݌Ƀ}�X�^��������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="goodsMakerCd">Ұ��</param>
        /// <param name="stockList">�݌Ƀ��X�g</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <br>Note       : �݌Ƀ}�X�^��������</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchStockInfo(string enterpriseCode, string goodsNo, Int32 goodsMakerCd,
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
            out ArrayList stockList, out string retMessage);

        /// <summary>
        /// �o�׉񐔂�߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="stockHistoryDspSearchResultWork">��������</param>
        /// <param name="stockHistoryDspSearchParamWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �o�׉񐔌����������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchStockHisDsp(
            [CustomSerializationMethodParameterAttribute("PMZAI04107D", "Broadleaf.Application.Remoting.ParamData.StockHistoryDspSearchResultWork")]
            out object stockHistoryDspSearchResultWork,
            object stockHistoryDspSearchParamWork);

        /// <summary>
        /// �݌Ƀ}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="StockWork">�݌Ƀ��X�g</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀ}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        [MustCustomSerialization]
        int Write(
			ArrayList StockWork,
            out string retMessage);

        /// <summary>
        /// �݌Ƀ}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="StockWork">�݌Ƀ��X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀ}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        [MustCustomSerialization]
        int LogicalDelete(ref ArrayList StockWork);

        /// <summary>
        /// �_���폜�݌Ƀ}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="StockWork">�݌Ƀ��X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�݌Ƀ}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(ref ArrayList StockWork);

        /// <summary>
        /// �݌Ƀ}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="StockWork">�݌Ƀ}�X�^���I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀ}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        [MustCustomSerialization]
        int Delete(ArrayList StockWork);
    }
}
