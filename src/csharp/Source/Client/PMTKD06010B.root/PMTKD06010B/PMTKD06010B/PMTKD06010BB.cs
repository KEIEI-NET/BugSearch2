using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �ԗ��������\�b�h���ʒl
    /// </summary>
    /// <remarks>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public enum CarSearchResultReport
    {
        /// <summary> ��������0�� </summary>
        retFailed = 0,

        /// <summary> �Ԏ핡��������[���^�������v��] </summary>
        retMultipleCarKind = 1,

        /// <summary> �^������������ </summary>
        retMultipleCarModel = 2,

        /// <summary> �^��1������ </summary>
        retSingleCarModel = 4,

        /// <summary> �������G���[���� </summary>
        retError = 99
    }

    // --- ADD 2013/03/21 ---------->>>>>
    /// <summary>
    /// �ԗ������n���h���ʒu��񌋉ʒl
    /// </summary>
    /// <remarks>
    /// <br>Note       : 10900269-00 SPK�ԑ�ԍ�������Ή�</br>
    /// <br>Programmer : FSI�֓� �a�G</br>
    /// <br>Date       : 2013/03/21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public enum HandleInfoCdRet
    {
        /// <summary> ���f�s�� </summary>
        PositionError = -1,
        
        /// <summary> ���E����(�S�^��) </summary>
        PositionBoth = 0,

        /// <summary> �n���h���ʒu (�E) </summary>
        PositionRight = 1,

        /// <summary> �n���h���ʒu (��) </summary>
        PositionLeft = 2,
    }
    // --- ADD 2013/03/21 ----------<<<<<
}
