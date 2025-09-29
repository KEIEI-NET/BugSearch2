using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����c�N���ADB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����c�N���ADB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 20081</br>
    /// <br>Date       : 2008.08.20</br>
    /// <br></br>
    /// <br>Update Note: 2009/12/16 ������</br>
    /// <br>Date       : ���i�Ǘ����}�X�^�̎d������Q�Ƃ���悤�ɕύX</br>
    /// <br>Update Note: 2010/06/08 ���� ��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
    /// <br>Update Note: 2010/08/02 22018 ��� ���b</br>
    /// <br>           : �݌Ƀ}�X�^�̔����c�͎d���f�[�^�������Z�����Ƀ[�����Œ�ŃZ�b�g����悤�ύX</br>
    /// <br>Update Note: 2011/04/11 liyp</br>
    /// <br>           : ��ʂŎd�����͈͎w�肵�Ă��S�f�[�^�̔����c���N���A�����s��C��</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalesOrderRemainClearDB
    {
        /// <summary>
        /// ���o�����ɍ��v�����݌Ƀf�[�^�̔��������O�ōX�V���܂��B
        /// </summary>
        /// <param name="extrInfo_SalesOrderRemainClearWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        int SearchUpdate(object extrInfo_SalesOrderRemainClearWork);
        // -------------ADD 2009/12/16------------->>>>>
        /// <summary>
        /// ���o�����ɍ��v�����݌Ƀf�[�^�̎擾�B
        /// </summary>
        /// <param name="extrInfo_SalesOrderRemainClearWork">�����p�����[�^</param>
        /// <param name="resultList">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���o�����ɍ��v�����݌Ƀf�[�^�̎擾���s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.12.16</br>
        [MustCustomSerialization]
        int Search(
           [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
             out object resultList, object extrInfo_SalesOrderRemainClearWork);
        /// <summary>
        /// ���o�����ɍ��v�����݌Ƀf�[�^�̔��������O�ōX�V���܂��B
        /// </summary>
        /// <param name="resultList">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.12.16</br>
        /// <br>Update Note: 2010/06/08 ���� ��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
        // ----------------UPD 2010/06/08--------------->>>>>
        //int Update(object resultList);
        int Update(object resultList, object stockDetailWk);
        // ----------------UPD 2010/06/08---------------<<<<<
        // -------------ADD 2009/12/16-------------<<<<<

        // -------------ADD 2011/04/11------------->>>>>
        /// <summary>
        /// ���o�����ɍ��v�����݌Ƀf�[�^�̔��������O�ōX�V���܂��B
        /// </summary>
        /// <param name="resultList">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : liyp</br>
        /// <br>Date       : 2011/04/11</br>
        int Update(object resultList);
        // -------------ADD 2011/04/11-------------<<<<<

        // ----------------ADD 2010/06/08--------------->>>>>
        /// <summary>
        /// �d�����׃f�[�^����Ώۖ��ׂ̎擾
        /// </summary>
        /// <remarks>
        /// <param name="objExtrInfo_SalesOrderRemainClearWork">�����p�����[�^</param>
        /// <param name="resultList">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���o�����ɍ��v�����d�����׃f�[�^�̎擾���s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        int SearchStockDetail(out object rsultList, object extrInfo_SalesOrderRemainClearWork);

        /// <summary>
        /// �݌Ƀ}�X�^�f�[�^����Ώۖ��ׂ̎擾
        /// </summary>
        /// <remarks>
        /// <param name="objExtrInfo_SalesOrderRemainClearWork">�����p�����[�^</param>
        /// <param name="resultList">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���o�����ɍ��v�����݌Ƀ}�X�^�f�[�^�̎擾���s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        int SearchStock(out object rsultList, object extrInfo_StockDetailWork);

        // ----------------ADD 2010/06/08---------------<<<<<
        // --- ADD m.suzuki 2010/08/02 ---------->>>>>
        /// <summary>
        /// �d�����׍X�V�����i�d���f�[�^�̂ݍX�V�j
        /// </summary>
        /// <param name="stockDetailWork"></param>
        /// <returns></returns>
        int UpdateStockDetail( object stockDetailWork );
        // --- ADD m.suzuki 2010/08/02 ----------<<<<<
    }
}
