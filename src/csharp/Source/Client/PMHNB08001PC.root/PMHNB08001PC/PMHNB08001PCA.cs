using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.Generic;

using ar = DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Library.Resources;
//using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using System.Drawing;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// ���R���[(����`�[)�ʑΉ��p����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : ���R���[�i����`�[�j�̌ʑΉ��p�̈���h�L�������g���쐬���܂��B</br>
    /// <br>               �p�b�P�[�W�����p�̃_�~�[�t�@�C���ׁ̈A�����͋�ł��B</br>
    /// <br>Programmer   : 30517 �Ė� �x��</br>
    /// <br>Date         : 2010/08/25</br>
    /// <br></br>
    /// </remarks>
    public class PMHNB08001PCA
    {
        #region PrivateMember

        // 2010/08/25 Add >>>
        // �ʏ������s�������f
        // true:�ʏ������s���@false:�ʏ������s��Ȃ�
        private static bool _customizeFlg = false;
        // 2010/08/25 Add <<<


        #endregion

        #region Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMHNB08001PCA()
        {
        }
        #endregion

        // 2010/08/25 Add >>>
        /// <summary>
        /// �ʏ������s�������f
        /// true:�ʏ������s���@false:�ʏ������s��Ȃ�
        /// </summary>
        public static bool CustomizeFlg
        {
            get { return _customizeFlg; }
        }
        // 2010/08/25 Add <<<
        
    }


}
