//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �R���o�[�g���� �����[�g�I�u�W�F�N�g
//                  :   PMKHN08003R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   30290
// Date             :   2008.09.22
//----------------------------------------------------------------------
// Update Note      : 
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : wangf
// �C �� ��  2011/08/12  �C�����e : NS���[�U�[���Ǘv�]�ꗗ_20110629_��Q_�A��1023�Ή�
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : wangf
// �C �� ��  2011/08/19  �C�����e : NS���[�U�[���Ǘv�]�ꗗ_20110629_��Q_�A��953�Ή�
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : ���N�n��
// �C �� ��  2011/08/22  �C�����e : NS���[�U�[���Ǘv�]�ꗗ_20110629_��Q_�A��938�Ή�
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : wangf
// �C �� ��  2011/08/30  �C�����e : NS���[�U�[���Ǘv�]�ꗗ_20110629_��Q_�A��943�Ή�
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : �����
// �C �� ��  2011/09/06  �C�����e : �A��991�ARedmine#23658�̑Ή�
// �Ǘ��ԍ�              �쐬�S�� : ���N
// �C �� ��  2012/11/05  �C�����e : No.892 Redmine#32201�̑Ή�
// �Ǘ��ԍ�              �쐬�S�� : Lizc
// �C �� ��  2013/07/01  �C�����e : No.2007 Redmine#36971�̑Ή�
// �Ǘ��ԍ�  11170129-00 �쐬�S�� : gongzc
// �C �� ��  2015/08/27  �C�����e : Redmine#47009 �y��271�zNS���݌Ɏd���f�[�^�R���o�[�g�̏�Q�Ή�
// �Ǘ��ԍ�  11370032-00 �쐬�S�� : �c����
// �C �� ��  2019/10/22  �C�����e : SQLSERVER2017�Ή�
// �Ǘ��ԍ�  11670219-00 �쐬�S�� : ���X�ؘj
// �C �� ��  2020/06/18  �C�����e : �d�a�d�΍�
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
// DEL Lizc 2013/07/01 Redmine#36971 ----->>>>>
//using MSMC = Microsoft.SqlServer.Management.Common;
//using Microsoft.SqlServer.Management.Smo;
//using Microsoft.SqlServer.Server;
// DEL Lizc 2013/07/01 Redmine#36971 -----<<<<<
using Microsoft.SqlServer.Server;// ADD�@2019/10/22 �c���� SQLSERVER2017�Ή�
using Microsoft.Win32;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Text;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

using System.Runtime.Remoting.Lifetime;

// 2009/02/27 SQL Server�F�ؕύX�Ή�>>>>>>
using CustomInstaller;
using UBAU.Common;
// 2009/02/27 <<<<<<<<<<<<<<<<<<<<<<<<<<<<
using Broadleaf.Application.Remoting.Adapter; // add wangf 2011/08/12
// --- DEL�@2019/10/22 �c���� SQLSERVER2017�Ή�---------->>>>>
//using System.Reflection; // ADD Lizc 2013/07/01 Redmine#36971
// --- DEL�@2019/10/22 �c���� SQLSERVER2017�Ή�----------<<<<<

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �R���o�[�g���� �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �R���o�[�g�������f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.22</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   �݌Ɉړ��f�[�^����̍݌Ɏ󕥗����̍쐬���@�̕ύX</br>
    /// <br>Programmer       :   22008 ����</br>
    /// <br>Date             :   2009/06/19</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 13645 �݌Ƀ}�X�^ �Ǘ��敪"0"��NULL�ɂȂ�s��̏C��</br>
    /// <br>                     ����̃C���f�b�N�X�ɂāA�Ǘ��敪�̗�𔻒f���Ă��邽�߁A</br>
    /// <br>                     �@�R�S�s���O�ɍ݌Ƀ}�X�^�̗�ǉ����������ꍇ�̓C���f�b�N�X�̏C��������K�v����</br>
    /// <br>Programmer       :   22008 ����</br>
    /// <br>Date             :   2009/06/29</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 14369 �ԗ��Ǘ��}�X�^ �z��o�C�i����NULL�ɂȂ�s��̏C��</br>
    /// <br>Programmer       :   97427 �Ԍ�</br>
    /// <br>Date             :   2009/10/05</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 13967 �i�Ԃ̍ŏ���,���ƃG���[�ɂȂ�s��̏C��</br>
    /// <br>Programmer       :   30517 �Ė� �x��</br>
    /// <br>Date             :   2009/11/09</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 14529 CSV���f�[�^���Ȃ��Ă��N���A����������悤�ɏC��</br>
    /// <br>Programmer       :   30517 �Ė� �x��</br>
    /// <br>Date             :   2009/11/17</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 13966 �S�p�󔒂𔼊p�󔒂Q���ɕϊ�����悤�ɏC������</br>
    /// <br>Programmer       :   22008 ���� ���n</br>
    /// <br>Date             :   2010/01/28</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 15150 ���_�A���������Ŏn�܂镶����̑Ή�������ǉ�</br>
    /// <br>Programmer       :   980035 ���� ��`</br>
    /// <br>Date             :   2010/03/16</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS xxxxx �S�p�����𔼊p�����{���p�󔒂ɕϊ�����悤�ɏC������</br>
    /// <br>                     �f�[�^�̑��������ɔ��㗚���f�[�^�A�󒍃}�X�^�A�󒍃}�X�^�i�ԗ��j��ǉ�</br>
    /// <br>Programmer       :   980035 ���� ��`</br>
    /// <br>Date             :   2010/04/28</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 15742 ���R�����^���}�X�^�@�L�[���ڂ�NULL�̎��A�G���[�ɂȂ�s��̑Ή�</br>
    /// <br>Programmer       :   30531  ��� �r��</br>
    /// <br>Date             :   2010/07/07</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 15894 �f�[�^�̑��������ɓ��Ӑ搿�����z�}�X�^��ǉ�</br>
    /// <br>Programmer       :   30517  �Ė� �x��</br>
    /// <br>Date             :   2010/08/03</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 16068 ���R�����^���Œ�ԍ��z��̃Z�b�g�l��NULL�ɕύX</br>
    /// <br>Programmer       :   980035 ���� ��`</br>
    /// <br>Date             :   2010/09/16</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 16007 �݌Ɉړ��󕥍쐬���A�ړ����̃f�[�^�����׍ς݂ɂȂ�s��C��</br>
    /// <br>Programmer       :   30517 �Ė� �x��</br>
    /// <br>Date             :   2010/09/17</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 16007 �t�B�[�h�o�b�N�F���׊m�薳���ō݌Ɉړ��󕥍쐬���A</br>
    /// <br>                     ���׃f�[�^����o�׃f�[�^���쐬����ꍇ�o�׊m�����Null�ƂȂ�s��̏C��</br>
    /// <br>Programmer       :   30517 �Ė� �x��</br>
    /// <br>Date             :   2010/10/05</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 16076 ���㗚���̍݌Ɏ󕥗����f�[�^�쐬���Ƀ^�C���A�E�g�ƂȂ錏�̏C��</br>
    /// <br>                     �^�C���A�E�g���Ԃ����΂��đΉ�</br>
    /// <br>Programmer       :   30517 �Ė� �x��</br>
    /// <br>Date             :   2010/10/12</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 16007 �t�B�[�h�o�b�N</br>
    /// <br>                     �@�݌Ɉړ��󕥁F�ăR���o�[�g���A�R���o�[�g�O��œ��͋��_���قȂ�f�[�^������</br>
    /// <br>                     �A�ăR���o�[�g���A�_���폜�f�[�^�����݂��鎞�A�΂ɂȂ�}�C�i�X�f�[�^���쐬����Ȃ�</br>
    /// <br>Programmer       :   30517 �Ė� �x��</br>
    /// <br>Date             :   2010/10/13</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 16007 �t�B�[�h�o�b�N</br>
    /// <br>                     �@�ăR���o�[�g���A�_���폜�f�[�^�����݂��鎞�A�΂ɂȂ�}�C�i�X�f�[�^���쐬����Ȃ��i�݌ɒ����f�[�^�j</br>
    /// <br>                     �A�ݏo�v��̃f�[�^������ꍇ�A�R���o�[�g�O��Ŏ󕥂̍쐬�d�l���قȂ�׏C������B</br>
    /// <br>Programmer       :   30517 �Ė� �x��</br>
    /// <br>Date             :   2010/10/20</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   </br>
    /// <br>                     NS���[�U�[���Ǘv�]�ꗗ_20110629_��Q_�A��1023�Ή�</br>
    /// <br>Programmer       :   wangf</br>
    /// <br>Date             :   2011/08/12</br>
    /// <br>--------------------------------------</br>
    /// <br>                     NS���[�U�[���Ǘv�]�ꗗ_20110629_��Q_�A��953�Ή�</br>
    /// <br>Programmer       :   wangf</br>
    /// <br>Date             :   2011/08/19</br>
    /// <br>Update Note      :   NS���[�U�[���Ǘv�]�ꗗ_20110629_��Q_�A��938�Ή�</br>
    /// <br>Programmer       :   ���N�n��</br>
    /// <br>Date             :   2011/08/25</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   </br>
    /// <br>                     NS���[�U�[���Ǘv�]�ꗗ_20110629_��Q_�A��943�Ή�</br>
    /// <br>Programmer       :   wangf</br>
    /// <br>Date             :   2011/08/30</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   </br>
    /// <br>                     redmine#24171</br>
    /// <br>Programmer       :   tianjw</br>
    /// <br>Date             :   2011/09/03</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   �A��991�ARedmine#23658�̑Ή�</br>
    /// <br>Programmer       :   �����</br>
    /// <br>Date             :   2011/09/06</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   �Ǘ���10701342-00�@�L�����y�[���Ǘ�</br>
    /// <br>                     �L�����y�[���Ǘ��}�X�^��BL+Ұ���̏ꍇ�ɕi��NULL�ŃG���[�ɂȂ�Ȃ��悤�ɏC��</br>
    /// <br>Programmer       :   97427 �Ԍ�</br>
    /// <br>Date             :   2011/07/13</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   ��ʃf�[�^�����݂���e�[�u���ɑ΂��āA�ǉ��^��INSERT�����ꍇ��</br>
    /// <br>                 :   �^�C���A�E�g�G���[���������錏�̏C���i�C�X�R�Ŕ����j</br>
    /// <br>Programmer       :   ���� ���n</br>
    /// <br>Date             :   2011/09/29</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   �f�[�^�̑��������Ɏd�������f�[�^�E�d�����𖾍׃f�[�^��ǉ�</br>
    /// <br>Programmer       :   �Ė� �x��</br>
    /// <br>Date             :   2012/02/15</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   �f�[�^�̑��������ɍ݌ɗ����f�[�^��ǉ�</br>
    /// <br>Programmer       :   �Ė� �x��</br>
    /// <br>Date             :   2012/02/20</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   �݌Ɏ󕥗����f�[�^�쐬���Ƀ^�C���A�E�g�ƂȂ錏�̏C��</br>
    /// <br>                     �^�C���A�E�g���Ԃ����΂��đΉ�</br>
    /// <br>Programmer       :   97427 �Ԍ�</br>
    /// <br>Date             :   2012/04/27</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   Redmine#32201�̑Ή�</br>
    /// <br>                     �S�̏����ݒ�̑Ή�</br>
    /// <br>Programmer       :   ���N</br>
    /// <br>Date             :   2012/11/05</br>
    /// <br>Update Note      :   Redmine#36971�̑Ή�</br>
    /// <br>                     �d�|��2007 �R���o�[�g�v���O������SQLSERVER2012�Ή�</br>
    /// <br>Programmer       :   Lizc</br>
    /// <br>Date             :   2013/07/01</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   Redmine#47009 �y��271�zNS���݌Ɏd���f�[�^�R���o�[�g�̏�Q�Ή�</br>
    /// <br>Programmer       :   gongzc</br>
    /// <br>Date             :   2015/08/27</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   SQLSERVER2017�Ή�</br>
    /// <br>Programmer       :   �c����</br>
    /// <br>Date             :   2019/10/22</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   11670219-00�@�d�a�d�΍�</br>
    /// <br>Programmer       :   ���X�ؘj</br>
    /// <br>Date             :   2020/06/18</br>
    /// </remarks>

    [Serializable]
    public class ConvertProcessDB : RemoteWithAppLockDB, IConvertProcessDB
    {
        #region [ PRIVATE MEMBER ]

        // ----- DEL Lizc 2013/07/01 Redmine#36971----->>>>>
        //private MSMC.ServerConnection srvCon;
        //private Server serv;
        // ----- DEL Lizc 2013/07/01 Redmine#36971-----<<<<<
        // --- DEL�@2019/10/22 �c���� SQLSERVER2017�Ή�---------->>>>>
        //// ----- ADD Lizc 2013/07/01 Redmine#36971----->>>>>
        //private Type srvCon;
        //private Type serv;
        //private object servObj;
        //// ----- ADD Lizc 2013/07/01 Redmine#36971-----<<<<<
        // --- DEL�@2019/10/22 �c���� SQLSERVER2017�Ή�----------<<<<<
        private SqlConnection sqlConnection;
        private SqlTransaction sqlTransaction;
        private SqlDataAdapter da;
        //private string _tblId;// DEL�@2019/10/22 �c���� SQLSERVER2017�Ή�

        private bool onProcess = false;
        private bool stopFlg = false;
        private bool transactionFlg = false;

        private string _enterpriseCode = string.Empty;
        private string _updEmployeeCode = string.Empty;
        private string _updAssemblyId1 = string.Empty;
        private string _updAssemblyId2 = string.Empty;
        private const string ctConfFileNm = "ConvertSetting.xml";
        private const string ctDDTable = "DDSet";
        private const string ctColDfTable = "ColumnDf";
        private const string ctItemName = "ItemName";
        private const string ctItemDDName = "ItemDDName";
        private const string ctColumn = "Column";
        private const string ctPadZero = "PadZero";

        private DataSet conf;
        private StockAcPayHistDB stockAcPayHistDB = null;
        private Dictionary<string, SecInfoSetWork> lstSec = null;
        private Dictionary<int, BLGoodsCdUWork> lstBLCode = null;
        //private List<StockProcMoneyWork> lstFractionInfo = null;

        /// <summary>�d����O�e�[�u��</summary>
        private List<string> listChkExcpt;

        /// <summary>�f�[�^�Ȃ����󔒈��������O�̈ꗗ�i�[�p</summary>
        private struct ExcptTblCol
        {
            private string tblName;  // �e�[�u����
            private int colNo;       // �J����No�i�e�[�u���d�l����̔ԍ�-1�j

            /// <summary>�e�[�u����</summary>
            public string TblName
            {
                get { return tblName; }
                set { tblName = value; }
            }
            /// <summary>�e�[�u����</summary>
            public int ColNo
            {
                get { return colNo; }
                set { colNo = value; }
            }

            /// <summary>�e�[�u����</summary>
            public ExcptTblCol(string _tblName, int _colNo)
            {
                tblName = _tblName;
                colNo = _colNo;
            }
        }

        /// <summary>�f�[�^�Ȃ����󔒈��������O�̈ꗗ</summary>
        private List<ExcptTblCol> lstSpaceExcptTblCol;

        /// <summary>�f�[�^�Ȃ���0���������O�̈ꗗ</summary>
        private List<ExcptTblCol> lstSpaceZeroExcptTblCol;

        ///// <summary>0���󔒈��������O�̈ꗗ</summary>
        //private List<ExcptTblCol> lstZeroExcptTblCol;

        /// <summary>0��NULL���������O�̈ꗗ</summary>
        private List<ExcptTblCol> lstZeroNullExcptTblCol;

        /// <summary>�폜���Ȃ��L�b�e�B���O�f�[�^�̈ꗗ</summary>
        private List<ExcptTblCol> lstKittingTblCol;

        /// <summary>��ʃf�[�^�e�[�u���̈ꗗ</summary>
        private List<string> lstDataFullTbl;

        // ADD BY gongzc 2015/08/27 FOR Redmine#47009 �y��271�zNS���݌Ɏd���f�[�^�R���o�[�g�̏�Q�Ή� ---->>>>
        // 0��NULL�ɃR���o�[�g���Ȃ���O�̈ꗗ
        private List<ExcptTblCol> lstNotConvrtZeroToNullExcptTblCol;
        // ADD BY gongzc 2015/08/27 FOR Redmine#47009 �y��271�zNS���݌Ɏd���f�[�^�R���o�[�g�̏�Q�Ή� ----<<<<

        // -- ADD 2010/04/28 ------------------------------>>>
        /// <summary>�S�p�����`�F�b�N�Ώۂ̈ꗗ</summary>
        private List<string> lstFullSizeCheckTbl;
        // -- ADD 2010/04/28 ------------------------------<<<
        // -- add wangf 2011/08/12 ---------->>>>>
        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        //private StockSlipDB _stockSlipDB = null; // DEL tianjw 2011/09/03
        private AcceptOdrDB _acceptOdr = null;
        private Hashtable _acceptAnOrderNoHashTable = new Hashtable();
        // -- add wangf 2011/08/12 ----------<<<<<
        private Hashtable _hisDtlAcceptAnOrderNoHashTable = new Hashtable(); // ADD tianjw 2011/09/03

        private OprtnHisLogDB _oprtnHisLogDB = new OprtnHisLogDB(); // ADD 2011/09/06
        #endregion

        #region [ Constructor / Destructor ]
        //private static int cnt;
        /// <summary>
        /// �R���o�[�g����DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br>Update Note: NS���[�U�[���Ǘv�]�ꗗ_20110629_��Q_�A��938�Ή�</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/08/25</br>
        /// <br>Update Note: NS���[�U�[���Ǘv�]�ꗗ_20110629_��Q_�A��943�Ή�</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2011/08/30</br>
        /// <br>Update Note: �d�|��2007 �R���o�[�g�v���O������SQLSERVER2012�Ή�</br>
        /// <br>Programmer : Lizc</br>
        /// <br>Date       : 2013/07/01</br>
        /// <br>Update Note: PMKOBETSU-2232 SQLSERVER2017�Ή�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/10/22</br>
        /// </remarks>
        public ConvertProcessDB()
            : base("PMKHN08005D", "Broadleaf.Application.Remoting.ParamData.ConvertResultWork", "ConvertProcess")
        {
            // --- DEL�@2019/10/22 �c���� SQLSERVER2017�Ή�---------->>>>>
            //srvCon = null;
            //serv = null;
            //servObj = null; // ADD Lizc 2013/07/01 Redmine#36971
            // --- DEL�@2019/10/22 �c���� SQLSERVER2017�Ή�----------<<<<<
            sqlConnection = null;
            sqlTransaction = null;
            da = null;
            //_tblId = string.Empty;// DEL�@2019/10/22 �c���� SQLSERVER2017�Ή�
            // -- add wangf 2011/08/12 ---------->>>>>
            // �����[�g�I�u�W�F�N�g�擾
            //this._stockSlipDB = new StockSlipDB(); // DEL tianjw 2011/09/03
            this._acceptOdr = new AcceptOdrDB();
            // -- add wangf 2011/08/12 ---------->>>>>

            //cnt++;
            //System.Diagnostics.Debug.Write("Constructor");
            //System.Diagnostics.Debug.Write(string.Format("��:{0}\n", cnt));

            conf = new DataSet();
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
            string path = key.GetValue("InstallDirectory", @"d:\Partsman\USER_AP").ToString();
            conf.ReadXml(System.IO.Path.Combine(path, ctConfFileNm));
            conf.Tables[ctColDfTable].Constraints.Add("c1", conf.Tables[ctColDfTable].Columns[ctItemName], true);
            conf.Tables[ctDDTable].Constraints.Add("c2", conf.Tables[ctDDTable].Columns[ctItemDDName], true);

            listChkExcpt = new List<string>(
                new string[] {
                    "USERGDBDURF",      // ���[�U�[�K�C�h(��s�̎x�X�R�[�h�ɂ��d������P�[�X�j
                    "PARTSPOSCODEURF",  // ���ʁiBL�R�[�h����O�I�ɏd������P�[�X�j
                    "JOINPARTSURF",     // �����}�X�^(���[�U�[�o�^�j�i�\�����ʈႢ�Ō�����i���d������P�[�X�j
                    "GOODSSETRF"        // ���i�Z�b�g�}�X�^�i�\�����ʈႢ�ŃZ�b�g�q���d������P�[�X�j
                });

            // �f�[�^�Ȃ����󔒈��������O�̈ꗗ�쐬
            lstSpaceExcptTblCol = new List<ExcptTblCol>(
                new ExcptTblCol[] {
                     new ExcptTblCol("PARTSPOSCODEURF", 8)    //  ���ʃR�[�h�}�X�^�e�[�u�� ���_�R�[�h�J����
                    ,new ExcptTblCol("GOODSMNGRF", 12)        //  ���i�Ǘ����}�X�^�e�[�u�� ���i�ԍ��J����
                    ,new ExcptTblCol("CUSTDMDPRCRF", 13)      //  ���Ӑ搿�����z�}�X�^�e�[�u�� ���ы��_�R�[�h�J����
                    ,new ExcptTblCol("RATERF", 17)            //  �|���}�X�^�e�[�u�� ���i�ԍ��J����
                    ,new ExcptTblCol("RATERF", 18)            //  �|���}�X�^�e�[�u�� ���i�|�������N�J����
                    ,new ExcptTblCol("SUPLIERPAYRF", 13)      //  �d����x�����z�}�X�^�e�[�u�� ���ы��_�R�[�h�J����
                    ,new ExcptTblCol("GOODSMTTLSASLIPRF", 15) //  ���i�ʔ��㌎���W�v�f�[�^�e�[�u�� ���i�ԍ��J����
                    ,new ExcptTblCol("GCDSALESTARGETRF", 14)  //  ���i�ʔ���ڕW�ݒ�}�X�^�e�[�u�� ���i�ԍ��J����
                    ,new ExcptTblCol("UOEGUIDENAMERF", 11)    //  UOE�K�C�h���̃}�X�^�e�[�u�� UOE�K�C�h�R�[�h�J����
                    ,new ExcptTblCol("EMPSALESTARGETRF", 15)  //  �]�ƈ��ʔ���ڕW�ݒ�}�X�^�e�[�u�� �]�ƈ��R�[�h�J����
                    // --- ADD  ���r��  2010/07/07 ---------->>>>>
                    ,new ExcptTblCol("FREESEARCHMODELRF", 12) //  ���R�����^���}�X�^�e�[�u�� �r�K�X�L���J����
                    ,new ExcptTblCol("FREESEARCHMODELRF", 14) //  ���R�����^���}�X�^�e�[�u�� �^��(�ޕʋL��)�J����
                    // --- ADD  ���r��  2010/07/07 ----------<<<<<
                    // --- ADD  2011/07/13 ---------->>>>>
                    ,new ExcptTblCol("CAMPAIGNMNGRF", 12)     //  �L�����y�[���Ǘ��}�X�^ ���i�ԍ��J����
                    // --- ADD  2011/07/13 ----------<<<<<
                });

            // �f�[�^�Ȃ���0���������O�̈ꗗ
            lstSpaceZeroExcptTblCol = new List<ExcptTblCol>(
                new ExcptTblCol[] {
                     new ExcptTblCol("CUSTDMDPRCRF", 14)   //  ���Ӑ搿�����z�}�X�^�e�[�u�� ���Ӑ�R�[�h�J����
                    ,new ExcptTblCol("SUPLIERPAYRF", 14)   //  �d����x�����z�}�X�^�e�[�u�� �d����R�[�h�J����
                });

            //// 0���󔒈��������O�̈ꗗ�쐬
            //lstZeroExcptTblCol = new List<ExcptTblCol>(
            //    new ExcptTblCol[] {
            //        new ExcptTblCol("PARTSPOSCODEURF", 8)   //  ���ʃR�[�h�}�X�^�e�[�u�� ���_�R�[�h�J����
            //    });

            // 0��NULL���������O�̈ꗗ�쐬
            lstZeroNullExcptTblCol = new List<ExcptTblCol>(
                new ExcptTblCol[] {
                     new ExcptTblCol("SALESDETAILRF", 15)     //  ���㖾�׃f�[�^�e�[�u�� ������t�J����
                    ,new ExcptTblCol("SALESDETAILRF", 23)     //  ���㖾�׃f�[�^�e�[�u�� �[�i�����\����J����
                    ,new ExcptTblCol("SALESDETAILRF", 42)     //  ���㖾�׃f�[�^�e�[�u�� �q�ɃR�[�h�J����
                    ,new ExcptTblCol("SALESHISTORYRF", 104)   //  ���㗚���f�[�^�e�[�u�� �d�c�h���M���J����
                    ,new ExcptTblCol("SALESHISTORYRF", 105)   //  ���㗚���f�[�^�e�[�u�� �d�c�h�捞���J����
                    ,new ExcptTblCol("SALESHISTDTLRF", 40)    //  ���㗚�𖾍׃f�[�^�e�[�u�� �q�ɃR�[�h�J����
                    ,new ExcptTblCol("SALESSLIPRF", 24)       //  ����f�[�^�e�[�u�� ������t�J����
                    ,new ExcptTblCol("SALESSLIPRF", 25)       //  ����f�[�^�e�[�u�� �v����t�J����
                    ,new ExcptTblCol("SALESSLIPRF", 105)      //  ����f�[�^�e�[�u�� ���W�������J����
                    ,new ExcptTblCol("SALESSLIPRF", 109)      //  ����f�[�^�e�[�u�� �d�c�h���M���J����
                    ,new ExcptTblCol("SALESSLIPRF", 110)      //  ����f�[�^�e�[�u�� �d�c�h�捞���J����
                    ,new ExcptTblCol("SALESSLIPRF", 115)      //  ����f�[�^�e�[�u�� ����`�[���s���J����
                    ,new ExcptTblCol("STOCKSLIPRF", 72)       //  �d���f�[�^�e�[�u�� �d�c�h���M���J����
                    ,new ExcptTblCol("STOCKSLIPRF", 73)       //  �d���f�[�^�e�[�u�� �d�c�h�捞���J����
                    ,new ExcptTblCol("STOCKSLIPRF", 78)       //  �d���f�[�^�e�[�u�� �d���`�[���s���J����
                    ,new ExcptTblCol("STOCKDETAILRF", 43)     //  �d�����׃f�[�^�e�[�u�� �q�ɃR�[�h�J����
                    ,new ExcptTblCol("STOCKDETAILRF", 54)     //  �d�����׃f�[�^�e�[�u�� �|���ݒ苒�_�i�d���P���j�J����
                    ,new ExcptTblCol("STOCKDETAILRF", 55)     //  �d�����׃f�[�^�e�[�u�� �|���ݒ�敪�i�d���P���j�J����
                    ,new ExcptTblCol("STOCKDETAILRF", 98)     //  �d�����׃f�[�^�e�[�u�� �[�i�����\����J����
                    ,new ExcptTblCol("STOCKDETAILRF", 99)     //  �d�����׃f�[�^�e�[�u�� ��]�[���J����
                    ,new ExcptTblCol("STOCKDETAILRF", 101)    //  �d�����׃f�[�^�e�[�u�� �����f�[�^�쐬���J����
                    ,new ExcptTblCol("STOCKSLIPHISTRF", 72)   //  �d�������f�[�^�e�[�u�� �d�c�h���M���J����
                    ,new ExcptTblCol("STOCKSLIPHISTRF", 73)   //  �d�������f�[�^�e�[�u�� �d�c�h�捞���J����
                    ,new ExcptTblCol("STOCKSLIPHISTRF", 78)   //  �d�������f�[�^�e�[�u�� �d���`�[���s���J����
                    ,new ExcptTblCol("STOCKSLHISTDTLRF", 41)  //  �d�����𖾍׃f�[�^�e�[�u�� �q�ɃR�[�h�J����
                    ,new ExcptTblCol("STOCKSLHISTDTLRF", 52)  //  �d�����𖾍׃f�[�^�e�[�u�� �|���ݒ苒�_�i�d���P���j�J����
                    ,new ExcptTblCol("STOCKSLHISTDTLRF", 53)  //  �d�����𖾍׃f�[�^�e�[�u�� �|���ݒ�敪�i�d���P���j�J����
                    ,new ExcptTblCol("DEPSITMAINRF", 23)      //  �����}�X�^�e�[�u�� ��`�U�o���J����
                    ,new ExcptTblCol("DEPSITMAINRF", 32)      //  �����}�X�^�e�[�u�� �ŏI�������݌v����J����
                    ,new ExcptTblCol("PAYMENTSLPRF", 31)      //  �x���`�[�}�X�^�e�[�u�� ��`�U�o���J����
                    ,new ExcptTblCol("PAYMENTSLPRF", 38)      //  �x���`�[�}�X�^�e�[�u�� �x�����͎҃R�[�h�J����
                    ,new ExcptTblCol("PAYMENTSLPRF", 40)      //  �x���`�[�}�X�^�e�[�u�� �x���S���҃R�[�h�J����
                    ,new ExcptTblCol("ACCEPTODRCARRF", 15)    //  �󒍃}�X�^�i�ԗ��j�e�[�u�� �ԗ��o�^�ԍ��i��ʁj�J����
                    ,new ExcptTblCol("ACCEPTODRCARRF", 18)    //  �󒍃}�X�^�i�ԗ��j�e�[�u�� ���N�x�J����
                    ,new ExcptTblCol("STOCKMOVERF", 22)       //  �݌Ɉړ��f�[�^�e�[�u�� ���ד��J����
                });

            // ADD BY gongzc 2015/08/27 FOR Redmine#47009 �y��271�zNS���݌Ɏd���f�[�^�R���o�[�g�̏�Q�Ή� ---->>>>
            // 0��NULL�ɃR���o�[�g���Ȃ��e�[�u���̗�O���X�g
            lstNotConvrtZeroToNullExcptTblCol = new List<ExcptTblCol>(
               new ExcptTblCol[] {
                   new ExcptTblCol("GOODSURF", 17)          // ���i�}�X�^(���[�U�[�o�^)�@�n�C�t�������i�ԍ��J����
                  ,new ExcptTblCol("STOCKRF", 33)           // �݌Ƀ}�X�^�@���i�Ǘ��敪�P
                  ,new ExcptTblCol("STOCKRF", 34)           // �݌Ƀ}�X�^�@���i�Ǘ��敪�Q
                  // �ȍ~�A0��NULL�ɃR���o�[�g���Ȃ��e�[�u���ƃJ������ǉ�
                  ,new ExcptTblCol("STOCKRF", 29)           // �݌Ƀ}�X�^�@�n�C�t�������i�ԍ�
                  ,new ExcptTblCol("FREESEARCHPARTSRF", 16) // ���R�������i�}�X�^�@�n�C�t�������i�ԍ�
                  ,new ExcptTblCol("SALESDETAILRF", 29)     // ���㖾�׃f�[�^�@���i�ԍ�
                  ,new ExcptTblCol("SALESHISTDTLRF", 27)    // ���㗚�𖾍׃f�[�^�@���i�ԍ�
                  ,new ExcptTblCol("CNVCARPARTSRF", 16)     // ���q���i�f�[�^�i�R���o�[�g�j�@���i�ԍ�
                  ,new ExcptTblCol("STOCKDETAILRF", 30)     // �d�����׃f�[�^�@���i�ԍ�
                  ,new ExcptTblCol("STOCKSLHISTDTLRF", 28)  // �d�����𖾍׃f�[�^�@���i�ԍ�
                  ,new ExcptTblCol("STOCKMOVERF", 35)       // �݌Ɉړ��f�[�^�@���i�ԍ�
                  ,new ExcptTblCol("STOCKADJUSTDTLRF", 19)  // �݌ɒ������׃f�[�^�@���i�ԍ�
               });
            // ADD BY gongzc 2015/08/27 FOR Redmine#47009 �y��271�zNS���݌Ɏd���f�[�^�R���o�[�g�̏�Q�Ή� ----<<<<

            // �폜���Ȃ��L�b�e�B���O�f�[�^�̈ꗗ�쐬
            lstKittingTblCol = new List<ExcptTblCol>(
                new ExcptTblCol[] {
                    new ExcptTblCol("BILLALLSTRF", 8)       //  �����S�̐ݒ�}�X�^�e�[�u�� ���_�R�[�h�J����
                   ,new ExcptTblCol("SALESTTLSTRF", 8)      //  ����S�̐ݒ�}�X�^�e�[�u�� ���_�R�[�h�J����
                   ,new ExcptTblCol("STOCKTTLSTRF", 8)      //  �d���݌ɑS�̐ݒ�}�X�^�e�[�u�� ���_�R�[�h�J����
                   ,new ExcptTblCol("STOCKMNGTTLSTRF", 8)   //  �݌ɑS�̐ݒ�}�X�^�e�[�u�� ���_�R�[�h�J����
                    //2009/02/14 ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>
                   ,new ExcptTblCol("EMPLOYEERF", 8)        //  �]�ƈ��ݒ�}�X�^�e�[�u�� �]�ƈ��R�[�h�J����
                   ,new ExcptTblCol("EMPLOYEEDTLRF", 8)     //  �]�ƈ��ڍאݒ�}�X�^�e�[�u�� �]�ƈ��R�[�h�J����
                    //2009/02/14 ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<
                });

            // �f�[�^�̑����e�[�u���̈ꗗ�쐬 (lstKittingTblCol�Ɠ������ڂ��Ȃ��悤�ɒ���)
            lstDataFullTbl = new List<string>(
                new string[] {
                    "MTTLSALESSLIPRF"    // ���㌎���W�v�f�[�^
                   ,"GOODSMTTLSASLIPRF"  // ���i�ʔ��㌎���W�v�f�[�^
                   ,"SALESHISTDTLRF"     // ���㗚�𖾍׃f�[�^
                // -- ADD 2010/04/28 ------------------------------>>>
                   ,"SALESHISTORYRF"     // ���㗚���f�[�^
                   ,"ACCEPTODRRF"        // �󒍃}�X�^
                   ,"ACCEPTODRCARRF"     // �󒍃}�X�^�i�ԗ��j
                // -- ADD 2010/04/28 ------------------------------<<<
                // 2010/08/03 Add >>>
                    ,"CUSTDMDPRCRF"      // ���Ӑ搿�����z�}�X�^
                // 2010/08/03 Add <<<
                // 2012/02/15 Add >>>
                    ,"STOCKDETAILRF"     // �d�����׃f�[�^
                    ,"STOCKSLIPHISTRF"   // �d�������f�[�^
                    ,"STOCKSLHISTDTLRF"  // �d�����𖾍׃f�[�^
                // 2012/02/15 Add <<<
                // 2012/02/20 Add >>>
                    ,"STOCKHISTORYRF"    // �݌ɗ����f�[�^
                // 2012/02/20 Add <<<
                });

            // -- ADD 2010/04/28 ------------------------------>>>
            // �S�p�����`�F�b�N�Ώۂ̈ꗗ�쐬
            lstFullSizeCheckTbl = new List<string>(
                new string[] {
                    // �p���i�啶���j
                    "�`","�a","�b","�c","�d","�e","�f","�g","�h","�i","�j","�k","�l","�m","�n","�o","�p","�q","�r","�s","�t","�u","�v","�w","�x","�y"
                    // �p���i�������j
                   ,"��","��","��","��","��","��","��","��","��","��","��","��","��","��","��","��","��","��","��","��","��","��","��","��","��","��"
                    // ����
                   ,"�O","�P","�Q","�R","�S","�T","�U","�V","�W","�X"
                    //---ADD 2011/08/25 -------------------------->>>>>
                    // �S�p�J�^�J�i�̂T�O����
                   ,"�A","�C","�E","�G","�I","�J","�L","�N","�P","�R"
                   ,"�T","�V","�X","�Z","�\","�i","�j","�k","�l","�m"
                   ,"�^","�`","�c","�e","�g","��","��","��","��","��"
                   ,"�n","�q","�t","�w","�z","�}","�~","��","��","��"
                   ,"��","��","��","��","��","��"
                �@ ,"��","��","��","�D","�H","�B","�b","�F","�@"
                �@ ,"�K","�M","�O","�Q","�S","�U","�W","�Y","�[","�]"
            �@�@�@ ,"�_","�a","�d","�f","�h","�o","�r","�u","�x","�{"
                �@ ,"�p","�s","�v","�y","�|"
                    // �S�p�L��
                  ,"�e","�`","�I","��","��","��","��","�O","��","��","�i","�j","�Q","�[","�{","��","�o","�p","�u","�v","�G","�F","�f","�h","��","��","�C","�B","�H","�b","��","�D","�^"
                  ,"�A","�K","�U"
                    //---ADD 2011/08/25 --------------------------<<<<<
                });
            // -- ADD 2010/04/28 ------------------------------<<<
        }

        /// <summary>
        /// �f�X�g���N�^
        /// </summary>
        ~ConvertProcessDB()
        {
            // ----- DEL 2019/10/22 �c���� SQLSERVER2017�Ή� ----->>>>>
            //if (srvCon != null)
            //{
            //    /* ----- DEL Lizc 2013/07/01 Redmine#36971 ----->>>>>
            //    try
            //    {
            //        if (srvCon.IsOpen)
            //            srvCon.Disconnect();
            //    }
            //    catch { }
            //    srvCon = null;
            //    ----- DEL Lizc 2013/07/01 Redmine#36971 -----<<<<<*/

            //    // ----- DEL Lizc 2013/07/01 Redmine#36971 ----->>>>>
            //    try
            //    {
            //        bool isOpen = Convert.ToBoolean(srvCon.GetProperty("IsOpen").GetValue(servObj, null));

            //        if (isOpen)
            //        {
            //            srvCon.InvokeMember("Disconnect", BindingFlags.InvokeMethod, null, servObj, null);
            //        }
            //    }
            //    catch { }
            //    srvCon = null;
            //    // ----- DEL Lizc 2013/07/01 Redmine#36971 -----<<<<<
            //}
            // ----- DEL 2019/10/22 �c���� SQLSERVER2017�Ή� -----<<<<<
            if (sqlConnection != null)
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null && sqlTransaction.Connection.State == ConnectionState.Open)
                    {
                        try
                        {
                            sqlTransaction.Rollback();
                        }
                        catch { }
                    }
                    sqlTransaction.Dispose();
                    sqlTransaction = null;
                }
                if (sqlConnection.State != ConnectionState.Closed)
                {
                    try
                    {
                        sqlConnection.Dispose();
                        sqlConnection = null;
                    }
                    catch { }
                }
            }
        }
        #endregion

        #region [ �g�����U�N�V�������� ]
        /// <summary>
        /// �g�����U�N�V�������J�n���܂��B
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : �g�����U�N�V�������J�n���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br>Update Note: �d�|��2007 �R���o�[�g�v���O������SQLSERVER2012�Ή�</br>
        /// <br>Programmer : Lizc</br>
        /// <br>Date       : 2013/07/01</br>
        /// <br>Update Note: PMKOBETSU-2232 SQLSERVER2017�Ή�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/10/22</br>
        public int BeginTransaction()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            SqlConnection sqlConnection1 = null;// ADD�@2019/10/22 �c���� SQLSERVER2017�Ή�
            if (string.IsNullOrEmpty(connectionText))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            else
            {
                try
                {
                    // --- ADD�@2019/10/22 �c���� SQLSERVER2017�Ή�---------->>>>>
                    sqlConnection1 = new SqlConnection(connectionText);
                    sqlConnection1.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(String.Format("ALTER DATABASE {0} SET RECOVERY bulk_logged", sqlConnection1.Database), sqlConnection1))
                    {
                        sqlCommand.ExecuteReader();
                    }
                    // --- ADD�@2019/10/22 �c���� SQLSERVER2017�Ή�----------<<<<
                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();
                    sqlTransaction = sqlConnection.BeginTransaction();//IsolationLevel.ReadUncommitted);

                    // --- DEL�@2019/10/22 �c���� SQLSERVER2017�Ή�---------->>>>>
                    //if (srvCon == null)
                    //{
                    //    //srvCon = new MSMC.ServerConnection();  // DEL Lizc 2013/07/01 Redmine#36971
                    //    // 2009/02/27 SQL Server�F�ؕύX�Ή�>>>>>>>>>>>>>>>>>>>>
                    //    // Windows�F�؂ł�AP�T�[�o�[�ADB�T�[�o�[�̔z�u�������ꂽ�ꍇ�ɃG���[�ƂȂ邽�߁A
                    //    // sa������SQL Server�F�؂�����悤�ɏC��
                    //    //srvCon.LoginSecure = true;

                    //    UbauControl ubauControl = new UbauControl();
                    //    UbauControl.DbMaintenanceInfo dbMaintenanceInfo = new UbauControl.DbMaintenanceInfo();
                    //    InstallationInfo installationInfo = new InstallationInfo();

                    //    installationInfo.ServerName = Environment.MachineName;
                    //    installationInfo.ServerType = "DB";
                    //    installationInfo.ServiceCode = "USER_DB";         //DB�̎�ރR�[�h(USER_DB,OFFER_DB���j
                    //    installationInfo.OsAdminId = "";                        //������OK
                    //    installationInfo.OsAdminPwd = "";                      //������OK
                    //    installationInfo.InstallMngr = "";                      //������OK
                    //    installationInfo.ProductCode = ConstantManagement_SF_PRO.ProductCode;      //�v���_�N�g�R�[�h(�K�{)
                    //    installationInfo.DBTblNmLst = new string[] { };

                    //    dbMaintenanceInfo = ubauControl.GetDbInfo(installationInfo, UbauControl.TargetSystem.LSM);

                    //    if (dbMaintenanceInfo == null)
                    //    {
                    //        transactionFlg = false;
                    //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    //        return status;
                    //    }

                    //    /* ----- DEL Lizc 2013/07/01 Redmine#36971 ----->>>>>
                    //    srvCon.LoginSecure = false;

                    //    srvCon.Login = dbMaintenanceInfo.MyDbInfo.AdminId;
                    //    srvCon.Password = dbMaintenanceInfo.MyDbInfo.AdminPwd;
                    //    // 2009/02/27 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    //    srvCon.ServerInstance = sqlConnection.DataSource;
                    //    serv = new Server(srvCon);
                    //    ----- DEL Lizc 2013/07/01 Redmine#36971 -----<<<<< */
                    //    //----- ADD Lizc 2013/07/01 Redmine#36971 ----->>>>>
                    //    // SqlServer��DLL�𓮓I���[�h
                    //    string connectionInfoName = string.Empty;
                    //    string smoName = string.Empty;

                    //    int dbVersion = CheckDBVersion(sqlConnection, sqlTransaction);
                    //    // SqlServer�̃o�[�W�������u2008�v��
                    //    if (dbVersion == (int)DB_Version.ctDB_2008)
                    //    {
                    //        connectionInfoName = "Microsoft.SqlServer.ConnectionInfo, Version=10.0.0.0,Culture=neutral, PublicKeyToken=89845dcd8080cc91";
                    //        smoName = "Microsoft.SqlServer.Smo, Version=10.0.0.0, Culture=neutral,PublicKeyToken=89845dcd8080cc91";
                    //    }
                    //    // SqlServer�̃o�[�W�������u2012�v��
                    //    else if (dbVersion == (int)DB_Version.ctDB_2012)
                    //    {
                    //        connectionInfoName = "Microsoft.SqlServer.ConnectionInfo, Version=11.0.0.0, Culture=neutral,PublicKeyToken=89845dcd8080cc91";
                    //        smoName = "Microsoft.SqlServer.Smo, Version=11.0.0.0,Culture=neutral, PublicKeyToken=89845dcd8080cc91";
                    //    }
                    //    // SqlServer�̃o�[�W���������̂���
                    //    else
                    //    {
                    //        connectionInfoName = "Microsoft.SqlServer.ConnectionInfo";
                    //        smoName = "Microsoft.SqlServer.Smo";
                    //    }

                    //    // �usrvCon = new MSMC.ServerConnection();�v���ւ���
                    //    Assembly connectionInfoAssembly = Assembly.Load(connectionInfoName);
                    //    srvCon = connectionInfoAssembly.GetType("Microsoft.SqlServer.Management.Common.ServerConnection");
                    //    object serverConnection = srvCon.InvokeMember(null, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance, null, null, null);

                    //    // �usrvCon.LoginSecure = false;�v���ւ���
                    //    srvCon.GetProperty("LoginSecure").SetValue(serverConnection, false, null);
                    //    // �usrvCon.Login = dbMaintenanceInfo.MyDbInfo.AdminId;�v���ւ���
                    //    srvCon.GetProperty("Login").SetValue(serverConnection, dbMaintenanceInfo.MyDbInfo.AdminId, null);
                    //    // �usrvCon.Password = dbMaintenanceInfo.MyDbInfo.AdminPwd;�v���ւ���
                    //    srvCon.GetProperty("Password").SetValue(serverConnection, dbMaintenanceInfo.MyDbInfo.AdminPwd, null);
                    //    // �usrvCon.ServerInstance = sqlConnection.DataSource;�v���ւ���
                    //    srvCon.GetProperty("ServerInstance").SetValue(serverConnection, sqlConnection.DataSource, null);

                    //    // �userv = new Server(srvCon);�v���ւ���
                    //    Assembly smoAssembly = Assembly.Load(smoName);
                    //    servObj = smoAssembly.CreateInstance("Microsoft.SqlServer.Management.Smo.Server", false, BindingFlags.CreateInstance, null, new object[] { serverConnection }, null, null);
                    //    serv = servObj.GetType();
                    //    //----- ADD Lizc 2013/07/01 Redmine#36971 -----<<<<<
                    //}
                    ////serv.Databases[sqlConnection.Database].DatabaseOptions.RecoveryModel = RecoveryModel.BulkLogged;  // DEL Lizc 2013/07/01 Redmine#36971
                    //SetRecoveryModel(servObj, sqlConnection.Database, 2); // ADD Lizc 2013/07/01   Redmine#36971
                    // --- DEL�@2019/10/22 �c���� SQLSERVER2017�Ή�----------<<<<<
                    //transactionFlg = true;  
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("ROLLBACK") && sqlConnection.State == ConnectionState.Open)
                    { // ���肦�Ȃ����삷��ƈ��ڂ̃g�����U�N�V�������������s����ꍇ������A
                        try // ���g���C���邤��OK�Ȃ̂ł��̏��������ꂽ�B
                        {
                            sqlTransaction = sqlConnection.BeginTransaction();//IsolationLevel.ReadUncommitted);
                        }
                        catch
                        {
                            transactionFlg = false;
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                    }
                    else
                    {
                        transactionFlg = false;
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
                // --- ADD�@2019/10/22 �c���� SQLSERVER2017�Ή�---------->>>>>
                finally
                {
                    if (sqlConnection1 != null)
                    {
                        sqlConnection1.Close();
                        sqlConnection1 = null;
                    }
                }
                // --- ADD�@2019/10/22 �c���� SQLSERVER2017�Ή�----------<<<<<
            }
            return status;
        }

        /// <summary>
        /// �g�����U�N�V�������I�����܂��B
        /// </summary>
        /// <param name="commitFlg">true : �R�~�b�g�@false : ���[���o�b�N</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �g�����U�N�V�������I�����܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br>Update Note: �d�|��2007 �R���o�[�g�v���O������SQLSERVER2012�Ή�</br>
        /// <br>Programmer : Lizc</br>
        /// <br>Date       : 2013/07/01</br>
        /// <br>Update Note: PMKOBETSU-2232 SQLSERVER2017�Ή�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/10/22</br>
        public int EndTransaction(bool commitFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // --- ADD�@2019/10/22 �c���� SQLSERVER2017�Ή�---------->>>>>
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            // --- ADD�@2019/10/22 �c���� SQLSERVER2017�Ή�----------<<<<<
            if (sqlTransaction == null)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            else
            {
                try
                {
                    if (commitFlg)
                    {
                        sqlTransaction.Commit();
                    }
                    else
                    {
                        if (transactionFlg)
                            sqlTransaction.Rollback();
                    }
                    // --- UPD�@2019/10/22 �c���� SQLSERVER2017�Ή�---------->>>>>
                    sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;

                    string cmdStr = string.Format("SELECT BytesOnDisk / 1048576 AS FILESIZE  FROM fn_virtualfilestats(DB_ID(N'{0}'), FILE_ID('PM_USER_DB_Log'));",
                        sqlConnection.Database);
                    sqlCommand.CommandText = cmdStr;
                    myReader = sqlCommand.ExecuteReader();
                    //string cmdStr = string.Format("SELECT BytesOnDisk / 1048576 FROM fn_virtualfilestats(DB_ID(N'{0}'), FILE_ID('PM_USER_DB_Log'));",
                    //sqlConnection.Database);
                    // --- UPD�@2019/10/22 �c���� SQLSERVER2017�Ή�----------<<<<
                    long logFileSizeM;
                    try
                    {
                        // --- UPD�@2019/10/22 �c���� SQLSERVER2017�Ή�---------->>>>>
                        ////DataSet ds = serv.Databases[sqlConnection.Database].ExecuteWithResults(cmdStr); // DEL Lizc 2013/07/01 Redmine#36971 
                        //DataSet ds = (DataSet)ExecuteSql(serv, sqlConnection.Database, cmdStr);// ADD Lizc 2013/07/01 Redmine#36971 
                        //logFileSizeM = (long)ds.Tables[0].Rows[0][0];
                        if (myReader.Read())
                        {
                            logFileSizeM = SqlDataMediator.SqlGetLong(myReader, myReader.GetOrdinal("FILESIZE"));
                            if (myReader != null)
                            {
                                if (!myReader.IsClosed) myReader.Close();
                                myReader.Dispose();
                            }
                        }
                        else
                        {
                            logFileSizeM = 1025;
                        }
                        // --- UPD�@2019/10/22 �c���� SQLSERVER2017�Ή�----------<<<<<
                    }
                    catch
                    {
                        logFileSizeM = 1025; // ���O�t�@�C���T�C�Y�擾���s�����������O�t�@�C���k��
                    }

                    /* ----- DEL Lizc 2013/07/01 Redmine#36971 ----->>>>>
                    if (logFileSizeM > 1024) // ���O�t�@�C����1GB�����邩
                        serv.Databases[sqlConnection.Database].ExecuteNonQuery("DBCC SHRINKFILE (PM_USER_DB_Log, 500)");
                    serv.Databases[sqlConnection.Database].DatabaseOptions.RecoveryModel = RecoveryModel.Full;
                    ----- DEL Lizc 2013/07/01 Redmine#36971 -----<<<<<*/
                    // ----- ADD Lizc 2013/07/01 Redmine#36971 ----->>>>>
                    if (logFileSizeM > 1024) // ���O�t�@�C����1GB�����邩
                    // --- UPD�@2019/10/22 �c���� SQLSERVER2017�Ή�---------->>>>
                    //        ExecuteSql(serv, sqlConnection.Database, "DBCC SHRINKFILE (PM_USER_DB_Log, 500)");
                    //SetRecoveryModel(servObj, sqlConnection.Database, 1);
                    // ----- ADD Lizc 2013/07/01 Redmine#36971 -----<<<<<
                    {
                        sqlCommand.CommandText = "DBCC SHRINKFILE (PM_USER_DB_Log, 500)";
                        sqlCommand.ExecuteReader();
                    }

                    //serv.Databases[sqlConnection.Database].DatabaseOptions.RecoveryModel = RecoveryModel.Full;
                    sqlCommand.CommandText = string.Format("ALTER DATABASE {0} SET RECOVERY full", sqlConnection.Database);
                    sqlCommand.ExecuteReader();
                    // --- UPD�@2019/10/22 �c���� SQLSERVER2017�Ή�----------<<<<<

                }
                catch
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                finally
                {
                    // --- ADD�@2019/10/22 �c���� SQLSERVER2017�Ή�---------->>>>
                    if (sqlCommand != null)
                        sqlCommand.Dispose();
                    // --- ADD�@2019/10/22 �c���� SQLSERVER2017�Ή�----------<<<<
                    if (sqlTransaction != null)
                    {
                        sqlTransaction.Dispose();
                        sqlTransaction = null;
                    }
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        //sqlConnection.Dispose();
                        sqlConnection = null;
                    }
                    transactionFlg = false;
                }
            }
            return status;
        }
        #endregion

        #region [ �R���o�[�g�f�[�^�W�J���� ]
        /// <summary>
        /// �����J�n
        /// </summary>        
        /// <returns></returns>
        public int StartProcess()
        {
            onProcess = true;
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        // --- DEL�@2019/10/22 �c���� SQLSERVER2017�Ή�---------->>>>
        //// ----- ADD Lizc 2013/07/01 Redmine#36971 ----->>>>>

        //private enum DB_Version
        //{
        //    ctDB_2008 = 2008,
        //    ctDB_2012 = 2012,
        //    ctDB_Other = 0,
        //}

        ///// <summary>
        ///// �f�[�^�x�[�X�̃o�[�W�������擾�����B
        ///// </summary>
        ///// <param name="sqlConnection">SqlConnection</param>
        ///// <param name="sqlTransaction">SqlTransaction</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Note       : �f�[�^�x�[�X�̃o�[�W�������擾�����B</br>
        ///// <br>Programmer : Lizc</br>
        ///// <br>Date       : 2013/07/01</br>
        ///// </remarks>
        //private int CheckDBVersion(SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        //{
        //    int dbVersion = (int)DB_Version.ctDB_2008;

        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;
        //    try
        //    {
        //        // �f�[�^�x�[�X�̃o�[�W�������擾����
        //        string selectTxt = "SELECT SERVERPROPERTY('productversion') AS productversion";

        //        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {

        //            string productversion = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("productversion"));

        //            // 2008��
        //            if ("10".Equals(productversion.Substring(0, 2)))
        //            {
        //                dbVersion = (int)DB_Version.ctDB_2008;
        //            }
        //            // 2012��
        //            else if ("11".Equals(productversion.Substring(0, 2)))
        //            {
        //                dbVersion = (int)DB_Version.ctDB_2012;
        //            }
        //            // ���̑�
        //            else
        //            {
        //                dbVersion = (int)DB_Version.ctDB_Other;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //nothing
        //    }
        //    finally
        //    {
        //        if (myReader != null)
        //            myReader.Dispose();
        //        if (sqlCommand != null)
        //            sqlCommand.Dispose();
        //    }

        //    return dbVersion;
        //}

        ///// <summary>
        ///// �f�[�^�x�[�X�����擾�����B
        ///// </summary>
        ///// <param name="database">�f�[�^�x�[�X</param>
        ///// <param name="recoveryModel">���[�h</param>
        ///// <param name="servObj">server Object</param>
        ///// <remarks>
        ///// <br>Note       : �f�[�^�x�[�X�����擾�����B</br>
        ///// <br>Programmer : Lizc</br>
        ///// <br>Date       : 2013/07/01</br>
        ///// </remarks>
        //private void SetRecoveryModel(object servObj, string database, int recoveryModel)
        //{
        //    PropertyInfo databaseInfo = servObj.GetType().GetProperty("Databases");
        //    object databasesObj = databaseInfo.GetValue(servObj, null);
        //    PropertyInfo databaseGetInfo = databaseInfo.PropertyType.GetProperty("Item", null, new Type[] { typeof(string) });
        //    object databaseObj = databaseGetInfo.GetValue(databasesObj, new object[] { sqlConnection.Database });

        //    // �userv.Databases[sqlConnection.Database].DatabaseOptions.RecoveryModel = xx;�v���ւ���
        //    object databaseOptions = databaseGetInfo.PropertyType.GetProperty("DatabaseOptions").GetValue(databaseObj, null);
        //    databaseOptions.GetType().GetProperty("RecoveryModel").SetValue(databaseOptions, recoveryModel, null);
        //}

        ///// <summary>
        ///// �f�[�^�x�[�X�N�G�������B
        ///// </summary>
        ///// <param name="database">�f�[�^�x�[�X���</param>
        ///// <param name="serv">server Type</param>
        ///// <param name="sql">sql�N�G��</param>
        ///// <remarks>
        ///// <br>Note       : �f�[�^�x�[�X�N�G�������B</br>
        ///// <br>Programmer : Lizc</br>
        ///// <br>Date       : 2013/07/01</br>
        ///// </remarks>
        //private object ExecuteSql(Type serv, string database, string sql)
        //{
        //    // �userv.Databases[sqlConnection.Database].ExecuteNonQuery(xxxx);�v���ւ���
        //    PropertyInfo databaseInfo = serv.GetProperty("Databases");
        //    object databasesObj = databaseInfo.GetValue(servObj, null);
        //    PropertyInfo databaseGetInfo = databaseInfo.PropertyType.GetProperty("Item", null, new Type[] { typeof(string) });
        //    object databaseObj = databaseGetInfo.GetValue(databasesObj, new object[] { database });
        //    return databaseObj.GetType().InvokeMember("ExecuteNonQuery", BindingFlags.InvokeMethod, null, databaseObj, new object[] { sql });
        //}

        //// ----- ADD Lizc 2013/07/01 Redmine#36971 -----<<<<<
        // --- DEL�@2019/10/22 �c���� SQLSERVER2017�Ή�----------<<<<

        /// <summary>
        /// �R���o�[�g�f�[�^��PM.NS�̃��[�U�[DB�ɓW�J���܂��B
        /// </summary>
        /// <param name="tableID">�Ώۂ̃e�[�u��ID</param>
        /// <param name="truncateFlg">�폜�t���O</param>
        /// <param name="deployDataList">�f�[�^�̃��X�g(CustomSerializeArrayList)</param>
        /// <param name="errList"></param>
        /// <param name="result">�R���o�[�g����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �R���o�[�g�f�[�^��PM.NS�̃��[�U�[DB�ɓW�J���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        public int DeployConvertData(string tableID, bool truncateFlg, CustomSerializeArrayList deployDataList,
                ref CustomSerializeArrayList errList, out ConvertResultWork result)
        {
            result = new ConvertResultWork();
            if (stopFlg)
            {
                return DoCancel(result, errList);
            }
            int status = SetDataSet(tableID, truncateFlg, deployDataList, ref errList, ref result);
            onProcess = false;
            return status;
        }

        private int SetDataSet(string tableID, bool truncateFlg, CustomSerializeArrayList deployDataList,
                ref CustomSerializeArrayList errList, ref ConvertResultWork result)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int exceptionCnt = 0;
            ExcptTblCol ExcptTblCol = new ExcptTblCol(tableID, 0);
            string _tblId = string.Empty;// ADD�@2019/10/22 �c���� SQLSERVER2017�Ή�
            char[] pat = new char[] { ',' };
            object[] row;
            result.UpdateCnt = 0;
            result.FailedRowCnt = 0;
            DataTable dt = null;    // 2009/11/17 Add
            if (deployDataList.Count == 0)
                return status;
            ArrayList list = deployDataList[0] as ArrayList;
            // 2009/11/17 del >>>
            //if (list == null)
            //    return status;
            // 2009/11/17 del <<<
            // 2009/11/17 Add >>>
            if (list == null || list.Count == 0)
            {
                if (stopFlg)
                {
                    return DoCancel(result, errList);
                }
                GetFileHeaderInfo();
                //if (sqlConnection == null) // 30�����ȏ�̃f�[�^�̏����ł��̓s�x�R�~�b�g����Ƃ��̓g�����U�N�V�����J�n���K�v
                //    BeginTransaction();
                if (_tblId != tableID)
                {
                    _tblId = tableID;
                     // -- UPD 2011/09/29 ----------------------------->>>
                    //string query = string.Format("SELECT * FROM {0} WHERE ENTERPRISECODERF = '{1}'", tableID, _enterpriseCode);
                    //�X�L�[�}�̎擾�ɑS���擾�͕s�v�̂��߁A�P�����q�b�g���Ȃ������N�G���Ƃ���悤�ɏC��
                    string query = string.Format("SELECT * FROM {0} WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF = '{1}' AND 1=0 ", tableID, _enterpriseCode);
                    // -- UPD 2011/09/29 -----------------------------<<<
                    da = new SqlDataAdapter(query, sqlConnection);

                    da.SelectCommand.Transaction = sqlTransaction;
                    da.SelectCommand.CommandTimeout = 3600;  // ADD 2011/09/29

                    SqlCommandBuilder builder1 = new SqlCommandBuilder(da);
                }
                dt = new DataTable();
                dt.CaseSensitive = true;
                da.FillSchema(dt, SchemaType.Mapped);
                if (truncateFlg)
                {
                    ExcptTblCol.ColNo = 8;
                    if (lstKittingTblCol.Contains(ExcptTblCol) == false) // �s���̍폜�Ώۂ̃e�[�u���łȂ��ꍇ
                    {
                        dt.Rows.Clear();
                        SqlCommand command = new SqlCommand();// ADD�@2019/10/22 �c���� SQLSERVER2017�Ή�
                        ////command.CommandText = string.Format("DELETE FROM {0} WHERE ENTERPRISECODERF = '{1}'", tableID, _enterpriseCode);
                        //// DELETE���Ƒ�ʃf�[�^�̍폜���^�C���A�E�g�ɂȂ邽�߁A���L�ɂ���B
                        //// ��ƃR�[�h�Ⴂ�̓R���o�[�g���͂Ȃ����ߖ������Ă����Ɗm�F�B(2009/01/15)
                        // --- UPD�@2019/10/22 �c���� SQLSERVER2017�Ή�---------->>>>
                        command.CommandText = string.Format("TRUNCATE TABLE {0} ", tableID);
                        command.Connection = sqlConnection;
                        command.Transaction = sqlTransaction;
                        command.ExecuteNonQuery();
                        command.Dispose();
                        // --- UPD�@2019/10/22 �c���� SQLSERVER2017�Ή�----------<<<<
                        //serv.Databases[sqlConnection.Database].ExecuteNonQuery(string.Format("TRUNCATE TABLE {0} ", tableID)); // DEL Lizc 2013/07/01 Redmine#36971
                        //ExecuteSql(serv, sqlConnection.Database, string.Format("TRUNCATE TABLE {0} ", tableID));     // ADD Lizc 2013/07/01 Redmine#36971    // DEL 2019/10/22 �c���� SQLSERVER2017�Ή�           

                        dt.AcceptChanges();
                        da.Update(dt);
                        return 0;
                    }
                }
                //return status; // del wangf 2011/08/30
                return 0; // add wangf 2011/08/30
            }

            // --- ADD 2020/06/18 ���X�ؘj ---------->>>>>
            // �ϊ���� ���i�}�X�^�̂݌Ăяo��
            double dListPrice = double.MinValue;  // �艿
            ConvertDoubleRelease convertDoubleRelease = null;
            if ("GOODSPRICEURF".Equals(tableID))
            {
                // �ϊ����Ăяo��
                convertDoubleRelease = new ConvertDoubleRelease();

                // �ϊ���񏉊���
                convertDoubleRelease.ReleaseInitLib();
            }
            // --- ADD 2020/06/18 ���X�ؘj ----------<<<<<

            // 2009/11/17 Add <<<
            //SqlDataAdapter da = null;
            //DataTable dt = null;    // 2009/11/17 Del
            try
            {
                if (stopFlg)
                {
                    return DoCancel(result, errList);
                }
                GetFileHeaderInfo();
                //if (sqlConnection == null) // 30�����ȏ�̃f�[�^�̏����ł��̓s�x�R�~�b�g����Ƃ��̓g�����U�N�V�����J�n���K�v
                //    BeginTransaction();
                if (_tblId != tableID)
                {
                    _tblId = tableID;
                    string query = string.Format("SELECT * FROM {0} WHERE ENTERPRISECODERF = '{1}'", tableID, _enterpriseCode);
                    da = new SqlDataAdapter(query, sqlConnection);

                    da.SelectCommand.Transaction = sqlTransaction;
                    SqlCommandBuilder builder1 = new SqlCommandBuilder(da);
                }

                dt = new DataTable();
                dt.CaseSensitive = true;

                // -- ADD 2011/09/29 ----------------------------->>>
                //���L�A�X�L�[�}�̎擾�ɑS���擾�͕s�v�̂��߁A�P�����q�b�g���Ȃ������N�G���Ƃ���悤�ɏC��
                da.SelectCommand.CommandText = string.Format("SELECT * FROM {0} WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF = '{1}' AND 1=0 ", tableID, _enterpriseCode); ;
                // -- ADD 2011/09/29 -----------------------------<<<
                da.SelectCommand.CommandTimeout = 3600;  // ADD 2011/09/29

                da.FillSchema(dt, SchemaType.Mapped);

                // -- ADD 2011/09/29 ----------------------------->>>
                //Fill�Ŏg�p���邽�߁ACommandText�������߂�
                da.SelectCommand.CommandText = string.Format("SELECT * FROM {0} WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF = '{1}'", tableID, _enterpriseCode);
                // -- ADD 2011/09/29 -----------------------------<<<

                if (stopFlg)
                {
                    return DoCancel(result, errList);
                }
                ExcptTblCol.ColNo = 8;
                if ((truncateFlg == false  // �폜�t���O�Ȃ�
                    && lstDataFullTbl.Contains(tableID) == false) || // ��ʃf�[�^�͏d���`�F�b�N�̂��߂̊����f�[�^���[�h�Ȃ�
                    (truncateFlg && lstKittingTblCol.Contains(ExcptTblCol)))  // �f�[�^���e�`�F�b�N���Ȃ���폜����p�^�[��                    
                    da.Fill(dt);

                if (stopFlg)
                {
                    return DoCancel(result, errList);
                }
                if (truncateFlg)
                {
                    ExcptTblCol.ColNo = 8;
                    if (lstKittingTblCol.Contains(ExcptTblCol) == false) // �s���̍폜�Ώۂ̃e�[�u���łȂ��ꍇ
                    {
                        dt.Rows.Clear();
                        SqlCommand command = new SqlCommand();//ADD�@2019/10/22 �c���� SQLSERVER2017�Ή�
                        ////command.CommandText = string.Format("DELETE FROM {0} WHERE ENTERPRISECODERF = '{1}'", tableID, _enterpriseCode);
                        //// DELETE���Ƒ�ʃf�[�^�̍폜���^�C���A�E�g�ɂȂ邽�߁A���L�ɂ���B
                        //// ��ƃR�[�h�Ⴂ�̓R���o�[�g���͂Ȃ����ߖ������Ă����Ɗm�F�B(2009/01/15)
                        //command.CommandText = string.Format("TRUNCATE TABLE {0} ", tableID);
                        //command.Connection = sqlConnection;
                        //command.Transaction = sqlTransaction;
                        //command.ExecuteNonQuery();
                        //command.Dispose();
                        // ----- ADD ���N Redmine#32201 2012/11/05 -------------------->>>>>
                        if ("USERGDBDURF".Equals(tableID))
                        {
                            // --- UPD�@2019/10/22 �c���� SQLSERVER2017�Ή�---------->>>>
                            //serv.Databases[sqlConnection.Database].ExecuteNonQuery(string.Format("DELETE FROM {0} WHERE ENTERPRISECODERF = '{1}' AND USERGUIDEDIVCDRF ! = 80 ", tableID, _enterpriseCode)); // ADD Lizc 2013/07/01 Redmine#36971
                            //ExecuteSql(serv, sqlConnection.Database, string.Format("DELETE FROM {0} WHERE ENTERPRISECODERF = '{1}' AND USERGUIDEDIVCDRF ! = 80 ", tableID, _enterpriseCode));  // ADD Lizc 2013/07/01 Redmine#36971
                            command.CommandText = string.Format("DELETE FROM {0} WHERE ENTERPRISECODERF = '{1}' AND USERGUIDEDIVCDRF ! = 80 ", tableID, _enterpriseCode);
                            // --- UPD�@2019/10/22 �c���� SQLSERVER2017�Ή�----------<<<<
                        }
                        else
                        {
                        // ----- ADD ���N Redmine#32201 2012/11/05 --------------------<<<<<
                            // --- UPD�@2019/10/22 �c���� SQLSERVER2017�Ή�----------<<<<
                            //serv.Databases[sqlConnection.Database].ExecuteNonQuery(string.Format("TRUNCATE TABLE {0} ", tableID));// DEL Lizc 2013/07/01 Redmine#36971
                            //ExecuteSql(serv, sqlConnection.Database, string.Format("TRUNCATE TABLE {0} ", tableID)); // ADD Lizc 2013/07/01 Redmine#36971
                            command.CommandText = string.Format("TRUNCATE TABLE {0} ", tableID);
                            // --- UPD�@2019/10/22 �c���� SQLSERVER2017�Ή�----------<<<<
                        }   // ADD ���N Redmine#32201 2012/11/05
                        // --- ADD�@2019/10/22 �c���� SQLSERVER2017�Ή�---------->>>>
                        command.Connection = sqlConnection;
                        command.Transaction = sqlTransaction;
                        command.ExecuteNonQuery();
                        command.Dispose();
                        // --- ADD�@2019/10/22 �c���� SQLSERVER2017�Ή�----------<<<<
                        dt.AcceptChanges();
                    }
                    else
                    {
                        int rowCnt = dt.Rows.Count;
                        for (int i = 0; i < rowCnt; i++)
                        {
                            // 2009/02/14 MAINTIS 11475 >>>>>>>>>>>>>>>>>>>>>>
                            //if (dt.Rows[i][8].ToString().Trim().Equals("00") == false) // �폜�ΏۊO��
                            //    dt.Rows[i].Delete();

                            if (tableID != "EMPLOYEERF" && tableID != "EMPLOYEEDTLRF")
                            {
                                //�S�̐ݒ�֌W�͋��_�R�[�h'00'�͍폜���Ȃ�(�C���f�b�N�X[8]�̓��C�A�E�g��̋��_�R�[�h)
                                if (dt.Rows[i][8].ToString().Trim().Equals("00") == false) // �폜�ΏۊO��
                                    dt.Rows[i].Delete();
                            }
                            else
                            {
                                //�]�ƈ��}�X�^�́A�]�ƈ��R�[�h��������̏ꍇ�͍폜���Ȃ��i������̓L�b�e�B���O�j
                                if (CheckValueNum(dt.Rows[i][8].ToString()))
                                    dt.Rows[i].Delete();
                            }
                            // 2009/02/14 MAINTIS 11475 <<<<<<<<<<<<<<<<<<<<<<
                        }
                        da.Update(dt);
                    }
                    transactionFlg = true;
                }
                if (stopFlg)
                {
                    return DoCancel(result, errList);
                }
                Int64 now = DateTime.Now.Ticks;
                int cnt = dt.Columns.Count;

                row = new object[cnt];
                // �w�b�_�쐬
                row[0] = now; // �쐬����
                row[1] = now; // �X�V����
                row[2] = _enterpriseCode; // ��ƃR�[�h
                //row[3] = Guid.NewGuid(); // GUID
                row[4] = _updEmployeeCode; // �X�V�]�ƈ��R�[�h
                row[5] = _updAssemblyId1; // �X�V�A�Z���u��ID1
                row[6] = _updAssemblyId2; // �X�V�A�Z���u��ID2
                row[7] = 0; // �_���폜�敪
                foreach (string str in list)
                {

                    try
                    {
                        //CSV�̃��R�[�h�̓��e�𕶎���̔z��Ɋi�[
                        string[] dat = SplitString(str, cnt);// str.Split(pat);
                        row[3] = Guid.NewGuid(); // GUID
                        // -- add wangf 2011/08/12 ---------->>>>>
                        string tmpSectionCode = string.Empty;
                        int columnIndex = 0;
                        int tmpAcceptAnOrderNo = 0; // �󒍔ԍ�
                        // ----- DEL tianjw 2011/09/03 ---------------->>>>>
                        //int tmpSupplierFormalSync = 0; // �d���`��
                        //long tmpStockSlipDtlNumSync = 0; // �d�����גʔ�
                        // ----- DEL tianjw 2011/09/03 ----------------<<<<<

                        int tmpHisDtlAcceptAnOrderNo = 0; // �󒍔ԍ�

                        // -- add wangf 2011/08/12 ----------<<<<<
                        //�񖈂ɏ���
                        for (int i = 0; i < cnt; i++)
                        {
                            dat[i] = dat[i].Substring(1, dat[i].Length - 2).Replace("\"\"", "\"");
                            if (dat[i] != string.Empty) // �f�[�^����
                            {
                                ExcptTblCol.ColNo = i;
                                if (lstZeroNullExcptTblCol.Contains(ExcptTblCol) && (dat[i].Equals("0") || dat[i].Equals(0)))
                                {
                                    row[i] = DBNull.Value;
                                }
                                else if (dt.Columns[i].DataType.Name == "String") // ������̏ꍇ�A
                                {
                                    //if (lstZeroExcptTblCol.Contains(ExcptTblCol) && dat[i].Equals("0"))
                                    //{  // 0���󔒈��������O������
                                    //    row[i] = string.Empty;
                                    //}
                                    //else 
                                    if (tableID == "GCDSALESTARGETRF" && dat[10].Equals("\"45\"") && i == 8)
                                    { // ���i�ʔ���ڕW�ݒ�}�X�^ �ڕW�Δ�敪��[45:���_+���Е���]�̏ꍇ 0���󔒂Ƃ���
                                        row[i] = string.Empty;
                                    }
                                    // DEL BY gongzc 2015/08/27 FOR Redmine#47009 �y��271�zNS���݌Ɏd���f�[�^�R���o�[�g�̏�Q�Ή� ---->>>>
                                    //// 2009/06/29 MANTIS 13645 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
                                    //// �݌Ƀ}�X�^�̊Ǘ��敪(��)�ł͕�����"0"�����݂��邽�߁ANULL���Z�b�g���Ȃ�
                                    ////else if (dat[i].Equals("0") && dt.Columns[i].AllowDBNull)
                                    //else if (dat[i].Equals("0") && dt.Columns[i].AllowDBNull
                                    //    //&& !(tableID == "STOCKRF" && (i==33 || i==34)) ) // del wangf 2011/08/19
                                    //    // -- add wangf 2011/08/19 ---------->>>>>
                                    //          && !(tableID == "STOCKRF" && (i == 33 || i == 34))
                                    //          && !(tableID == "GOODSURF" && (i == 17))) // ���i�}�X�^�i���[�U�[�o�^���j�ɂŃn�C�t�������i�ԍ�
                                    //// -- add wangf 2011/08/19 ----------<<<<<
                                    //// 2009/06/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                    // DEL BY gongzc 2015/08/27 FOR Redmine#47009 �y��271�zNS���݌Ɏd���f�[�^�R���o�[�g�̏�Q�Ή� ----<<<<
                                    // ADD BY gongzc 2015/08/27 FOR Redmine#47009 �y��271�zNS���݌Ɏd���f�[�^�R���o�[�g�̏�Q�Ή� ---->>>>
                                    else if (!lstNotConvrtZeroToNullExcptTblCol.Contains(ExcptTblCol)
                                             && dat[i].Equals("0")
                                             && dt.Columns[i].AllowDBNull)
                                    // ADD BY gongzc 2015/08/27 FOR Redmine#47009 �y��271�zNS���݌Ɏd���f�[�^�R���o�[�g�̏�Q�Ή� ----<<<<
                                    {
                                        row[i] = DBNull.Value;
                                    }
                                    // -- ADD 2010/01/28 ------------------------------>>>
                                    //���i�����W�v�f�[�^�ŕi�ԂɑS�p�󔒂��Z�b�g����Ă����ꍇ�́A���p�Q���̋󔒂ɕϊ�����B
                                    else if (tableID == "GOODSMTTLSASLIPRF" && i == 15 && dat[i].Contains("�@"))
                                    {
                                        row[i] = dat[i].Replace("�@","  ");
                                    }
                                    // -- ADD 2010/01/28 ------------------------------<<<
                                    // -- ADD 2010/04/28 ------------------------------>>>
                                    //���i�����W�v�f�[�^�ŕi�ԂɑS�p�p���������Z�b�g����Ă����ꍇ�́A���p�����{���p�󔒂ɕϊ�����B
                                    else if (tableID == "GOODSMTTLSASLIPRF" && i == 15)
                                    {
                                        string workdat = dat[i];
                                        for (int j = 0; j < lstFullSizeCheckTbl.Count; j++)
                                        {
                                            //�u�������Ώۂ̑S�p�������܂ނ��`�F�b�N
                                            if (workdat.Contains(lstFullSizeCheckTbl[j].ToString()))
                                            {
                                                workdat = workdat.Replace(lstFullSizeCheckTbl[j].ToString(), Microsoft.VisualBasic.Strings.StrConv(lstFullSizeCheckTbl[j].ToString(), Microsoft.VisualBasic.VbStrConv.Narrow, 0) + " ");
                                            }
                                        }
                                        row[i] = workdat;
                                    }
                                    // -- ADD 2010/04/28 ------------------------------<<<
                                    else
                                    {
                                        DataRow rowCol = conf.Tables[ctColDfTable].Rows.Find(dt.Columns[i].ColumnName);
                                        if (rowCol == null) // 0�l�����s�v
                                        {
                                            row[i] = Convert.ChangeType(dat[i], dt.Columns[i].DataType);
                                        }
                                        else // 0�l�������K�v
                                        {
                                            DataRow rowDD = conf.Tables[ctDDTable].Rows.Find(rowCol[ctItemDDName].ToString());
                                            int cntCol = Convert.ToInt32(rowDD[ctColumn]);
                                            if (cntCol > 0 && cntCol < 256)
                                            {
                                                StringBuilder fmt = new StringBuilder();
                                                fmt.Append("{0:");
                                                fmt.Append('0', cntCol);
                                                fmt.Append("}");
                                                row[i] = string.Format(fmt.ToString(), Convert.ToInt32(dat[i]));
                                            }
                                            else
                                            {
                                                row[i] = Convert.ChangeType(dat[i], dt.Columns[i].DataType);
                                            }
                                        }
                                    }
                                    // -- add wangf 2011/08/12 ---------->>>>>
                                    // ���_�R�[�h��ۑ�
                                    if ("SECTIONCODERF".Equals(dt.Columns[i].ToString()))
                                    {
                                        tmpSectionCode = dat[i];
                                    }
                                    // -- add wangf 2011/08/12 ----------<<<<<
                                }
                                else // �f�[�^�^�C�v��String�łȂ��ꍇ
                                {
                                    row[i] = Convert.ChangeType(dat[i], dt.Columns[i].DataType);
                                    // -- add wangf 2011/08/12 ---------->>>>>
                                    if ("SALESDETAILRF".Equals(tableID))
                                    {
                                        if ("ACCEPTANORDERNORF".Equals(dt.Columns[i].ToString()))
                                        {
                                            columnIndex = i;
                                            tmpAcceptAnOrderNo = Convert.ToInt32(dat[i]);
                                        }
                                        // ----- DEL tianjw 2011/09/03 ---------------->>>>>
                                        //// �d���`����ۑ�
                                        //if ("SUPPLIERFORMALSYNCRF".Equals(dt.Columns[i].ToString()))
                                        //{
                                        //    tmpSupplierFormalSync = Convert.ToInt32(dat[i]);
                                        //}
                                        //// �d�����גʔԂ�ۑ�
                                        //if ("STOCKSLIPDTLNUMSYNCRF".Equals(dt.Columns[i].ToString()))
                                        //{
                                        //    tmpStockSlipDtlNumSync = Convert.ToInt64(dat[i]);
                                        //}
                                        // ----- DEL tianjw 2011/09/03 ----------------<<<<<
                                    }
                                    // ----- ADD tianjw 2011/09/03 ----------------------------->>>>>
                                    if ("SALESHISTDTLRF".Equals(tableID))
                                    {
                                        if ("ACCEPTANORDERNORF".Equals(dt.Columns[i].ToString()))
                                        {
                                            columnIndex = i;
                                            tmpHisDtlAcceptAnOrderNo = Convert.ToInt32(dat[i]);
                                        }
                                    }
                                    // ----- ADD tianjw 2011/09/03 -----------------------------<<<<<
                                    if ("ACCEPTODRCARRF".Equals(tableID))
                                    {
                                        if ("ACCEPTANORDERNORF".Equals(dt.Columns[i].ToString()))
                                        {
                                            if (Convert.ToInt32(dat[i]) < 0)
                                            {
                                                if (this._acceptAnOrderNoHashTable.Contains(Convert.ToInt32(dat[i])))
                                                {
                                                    row[i] = this._acceptAnOrderNoHashTable[Convert.ToInt32(dat[i])];
                                                    this._acceptAnOrderNoHashTable.Remove(Convert.ToInt32(dat[i])); // ADD tianjw 2011/09/05
                                                }
                                                // ----- ADD tianjw 2011/09/03 ----------------------------->>>>>
                                                else if (this._hisDtlAcceptAnOrderNoHashTable.Contains(Convert.ToInt32(dat[i])))
                                                {
                                                    row[i] = this._hisDtlAcceptAnOrderNoHashTable[Convert.ToInt32(dat[i])];
                                                    this._hisDtlAcceptAnOrderNoHashTable.Remove(Convert.ToInt32(dat[i])); // ADD tianjw 2011/09/05
                                                }
                                                // ----- ADD tianjw 2011/09/03 -----------------------------<<<<<
                                            }
                                        }
                                    }
                                    // -- add wangf 2011/08/12 ----------<<<<<

                                    // --- ADD 2020/06/18 ���X�ؘj ---------->>>>>
                                    if ("GOODSPRICEURF".Equals(tableID))
                                    {
                                        if ("LISTPRICERF".Equals(dt.Columns[i].ToString()))
                                        {
                                            if (double.TryParse(dat[i], out dListPrice) == true)
                                            {
                                                convertDoubleRelease.EnterpriseCode = _enterpriseCode;
                                                convertDoubleRelease.GoodsMakerCd = int.MinValue; // �_�~�[
                                                convertDoubleRelease.GoodsNo = string.Empty; // �_�~�[
                                                convertDoubleRelease.ConvertSetParam = dListPrice; 
                                                // �ϊ��������s
                                                convertDoubleRelease.ConvertProc();

                                                row[i] = Convert.ChangeType(convertDoubleRelease.ConvertInfParam.ConvertGetParam, dt.Columns[i].DataType);
                                            }
                                        }
                                    }
                                    // --- ADD 2020/06/18 ���X�ؘj ----------<<<<<
                                }
                            }
                            else if (i > 7) // �f�[�^�Ȃ����w�b�_�łȂ��ꍇ
                            {
                                //if (tableID == "GOODSMNGRF" && i == 11) // ���i�Ǘ����}�X�^�e�[�u���̏��i�ԍ��i��O�����j
                                ExcptTblCol.ColNo = i;
                                if (lstSpaceExcptTblCol.Contains(ExcptTblCol))
                                {
                                    row[i] = string.Empty; // �L�[�Ȃ̂�NULL�s�̍��ڂ̂��߁A��O�I�ɋ󔒐ݒ�
                                }
                                else if (lstSpaceZeroExcptTblCol.Contains(ExcptTblCol))
                                {
                                    row[i] = 0; // NULL�s�������J�����̂��߁A��O�I��0�ݒ�
                                }
                                // 2009/10/05 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
                                //else if (tableID == "ACCEPTODRCARRF" &&
                                else if ((tableID == "ACCEPTODRCARRF" || tableID == "CARMANAGEMENTRF") &&
                                    // 2009/10/05 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                    dt.Columns[i].DataType.Name == "Byte[]") // �󒍃}�X�^�i�ԗ��j�̃o�C�i���z��Ή�
                                {
                                    // 2010/09/16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
                                    //row[i] = new byte[0];
                                    if (dt.Columns[i].ColumnName == "FREESRCHMDLFXDNOARYRF")
                                    {
                                        // ���R�����^���Œ�ԍ��z��̃o�C�i���z��Ή�
                                        row[i] = DBNull.Value;
                                    }
                                    else
                                    {
                                        row[i] = new byte[0];
                                    }
                                    // 2010/09/16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                }
                                else
                                {
                                    row[i] = DBNull.Value;
                                }
                            }
                        }
                        // -- add wangf 2011/08/12 ---------->>>>>
                        if ("SALESDETAILRF".Equals(tableID))
                        {
                            if (tmpAcceptAnOrderNo < 0)
                            {
                                int standardAcceptAnOrderNo = 0;
                                // �ԍ��Ǘ��ݒ�ǂݍ���
                                int statusNoMng = this._acceptOdr.GetAcceptAnOrderNo(_enterpriseCode, tmpSectionCode.PadLeft(2, '0'), out standardAcceptAnOrderNo);
                                if (statusNoMng == 0)
                                {
                                    // XML�̓ǂݍ���
                                    row[columnIndex] = standardAcceptAnOrderNo;
                                    if (!this._acceptAnOrderNoHashTable.Contains(tmpAcceptAnOrderNo))
                                    {
                                        this._acceptAnOrderNoHashTable.Add(tmpAcceptAnOrderNo, standardAcceptAnOrderNo);
                                    }
                                    else
                                    {
                                        this._acceptAnOrderNoHashTable.Remove(tmpAcceptAnOrderNo);
                                        this._acceptAnOrderNoHashTable.Add(tmpAcceptAnOrderNo, standardAcceptAnOrderNo);
                                    }
                                }
                                // ----- DEL tianjw 2011/09/03 --------------------------->>>>>
                                //// �d�����׃f�[�^�X�V
                                //ArrayList stockDetailWorks = new ArrayList();
                                //ArrayList parastockDetailWorks = new ArrayList();
                                //StockDetailWork paraDtlWork = new StockDetailWork();
                                //paraDtlWork.EnterpriseCode = this._enterpriseCode;
                                //// �d���`��
                                //paraDtlWork.SupplierFormal = tmpSupplierFormalSync;
                                //// �d�����גʔ�
                                //paraDtlWork.StockSlipDtlNum = (int)tmpStockSlipDtlNumSync;
                                //parastockDetailWorks.Add(paraDtlWork);
                                //int statusStockDetailWork = this._stockSlipDB.ReadStockDetailWork(out stockDetailWorks, parastockDetailWorks, ref sqlConnection, ref sqlTransaction);
                                //if (statusStockDetailWork == 0)
                                //{
                                //    StockDetailWork tmpStockDetailWork = (StockDetailWork)stockDetailWorks[0];
                                //    tmpStockDetailWork.AcceptAnOrderNo = standardAcceptAnOrderNo;
                                //    tmpStockDetailWork.EnterpriseCode = this._enterpriseCode;
                                //    tmpStockDetailWork.SupplierFormal = tmpSupplierFormalSync;
                                //    tmpStockDetailWork.StockSlipDtlNum = (int)tmpStockSlipDtlNumSync;
                                //    this._stockSlipDB.UpdateConvertStockDetailWork(ref tmpStockDetailWork, ref sqlConnection, ref sqlTransaction);
                                //}
                                // ----- DEL tianjw 2011/09/03 ---------------------------<<<<<
                            }
                        }
                        // -- add wangf 2011/08/12 ----------<<<<<
                        // ----- ADD tianjw 2011/09/03 ----------------------------->>>>>
                        if ("SALESHISTDTLRF".Equals(tableID))
                        {
                            if (tmpHisDtlAcceptAnOrderNo < 0)
                            {
                                int standardAcceptAnOrderNo = 0;
                                int statusNoMng = 0;
                                if (!this._acceptAnOrderNoHashTable.Contains(tmpHisDtlAcceptAnOrderNo))
                                {
                                    // �ԍ��Ǘ��ݒ�ǂݍ���
                                    statusNoMng = this._acceptOdr.GetAcceptAnOrderNo(_enterpriseCode, tmpSectionCode.PadLeft(2, '0'), out standardAcceptAnOrderNo);

                                    if (statusNoMng == 0)
                                    {
                                        // XML�̓ǂݍ���
                                        row[columnIndex] = standardAcceptAnOrderNo;
                                        if (!this._hisDtlAcceptAnOrderNoHashTable.Contains(tmpHisDtlAcceptAnOrderNo))
                                        {
                                            this._hisDtlAcceptAnOrderNoHashTable.Add(tmpHisDtlAcceptAnOrderNo, standardAcceptAnOrderNo);
                                        }
                                        else
                                        {
                                            this._hisDtlAcceptAnOrderNoHashTable.Remove(tmpHisDtlAcceptAnOrderNo);
                                            this._hisDtlAcceptAnOrderNoHashTable.Add(tmpHisDtlAcceptAnOrderNo, standardAcceptAnOrderNo);
                                        }
                                    }
                                }
                                else
                                {
                                    row[columnIndex] = this._acceptAnOrderNoHashTable[tmpHisDtlAcceptAnOrderNo];
                                }
                            }
                        }
                        // ----- ADD tianjw 2011/09/03 -----------------------------<<<<<

                        DataRow addedRow = dt.Rows.Add(row);
                        if (stopFlg)
                        {
                            return DoCancel(result, errList);
                        }
                    }
                    catch (Exception ex) // �f�[�^�^�C�v�~�X�}�b�`�@���� ���ɓ����L�[�����f�[�^��DB�ɑ��݂���ꍇ�@�Ȃ�
                    {
                        if (listChkExcpt.Contains(tableID) // �d����O�e�[�u����
                                && ex is ConstraintException)
                        {
                            exceptionCnt++;
                        }

                        result.FailedRowCnt++;
                        ErrorReportWork err = new ErrorReportWork();
                        err.ProcessingData = str;

                        if (ex is ConstraintException || ex is NoNullAllowedException || ex is ArgumentException
                            || ex is FormatException || ex.Source == "PMKHN08003R")
                            err.ErrMsg = ex.Message;
                        else
                            // 2012/02/15 >>>
                            //err.ErrMsg = "�������G���[���������܂����B";
                            err.ErrMsg = ex.Message + " : �������G���[���������܂����B";
                            // 2012/02/15 <<<

                        errList.Add(err);
                    }
                }
                if (errList.Count == 0 || (listChkExcpt.Contains(tableID) && errList.Count == exceptionCnt))
                {
                    // -- ADD 2011/09/29 ----------------------------->>>
                    // �ǉ����̃^�C���A�E�g���Ԃ���������B
                    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                    da.InsertCommand = cmdBuilder.GetInsertCommand();
                    da.InsertCommand.CommandTimeout = 3600;
                    // -- ADD 2011/09/29 -----------------------------<<<

                    result.UpdateCnt = da.Update(dt);
                    transactionFlg = true;
                    if (result.UpdateCnt == list.Count || (listChkExcpt.Contains(tableID) && result.UpdateCnt + exceptionCnt == list.Count))
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        if (listChkExcpt.Contains(tableID) && exceptionCnt > 0)
                            result.ErrMsg = "DB�X�V���ꕔ�s�̍X�V�Ɏ��s���܂����BDB���O���Q�Ƃ��ĉ������B";
                    }
                    else
                    {
                        result.ErrMsg = "DB�X�V���ꕔ�s�̍X�V�Ɏ��s���܂����BDB���O���Q�Ƃ��ĉ������B";
                        result.FailedRowCnt = list.Count - result.UpdateCnt;
                    }
                    //if (result.UpdateCnt == 100000) // 10�������Ƃ̕��������̏ꍇ���̓s�x�R�~�b�g����B
                    //{
                    //    EndTransaction(true);
                    //}
                }
                else // �f�[�^�e�[�u���쐬���̃G���[
                {
                    result.UpdateCnt = 0;
                    result.FailedRowCnt = list.Count;
                    result.ErrMsg = "�f�[�^�ُ�ł��BConvertErrorLog�t�H���_�ɂ���G���[���O���Q�Ƃ��ĉ������B";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, " ");
                // FOR TEST
                //result.ErrMsg = ex.Message;
                // 2012/02/15 >>>
                //result.ErrMsg = "�������G���[���������܂����B";
                result.ErrMsg = ex.Message + " : �������G���[���������܂����B";
                // 2012/02/15 <<<

                WriteLog(_enterpriseCode, "SetDataSet", ex.Message, status);  // ADD 2011/09/06
            }
            finally
            {
                dt.Rows.Clear();
                dt.Dispose();
                // --- ADD 2020/06/18 ���X�ؘj ---------->>>>>
                // ���
                if (convertDoubleRelease != null)
                {
                    convertDoubleRelease.Dispose();
                }
                // --- ADD 2020/06/18 ���X�ؘj ----------<<<<<
                GC.Collect();
                //da.Dispose();
            }

            // --- ADD 2011/09/06---------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                WriteLog(_enterpriseCode, "SetDataSet", "�R���o�[�g�f�[�^��PM.NS�̃��[�U�[DB�ɓW�J", status);
            }
            // --- ADD 2011/09/06----------<<<<<

            return status;
        }

        /// <summary>
        /// ����ɃC���X�^���X�������錸����h������
        /// </summary>
        /// <returns></returns>
        public override object InitializeLifetimeService()
        {
            ILease lease = (ILease)base.InitializeLifetimeService();
            if (lease.CurrentState == LeaseState.Initial)
            {
                //lease.InitialLeaseTime = TimeSpan.FromMinutes(10);
                lease.InitialLeaseTime = TimeSpan.FromHours(10);
                lease.SponsorshipTimeout = TimeSpan.FromMinutes(20);
                lease.RenewOnCallTime = TimeSpan.FromMinutes(60);
            }
            return lease;
        }

        /// <summary>
        /// �L�����Z������
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errList"></param>
        /// <returns></returns>
        private int DoCancel(ConvertResultWork result, CustomSerializeArrayList errList)
        {
            stopFlg = false;
            result.ErrMsg = "�����͒��~����܂����B";
            if (errList.Count > 0)
            {
                result.ErrMsg += "�G���[���O���m�F���ĉ������B";
            }
            return (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
        }

        private static string[] SplitString(string src, int cnt)
        {
            char[] pat = new char[] { ',' };
            string[] ret = src.Split(pat);
            // 2009/11/09 Add >>>
            // ���ڐ��m�F�p
            int retCount = 0;
            int delCount = 0;
            string[] newret = new string[ret.Length];
            // 2009/11/09 Add <<<
            if (ret.Length < cnt)
            {
                string msg = string.Format("���ڂ�{0}����܂���BCSV�t�@�C����������x�m�F���肢���܂��B", cnt - ret.Length);
                throw new Exception(msg);
            }
            // 2009/11/09 >>>
            //else if (ret.Length > cnt)
            else
            // 2009/11/09 <<<
            {
                for (int i = 0; i < ret.Length; i++)
                {
                    if (ret[i].EndsWith("\"") == false)
                    {
                        if (ret[i].StartsWith("\""))
                        {
                            ret[i] = ret[i] + "," + ret[i + 1];
                            Array.Copy(ret, i + 2, ret, i + 1, ret.Length - i - 2);
                            // 2009/11/09 Add >>>
                            // �R���}�Ή����͎��̗v�f�ֈړ����Ȃ��悤�ɂ���
                            i--;
                            delCount++;
                            // 2009/11/09 Add <<<
                        }
                        // 2010/03/16 Add >>>
                        else if ((ret[i].StartsWith("\"�"))  || (ret[i].StartsWith("\"�"))  ||
                                 (ret[i].StartsWith("\"��")) || (ret[i].StartsWith("\"��")) ||
                                 (ret[i].StartsWith("\"��")) || (ret[i].StartsWith("\"��")))
                        {
                            ret[i] = ret[i] + "," + ret[i + 1];
                            Array.Copy(ret, i + 2, ret, i + 1, ret.Length - i - 2);
                            // �R���}�Ή����͎��̗v�f�ֈړ����Ȃ��悤�ɂ���
                            i--;
                            delCount++;
                        }
                        // 2010/03/16 Add <<<
                        // 2009/11/09 Del >>>
                        //else
                        //{
                        //    ret[i - 1] = ret[i - 1] + "," + ret[i];
                        //    if (i < ret.Length - 1)
                        //    {
                        //        Array.Copy(ret, i + 1, ret, i, ret.Length - i - 1);
                        //        i--;
                        //    }
                        //}
                        // 2009/11/09 Del <<<
                    }
                    else
                    {
                        // 2009/11/09 Del >>>
                        //if (ret[i].Length < 2 || ret[i].StartsWith("\"") == false)
                        //{
                        //    ret[i - 1] = ret[i - 1] + "," + ret[i];
                        //    if (i < ret.Length - 1)
                        //    {
                        //        Array.Copy(ret, i + 1, ret, i, ret.Length - i - 1);
                        //        i--;
                        //    }
                        //}
                        // 2009/11/09 Del <<<
                        // 2009/11/09 Add >>>
                        if (ret[i].Length < 2)
                        {
                            if (i < ret.Length - 1)
                            {
                                ret[i] = ret[i] + "," + ret[i + 1];
                                Array.Copy(ret, i + 2, ret, i + 1, ret.Length - i - 2);
                                i--;
                                delCount++;
                            }
                        }
                        else
                        {
                            // �t�B�[���h����","������ꍇ�̑Ή�
                            int count = 0;
                            for (int j = 0; ret[i].Length > j; j++)
                            {
                                j = ret[i].IndexOf("\"", j);
                                count++;
                            }
                            // 2010/03/16 Add >>>
                            if ((ret[i].StartsWith("\"�"))  || (ret[i].StartsWith("\"�"))  ||
                                (ret[i].StartsWith("\"��")) || (ret[i].StartsWith("\"��")) ||
                                (ret[i].StartsWith("\"��")) || (ret[i].StartsWith("\"��")))
                            {
                                count++;
                            }
                            // 2010/03/16 Add <<<
                            if (count % 2 == 1)
                            {
                                if (i < ret.Length - delCount)
                                {
                                    ret[i] = ret[i] + "," + ret[i + 1];
                                    Array.Copy(ret, i + 2, ret, i + 1, ret.Length - i - 2);
                                    i--;
                                    delCount++;
                                }
                            }
                            else
                            {
                                if (retCount + delCount < ret.Length)
                                {
                                    newret[retCount] = ret[retCount];
                                    retCount++;
                                }
                            }
                        }
                        // 2009/11/09 Add <<<
                    }
                }
            }

            // 2009/11/09 Add >>>
            // ��͌�ēx���ڐ��`�F�b�N
            if (retCount < cnt)
            {
                string msg = string.Format("���ڂ�{0}����܂���BCSV�t�@�C����������x�m�F���肢���܂��B", cnt - retCount);
                throw new Exception(msg);
            }
            else if (retCount > cnt)
            {
                string msg = string.Format("���ڂ�{0}�����ł��BCSV�t�@�C����������x�m�F���肢���܂��B", retCount - cnt);
                throw new Exception(msg);
            }
            // 2009/11/09 Add <<<

            // 2009/11/09 >>>
            return ret;
            //return newret;
            // 2009/11/09 <<<
        }

        private void GetFileHeaderInfo()
        {
            if (string.IsNullOrEmpty(_enterpriseCode))
            {
                ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
                _enterpriseCode = acquisition.EnterpriseCode;
                // 2009/02/24 MANTIS 11844>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //���O�C���]�ƈ���񂪎擾�o���Ȃ����̏C��
                //_updEmployeeCode = string.Format("{0:0000}", Convert.ToInt32(acquisition.EmployeeCode));
                if (CheckValueNum(acquisition.EmployeeCode))
                {
                    _updEmployeeCode = string.Format("{0:0000}", Convert.ToInt32(acquisition.EmployeeCode));
                }
                else
                {
                    //support�ŃR���o�[�g���s�����ߏC��
                    _updEmployeeCode = acquisition.EmployeeCode;
                }
                // 2009/02/24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                _updAssemblyId1 = acquisition.ClientUpateAssemblyId;
                _updAssemblyId2 = "PMConvert";
            }
        }

        /// <summary>
        /// �������~
        /// </summary>        
        /// <returns></returns>
        public int StopProcess()
        {
            return StopProcessProc();
        }

        private int StopProcessProc()
        {
            if (onProcess == false) // �������łȂ��ꍇ(�L�����Z�����N�G�X�g������r���������I�����邱�Ƃ�����̂�)
                return 1; // �߂�l1�͏����L�����Z���������������I�������Ƃ̂��ƁB
            stopFlg = true;
            int cnt = 0;
            do
            {
                System.Threading.Thread.Sleep(50);
                cnt++;
                if (cnt > 30) // ��莞�ԑ҂��ĂĂ�true�ɂȂ�Ȃ��Ǝ��s�ƌ��Ȃ��B
                {
                    stopFlg = false;
                    return -1;
                }
            } while (stopFlg);
            return 0;
        }
        #endregion

        #region [ �󕥗����f�[�^�ݒ菈�� ]
        /// <summary>
        /// �݌Ɏ󕥐ݒ菈��
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="lstSource">�݌Ɏ󕥐ݒ�̌��f�[�^[0:����/1:���㗚��/2:�d��/3:�d������/4:�݌Ɉړ�/5:�݌ɒ���]</param>
        /// <param name="resultCnt">�����f�[�^����</param>
        /// <returns></returns>
        public int SetStockAcPayHist(string enterpriseCode, List<int> lstSource, out int resultCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            _enterpriseCode = enterpriseCode;
            resultCnt = 0;
            int cnt = 0;
            foreach (int source in lstSource)
            {
                switch (source)
                {
                    case -1: // �e�[�u���N���A
                        status = SetStockAcPayHistClear();
                        break;
                    case 0: // ����
                        status = SetStockAcPayHistFromSales(out cnt);
                        break;
                    case 1: // ���㗚��
                        status = SetStockAcPayHistFromSalesHist(out cnt);
                        break;
                    case 2: // �d��
                        status = SetStockAcPayHistFromStockSlip(out cnt);
                        break;
                    case 3: // �d������
                        status = SetStockAcPayHistFromStockSlipHist(out cnt);
                        break;
                    // 2009/03/23 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //case 4: // �݌Ɉړ�
                    //    status = SetStockAcPayHistFromStockMove(out cnt);
                    //    break;
                    case 4:
                    case 6:
                        {
                            if (source == 4)
                                //���ׁA�o�׎󕥍쐬
                                status = SetStockAcPayHistFromStockMove(out cnt, 0);
                            else
                                //���ׂ̂ݎ󕥍쐬
                                status = SetStockAcPayHistFromStockMove(out cnt, 1);

                        }
                        break;
                    // 2009/03/23 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    case 5: // �݌ɒ���
                        status = SetStockAcPayHistFromStockAdjust(out cnt);
                        break;
                }
                if (status == 0)
                {
                    resultCnt += cnt;
                }
                else
                {
                    resultCnt = 0;
                    break;
                }
            }
            return status;
        }

        /// <summary>
        /// �݌Ɏ󕥗����f�[�^�N���A
        /// </summary>
        private int SetStockAcPayHistClear()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;// ADD�@2019/10/22 �c���� SQLSERVER2017�Ή�
            try
            {
                sqlCommand = new SqlCommand();// ADD�@2019/10/22 �c���� SQLSERVER2017�Ή�

                //sqlCommand.CommandText = string.Format("DELETE FROM STOCKACPAYHISTRF WHERE ENTERPRISECODERF = '{0}'", _enterpriseCode);
                // --- UPD�@2019/10/22 �c���� SQLSERVER2017�Ή�---------->>>>
                //serv.Databases[sqlConnection.Database].ExecuteNonQuery("TRUNCATE TABLE STOCKACPAYHISTRF ");
                sqlCommand.CommandText = string.Format("TRUNCATE TABLE STOCKACPAYHISTRF");
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.ExecuteNonQuery();
                //serv.Databases[sqlConnection.Database].ExecuteNonQuery("TRUNCATE TABLE STOCKACPAYHISTRF "); // DEL Lizc 2013/07/01 Redmine#36971
                //this.ExecuteSql(serv, sqlConnection.Database, "TRUNCATE TABLE STOCKACPAYHISTRF ");  // ADD Lizc 2013/07/01 Redmine#36971
                // --- UPD�@2019/10/22 �c���� SQLSERVER2017�Ή�----------<<<<
                status = 0;
            }
            // --- UPD 2011/09/06---------->>>>>
            //catch
            //{
            //    return -1;
            //}
            catch (SqlException ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistClear", "�݌Ɏ󕥗����f�[�^�N���A[" +ex.Message + "]", ex.Number);
            }
            catch (Exception ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistClear", "�݌Ɏ󕥗����f�[�^�N���A[" + ex.Message + "]", status);
            }
            // --- UPD 2011/09/06----------<<<<<
            finally
            {
                // --- ADD�@2019/10/22 �c���� SQLSERVER2017�Ή�---------->>>>
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                // --- ADD�@2019/10/22 �c���� SQLSERVER2017�Ή�---------->>>>
            }

            // --- ADD 2011/09/06---------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistClear", "�݌Ɏ󕥗����f�[�^�N���A", status);
            }
            // --- ADD 2011/09/06----------<<<<<

            return status;
        }

        /// <summary>
        /// ���ォ��݌Ɏ󕥗����f�[�^�ݒ�(�ݏo)
        /// </summary>
        /// <param name="cnt">�����f�[�^�J�E���^</param>
        private int SetStockAcPayHistFromSales(out int cnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            cnt = 0;
            if (lstSec == null)
                GetSectionInfo();

            #region [ ���ォ��݌Ɏ󕥏��擾 ]
            SqlConnection sqlCon = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            try
            {
                sqlCon = new SqlConnection(connectionText);
                sqlCon.Open();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlCon;

                #region [ ����f�[�^�擾�N�G�� ]
                string sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "SLIP.LOGICALDELETECODERF," + Environment.NewLine;   // 2010/10/13 Add
                sqlText += "SLIP.SALESINPSECCDRF," + Environment.NewLine;
                sqlText += "SLIP.SALESDATERF," + Environment.NewLine;
                sqlText += "SLIP.ADDUPADATERF," + Environment.NewLine;
                sqlText += "SLIP.SHIPMENTDAYRF," + Environment.NewLine; // 2009/03/27 MANTIS 12822
                sqlText += "SLIP.INPUTAGENCDRF," + Environment.NewLine;
                sqlText += "SLIP.INPUTAGENNMRF," + Environment.NewLine;
                sqlText += "SLIP.CUSTOMERCODERF," + Environment.NewLine;
                sqlText += "SLIP.CUSTOMERSNMRF," + Environment.NewLine;
                sqlText += "SLIP.CUSTSLIPNORF," + Environment.NewLine;
                sqlText += "DTIL.SALESSLIPNUMRF," + Environment.NewLine;
                sqlText += "DTIL.SALESROWNORF," + Environment.NewLine;
                sqlText += "DTIL.SECTIONCODERF," + Environment.NewLine;
                sqlText += "DTIL.SALESSLIPDTLNUMRF," + Environment.NewLine;
                sqlText += "DTIL.SALESSLIPCDDTLRF," + Environment.NewLine;
                sqlText += "DTIL.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "DTIL.MAKERNAMERF," + Environment.NewLine;
                sqlText += "DTIL.GOODSNORF," + Environment.NewLine;
                sqlText += "DTIL.GOODSNAMERF," + Environment.NewLine;
                sqlText += "DTIL.BLGOODSCODERF," + Environment.NewLine;
                sqlText += "DTIL.BLGOODSFULLNAMERF," + Environment.NewLine;
                sqlText += "DTIL.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "DTIL.WAREHOUSENAMERF," + Environment.NewLine;
                sqlText += "DTIL.WAREHOUSESHELFNORF," + Environment.NewLine;
                sqlText += "DTIL.LISTPRICETAXEXCFLRF," + Environment.NewLine;
                sqlText += "DTIL.SALESUNPRCTAXEXCFLRF," + Environment.NewLine;
                sqlText += "DTIL.SALESUNITCOSTRF," + Environment.NewLine;
                sqlText += "DTIL.SHIPMENTCNTRF," + Environment.NewLine;
                sqlText += "DTIL.SALESMONEYTAXEXCRF," + Environment.NewLine;
                sqlText += "DTIL.COSTRF," + Environment.NewLine;
                sqlText += "DTIL.SALESSLIPCDDTLRF," + Environment.NewLine;
                // 2010/10/20 >>>
                //sqlText += "DTIL.SALESORDERDIVCDRF" + Environment.NewLine;
                sqlText += "DTIL.SALESORDERDIVCDRF," + Environment.NewLine;
                // 2010/10/20 <<<
                // 2010/10/21 >>>
                //sqlText += "DTIL.ACPTANODRREMAINCNTRF" + Environment.NewLine;  // 2010/10/20 Add
                sqlText += "DTIL.ACPTANODRREMAINCNTRF," + Environment.NewLine;
                // 2010/10/21 <<<
                // 2010/10/21 Add >>>
                sqlText += "DTL2.SHIPMENTCNTRF AS SHIPMENTCNTRF2," + Environment.NewLine;
                sqlText += "DTL2.SALESSLIPCDDTLRF AS SALESSLIPCDDTLRF2," + Environment.NewLine;
                sqlText += "SLP2.ADDUPADATERF AS ADDUPADATERF2" + Environment.NewLine;
                // 2010/10/21 Add <<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SALESSLIPRF AS SLIP" + Environment.NewLine;
                sqlText += "  INNER JOIN SALESDETAILRF AS DTIL" + Environment.NewLine;
                sqlText += "ON SLIP.ACPTANODRSTATUSRF = DTIL.ACPTANODRSTATUSRF AND  SLIP.SALESSLIPNUMRF = DTIL.SALESSLIPNUMRF" + Environment.NewLine;
                // 2010/10/21 Add >>>
                sqlText += "  LEFT JOIN SALESDETAILRF AS DTL2" + Environment.NewLine;
                sqlText += "  ON DTIL.SALESSLIPDTLNUMRF=DTL2.SALESSLIPDTLNUMSRCRF" + Environment.NewLine;
                sqlText += "  AND SLIP.ACPTANODRSTATUSRF=DTL2.ACPTANODRSTATUSSRCRF" + Environment.NewLine;
                sqlText += "  LEFT JOIN SALESSLIPRF AS SLP2" + Environment.NewLine;
                sqlText += "  ON SLP2.ACPTANODRSTATUSRF = DTL2.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += "  AND  SLP2.SALESSLIPNUMRF = DTL2.SALESSLIPNUMRF" + Environment.NewLine;
                // 2010/10/21 Add <<<
                sqlText += "WHERE SLIP.ACPTANODRSTATUSRF = 40";
                #endregion
                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandTimeout = 300;// 2010/10/12 Add

                ArrayList innerList = null;
                DateTime prevDateTime = DateTime.MaxValue;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StockAcPayHistWork stockAcPayHistWork = new StockAcPayHistWork();
                    StockAcPayHistWork stockAcPayHistDeleteWork = null;

                    stockAcPayHistWork.LogicalDeleteCode = 0;
                    // 2009/03/27 MANTIS 12822 >>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //stockAcPayHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                    //stockAcPayHistWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    //stockAcPayHistWork.AcPaySlipCd = 20; // 20:����Œ�

                    stockAcPayHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
                    stockAcPayHistWork.AcPaySlipCd = 22; // 22:�o��
                    // 2009/03/27 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    stockAcPayHistWork.AcPaySlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    stockAcPayHistWork.AcPaySlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                    int kubun = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                    if (kubun == 0)
                        stockAcPayHistWork.AcPayTransCd = 10; // 0:����	 -> 10:�ʏ�`�[
                    else if (kubun == 1)
                        stockAcPayHistWork.AcPayTransCd = 11; // 1:�ԕi	 -> 11:�ԕi

                    stockAcPayHistWork.InputSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPSECCDRF"));
                    if (lstSec.ContainsKey(stockAcPayHistWork.InputSectionCd))
                    {
                        stockAcPayHistWork.InputSectionGuidNm = lstSec[stockAcPayHistWork.InputSectionCd].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.InputSectionGuidNm = "";
                    }
                    stockAcPayHistWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));
                    stockAcPayHistWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));
                    stockAcPayHistWork.MoveStatus = 0; // 0:�ړ��ΏۊO
                    stockAcPayHistWork.CustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNORF")).ToString();
                    stockAcPayHistWork.SlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
                    stockAcPayHistWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockAcPayHistWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    stockAcPayHistWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockAcPayHistWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    stockAcPayHistWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    stockAcPayHistWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    stockAcPayHistWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    if (lstSec.ContainsKey(stockAcPayHistWork.SectionCode))
                    {
                        stockAcPayHistWork.SectionGuideNm = lstSec[stockAcPayHistWork.SectionCode].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.SectionGuideNm = "";
                    }
                    stockAcPayHistWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockAcPayHistWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    stockAcPayHistWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    stockAcPayHistWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    stockAcPayHistWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    stockAcPayHistWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    stockAcPayHistWork.OpenPriceDiv = 0; // 0:�ʏ�
                    stockAcPayHistWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    stockAcPayHistWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    stockAcPayHistWork.StockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
                    stockAcPayHistWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                    stockAcPayHistWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));

                    // �݌ɊǗ��������
                    // �@ �q�ɃR�[�h���ݒ肳��Ă���
                    // �A ����݌Ɏ�񂹋敪�� 1:�݌�
                    // �B �o�א���0�ȊO
                    // �C ����`�[�敪(����)�� 0:���� 1:�ԕi �̏ꍇ
                    // 2010/10/08 Add >>>
                    // �D �i�Ԃ��Z�b�g����Ă���
                    // 2010/10/08 Add <<<
                    int slipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                    int orderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                    string goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  // 2010/10/08 Add
                    // 2010/10/08 >>>
                    //if (string.IsNullOrEmpty(stockAcPayHistWork.WarehouseCode) ||
                    //    orderDivCd != 1 ||
                    //    stockAcPayHistWork.ShipmentCnt == 0 ||
                    //    (slipCdDtl != 0 && slipCdDtl != 1))
                    //    continue;
                    if (string.IsNullOrEmpty(stockAcPayHistWork.WarehouseCode) ||
                        orderDivCd != 1 ||
                        stockAcPayHistWork.ShipmentCnt == 0 ||
                        (slipCdDtl != 0 && slipCdDtl != 1) ||
                        string.IsNullOrEmpty(goodsNo))
                        continue;
                    // 2010/10/08 <<<

                    // 2010/10/13 Add >>>
                    int logicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    double acptAnOdrRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));    // 2010/10/20 Add
                    // 2010/10/20 >>>
                    // �ݏo���Ŏ󒍎c����0�̏ꍇ�͏o�׃f�[�^�v��c�敪���w�c���Ȃ��x�ō쐬���ꂽ�f�[�^�̈׃R���o�[�g�ΏۊO
                    //if (logicalDeleteCode == 1)
                    // 2010/10/21 >>>
                    //if (logicalDeleteCode == 1 && acptAnOdrRemainCnt != 0.0)
                    if (logicalDeleteCode == 1)
                    // 2010/10/21 <<<
                    // 2010/10/20 <<<
                    {
                        // 2010/10/21 Add >>>
                        if (acptAnOdrRemainCnt != 0.0)
                        {
                            // 2010/10/21 Add <<<
                            stockAcPayHistDeleteWork = new StockAcPayHistWork();
                            stockAcPayHistDeleteWork.LogicalDeleteCode = 0;

                            stockAcPayHistDeleteWork.IoGoodsDay = stockAcPayHistWork.IoGoodsDay;
                            stockAcPayHistDeleteWork.AcPaySlipCd = 22; // 22:�o��
                            stockAcPayHistDeleteWork.AcPaySlipNum = stockAcPayHistWork.AcPaySlipNum;
                            stockAcPayHistDeleteWork.AcPaySlipRowNo = stockAcPayHistWork.AcPaySlipRowNo;
                            stockAcPayHistDeleteWork.AcPayTransCd = 21; // 21:�폜
                            stockAcPayHistDeleteWork.InputSectionCd = stockAcPayHistWork.InputSectionCd;
                            stockAcPayHistDeleteWork.InputSectionGuidNm = stockAcPayHistWork.InputSectionGuidNm;
                            stockAcPayHistDeleteWork.InputAgenCd = stockAcPayHistWork.InputAgenCd;
                            stockAcPayHistDeleteWork.InputAgenNm = stockAcPayHistWork.InputAgenNm;
                            stockAcPayHistDeleteWork.MoveStatus = 0; // 0:�ړ��ΏۊO
                            stockAcPayHistDeleteWork.CustSlipNo = stockAcPayHistWork.CustSlipNo;
                            stockAcPayHistDeleteWork.SlipDtlNum = stockAcPayHistWork.SlipDtlNum;
                            stockAcPayHistDeleteWork.GoodsMakerCd = stockAcPayHistWork.GoodsMakerCd;
                            stockAcPayHistDeleteWork.MakerName = stockAcPayHistWork.MakerName;
                            stockAcPayHistDeleteWork.GoodsNo = stockAcPayHistWork.GoodsNo;
                            stockAcPayHistDeleteWork.GoodsName = stockAcPayHistWork.GoodsName;
                            stockAcPayHistDeleteWork.BLGoodsCode = stockAcPayHistWork.BLGoodsCode;
                            stockAcPayHistDeleteWork.BLGoodsFullName = stockAcPayHistWork.BLGoodsFullName;
                            stockAcPayHistDeleteWork.SectionCode = stockAcPayHistWork.SectionCode;
                            stockAcPayHistDeleteWork.SectionGuideNm = stockAcPayHistWork.SectionGuideNm;
                            stockAcPayHistDeleteWork.WarehouseCode = stockAcPayHistWork.WarehouseCode;
                            stockAcPayHistDeleteWork.WarehouseName = stockAcPayHistWork.WarehouseName;
                            stockAcPayHistDeleteWork.ShelfNo = stockAcPayHistWork.ShelfNo;
                            stockAcPayHistDeleteWork.CustomerCode = stockAcPayHistWork.CustomerCode;
                            stockAcPayHistDeleteWork.CustomerSnm = stockAcPayHistWork.CustomerSnm;
                            stockAcPayHistDeleteWork.ShipmentCnt = -stockAcPayHistWork.ShipmentCnt;
                            stockAcPayHistDeleteWork.OpenPriceDiv = 0; // 0:�ʏ�
                            stockAcPayHistDeleteWork.ListPriceTaxExcFl = stockAcPayHistWork.ListPriceTaxExcFl;
                            stockAcPayHistDeleteWork.StockUnitPriceFl = stockAcPayHistWork.StockUnitPriceFl;
                            stockAcPayHistDeleteWork.StockPrice = -stockAcPayHistWork.StockPrice;
                            stockAcPayHistDeleteWork.SalesUnPrcTaxExcFl = stockAcPayHistWork.SalesUnPrcTaxExcFl;
                            stockAcPayHistDeleteWork.SalesMoney = -stockAcPayHistWork.SalesMoney;
                            // 2010/10/21 Add >>>
                        }
                        else
                        {
                            // ���v��c���Ȃ��ō쐬���ꂽ�f�[�^�ׁ̈A�ݏo�ԕi�f�[�^���쐬����
                            int salesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF2"));
                            if (salesSlipCdDtl == 0)
                            {
                                // �������v���̔���f�[�^�̔���`�[�敪�i���ׁj������̎��̂ݍ쐬
                                stockAcPayHistDeleteWork = new StockAcPayHistWork();
                                stockAcPayHistDeleteWork.LogicalDeleteCode = 0;

                                stockAcPayHistDeleteWork.IoGoodsDay = stockAcPayHistWork.IoGoodsDay;
                                stockAcPayHistDeleteWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF2"));
                                stockAcPayHistDeleteWork.AcPaySlipCd = 22; // 22:�o��
                                stockAcPayHistDeleteWork.AcPaySlipNum = stockAcPayHistWork.AcPaySlipNum;
                                stockAcPayHistDeleteWork.AcPaySlipRowNo = stockAcPayHistWork.AcPaySlipRowNo;
                                stockAcPayHistDeleteWork.AcPayTransCd = 11; // 11:�ԕi
                                stockAcPayHistDeleteWork.InputSectionCd = stockAcPayHistWork.InputSectionCd;
                                stockAcPayHistDeleteWork.InputSectionGuidNm = stockAcPayHistWork.InputSectionGuidNm;
                                stockAcPayHistDeleteWork.InputAgenCd = stockAcPayHistWork.InputAgenCd;
                                stockAcPayHistDeleteWork.InputAgenNm = stockAcPayHistWork.InputAgenNm;
                                stockAcPayHistDeleteWork.MoveStatus = 0; // 0:�ړ��ΏۊO
                                stockAcPayHistDeleteWork.CustSlipNo = stockAcPayHistWork.CustSlipNo;
                                stockAcPayHistDeleteWork.SlipDtlNum = stockAcPayHistWork.SlipDtlNum;
                                stockAcPayHistDeleteWork.GoodsMakerCd = stockAcPayHistWork.GoodsMakerCd;
                                stockAcPayHistDeleteWork.MakerName = stockAcPayHistWork.MakerName;
                                stockAcPayHistDeleteWork.GoodsNo = stockAcPayHistWork.GoodsNo;
                                stockAcPayHistDeleteWork.GoodsName = stockAcPayHistWork.GoodsName;
                                stockAcPayHistDeleteWork.BLGoodsCode = stockAcPayHistWork.BLGoodsCode;
                                stockAcPayHistDeleteWork.BLGoodsFullName = stockAcPayHistWork.BLGoodsFullName;
                                stockAcPayHistDeleteWork.SectionCode = stockAcPayHistWork.SectionCode;
                                stockAcPayHistDeleteWork.SectionGuideNm = stockAcPayHistWork.SectionGuideNm;
                                stockAcPayHistDeleteWork.WarehouseCode = stockAcPayHistWork.WarehouseCode;
                                stockAcPayHistDeleteWork.WarehouseName = stockAcPayHistWork.WarehouseName;
                                stockAcPayHistDeleteWork.ShelfNo = stockAcPayHistWork.ShelfNo;
                                stockAcPayHistDeleteWork.CustomerCode = stockAcPayHistWork.CustomerCode;
                                stockAcPayHistDeleteWork.CustomerSnm = stockAcPayHistWork.CustomerSnm;
                                double ShipmentCnt2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF2"));
                                stockAcPayHistDeleteWork.ShipmentCnt = ShipmentCnt2 - stockAcPayHistWork.ShipmentCnt;
                                stockAcPayHistDeleteWork.OpenPriceDiv = 0; // 0:�ʏ�
                                stockAcPayHistDeleteWork.ListPriceTaxExcFl = stockAcPayHistWork.ListPriceTaxExcFl;
                                stockAcPayHistDeleteWork.StockUnitPriceFl = stockAcPayHistWork.StockUnitPriceFl;
                                stockAcPayHistDeleteWork.StockPrice = (long)stockAcPayHistWork.StockUnitPriceFl * (long)stockAcPayHistDeleteWork.ShipmentCnt;
                                stockAcPayHistDeleteWork.SalesUnPrcTaxExcFl = stockAcPayHistWork.SalesUnPrcTaxExcFl;
                                stockAcPayHistDeleteWork.SalesMoney = (long)stockAcPayHistWork.SalesUnPrcTaxExcFl * (long)stockAcPayHistDeleteWork.ShipmentCnt;
                                if (stockAcPayHistDeleteWork.ShipmentCnt == 0.0)
                                {
                                    // �ԕi����0�̏ꍇ�͖��v�㕪��0�̈וԕi�f�[�^���쐬���Ȃ�
                                    stockAcPayHistDeleteWork = null;
                                }
                            }
                            else
                            {
                                stockAcPayHistDeleteWork = null;
                            }
                        }
                        // 2010/10/21 Add <<<
                    }
                    else
                    {
                        stockAcPayHistDeleteWork = null;
                    }
                    // 2010/10/13 Add <<<
                    if (stockAcPayHistWork.IoGoodsDay != prevDateTime) // ������t���O��f�[�^�ƈႤ���H�i����ڂӂ��߁j                        
                    {
                        if (innerList != null && innerList.Count > 0)
                        {
                            if (stockAcPayHistDB == null)
                                stockAcPayHistDB = new StockAcPayHistDB();
                            //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                            status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                            if (status == 0)
                                cnt += innerList.Count;
                            else
                                break;
                        }
                        innerList = new ArrayList();
                        prevDateTime = stockAcPayHistWork.IoGoodsDay;
                    }
                    innerList.Add(stockAcPayHistWork);
                    // 2010/10/13 Add >>>
                    if (stockAcPayHistDeleteWork != null)
                        innerList.Add(stockAcPayHistDeleteWork);
                    // 2010/10/13 Add <<<

                }
                if (innerList != null && innerList.Count > 0)
                {
                    if (stockAcPayHistDB == null)
                        stockAcPayHistDB = new StockAcPayHistDB();
                    //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                    status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                    if (status == 0)
                        cnt += innerList.Count;
                }
                else if (cnt == 0) // 0���͐���ƌ��Ȃ��B
                {
                    status = 0;
                }
            }
            // --- UPD 2011/09/06---------->>>>>
            // catch { }
            catch (SqlException ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromSales", "���ォ��݌Ɏ󕥗����f�[�^�ݒ�(�ݏo)[" + ex.Message + "]", ex.Number);
            }
            catch (Exception ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromSales", "���ォ��݌Ɏ󕥗����f�[�^�ݒ�(�ݏo)[" + ex.Message + "]", status);
            }
            // --- UPD 2011/09/06----------<<<<<
            finally
            {
                if (myReader != null)
                    myReader.Dispose();
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (sqlCon != null)
                    sqlCon.Dispose();
            }
            #endregion

            // --- ADD 2011/09/06---------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromSales", "���ォ��݌Ɏ󕥗����f�[�^�ݒ�(�ݏo)", status);
            }
            // --- ADD 2011/09/06----------<<<<<

            return status;
        }

        /// <summary>
        /// ���㗚������݌Ɏ󕥗����f�[�^�ݒ�
        /// </summary>
        /// <param name="cnt">�����f�[�^�J�E���^</param>
        private int SetStockAcPayHistFromSalesHist(out int cnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            cnt = 0;
            if (lstSec == null)
                GetSectionInfo();

            #region [ ���㗚������݌Ɏ󕥏��擾 ]
            SqlConnection sqlCon = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            try
            {
                sqlCon = new SqlConnection(connectionText);
                sqlCon.Open();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlCon;

                string sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "SHST.LOGICALDELETECODERF," + Environment.NewLine;   // 2010/10/13 Add
                sqlText += "SHST.SALESINPSECCDRF," + Environment.NewLine;
                sqlText += "SHST.SALESDATERF," + Environment.NewLine;
                sqlText += "SHST.ADDUPADATERF," + Environment.NewLine;
                sqlText += "SHST.INPUTAGENCDRF," + Environment.NewLine;
                sqlText += "SHST.INPUTAGENNMRF," + Environment.NewLine;
                sqlText += "SHST.CUSTOMERCODERF," + Environment.NewLine;
                sqlText += "SHST.CUSTOMERSNMRF," + Environment.NewLine;

                sqlText += "DTHS.SALESSLIPNUMRF," + Environment.NewLine;
                sqlText += "DTHS.SALESROWNORF," + Environment.NewLine;
                sqlText += "DTHS.SECTIONCODERF," + Environment.NewLine;
                sqlText += "DTHS.SALESSLIPDTLNUMRF," + Environment.NewLine;
                sqlText += "DTHS.ACPTANODRSTATUSSRCRF," + Environment.NewLine;  // 2010/10/20 Add
                sqlText += "DTHS.SALESSLIPCDDTLRF," + Environment.NewLine;
                sqlText += "DTHS.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "DTHS.MAKERNAMERF," + Environment.NewLine;
                sqlText += "DTHS.GOODSNORF," + Environment.NewLine;
                sqlText += "DTHS.GOODSNAMERF," + Environment.NewLine;
                sqlText += "DTHS.BLGOODSCODERF," + Environment.NewLine;
                sqlText += "DTHS.BLGOODSFULLNAMERF," + Environment.NewLine;
                sqlText += "DTHS.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "DTHS.WAREHOUSENAMERF," + Environment.NewLine;
                sqlText += "DTHS.WAREHOUSESHELFNORF," + Environment.NewLine;
                sqlText += "DTHS.LISTPRICETAXEXCFLRF," + Environment.NewLine;
                sqlText += "DTHS.SALESUNPRCTAXEXCFLRF," + Environment.NewLine;
                sqlText += "DTHS.SALESUNITCOSTRF," + Environment.NewLine;
                sqlText += "DTHS.SHIPMENTCNTRF," + Environment.NewLine;
                sqlText += "DTHS.SALESMONEYTAXEXCRF," + Environment.NewLine;
                sqlText += "DTHS.COSTRF," + Environment.NewLine;
                sqlText += "DTHS.SALESSLIPCDDTLRF," + Environment.NewLine;
                sqlText += "DTHS.SALESORDERDIVCDRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SALESHISTORYRF AS SHST" + Environment.NewLine;
                sqlText += "  INNER JOIN SALESHISTDTLRF AS DTHS" + Environment.NewLine;
                sqlText += "ON SHST.ACPTANODRSTATUSRF = DTHS.ACPTANODRSTATUSRF AND  SHST.SALESSLIPNUMRF = DTHS.SALESSLIPNUMRF";

                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandTimeout = 300;// 2010/10/12 Add

                ArrayList innerList = null;
                // --- DEL 2020/06/18 ���X�ؘj �x���Ή� ---------->>>>>
                //ArrayList innerDeleteList = null; // 2010/10/13 Add
                // --- DEL 2020/06/18 ���X�ؘj �x���Ή� ----------<<<<<
                DateTime prevDateTime = DateTime.MaxValue;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StockAcPayHistWork stockAcPayHistWork = new StockAcPayHistWork();
                    StockAcPayHistWork stockAcPayHistDeleteWork = null;   // 2010/10/13 Add

                    stockAcPayHistWork.LogicalDeleteCode = 0;
                    // 2010/10/20 Add >>>
                    // �ݏo�v�㕪�͓��o�ד����Z�b�g���Ȃ�
                    int acptAnOdrStatusSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSRCRF"));
                    if (acptAnOdrStatusSrc == 40)
                    {
                        stockAcPayHistWork.IoGoodsDay = DateTime.MinValue;
                    }
                    else
                    // 2010/10/20 Add <<<
                        stockAcPayHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                    stockAcPayHistWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    stockAcPayHistWork.AcPaySlipCd = 20; // 20:����Œ�
                    stockAcPayHistWork.AcPaySlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    stockAcPayHistWork.AcPaySlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                    int kubun = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                    if (kubun == 0)
                        stockAcPayHistWork.AcPayTransCd = 10; // 0:����	 -> 10:�ʏ�`�[
                    else if (kubun == 1)
                        stockAcPayHistWork.AcPayTransCd = 11; // 1:�ԕi	 -> 11:�ԕi

                    stockAcPayHistWork.InputSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPSECCDRF"));
                    if (lstSec.ContainsKey(stockAcPayHistWork.InputSectionCd))
                    {
                        stockAcPayHistWork.InputSectionGuidNm = lstSec[stockAcPayHistWork.InputSectionCd].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.InputSectionGuidNm = "";
                    }
                    stockAcPayHistWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));
                    stockAcPayHistWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));
                    stockAcPayHistWork.MoveStatus = 0; // 0:�ړ��ΏۊO
                    stockAcPayHistWork.SlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
                    stockAcPayHistWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockAcPayHistWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    stockAcPayHistWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockAcPayHistWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    stockAcPayHistWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    stockAcPayHistWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    stockAcPayHistWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    if (lstSec.ContainsKey(stockAcPayHistWork.SectionCode))
                    {
                        stockAcPayHistWork.SectionGuideNm = lstSec[stockAcPayHistWork.SectionCode].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.SectionGuideNm = "";
                    }
                    stockAcPayHistWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockAcPayHistWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    stockAcPayHistWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    stockAcPayHistWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    stockAcPayHistWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    stockAcPayHistWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    stockAcPayHistWork.OpenPriceDiv = 0; // 0 : �ʏ�
                    stockAcPayHistWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    stockAcPayHistWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    stockAcPayHistWork.StockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
                    stockAcPayHistWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                    stockAcPayHistWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));

                    // �݌ɊǗ��������
                    // �@ �q�ɃR�[�h���ݒ肳��Ă���
                    // �A ����݌Ɏ�񂹋敪�� 1:�݌�
                    // �B �o�א���0�ȊO
                    // �C ����`�[�敪(����)�� 0:���� 1:�ԕi �̏ꍇ
                    // 2010/10/08 Add >>>
                    // �D �i�Ԃ��Z�b�g����Ă���
                    // 2010/10/08 Add <<<
                    int slipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                    int orderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                    string goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  // 2010/10/08 Add
                    // 2010/10/08 >>>
                    //if (string.IsNullOrEmpty(stockAcPayHistWork.WarehouseCode) ||
                    //    orderDivCd != 1 ||
                    //    stockAcPayHistWork.ShipmentCnt == 0 ||
                    //    (slipCdDtl != 0 && slipCdDtl != 1))
                    //    continue;
                    if (string.IsNullOrEmpty(stockAcPayHistWork.WarehouseCode) ||
                        orderDivCd != 1 ||
                        stockAcPayHistWork.ShipmentCnt == 0 ||
                        (slipCdDtl != 0 && slipCdDtl != 1) ||
                        string.IsNullOrEmpty(goodsNo))
                        continue;
                    // 2010/10/08 <<<

                    // 2010/10/13 Add >>>
                    int logicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    if (logicalDeleteCode == 1)
                    {
                        stockAcPayHistDeleteWork = new StockAcPayHistWork();
                        stockAcPayHistDeleteWork.LogicalDeleteCode = 0;
                        stockAcPayHistDeleteWork.IoGoodsDay = stockAcPayHistWork.IoGoodsDay;
                        stockAcPayHistDeleteWork.AddUpADate = stockAcPayHistWork.AddUpADate;
                        stockAcPayHistDeleteWork.AcPaySlipCd = 20; // 20:����Œ�
                        stockAcPayHistDeleteWork.AcPaySlipNum = stockAcPayHistWork.AcPaySlipNum;
                        stockAcPayHistDeleteWork.AcPaySlipRowNo = stockAcPayHistWork.AcPaySlipRowNo;
                        stockAcPayHistDeleteWork.AcPayTransCd = 21; // 21:�폜
                        stockAcPayHistDeleteWork.InputSectionCd = stockAcPayHistWork.InputSectionCd;
                        stockAcPayHistDeleteWork.InputSectionGuidNm = stockAcPayHistWork.InputSectionGuidNm;
                        stockAcPayHistDeleteWork.InputAgenCd = stockAcPayHistWork.InputAgenCd;
                        stockAcPayHistDeleteWork.InputAgenNm = stockAcPayHistWork.InputAgenNm;
                        stockAcPayHistDeleteWork.MoveStatus = 0; // 0:�ړ��ΏۊO
                        stockAcPayHistDeleteWork.SlipDtlNum = stockAcPayHistWork.SlipDtlNum;
                        stockAcPayHistDeleteWork.GoodsMakerCd = stockAcPayHistWork.GoodsMakerCd;
                        stockAcPayHistDeleteWork.MakerName = stockAcPayHistWork.MakerName;
                        stockAcPayHistDeleteWork.GoodsNo = stockAcPayHistWork.GoodsNo;
                        stockAcPayHistDeleteWork.GoodsName = stockAcPayHistWork.GoodsName;
                        stockAcPayHistDeleteWork.BLGoodsCode = stockAcPayHistWork.BLGoodsCode;
                        stockAcPayHistDeleteWork.BLGoodsFullName = stockAcPayHistWork.BLGoodsFullName;
                        stockAcPayHistDeleteWork.SectionCode = stockAcPayHistWork.SectionCode;
                        stockAcPayHistDeleteWork.SectionGuideNm = stockAcPayHistWork.SectionGuideNm;
                        stockAcPayHistDeleteWork.WarehouseCode = stockAcPayHistWork.WarehouseCode;
                        stockAcPayHistDeleteWork.WarehouseName = stockAcPayHistWork.WarehouseName;
                        stockAcPayHistDeleteWork.ShelfNo = stockAcPayHistWork.ShelfNo;
                        stockAcPayHistDeleteWork.CustomerCode = stockAcPayHistWork.CustomerCode;
                        stockAcPayHistDeleteWork.CustomerSnm = stockAcPayHistWork.CustomerSnm;
                        stockAcPayHistDeleteWork.ShipmentCnt = -stockAcPayHistWork.ShipmentCnt;
                        stockAcPayHistDeleteWork.OpenPriceDiv = 0; // 0 : �ʏ�
                        stockAcPayHistDeleteWork.ListPriceTaxExcFl = stockAcPayHistWork.ListPriceTaxExcFl;
                        stockAcPayHistDeleteWork.StockUnitPriceFl = stockAcPayHistWork.StockUnitPriceFl;
                        stockAcPayHistDeleteWork.StockPrice = -stockAcPayHistWork.StockPrice;
                        stockAcPayHistDeleteWork.SalesUnPrcTaxExcFl = stockAcPayHistWork.SalesUnPrcTaxExcFl;
                        stockAcPayHistDeleteWork.SalesMoney = -stockAcPayHistWork.SalesMoney;
                    }
                    else
                    {
                        stockAcPayHistDeleteWork = null;
                    }
                    // 2010/10/13 Add <<<
                    if (stockAcPayHistWork.IoGoodsDay != prevDateTime) // ������t���O��f�[�^�ƈႤ���H�i����ڂӂ��߁j                        
                    {
                        if (innerList != null)
                        {
                            if (stockAcPayHistDB == null)
                                stockAcPayHistDB = new StockAcPayHistDB();
                            //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                            status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                            if (status == 0)
                                cnt += innerList.Count;
                            else
                                break;
                        }
                        innerList = new ArrayList();
                        prevDateTime = stockAcPayHistWork.IoGoodsDay;
                    }
                    innerList.Add(stockAcPayHistWork);
                    // 2010/10/13 Add >>>
                    if (stockAcPayHistDeleteWork != null)
                        innerList.Add(stockAcPayHistDeleteWork);
                    // 2010/10/13 Add <<<
                }
                if (innerList != null && innerList.Count > 0)
                {
                    if (stockAcPayHistDB == null)
                        stockAcPayHistDB = new StockAcPayHistDB();
                    //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                    status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                    if (status == 0)
                        cnt += innerList.Count;
                }
                else if (cnt == 0) // 0���͐���ƌ��Ȃ��B
                {
                    status = 0;
                }
            }
            // --- UPD 2011/09/06---------->>>>>
            // catch {}
            catch (SqlException ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromSalesHist", "���㗚������݌Ɏ󕥗����f�[�^�ݒ�[" + ex.Message + "]", ex.Number);
            }
            catch (Exception ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromSalesHist", "���㗚������݌Ɏ󕥗����f�[�^�ݒ�[" + ex.Message + "]", status);
            }
            // --- UPD 2011/09/06----------<<<<<
            finally
            {
                if (myReader != null)
                    myReader.Dispose();
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (sqlCon != null)
                    sqlCon.Dispose();
            }
            #endregion

            // --- ADD 2011/09/06---------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromSalesHist", "���㗚������݌Ɏ󕥗����f�[�^�ݒ�", status);
            }
            // --- ADD 2011/09/06----------<<<<<

            return status;
        }

        /// <summary>
        /// �d������݌Ɏ󕥗����f�[�^�ݒ�
        /// </summary>
        /// <param name="cnt">�����f�[�^�J�E���^</param>
        private int SetStockAcPayHistFromStockSlip(out int cnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            cnt = 0;
            if (lstSec == null)
                GetSectionInfo();

            #region [ �d������݌Ɏ󕥏��擾 ]
            SqlConnection sqlCon = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            try
            {
                sqlCon = new SqlConnection(connectionText);
                sqlCon.Open();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlCon;

                string sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "STOK.SECTIONCODERF," + Environment.NewLine;
                sqlText += "STOK.STOCKDATERF," + Environment.NewLine;
                sqlText += "STOK.STOCKADDUPADATERF," + Environment.NewLine;
                sqlText += "STOK.STOCKINPUTCODERF," + Environment.NewLine;
                sqlText += "STOK.STOCKINPUTNAMERF," + Environment.NewLine;
                sqlText += "STOK.SUPPLIERCDRF," + Environment.NewLine;
                sqlText += "STOK.SUPPLIERSNMRF," + Environment.NewLine;
                sqlText += "STOK.PARTYSALESLIPNUMRF," + Environment.NewLine;

                sqlText += "STDT.SUPPLIERSLIPNORF," + Environment.NewLine;
                sqlText += "STDT.STOCKROWNORF," + Environment.NewLine;
                sqlText += "STDT.STOCKSLIPDTLNUMRF," + Environment.NewLine;
                sqlText += "STDT.STOCKSLIPCDDTLRF," + Environment.NewLine;
                sqlText += "STDT.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "STDT.MAKERNAMERF," + Environment.NewLine;
                sqlText += "STDT.GOODSNORF," + Environment.NewLine;
                sqlText += "STDT.GOODSNAMERF," + Environment.NewLine;
                sqlText += "STDT.BLGOODSCODERF," + Environment.NewLine;
                sqlText += "STDT.BLGOODSFULLNAMERF," + Environment.NewLine;
                sqlText += "STDT.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "STDT.WAREHOUSENAMERF," + Environment.NewLine;
                sqlText += "STDT.WAREHOUSESHELFNORF," + Environment.NewLine;
                sqlText += "STDT.LISTPRICETAXEXCFLRF," + Environment.NewLine;
                sqlText += "STDT.STOCKUNITPRICEFLRF," + Environment.NewLine;
                sqlText += "STDT.STOCKCOUNTRF," + Environment.NewLine;
                sqlText += "STDT.STOCKPRICETAXEXCRF," + Environment.NewLine;
                sqlText += "STDT.STOCKORDERDIVCDRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  STOCKSLIPRF AS STOK" + Environment.NewLine;
                sqlText += "  INNER JOIN STOCKDETAILRF AS STDT" + Environment.NewLine;
                sqlText += "ON STOK.SUPPLIERSLIPNORF = STDT.SUPPLIERSLIPNORF AND  STOK.SUPPLIERFORMALRF = STDT.SUPPLIERFORMALRF";

                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandTimeout = 300;// 2012/04/27 Add

                ArrayList innerList = null;
                DateTime prevDateTime = DateTime.MaxValue;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StockAcPayHistWork stockAcPayHistWork = new StockAcPayHistWork();

                    stockAcPayHistWork.LogicalDeleteCode = 0;
                    stockAcPayHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
                    stockAcPayHistWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
                    stockAcPayHistWork.AcPaySlipCd = 10; // 10:�d���Œ�
                    stockAcPayHistWork.AcPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF")).ToString();
                    stockAcPayHistWork.AcPaySlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
                    int kubun = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
                    if (kubun == 0)
                        stockAcPayHistWork.AcPayTransCd = 10; // 0:�d��	 -> 10:�ʏ�`�[
                    else if (kubun == 1)
                        stockAcPayHistWork.AcPayTransCd = 11; // 1:�ԕi	 -> 11:�ԕi
                    else if (kubun == 2)
                        stockAcPayHistWork.AcPayTransCd = 12; // 2:�l��	 -> 12:�l��

                    stockAcPayHistWork.InputSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    if (lstSec.ContainsKey(stockAcPayHistWork.InputSectionCd))
                    {
                        stockAcPayHistWork.InputSectionGuidNm = lstSec[stockAcPayHistWork.InputSectionCd].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.InputSectionGuidNm = "";
                    }
                    stockAcPayHistWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
                    stockAcPayHistWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
                    stockAcPayHistWork.MoveStatus = 0; // 0 : �ړ��ΏۊO
                    stockAcPayHistWork.CustSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                    stockAcPayHistWork.SlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
                    stockAcPayHistWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockAcPayHistWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    stockAcPayHistWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockAcPayHistWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    stockAcPayHistWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    stockAcPayHistWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    stockAcPayHistWork.SectionCode = stockAcPayHistWork.InputSectionCd;
                    if (lstSec.ContainsKey(stockAcPayHistWork.SectionCode))
                    {
                        stockAcPayHistWork.SectionGuideNm = lstSec[stockAcPayHistWork.SectionCode].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.SectionGuideNm = "";
                    }

                    stockAcPayHistWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockAcPayHistWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    stockAcPayHistWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    stockAcPayHistWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    stockAcPayHistWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    stockAcPayHistWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
                    stockAcPayHistWork.OpenPriceDiv = 0; // 0:�ʏ�
                    stockAcPayHistWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    stockAcPayHistWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    stockAcPayHistWork.StockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));

                    // �݌ɊǗ��������
                    // �@ �q�ɃR�[�h���ݒ肳��Ă���
                    // �A �d���݌Ɏ�񂹋敪�� 1:�݌�
                    // �B �d������0�ȊO
                    // �C �d���`�[�敪(����)�� 0:���� 1:�ԕi �̏ꍇ
                    // 2010/10/08 Add >>>
                    // �D �i�Ԃ��Z�b�g����Ă���
                    // 2010/10/08 Add <<<
                    int orderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
                    string goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  // 2010/10/08 Add
                    // 2010/10/08 >>>
                    //if (string.IsNullOrEmpty(stockAcPayHistWork.WarehouseCode) ||
                    //    orderDivCd != 1 ||
                    //    stockAcPayHistWork.ArrivalCnt == 0 ||
                    //    (kubun != 0 && kubun != 1))
                    //    continue;
                    if (string.IsNullOrEmpty(stockAcPayHistWork.WarehouseCode) ||
                        orderDivCd != 1 ||
                        stockAcPayHistWork.ArrivalCnt == 0 ||
                        (kubun != 0 && kubun != 1) ||
                        string.IsNullOrEmpty(goodsNo))
                        continue;
                    // 2010/10/08 <<<

                    if (stockAcPayHistWork.IoGoodsDay != prevDateTime) // ������t���O��f�[�^�ƈႤ���H�i����ڂӂ��߁j                        
                    {
                        if (innerList != null)
                        {
                            if (stockAcPayHistDB == null)
                                stockAcPayHistDB = new StockAcPayHistDB();
                            //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                            status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                            if (status == 0)
                                cnt += innerList.Count;
                            else
                                break;
                        }
                        innerList = new ArrayList();
                        prevDateTime = stockAcPayHistWork.IoGoodsDay;
                    }
                    innerList.Add(stockAcPayHistWork);

                }
                if (innerList != null && innerList.Count > 0)
                {
                    if (stockAcPayHistDB == null)
                        stockAcPayHistDB = new StockAcPayHistDB();
                    //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                    status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                    if (status == 0)
                        cnt += innerList.Count;
                }
                else if (cnt == 0) // 0���͐���ƌ��Ȃ��B
                {
                    status = 0;
                }
            }
            // --- UPD 2011/09/06---------->>>>>
            // catch {}
            catch (SqlException ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockSlip", "�d������݌Ɏ󕥗����f�[�^�ݒ�[" + ex.Message + "]", ex.Number);
            }
            catch (Exception ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockSlip", "�d������݌Ɏ󕥗����f�[�^�ݒ�[" + ex.Message + "]", status);
            }
            // --- UPD 2011/09/06----------<<<<<
            finally
            {
                if (myReader != null)
                    myReader.Dispose();
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (sqlCon != null)
                    sqlCon.Dispose();
            }
            #endregion

            // --- ADD 2011/09/06---------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockSlip", "�d������݌Ɏ󕥗����f�[�^�ݒ�", status);
            }
            // --- ADD 2011/09/06----------<<<<<

            return status;
        }

        /// <summary>
        /// �d����������݌Ɏ󕥗����f�[�^�ݒ�
        /// </summary>
        /// <param name="cnt">�����f�[�^�J�E���^</param>
        private int SetStockAcPayHistFromStockSlipHist(out int cnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            cnt = 0;
            if (lstSec == null)
                GetSectionInfo();
            #region [ �d����������݌Ɏ󕥏��擾 ]
            SqlConnection sqlCon = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            try
            {
                sqlCon = new SqlConnection(connectionText);
                sqlCon.Open();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlCon;

                string sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "STHST.LOGICALDELETECODERF," + Environment.NewLine;    // 2010/10/13 Add
                sqlText += "STHST.SECTIONCODERF," + Environment.NewLine;
                sqlText += "STHST.STOCKSECTIONCDRF," + Environment.NewLine;
                sqlText += "STHST.ARRIVALGOODSDAYRF," + Environment.NewLine;  // 2010/10/13 Add
                sqlText += "STHST.STOCKDATERF," + Environment.NewLine;
                sqlText += "STHST.STOCKADDUPADATERF," + Environment.NewLine;
                sqlText += "STHST.STOCKINPUTCODERF," + Environment.NewLine;
                sqlText += "STHST.STOCKINPUTNAMERF," + Environment.NewLine;
                sqlText += "STHST.SUPPLIERCDRF," + Environment.NewLine;
                sqlText += "STHST.SUPPLIERSNMRF," + Environment.NewLine;
                sqlText += "STHST.PARTYSALESLIPNUMRF," + Environment.NewLine;

                sqlText += "STHDT.SUPPLIERSLIPNORF," + Environment.NewLine;
                sqlText += "STHDT.STOCKROWNORF," + Environment.NewLine;
                sqlText += "STHDT.STOCKSLIPDTLNUMRF," + Environment.NewLine;
                sqlText += "STHDT.STOCKSLIPCDDTLRF," + Environment.NewLine;
                sqlText += "STHDT.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "STHDT.MAKERNAMERF," + Environment.NewLine;
                sqlText += "STHDT.GOODSNORF," + Environment.NewLine;
                sqlText += "STHDT.GOODSNAMERF," + Environment.NewLine;
                sqlText += "STHDT.BLGOODSCODERF," + Environment.NewLine;
                sqlText += "STHDT.BLGOODSFULLNAMERF," + Environment.NewLine;
                sqlText += "STHDT.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "STHDT.WAREHOUSENAMERF," + Environment.NewLine;
                sqlText += "STHDT.WAREHOUSESHELFNORF," + Environment.NewLine;
                sqlText += "STHDT.LISTPRICETAXEXCFLRF," + Environment.NewLine;
                sqlText += "STHDT.STOCKUNITPRICEFLRF," + Environment.NewLine;
                sqlText += "STHDT.STOCKCOUNTRF," + Environment.NewLine;
                sqlText += "STHDT.STOCKPRICETAXEXCRF," + Environment.NewLine;
                sqlText += "STHDT.STOCKORDERDIVCDRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  STOCKSLIPHISTRF AS STHST" + Environment.NewLine;
                sqlText += "  INNER JOIN STOCKSLHISTDTLRF AS STHDT" + Environment.NewLine;
                sqlText += "ON STHST.SUPPLIERSLIPNORF = STHDT.SUPPLIERSLIPNORF AND  STHST.SUPPLIERFORMALRF = STHDT.SUPPLIERFORMALRF";

                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandTimeout = 300;// 2012/04/27 Add

                ArrayList innerList = null;
                DateTime prevDateTime = DateTime.MaxValue;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StockAcPayHistWork stockAcPayHistWork = new StockAcPayHistWork();
                    StockAcPayHistWork stockAcPayHistDeleteWork = null;

                    stockAcPayHistWork.LogicalDeleteCode = 0;
                    // 2010/10/13 >>>
                    //stockAcPayHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
                    stockAcPayHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
                    // 2010/10/13 <<<
                    stockAcPayHistWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
                    stockAcPayHistWork.AcPaySlipCd = 10; // 10:�d���Œ�
                    stockAcPayHistWork.AcPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF")).ToString();
                    stockAcPayHistWork.AcPaySlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
                    int kubun = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
                    if (kubun == 0)
                        stockAcPayHistWork.AcPayTransCd = 10; // 0:�d��	 -> 10:�ʏ�`�[
                    else if (kubun == 1)
                        stockAcPayHistWork.AcPayTransCd = 11; // 1:�ԕi	 -> 11:�ԕi
                    else if (kubun == 2)
                        stockAcPayHistWork.AcPayTransCd = 12; // 2:�l��	 -> 12:�l��
                    stockAcPayHistWork.InputSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    if (lstSec.ContainsKey(stockAcPayHistWork.InputSectionCd))
                    {
                        stockAcPayHistWork.InputSectionGuidNm = lstSec[stockAcPayHistWork.InputSectionCd].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.InputSectionGuidNm = "";
                    }
                    stockAcPayHistWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
                    stockAcPayHistWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
                    stockAcPayHistWork.MoveStatus = 0; // 0:�ړ��ΏۊO
                    stockAcPayHistWork.CustSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                    stockAcPayHistWork.SlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
                    stockAcPayHistWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockAcPayHistWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    stockAcPayHistWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockAcPayHistWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    stockAcPayHistWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    stockAcPayHistWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    stockAcPayHistWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
                    if (lstSec.ContainsKey(stockAcPayHistWork.SectionCode))
                    {
                        stockAcPayHistWork.SectionGuideNm = lstSec[stockAcPayHistWork.SectionCode].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.SectionGuideNm = "";
                    }
                    stockAcPayHistWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockAcPayHistWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    stockAcPayHistWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    stockAcPayHistWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    stockAcPayHistWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    stockAcPayHistWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
                    stockAcPayHistWork.OpenPriceDiv = 0; // 0:�ʏ�
                    stockAcPayHistWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    stockAcPayHistWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    stockAcPayHistWork.StockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));

                    // �݌ɊǗ��������
                    // �@ �q�ɃR�[�h���ݒ肳��Ă���
                    // �A �d���݌Ɏ�񂹋敪�� 1:�݌�
                    // �B �d������0�ȊO
                    // �C �d���`�[�敪(����)�� 0:���� 1:�ԕi �̏ꍇ
                    // 2010/10/08 Add >>>
                    // �D �i�Ԃ��Z�b�g����Ă���
                    // 2010/10/08 Add <<<
                    int orderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
                    string goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  // 2010/10/08 Add
                    if (string.IsNullOrEmpty(stockAcPayHistWork.WarehouseCode) ||
                        orderDivCd != 1 ||
                        stockAcPayHistWork.ArrivalCnt == 0 ||
                        (kubun != 0 && kubun != 1) ||
                        string.IsNullOrEmpty(goodsNo))
                        continue;

                    // 2010/10/13 Add >>>
                    int logicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    if (logicalDeleteCode == 1)
                    {
                        stockAcPayHistDeleteWork = new StockAcPayHistWork();
                        stockAcPayHistDeleteWork.LogicalDeleteCode = 0;
                        stockAcPayHistDeleteWork.IoGoodsDay = stockAcPayHistWork.IoGoodsDay;
                        stockAcPayHistDeleteWork.AddUpADate = stockAcPayHistWork.AddUpADate;
                        stockAcPayHistDeleteWork.AcPaySlipCd = 10; // 10:�d���Œ�
                        stockAcPayHistDeleteWork.AcPaySlipNum = stockAcPayHistWork.AcPaySlipNum;
                        stockAcPayHistDeleteWork.AcPaySlipRowNo = stockAcPayHistWork.AcPaySlipRowNo;
                        stockAcPayHistDeleteWork.AcPayTransCd = 21; // 21:�폜
                        stockAcPayHistDeleteWork.InputSectionCd = stockAcPayHistWork.InputSectionCd;
                        stockAcPayHistDeleteWork.InputSectionGuidNm = stockAcPayHistWork.InputSectionGuidNm;
                        stockAcPayHistDeleteWork.InputAgenCd = stockAcPayHistWork.InputAgenCd;
                        stockAcPayHistDeleteWork.InputAgenNm = stockAcPayHistWork.InputAgenNm;
                        stockAcPayHistDeleteWork.MoveStatus = 0; // 0:�ړ��ΏۊO
                        stockAcPayHistDeleteWork.CustSlipNo = stockAcPayHistWork.CustSlipNo;
                        stockAcPayHistDeleteWork.SlipDtlNum = stockAcPayHistWork.SlipDtlNum;
                        stockAcPayHistDeleteWork.GoodsMakerCd = stockAcPayHistWork.GoodsMakerCd;
                        stockAcPayHistDeleteWork.MakerName = stockAcPayHistWork.MakerName;
                        stockAcPayHistDeleteWork.GoodsNo = stockAcPayHistWork.GoodsNo;
                        stockAcPayHistDeleteWork.GoodsName = stockAcPayHistWork.GoodsName;
                        stockAcPayHistDeleteWork.BLGoodsCode = stockAcPayHistWork.BLGoodsCode;
                        stockAcPayHistDeleteWork.BLGoodsFullName = stockAcPayHistWork.BLGoodsFullName;
                        stockAcPayHistDeleteWork.SectionCode = stockAcPayHistWork.SectionCode;
                        stockAcPayHistDeleteWork.SectionGuideNm = stockAcPayHistWork.SectionGuideNm;
                        stockAcPayHistDeleteWork.WarehouseCode = stockAcPayHistWork.WarehouseCode;
                        stockAcPayHistDeleteWork.WarehouseName = stockAcPayHistWork.WarehouseName;
                        stockAcPayHistDeleteWork.ShelfNo = stockAcPayHistWork.ShelfNo;
                        stockAcPayHistDeleteWork.SupplierCd = stockAcPayHistWork.SupplierCd;
                        stockAcPayHistDeleteWork.SupplierSnm = stockAcPayHistWork.SupplierSnm;
                        stockAcPayHistDeleteWork.ArrivalCnt = -stockAcPayHistWork.ArrivalCnt;
                        stockAcPayHistDeleteWork.OpenPriceDiv = 0; // 0:�ʏ�
                        stockAcPayHistDeleteWork.ListPriceTaxExcFl = stockAcPayHistWork.ListPriceTaxExcFl;
                        stockAcPayHistDeleteWork.StockUnitPriceFl = stockAcPayHistWork.StockUnitPriceFl;
                        stockAcPayHistDeleteWork.StockPrice = -stockAcPayHistWork.StockPrice;
                    }
                    else
                    {
                        stockAcPayHistDeleteWork = null;
                    }
                    // 2010/10/13 Add <<<

                    if (stockAcPayHistWork.IoGoodsDay != prevDateTime) // ������t���O��f�[�^�ƈႤ���H�i����ڂӂ��߁j                        
                    {
                        if (innerList != null)
                        {
                            if (stockAcPayHistDB == null)
                                stockAcPayHistDB = new StockAcPayHistDB();
                            //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                            status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                            if (status == 0)
                                cnt += innerList.Count;
                            else
                                break;
                        }
                        innerList = new ArrayList();
                        prevDateTime = stockAcPayHistWork.IoGoodsDay;
                    }
                    innerList.Add(stockAcPayHistWork);
                    if (stockAcPayHistDeleteWork != null)
                    {
                        innerList.Add(stockAcPayHistDeleteWork);
                    }
                }
                if (innerList != null && innerList.Count > 0)
                {
                    if (stockAcPayHistDB == null)
                        stockAcPayHistDB = new StockAcPayHistDB();
                    //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                    status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                    if (status == 0)
                        cnt += innerList.Count;
                }
                else if (cnt == 0) // 0���͐���ƌ��Ȃ��B
                {
                    status = 0;
                }

            }
            // --- UPD 2011/09/06---------->>>>>
            // catch {}
            catch (SqlException ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockSlipHist", "�d����������݌Ɏ󕥗����f�[�^�ݒ�[" + ex.Message + "]", ex.Number);
            }
            catch (Exception ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockSlipHist", "�d����������݌Ɏ󕥗����f�[�^�ݒ�[" + ex.Message + "]", status);
            }
            // --- UPD 2011/09/06----------<<<<<
            finally
            {
                if (myReader != null)
                    myReader.Dispose();
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (sqlCon != null)
                    sqlCon.Dispose();
            }
            #endregion

            // --- ADD 2011/09/06---------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockSlipHist", "�d����������݌Ɏ󕥗����f�[�^�ݒ�", status);
            }
            // --- ADD 2011/09/06----------<<<<<

            return status;
        }

        /// <summary>
        /// �݌Ɉړ�����݌Ɏ󕥗����f�[�^�ݒ�
        /// </summary>
        /// <param name="cnt">�����f�[�^�J�E���^</param>
        /// <param name="mode">���׍ς݃f�[�^�̑Ώ� 0:�o�ׁA����,1:���ׂ̂ݍ쐬</param>
        private int SetStockAcPayHistFromStockMove(out int cnt, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            cnt = 0;
            if (lstSec == null)
                GetSectionInfo();
            //if (lstFractionInfo == null)
            //    GetStockProcMoneyInfo();
            //if (lstFractionInfo == null) // GetStockProcMoneyInfo�����Œ[���������擾���s�����ꍇ�����𒆒f
            //    return status;

            #region [ �݌Ɉړ�����݌Ɏ󕥏��擾 ]
            SqlConnection sqlCon = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            try
            {
                sqlCon = new SqlConnection(connectionText);
                sqlCon.Open();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlCon;


                string sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "STKMV.LOGICALDELETECODERF," + Environment.NewLine;   // 2010/10/13 Add
                sqlText += "STKMV.MOVESTATUSRF," + Environment.NewLine;   // 2010/09/17 Add
                sqlText += "STKMV.STOCKMOVEFORMALRF," + Environment.NewLine;   // 2009/06/19
                sqlText += "STKMV.STOCKMOVESLIPNORF," + Environment.NewLine;
                sqlText += "STKMV.STOCKMOVEROWNORF," + Environment.NewLine;
                sqlText += "SECINF.SECTIONGUIDESNMRF," + Environment.NewLine; // 2010/10/13 Add
                sqlText += "STKMV.UPDATESECCDRF," + Environment.NewLine;  // 2010/10/13 Add
                sqlText += "STKMV.BFSECTIONCODERF," + Environment.NewLine;
                sqlText += "STKMV.BFSECTIONGUIDESNMRF," + Environment.NewLine;
                sqlText += "STKMV.BFENTERWAREHCODERF," + Environment.NewLine;
                sqlText += "STKMV.BFENTERWAREHNAMERF," + Environment.NewLine;
                sqlText += "STKMV.AFSECTIONCODERF," + Environment.NewLine;
                sqlText += "STKMV.AFSECTIONGUIDESNMRF," + Environment.NewLine;
                sqlText += "STKMV.AFENTERWAREHCODERF," + Environment.NewLine;
                sqlText += "STKMV.AFENTERWAREHNAMERF," + Environment.NewLine;
                sqlText += "STKMV.SHIPMENTFIXDAYRF," + Environment.NewLine;
                sqlText += "STKMV.ARRIVALGOODSDAYRF," + Environment.NewLine;
                sqlText += "STKMV.STOCKMVEMPCODERF," + Environment.NewLine;
                sqlText += "STKMV.STOCKMVEMPNAMERF," + Environment.NewLine;
                sqlText += "STKMV.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "STKMV.MAKERNAMERF," + Environment.NewLine;
                sqlText += "STKMV.GOODSNORF," + Environment.NewLine;
                sqlText += "STKMV.GOODSNAMERF," + Environment.NewLine;
                sqlText += "STKMV.STOCKUNITPRICEFLRF," + Environment.NewLine;
                sqlText += "STKMV.MOVECOUNTRF," + Environment.NewLine;
                sqlText += "STKMV.BFSHELFNORF," + Environment.NewLine;
                sqlText += "STKMV.AFSHELFNORF," + Environment.NewLine;
                sqlText += "STKMV.BLGOODSCODERF," + Environment.NewLine;
                sqlText += "STKMV.BLGOODSFULLNAMERF," + Environment.NewLine;
                sqlText += "STKMV.LISTPRICEFLRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  STOCKMOVERF AS STKMV" + Environment.NewLine;
                // 2010/10/13 Add >>>
                sqlText += "LEFT JOIN" + Environment.NewLine;
                sqlText += "  SECINFOSETRF AS SECINF" + Environment.NewLine;
                sqlText += "    ON STKMV.ENTERPRISECODERF=SECINF.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND STKMV.UPDATESECCDRF=SECINF.SECTIONCODERF" + Environment.NewLine;
                // 2010/10/13 Add <<<

                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandTimeout = 300;// 2012/04/27 Add

                ArrayList innerListShipping = null;
                ArrayList innerListArrival = null;
                DateTime prevDateTimeShipping = DateTime.MaxValue;
                DateTime prevDateTimeArrival = DateTime.MaxValue;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region [ �ړ��o�� ]
                    StockAcPayHistWork shippingStockHistWork = new StockAcPayHistWork(); // �ړ��o��
                    shippingStockHistWork.LogicalDeleteCode = 0;
                    // 2010/10/05 Add >>>
                    // ���׊m��Ȃ��̏ꍇ�A���׃f�[�^�ɏo�׊m������Z�b�g����Ă��Ȃ��ׁA���ד�����o�׊m������Z�b�g����
                    if(mode==1)
                        shippingStockHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF")); // �o�׊m���
                    else
                    // 2010/10/05 Add <<<
                    shippingStockHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTFIXDAYRF")); // �o�׊m���
                    //shippingStockHistWork.AddUpADate = shippingStockHistWork.IoGoodsDay;  // DEL 2009/03/27 MANTIS 12532
                    shippingStockHistWork.AcPaySlipCd = 30; // 30:�ړ��o��
                    shippingStockHistWork.AcPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVESLIPNORF")).ToString();
                    shippingStockHistWork.AcPaySlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEROWNORF"));
                    shippingStockHistWork.AcPayTransCd = 10; // 10:�ʏ�`�[

                    // 2010/10/13 >>>
                    //shippingStockHistWork.InputSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF"));
                    shippingStockHistWork.InputSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                    // 2010/10/13 <<<
                    if (lstSec.ContainsKey(shippingStockHistWork.InputSectionCd))
                    {
                        shippingStockHistWork.InputSectionGuidNm = lstSec[shippingStockHistWork.InputSectionCd].SectionGuideNm;
                    }
                    else
                    {
                        // 2010/10/13 >>>
                        //shippingStockHistWork.InputSectionGuidNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDESNMRF"));
                        shippingStockHistWork.InputSectionGuidNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                        // 2010/10/13 <<<
                        if (shippingStockHistWork.InputSectionGuidNm.Length > 6) // ���̂�10���E�K�C�h����6���̂��߁A
                        {
                            shippingStockHistWork.InputSectionGuidNm = shippingStockHistWork.InputSectionGuidNm.Remove(6);
                        }
                    }
                    shippingStockHistWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKMVEMPCODERF"));
                    shippingStockHistWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKMVEMPNAMERF"));
                    
                    // 2009/06/19 >>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //// 2009/03/27 MANTIS 12532>>>>>>>>>>>>>>>>>
                    ////shippingStockHistWork.MoveStatus = 9; // 9:���׍� 
                    //shippingStockHistWork.MoveStatus = 2; // 3:�ړ��� 
                    //// 2009/03/27 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    // 2010/09/17 >>>
                    //shippingStockHistWork.MoveStatus = 9; // 9:���׍� 
                    shippingStockHistWork.MoveStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOVESTATUSRF"));
                    // 2010/09/17 <<<
                    // 2009/06/19 <<<<<<<<<<<<<<<<<<<<<<<<<<<
                    shippingStockHistWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    shippingStockHistWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    shippingStockHistWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    shippingStockHistWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    shippingStockHistWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    shippingStockHistWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));

                    // 2010/10/13 Add >>>
                    shippingStockHistWork.BfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF")); ;
                    if (lstSec.ContainsKey(shippingStockHistWork.BfSectionCode))
                    {
                        shippingStockHistWork.BfSectionGuideNm = lstSec[shippingStockHistWork.BfSectionCode].SectionGuideNm;
                    }
                    else
                    {
                        shippingStockHistWork.BfSectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDESNMRF"));
                        if (shippingStockHistWork.BfSectionGuideNm.Length > 6) // ���̂�10���E�K�C�h����6���̂��߁A
                        {
                            shippingStockHistWork.BfSectionGuideNm = shippingStockHistWork.BfSectionGuideNm.Remove(6);
                        }
                    }
                    // 2010/10/13 Add <<<
                    // 2010/10/13 >>>
                    //shippingStockHistWork.SectionCode = shippingStockHistWork.InputSectionCd;
                    //shippingStockHistWork.SectionGuideNm = shippingStockHistWork.InputSectionGuidNm;
                    shippingStockHistWork.SectionCode = shippingStockHistWork.BfSectionCode;
                    shippingStockHistWork.SectionGuideNm = shippingStockHistWork.BfSectionGuideNm;
                    // 2010/10/13 <<<
                    shippingStockHistWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF"));
                    shippingStockHistWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
                    shippingStockHistWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSHELFNORF"));
                    //shippingStockHistWork.BfSectionCode = shippingStockHistWork.InputSectionCd; // 2010/10/13 Del
                    //shippingStockHistWork.BfSectionGuideNm = shippingStockHistWork.InputSectionGuidNm;  // 2010/10/13 Del

                    shippingStockHistWork.BfEnterWarehCode = shippingStockHistWork.WarehouseCode;
                    shippingStockHistWork.BfEnterWarehName = shippingStockHistWork.WarehouseName;
                    shippingStockHistWork.BfShelfNo = shippingStockHistWork.ShelfNo;

                    shippingStockHistWork.AfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONCODERF"));
                    if (lstSec.ContainsKey(shippingStockHistWork.AfSectionCode))
                    {
                        shippingStockHistWork.AfSectionGuideNm = lstSec[shippingStockHistWork.AfSectionCode].SectionGuideNm;
                    }
                    else
                    {
                        shippingStockHistWork.AfSectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDESNMRF"));
                        if (shippingStockHistWork.AfSectionGuideNm.Length > 6) // ���̂�10���E�K�C�h����6���̂��߁A
                        {
                            shippingStockHistWork.AfSectionGuideNm = shippingStockHistWork.AfSectionGuideNm.Remove(6);
                        }
                    }
                    shippingStockHistWork.AfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF"));
                    shippingStockHistWork.AfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
                    shippingStockHistWork.AfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSHELFNORF"));

                    shippingStockHistWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTRF"));
                    shippingStockHistWork.OpenPriceDiv = 0; // 0:�ʏ�
                    shippingStockHistWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
                    //shippingStockHistWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    shippingStockHistWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    double price = shippingStockHistWork.SalesUnPrcTaxExcFl * shippingStockHistWork.ShipmentCnt;
                    //shippingStockHistWork.StockPrice = GetStockPrice(price);
                    shippingStockHistWork.SalesMoney = GetStockPrice(price);
                    #endregion
                    
                    // 2009/06/19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //mode��1�̏ꍇ�A�݌Ɉړ��`����1:�݌Ɉړ��i�o�Ɂj,2:�q�Ɉړ��i�o�Ɂj�̏ꍇ�ɏo�׃��R�[�h���쐬����
                    int stockMoveFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEFORMALRF"));

                    // 2010/10/08 Add >>>
                    bool updflg = true;
                    if (mode == 1)
                    {
                        // �݌Ƀ}�X�^Read�@�Ȃ���΁A�݌Ɉړ��̍ۂ͐V�K�ǉ����Ȃ�
                        StockDB stockDB = new StockDB();
                        StockWork stWork = new StockWork();
                        stWork.EnterpriseCode = _enterpriseCode;
                        stWork.WarehouseCode = shippingStockHistWork.BfEnterWarehCode;
                        stWork.GoodsMakerCd = shippingStockHistWork.GoodsMakerCd;
                        stWork.GoodsNo = shippingStockHistWork.GoodsNo;

                        int stockstatus = stockDB.ReadProc(ref stWork, 0, ref sqlConnection, ref sqlTransaction);

                        if (stockstatus != 0)
                        {
                            if (stockMoveFormal == 1 || stockMoveFormal == 3)
                                updflg = false;
                        }

                    }
                    StockAcPayHistWork deleteShippingStockHistWork = null;
                    StockAcPayHistWork deletearrivalStockHistWork = null;
                    int logicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    // 2010/10/08 Add <<<

                    //// 2009/03/23 >>>>>>>>>>>>>>>>>>>>>>>>>
                    //// ���o�׍쐬���[�h�̏ꍇ�͖������A���ׂ̂ݍ쐬���[�h�̏ꍇ�͓��ד������ݒ�̃��R�[�h�̂ݏo�ׂ̎󕥗����f�[�^���쐬����
                    //if (mode == 0 || SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF")) == DateTime.MinValue)
                    //// 2009/03/23 <<<<<<<<<<<<<<<<<<<<<<<<<
                    // 2010/09/17 mode�̐ؑւ��t >>>
                    //if (mode == 0 || (mode == 1 && (stockMoveFormal == 1 || stockMoveFormal == 2)))
                    if ((mode == 1 || (mode == 0 && (stockMoveFormal == 1 || stockMoveFormal == 2))) && updflg)
                    // 2010/09/17 <<<
                    // 2009/06/19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    {
                        // 2010/10/13 Add >>>
                        #region [�ړ��o�ׁE�폜��]
                        if (logicalDeleteCode == 1)
                        {
                            deleteShippingStockHistWork = new StockAcPayHistWork();
                            deleteShippingStockHistWork.LogicalDeleteCode = 0;
                            deleteShippingStockHistWork.IoGoodsDay = shippingStockHistWork.IoGoodsDay;
                            deleteShippingStockHistWork.AcPaySlipCd = 30; // 30:�ړ��o��
                            deleteShippingStockHistWork.AcPaySlipNum = shippingStockHistWork.AcPaySlipNum;
                            deleteShippingStockHistWork.AcPaySlipRowNo = shippingStockHistWork.AcPaySlipRowNo;
                            deleteShippingStockHistWork.AcPayTransCd = 21; // 21:�폜

                            deleteShippingStockHistWork.InputSectionCd = shippingStockHistWork.InputSectionCd;
                            deleteShippingStockHistWork.InputSectionGuidNm = shippingStockHistWork.InputSectionGuidNm;
                            deleteShippingStockHistWork.InputAgenCd = shippingStockHistWork.InputAgenCd;
                            deleteShippingStockHistWork.InputAgenNm = shippingStockHistWork.InputAgenNm;

                            deleteShippingStockHistWork.MoveStatus = shippingStockHistWork.MoveStatus;
                            deleteShippingStockHistWork.GoodsMakerCd = shippingStockHistWork.GoodsMakerCd;
                            deleteShippingStockHistWork.MakerName = shippingStockHistWork.MakerName;
                            deleteShippingStockHistWork.GoodsNo = shippingStockHistWork.GoodsNo;
                            deleteShippingStockHistWork.GoodsName = shippingStockHistWork.GoodsName;
                            deleteShippingStockHistWork.BLGoodsCode = shippingStockHistWork.BLGoodsCode;
                            deleteShippingStockHistWork.BLGoodsFullName = shippingStockHistWork.BLGoodsFullName;

                            deleteShippingStockHistWork.SectionCode = shippingStockHistWork.InputSectionCd;
                            deleteShippingStockHistWork.SectionGuideNm = shippingStockHistWork.InputSectionGuidNm;
                            deleteShippingStockHistWork.WarehouseCode = shippingStockHistWork.WarehouseCode;
                            deleteShippingStockHistWork.WarehouseName = shippingStockHistWork.WarehouseName;
                            deleteShippingStockHistWork.ShelfNo = shippingStockHistWork.ShelfNo;
                            deleteShippingStockHistWork.BfSectionCode = shippingStockHistWork.InputSectionCd;
                            deleteShippingStockHistWork.BfSectionGuideNm = shippingStockHistWork.InputSectionGuidNm;

                            deleteShippingStockHistWork.BfEnterWarehCode = shippingStockHistWork.WarehouseCode;
                            deleteShippingStockHistWork.BfEnterWarehName = shippingStockHistWork.WarehouseName;
                            deleteShippingStockHistWork.BfShelfNo = shippingStockHistWork.ShelfNo;

                            deleteShippingStockHistWork.AfSectionCode = shippingStockHistWork.AfSectionCode;
                            deleteShippingStockHistWork.AfSectionGuideNm = shippingStockHistWork.AfSectionGuideNm;
                            deleteShippingStockHistWork.AfEnterWarehCode = shippingStockHistWork.AfEnterWarehCode;
                            deleteShippingStockHistWork.AfEnterWarehName = shippingStockHistWork.AfEnterWarehName;
                            deleteShippingStockHistWork.AfShelfNo = shippingStockHistWork.AfShelfNo;

                            deleteShippingStockHistWork.ShipmentCnt = -shippingStockHistWork.ShipmentCnt;
                            deleteShippingStockHistWork.OpenPriceDiv = shippingStockHistWork.OpenPriceDiv; // 0:�ʏ�
                            deleteShippingStockHistWork.ListPriceTaxExcFl = shippingStockHistWork.ListPriceTaxExcFl;
                            deleteShippingStockHistWork.SalesUnPrcTaxExcFl = shippingStockHistWork.SalesUnPrcTaxExcFl;
                            price = deleteShippingStockHistWork.SalesUnPrcTaxExcFl * deleteShippingStockHistWork.ShipmentCnt;
                            deleteShippingStockHistWork.SalesMoney = GetStockPrice(price);
                        }
                        else
                        {
                            deleteShippingStockHistWork = null;
                        }
                        #endregion
                        // 2010/10/13 Add <<<
                        if (shippingStockHistWork.IoGoodsDay != prevDateTimeShipping) // ������t���O��f�[�^�ƈႤ���H�i����ڂӂ��߁j                        
                        {
                            if (innerListShipping != null)
                            {
                                if (stockAcPayHistDB == null)
                                    stockAcPayHistDB = new StockAcPayHistDB();
                                //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerListShipping, prevDateTimeShipping.Ticks, ref sqlConnection, ref sqlTransaction);
                                status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerListShipping, ref sqlConnection, ref sqlTransaction);
                                if (status == 0)
                                    cnt += innerListShipping.Count;
                                else
                                    break;
                            }
                            innerListShipping = new ArrayList();
                            prevDateTimeShipping = shippingStockHistWork.IoGoodsDay;
                        }
                        innerListShipping.Add(shippingStockHistWork);
                        // 2010/10/13 Add >>>
                        if (deleteShippingStockHistWork != null)
                        {
                            innerListShipping.Add(deleteShippingStockHistWork);
                        }
                        // 2010/10/13 Add <<<

                    } // 2009/03/23 

                    #region [ �ړ����� ]
                    StockAcPayHistWork arrivalStockHistWork = new StockAcPayHistWork(); // �ړ�����
                    arrivalStockHistWork.LogicalDeleteCode = 0;
                    arrivalStockHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF")); // ���ד�
                    // 2009/03/27 MANTIS 12532 >>>>>>>>>>>>>>>>>
                    //// 2009/02/25 MANTIS 11630 >>>>>>>>>>>>>>>>>>
                    //if (arrivalStockHistWork.IoGoodsDay == DateTime.MinValue)
                    //{
                    //    //���ד���NULL�̏ꍇ�͏o�׊m������Z�b�g
                    //    arrivalStockHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTFIXDAYRF")); // �o�׊m���
                    //}
                    //// 2009/02/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    // 2009/03/27 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    arrivalStockHistWork.AddUpADate = arrivalStockHistWork.IoGoodsDay;
                    arrivalStockHistWork.AcPaySlipCd = 31; // 31:�ړ�����
                    arrivalStockHistWork.AcPaySlipNum = shippingStockHistWork.AcPaySlipNum;
                    arrivalStockHistWork.AcPaySlipRowNo = shippingStockHistWork.AcPaySlipRowNo;
                    arrivalStockHistWork.AcPayTransCd = 10; // 10:�ʏ�`�[

                    // 2010/10/13 >>>
                    //arrivalStockHistWork.InputSectionCd = shippingStockHistWork.AfSectionCode;
                    //arrivalStockHistWork.InputSectionGuidNm = shippingStockHistWork.AfSectionGuideNm;
                    arrivalStockHistWork.InputSectionCd = shippingStockHistWork.InputSectionCd;
                    arrivalStockHistWork.InputSectionGuidNm = shippingStockHistWork.InputSectionGuidNm;
                    // 2010/10/13 <<<
                    arrivalStockHistWork.InputAgenCd = shippingStockHistWork.InputAgenCd;
                    arrivalStockHistWork.InputAgenNm = shippingStockHistWork.InputAgenNm;
                    // 2010/09/17 >>>
                    //arrivalStockHistWork.MoveStatus = 9; // 9:���׍�
                    arrivalStockHistWork.MoveStatus = shippingStockHistWork.MoveStatus; // 9:���׍�
                    // 2010/09/17 <<<
                    arrivalStockHistWork.GoodsMakerCd = shippingStockHistWork.GoodsMakerCd;
                    arrivalStockHistWork.MakerName = shippingStockHistWork.MakerName;
                    arrivalStockHistWork.GoodsNo = shippingStockHistWork.GoodsNo;
                    arrivalStockHistWork.GoodsName = shippingStockHistWork.GoodsName;
                    arrivalStockHistWork.BLGoodsCode = shippingStockHistWork.BLGoodsCode;
                    arrivalStockHistWork.BLGoodsFullName = shippingStockHistWork.BLGoodsFullName;

                    // 2010/10/13 >>>
                    //arrivalStockHistWork.SectionCode = arrivalStockHistWork.InputSectionCd;
                    //arrivalStockHistWork.SectionGuideNm = arrivalStockHistWork.InputSectionGuidNm;
                    arrivalStockHistWork.SectionCode = shippingStockHistWork.AfSectionCode;
                    arrivalStockHistWork.SectionGuideNm = shippingStockHistWork.AfSectionGuideNm;
                    // 2010/10/13 <<<
                    arrivalStockHistWork.WarehouseCode = shippingStockHistWork.AfEnterWarehCode;
                    arrivalStockHistWork.WarehouseName = shippingStockHistWork.AfEnterWarehName;
                    arrivalStockHistWork.ShelfNo = shippingStockHistWork.AfShelfNo;

                    arrivalStockHistWork.BfSectionCode = shippingStockHistWork.BfSectionCode;
                    arrivalStockHistWork.BfSectionGuideNm = shippingStockHistWork.BfSectionGuideNm;
                    arrivalStockHistWork.BfEnterWarehCode = shippingStockHistWork.BfEnterWarehCode;
                    arrivalStockHistWork.BfEnterWarehName = shippingStockHistWork.BfEnterWarehName;
                    arrivalStockHistWork.BfShelfNo = shippingStockHistWork.BfShelfNo;

                    arrivalStockHistWork.AfSectionCode = shippingStockHistWork.AfSectionCode;
                    arrivalStockHistWork.AfSectionGuideNm = shippingStockHistWork.AfSectionGuideNm;
                    arrivalStockHistWork.AfEnterWarehCode = shippingStockHistWork.AfEnterWarehCode;
                    arrivalStockHistWork.AfEnterWarehName = shippingStockHistWork.AfEnterWarehName;
                    arrivalStockHistWork.AfShelfNo = shippingStockHistWork.AfShelfNo;

                    arrivalStockHistWork.ArrivalCnt = shippingStockHistWork.ShipmentCnt;
                    arrivalStockHistWork.OpenPriceDiv = 0; // 0:�ʏ�
                    arrivalStockHistWork.ListPriceTaxExcFl = shippingStockHistWork.ListPriceTaxExcFl;
                    //arrivalStockHistWork.StockUnitPriceFl = shippingStockHistWork.StockUnitPriceFl;
                    arrivalStockHistWork.StockUnitPriceFl = shippingStockHistWork.SalesUnPrcTaxExcFl;
                    price = arrivalStockHistWork.StockUnitPriceFl * arrivalStockHistWork.ArrivalCnt;
                    arrivalStockHistWork.StockPrice = GetStockPrice(price);
                    #endregion

                    // 2009/06/19 >>>>>>>>>>>>>>>>>>>
                    //mode��1�̏ꍇ�A�݌Ɉړ��`����3:�݌Ɉړ��i���Ɂj,4:�q�Ɉړ��i���Ɂj�̏ꍇ�ɓ��׃��R�[�h���쐬����

                    // 2010/10/08 Add >>>
                    updflg = true;
                    if (mode == 1)
                    {
                        // �݌Ƀ}�X�^Read�@�Ȃ���΁A�݌Ɉړ��̍ۂ͐V�K�ǉ����Ȃ�
                        StockDB stockDB = new StockDB();
                        StockWork stWork = new StockWork();
                        stWork.EnterpriseCode = _enterpriseCode;
                        stWork.WarehouseCode = shippingStockHistWork.AfEnterWarehCode;
                        stWork.GoodsMakerCd = shippingStockHistWork.GoodsMakerCd;
                        stWork.GoodsNo = shippingStockHistWork.GoodsNo;

                        int stockstatus = stockDB.ReadProc(ref stWork, 0, ref sqlConnection, ref sqlTransaction);

                        if (stockstatus != 0)
                        {
                            if (stockMoveFormal == 1 || stockMoveFormal == 3)
                                updflg = false;
                        }

                    }
                    // 2010/10/08 Add <<<
                    //// 2009/03/23 >>>>>>>>>>>>>>>
                    //// ���ד����Z�b�g����Ă���ꍇ�̂݁A���׍ς݂Ƃ��ē��ׂ̎󕥗����f�[�^���쐬����
                    //if (SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF")) != DateTime.MinValue)
                    //// 2009/03/23 <<<<<<<<<<<<<<<
                    // 2010/09/17 mode�̐ؑւ��t >>>
                    //if (mode == 0 || (mode == 1 && (stockMoveFormal == 3 || stockMoveFormal == 4)))
                    if ((mode == 1 || (mode == 0 && (stockMoveFormal == 3 || stockMoveFormal == 4))) && updflg)
                    // 2010/09/17 <<<
                    // 2009/06/19 <<<<<<<<<<<<<<<<<<<
                    {
                        // 2010/10/13 Add >>>
                        if (logicalDeleteCode == 1)
                        {
                            deletearrivalStockHistWork = new StockAcPayHistWork();
                            deletearrivalStockHistWork.LogicalDeleteCode = 0;
                            deletearrivalStockHistWork.IoGoodsDay = arrivalStockHistWork.IoGoodsDay; // ���ד�
                            deletearrivalStockHistWork.AddUpADate = arrivalStockHistWork.IoGoodsDay;
                            deletearrivalStockHistWork.AcPaySlipCd = 31; // 31:�ړ�����
                            deletearrivalStockHistWork.AcPaySlipNum = arrivalStockHistWork.AcPaySlipNum;
                            deletearrivalStockHistWork.AcPaySlipRowNo = arrivalStockHistWork.AcPaySlipRowNo;
                            deletearrivalStockHistWork.AcPayTransCd = 21; // 21:�폜

                            deletearrivalStockHistWork.InputSectionCd = arrivalStockHistWork.InputSectionCd;
                            deletearrivalStockHistWork.InputSectionGuidNm = arrivalStockHistWork.AfSectionGuideNm;
                            deletearrivalStockHistWork.InputAgenCd = arrivalStockHistWork.InputAgenCd;
                            deletearrivalStockHistWork.InputAgenNm = arrivalStockHistWork.InputAgenNm;
                            deletearrivalStockHistWork.MoveStatus = arrivalStockHistWork.MoveStatus; // 9:���׍�
                            deletearrivalStockHistWork.GoodsMakerCd = arrivalStockHistWork.GoodsMakerCd;
                            deletearrivalStockHistWork.MakerName = arrivalStockHistWork.MakerName;
                            deletearrivalStockHistWork.GoodsNo = arrivalStockHistWork.GoodsNo;
                            deletearrivalStockHistWork.GoodsName = arrivalStockHistWork.GoodsName;
                            deletearrivalStockHistWork.BLGoodsCode = arrivalStockHistWork.BLGoodsCode;
                            deletearrivalStockHistWork.BLGoodsFullName = arrivalStockHistWork.BLGoodsFullName;

                            deletearrivalStockHistWork.SectionCode = arrivalStockHistWork.InputSectionCd;
                            deletearrivalStockHistWork.SectionGuideNm = arrivalStockHistWork.InputSectionGuidNm;
                            deletearrivalStockHistWork.WarehouseCode = arrivalStockHistWork.AfEnterWarehCode;
                            deletearrivalStockHistWork.WarehouseName = arrivalStockHistWork.AfEnterWarehName;
                            deletearrivalStockHistWork.ShelfNo = arrivalStockHistWork.AfShelfNo;

                            deletearrivalStockHistWork.BfSectionCode = arrivalStockHistWork.BfSectionCode;
                            deletearrivalStockHistWork.BfSectionGuideNm = arrivalStockHistWork.BfSectionGuideNm;
                            deletearrivalStockHistWork.BfEnterWarehCode = arrivalStockHistWork.BfEnterWarehCode;
                            deletearrivalStockHistWork.BfEnterWarehName = arrivalStockHistWork.BfEnterWarehName;
                            deletearrivalStockHistWork.BfShelfNo = arrivalStockHistWork.BfShelfNo;

                            deletearrivalStockHistWork.AfSectionCode = arrivalStockHistWork.AfSectionCode;
                            deletearrivalStockHistWork.AfSectionGuideNm = arrivalStockHistWork.AfSectionGuideNm;
                            deletearrivalStockHistWork.AfEnterWarehCode = arrivalStockHistWork.AfEnterWarehCode;
                            deletearrivalStockHistWork.AfEnterWarehName = arrivalStockHistWork.AfEnterWarehName;
                            deletearrivalStockHistWork.AfShelfNo = arrivalStockHistWork.AfShelfNo;

                            deletearrivalStockHistWork.ArrivalCnt = -arrivalStockHistWork.ArrivalCnt;
                            deletearrivalStockHistWork.OpenPriceDiv = 0; // 0:�ʏ�
                            deletearrivalStockHistWork.ListPriceTaxExcFl = arrivalStockHistWork.ListPriceTaxExcFl;
                            deletearrivalStockHistWork.StockUnitPriceFl = arrivalStockHistWork.StockUnitPriceFl;
                            price = deletearrivalStockHistWork.StockUnitPriceFl * deletearrivalStockHistWork.ArrivalCnt;
                            deletearrivalStockHistWork.StockPrice = GetStockPrice(price);
                        }
                        else
                        {
                            deletearrivalStockHistWork = null;
                        }
                        // 2010/10/13 Add <<<
                        
                        if (arrivalStockHistWork.IoGoodsDay != prevDateTimeArrival) // ������t���O��f�[�^�ƈႤ���H�i����ڂӂ��߁j                        
                        {
                            if (innerListArrival != null)
                            {
                                if (stockAcPayHistDB == null)
                                    stockAcPayHistDB = new StockAcPayHistDB();
                                //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerListArrival, prevDateTimeArrival.Ticks, ref sqlConnection, ref sqlTransaction);
                                status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerListArrival, ref sqlConnection, ref sqlTransaction);
                                if (status == 0)
                                    cnt += innerListArrival.Count;
                                else
                                    break;
                            }
                            innerListArrival = new ArrayList();
                            prevDateTimeArrival = arrivalStockHistWork.IoGoodsDay;
                        }
                        innerListArrival.Add(arrivalStockHistWork);
                        // 2010/10/13 Add >>>
                        if (deletearrivalStockHistWork != null)
                        {
                            innerListArrival.Add(deletearrivalStockHistWork);
                        }
                        // 2010/10/13 Add <<<

                    } //2009/03/23
                }

                if (innerListShipping != null && innerListShipping.Count > 0)
                {
                    if (stockAcPayHistDB == null)
                        stockAcPayHistDB = new StockAcPayHistDB();
                    //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerListShipping, prevDateTimeShipping.Ticks, ref sqlConnection, ref sqlTransaction);
                    status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerListShipping, ref sqlConnection, ref sqlTransaction);
                    if (status == 0)
                        cnt += innerListShipping.Count;
                }
                if (innerListArrival != null && innerListArrival.Count > 0)
                {
                    if (stockAcPayHistDB == null)
                        stockAcPayHistDB = new StockAcPayHistDB();
                    //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerListArrival, prevDateTimeArrival.Ticks, ref sqlConnection, ref sqlTransaction);
                    status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerListArrival, ref sqlConnection, ref sqlTransaction);
                    if (status == 0)
                        cnt += innerListArrival.Count;
                }
                if (cnt == 0) // 0���͐���ƌ��Ȃ��B
                {
                    status = 0;
                }
            }
            // --- UPD 2011/09/06---------->>>>>
            // catch { }
            catch (SqlException ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockMove", "�݌Ɉړ�����݌Ɏ󕥗����f�[�^�ݒ�[" + ex.Message + "]", ex.Number);
            }
            catch (Exception ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockMove", "�݌Ɉړ�����݌Ɏ󕥗����f�[�^�ݒ�[" + ex.Message + "]", status);
            }
            // --- UPD 2011/09/06----------<<<<<
            finally
            {
                if (myReader != null)
                    myReader.Dispose();
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (sqlCon != null)
                    sqlCon.Dispose();
            }
            #endregion

            // --- ADD 2011/09/06---------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockMove", "�݌Ɉړ�����݌Ɏ󕥗����f�[�^�ݒ�", status);
            }
            // --- ADD 2011/09/06----------<<<<<

            return status;
        }

        /// <summary>
        /// �݌Ɏd��[�݌ɒ���]����݌Ɏ󕥗����f�[�^�ݒ�
        /// </summary>
        /// <param name="cnt">�����f�[�^�J�E���^</param>
        private int SetStockAcPayHistFromStockAdjust(out int cnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            cnt = 0;
            ArrayList lst = new ArrayList();
            if (lstSec == null)
                GetSectionInfo();
            if (lstBLCode == null)
                GetBlInfo();
            //if (lstFractionInfo == null)
            //    GetStockProcMoneyInfo();
            //if (lstFractionInfo == null) // GetStockProcMoneyInfo�����Œ[���������擾���s�����ꍇ�����𒆒f
            //    return status;
            #region [ �݌Ɏd��[�݌ɒ���]����݌Ɏ󕥏��擾 ]
            SqlConnection sqlCon = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            try
            {
                sqlCon = new SqlConnection(connectionText);
                sqlCon.Open();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlCon;

                string sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "STAD.LOGICALDELETECODERF," + Environment.NewLine;   // 2010/10/20 Add
                sqlText += "STAD.SECTIONCODERF AS INPUTSECTIONCODERF," + Environment.NewLine;
                sqlText += "STAD.STOCKINPUTCODERF," + Environment.NewLine;
                sqlText += "STAD.STOCKINPUTNAMERF," + Environment.NewLine;

                sqlText += "SADT.SECTIONCODERF," + Environment.NewLine;
                sqlText += "SADT.STOCKADJUSTSLIPNORF," + Environment.NewLine;
                sqlText += "SADT.STOCKADJUSTROWNORF," + Environment.NewLine;
                sqlText += "SADT.ACPAYSLIPCDRF," + Environment.NewLine;
                sqlText += "SADT.ACPAYTRANSCDRF," + Environment.NewLine;
                sqlText += "SADT.ADJUSTDATERF," + Environment.NewLine;
                sqlText += "SADT.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "SADT.MAKERNAMERF," + Environment.NewLine;
                sqlText += "SADT.GOODSNORF," + Environment.NewLine;
                sqlText += "SADT.GOODSNAMERF," + Environment.NewLine;
                sqlText += "SADT.STOCKUNITPRICEFLRF," + Environment.NewLine;
                sqlText += "SADT.ADJUSTCOUNTRF," + Environment.NewLine;
                sqlText += "SADT.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "SADT.WAREHOUSENAMERF," + Environment.NewLine;
                sqlText += "SADT.BLGOODSCODERF," + Environment.NewLine;
                sqlText += "SADT.WAREHOUSESHELFNORF," + Environment.NewLine;
                sqlText += "SADT.LISTPRICEFLRF," + Environment.NewLine;
                sqlText += "SADT.STOCKPRICETAXEXCRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  STOCKADJUSTRF AS STAD" + Environment.NewLine;
                sqlText += "  INNER JOIN STOCKADJUSTDTLRF AS SADT" + Environment.NewLine;
                sqlText += " ON STAD.STOCKADJUSTSLIPNORF = SADT.STOCKADJUSTSLIPNORF";

                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandTimeout = 300;// 2012/04/27 Add

                ArrayList innerList = null;
                DateTime prevDateTime = DateTime.MaxValue;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StockAcPayHistWork stockAcPayHistWork = new StockAcPayHistWork();
                    StockAcPayHistWork stockAcPayHistDeleteWork = null; // 2010/10/20 Add
                    stockAcPayHistWork.LogicalDeleteCode = 0;
                    stockAcPayHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADJUSTDATERF"));
                    stockAcPayHistWork.AddUpADate = stockAcPayHistWork.IoGoodsDay;
                    stockAcPayHistWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
                    stockAcPayHistWork.AcPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF")).ToString();
                    stockAcPayHistWork.AcPaySlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTROWNORF"));
                    stockAcPayHistWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));

                    stockAcPayHistWork.InputSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTSECTIONCODERF"));
                    if (lstSec.ContainsKey(stockAcPayHistWork.InputSectionCd))
                    {
                        stockAcPayHistWork.InputSectionGuidNm = lstSec[stockAcPayHistWork.InputSectionCd].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.InputSectionGuidNm = "";
                    }
                    stockAcPayHistWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
                    stockAcPayHistWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
                    stockAcPayHistWork.MoveStatus = 0; // 0:�ړ��ΏۊO
                    stockAcPayHistWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockAcPayHistWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    stockAcPayHistWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockAcPayHistWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    stockAcPayHistWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    if (lstBLCode.ContainsKey(stockAcPayHistWork.BLGoodsCode))
                    {
                        stockAcPayHistWork.BLGoodsFullName = lstBLCode[stockAcPayHistWork.BLGoodsCode].BLGoodsFullName;
                    }
                    else
                    {
                        stockAcPayHistWork.BLGoodsFullName = "";
                    }
                    stockAcPayHistWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    if (lstSec.ContainsKey(stockAcPayHistWork.SectionCode))
                    {
                        stockAcPayHistWork.SectionGuideNm = lstSec[stockAcPayHistWork.SectionCode].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.SectionGuideNm = "";
                    }
                    stockAcPayHistWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockAcPayHistWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    stockAcPayHistWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    // 2010/10/20 Add >>>
                    if (stockAcPayHistWork.AcPaySlipCd == 71)
                    {
                        double shipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));
                        stockAcPayHistWork.ShipmentCnt = -shipmentCnt;
                        // 2010/10/21 Add >>>
                        double salesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                        long salesMoney = SqlDataMediator.SqlGetLong(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                        stockAcPayHistWork.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
                        stockAcPayHistWork.SalesMoney = -salesMoney;
                        // 2010/10/21 Add <<<
                    }
                    else
                    // 2010/10/20 Add <<<
                    // 2010/10/21 Add >>>
                    {
                        stockAcPayHistWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                        stockAcPayHistWork.StockPrice = SqlDataMediator.SqlGetLong(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                        // 2010/10/21 Add <<<
                        stockAcPayHistWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));
                    }   // 2010/10/21 Add
                    stockAcPayHistWork.OpenPriceDiv = 0; // 0:�ʏ�
                    stockAcPayHistWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
                    // 2010/10/21 Del >>>
                    //stockAcPayHistWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    //stockAcPayHistWork.StockPrice = SqlDataMediator.SqlGetLong(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                    // 2010/10/21 Del <<<
                    //double price = stockAcPayHistWork.StockUnitPriceFl * stockAcPayHistWork.ArrivalCnt;
                    //stockAcPayHistWork.StockPrice = GetStockPrice(price);


                    // 2010/10/20 Add >>>
                    int logcalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    if (logcalDeleteCode == 1)
                    {
                        stockAcPayHistDeleteWork = new StockAcPayHistWork();
                        stockAcPayHistDeleteWork.LogicalDeleteCode = 0;
                        stockAcPayHistDeleteWork.IoGoodsDay = stockAcPayHistWork.IoGoodsDay;
                        stockAcPayHistDeleteWork.AddUpADate = stockAcPayHistDeleteWork.IoGoodsDay;
                        stockAcPayHistDeleteWork.AcPaySlipCd = stockAcPayHistWork.AcPaySlipCd;
                        stockAcPayHistDeleteWork.AcPaySlipNum = stockAcPayHistWork.AcPaySlipNum;
                        stockAcPayHistDeleteWork.AcPaySlipRowNo = stockAcPayHistWork.AcPaySlipRowNo;
                        stockAcPayHistDeleteWork.AcPayTransCd = 21; // 21:�폜

                        stockAcPayHistDeleteWork.InputSectionCd = stockAcPayHistWork.InputSectionCd;
                        stockAcPayHistDeleteWork.InputSectionGuidNm = stockAcPayHistWork.InputSectionGuidNm;
                        stockAcPayHistDeleteWork.InputAgenCd = stockAcPayHistWork.InputAgenCd;
                        stockAcPayHistDeleteWork.InputAgenNm = stockAcPayHistWork.InputAgenNm;
                        stockAcPayHistDeleteWork.MoveStatus = 0; // 0:�ړ��ΏۊO
                        stockAcPayHistDeleteWork.GoodsMakerCd = stockAcPayHistWork.GoodsMakerCd;
                        stockAcPayHistDeleteWork.MakerName = stockAcPayHistWork.MakerName;
                        stockAcPayHistDeleteWork.GoodsNo = stockAcPayHistWork.GoodsNo;
                        stockAcPayHistDeleteWork.GoodsName = stockAcPayHistWork.GoodsName;
                        stockAcPayHistDeleteWork.BLGoodsCode = stockAcPayHistWork.BLGoodsCode;
                        stockAcPayHistDeleteWork.BLGoodsFullName = stockAcPayHistWork.BLGoodsFullName;
                        stockAcPayHistDeleteWork.SectionCode = stockAcPayHistWork.SectionCode;
                        stockAcPayHistDeleteWork.SectionGuideNm = stockAcPayHistWork.SectionGuideNm;
                        stockAcPayHistDeleteWork.WarehouseCode = stockAcPayHistWork.WarehouseCode;
                        stockAcPayHistDeleteWork.WarehouseName = stockAcPayHistWork.WarehouseName;
                        stockAcPayHistDeleteWork.ShelfNo = stockAcPayHistWork.ShelfNo;
                        stockAcPayHistDeleteWork.ArrivalCnt = -stockAcPayHistWork.ArrivalCnt;
                        stockAcPayHistDeleteWork.OpenPriceDiv = 0; // 0:�ʏ�
                        stockAcPayHistDeleteWork.ListPriceTaxExcFl = stockAcPayHistWork.ListPriceTaxExcFl;
                        stockAcPayHistDeleteWork.StockUnitPriceFl = stockAcPayHistWork.StockUnitPriceFl;
                        stockAcPayHistDeleteWork.StockPrice = -stockAcPayHistWork.StockPrice;
                    }
                    else
                    {
                        stockAcPayHistDeleteWork = null;
                    }
                    // 2010/10/20 Add <<<
                    if (stockAcPayHistWork.IoGoodsDay != prevDateTime) // ������t���O��f�[�^�ƈႤ���H�i����ڂӂ��߁j                        
                    {
                        if (innerList != null)
                        {
                            if (stockAcPayHistDB == null)
                                stockAcPayHistDB = new StockAcPayHistDB();
                            //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                            status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                            if (status == 0)
                                cnt += innerList.Count;
                            else
                                break;
                        }
                        innerList = new ArrayList();
                    }
                    innerList.Add(stockAcPayHistWork);
                    // 2010/10/20 Add >>>
                    if (stockAcPayHistDeleteWork != null)
                    {
                        innerList.Add(stockAcPayHistDeleteWork);
                    }
                    // 2010/10/20 Add <<<
                    prevDateTime = stockAcPayHistWork.IoGoodsDay;
                }
                if (innerList != null && innerList.Count > 0)
                {
                    if (stockAcPayHistDB == null)
                        stockAcPayHistDB = new StockAcPayHistDB();
                    //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                    status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                    if (status == 0)
                        cnt += innerList.Count;
                }
                else if (cnt == 0) // 0���͐���ƌ��Ȃ��B
                {
                    status = 0;
                }
            }
            // --- UPD 2011/09/06---------->>>>>
            // catch { }
            catch (SqlException ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockAdjust", "�݌Ɏd��[�݌ɒ���]����݌Ɏ󕥗����f�[�^�ݒ�[" + ex.Message + "]", ex.Number);
            }
            catch (Exception ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockAdjust", "�݌Ɏd��[�݌ɒ���]����݌Ɏ󕥗����f�[�^�ݒ�[" + ex.Message + "]", status);
            }
            // --- UPD 2011/09/06----------<<<<<
            finally
            {
                if (myReader != null)
                    myReader.Dispose();
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (sqlCon != null)
                    sqlCon.Dispose();
            }
            #endregion

            // --- ADD 2011/09/06---------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockAdjust", "�݌Ɏd��[�݌ɒ���]����݌Ɏ󕥗����f�[�^�ݒ�", status);
            }
            // --- ADD 2011/09/06----------<<<<<

            return status;
        }
        #endregion

        #region [ �f�[�^�⑫�����̂��߂̃}�X�^�擾 ]
        /// <summary>
        /// ���_�}�X�^���擾
        /// </summary>
        private void GetSectionInfo()
        {
            SqlConnection sqlCon = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            try
            {
                sqlCon = new SqlConnection(connectionText);
                sqlCon.Open();

                if (sqlCon != null)
                {
                    SectionInfo sectionInfo = new SectionInfo();
                    lstSec = new Dictionary<string, SecInfoSetWork>();

                    CustomSerializeArrayList retList = null;
                    SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
                    secInfoSetWork.EnterpriseCode = _enterpriseCode;
                    int status = sectionInfo.Search(out retList, secInfoSetWork, ref sqlCon, 0, ConstantManagement.LogicalMode.GetDataAll);
                    if (status == 0 && retList.Count > 0)
                    {
                        if (retList[0] is ArrayList)
                        {
                            foreach (ArrayList list in retList)
                            {
                                if (list.Count > 0 && list[0] is SecInfoSetWork)
                                {
                                    foreach (SecInfoSetWork sec in list)
                                    {
                                        lstSec.Add(sec.SectionCode, sec);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            finally
            {
                if (sqlCon != null)
                    sqlCon.Dispose();
            }
        }

        /// <summary>
        /// BL�}�X�^���擾
        /// </summary>
        private void GetBlInfo()
        {
            SqlConnection sqlCon = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            try
            {
                sqlCon = new SqlConnection(connectionText);
                sqlCon.Open();

                if (sqlCon != null)
                {
                    BLGoodsCdUDB bLGoodsCdUDB = new BLGoodsCdUDB();
                    lstBLCode = new Dictionary<int, BLGoodsCdUWork>();

                    ArrayList retList = null;
                    BLGoodsCdUWork bLGoodsCdUWork = new BLGoodsCdUWork();
                    bLGoodsCdUWork.EnterpriseCode = _enterpriseCode;
                    int status = bLGoodsCdUDB.SearchBLGoodsCdProc(out retList, bLGoodsCdUWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlCon);
                    if (status == 0)
                    {
                        foreach (BLGoodsCdUWork bl in retList)
                        {
                            lstBLCode.Add(bl.BLGoodsCode, bl);
                        }
                    }
                }
            }
            catch { }
            finally
            {
                if (sqlCon != null)
                    sqlCon.Dispose();
            }
        }

        #region [DELETE]
        // �݌ɒ����E�݌Ɉړ��͌Œ�Ŏl�̌ܓ�����悤�ɂȂ������߉��L�����͕s�v 2008.12.05
        ///// <summary>
        ///// �d�����z�p�[���������擾[�s�v]
        ///// </summary>
        //private void GetStockProcMoneyInfo()
        //{
        //    SqlConnection sqlCon = null;
        //    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
        //    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
        //    try
        //    {
        //        sqlCon = new SqlConnection(connectionText);
        //        sqlCon.Open();

        //        if (sqlCon != null)
        //        {
        //            StockProcMoneyDB stockProcMoneyDB = new StockProcMoneyDB();

        //            ArrayList retList = null;
        //            StockProcMoneyWork stockProcMoneyWork = new StockProcMoneyWork();
        //            stockProcMoneyWork.EnterpriseCode = _enterpriseCode;
        //            stockProcMoneyWork.FracProcMoneyDiv = 0; // �[�������Ώۋ��z�敪[0:�d�����z]
        //            stockProcMoneyWork.FractionProcCd = 0; // ���Зp�i�W���j[ �d�����񂪂Ȃ����ߎ��Зp�[���R�[�h�g�p ]
        //            int status = stockProcMoneyDB.SearchStockProcMoneyProc(out retList, stockProcMoneyWork, 0,
        //                ConstantManagement.LogicalMode.GetData0, ref sqlCon);
        //            if (status == 0 && retList.Count > 0)
        //            {
        //                lstFractionInfo = new List<StockProcMoneyWork>();
        //                foreach (StockProcMoneyWork stockProckMoneyInfo in retList)
        //                {
        //                    bool addFlg = false;
        //                    for (int i = 0; i < lstFractionInfo.Count; i++) // ������z�̍~���ŕ��я���
        //                    {
        //                        if (stockProckMoneyInfo.UpperLimitPrice > lstFractionInfo[i].UpperLimitPrice)
        //                        {
        //                            lstFractionInfo.Insert(i, stockProckMoneyInfo);
        //                            addFlg = true;
        //                            break;
        //                        }
        //                    }
        //                    if (addFlg == false)
        //                    {
        //                        lstFractionInfo.Add(stockProckMoneyInfo);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch { }
        //    finally
        //    {
        //        if (sqlCon != null)
        //            sqlCon.Dispose();
        //    }
        //}
        #endregion

        /// <summary>
        /// �[���������s�����d�����z���Z�o����
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        private long GetStockPrice(double price)
        {
            double tmpRet;
            long retPrice = 0;
            //for (int i = 0; i < lstFractionInfo.Count; i++)
            //{
            //    if (lstFractionInfo[i].UpperLimitPrice > price)
            //    {
            //        FracCalc(price, lstFractionInfo[i].FractionProcUnit, lstFractionInfo[i].FractionProcCd, out tmpRet);
            //        retPrice = Convert.ToInt64(tmpRet);
            //        break;
            //    }
            //}
            // ���E�d���̏ꍇ�͒[���������s�v�Ȃ̂ō݌Ɋ֘A�����Ɋւ��Ă̂݉��L�̌Œ�l�̌ܓ���OK
            FracCalc(price, 1, 2, out tmpRet); // �[�������͎l�̌ܓ��Œ�Ƃ���
            retPrice = Convert.ToInt64(tmpRet);
            return retPrice;
        }

        /// <summary>
        /// �[������
        /// </summary>
        /// <param name="inputNumerical">���l</param>
        /// <param name="fractionUnit">�[�������P��</param>
        /// <param name="fractionProcess">�[�������i1:�؎� 2:�l�̌ܓ� 3:�؏�j</param>
        /// <param name="resultNumerical">�Z�o���z</param>
        private void FracCalc(double inputNumerical, double fractionUnit, Int32 fractionProcess, out double resultNumerical)
        {
            // �����l�Z�b�g
            resultNumerical = inputNumerical;

            inputNumerical = (double)((decimal)inputNumerical - ((decimal)inputNumerical % (decimal)0.000001));	// �����_6���ȉ��؎�
            fractionUnit = (double)((decimal)fractionUnit - ((decimal)fractionUnit % (decimal)0.000001));		// �����_6���ȉ��؎�

            // �[���P�ʂŏ��Z
            decimal tmpKin = (decimal)inputNumerical / (decimal)fractionUnit;

            // �}�C�i�X�␳
            bool sign = false;
            if (tmpKin < 0)
            {
                sign = true;
                tmpKin = tmpKin * (-1);
            }

            // ������1���擾
            decimal tmpDecimal = (tmpKin - (decimal)((long)tmpKin)) * 10;

            // tmpKin �[���w��
            bool wRoundFlg = true; // �؎�
            switch (fractionProcess)
            {
                //--------------------------------------
                // 1:�؎�
                //--------------------------------------
                case 1:
                    {
                        wRoundFlg = true; // �؎�
                        break;
                    }
                //--------------------------------------
                // 2:�l�̌ܓ�
                //--------------------------------------
                case 2: // �l�̌ܓ�
                    {
                        if (tmpDecimal >= 5)
                        {
                            wRoundFlg = false; // �؏�
                        }
                        break;
                    }
                //--------------------------------------
                // 3:�؏�
                //--------------------------------------
                case 3: // �؏�
                    {
                        if (tmpDecimal > 0)
                        {
                            wRoundFlg = false; // �؏�
                        }
                        break;
                    }
            }

            // �[������
            if (wRoundFlg == false)
            {
                tmpKin = tmpKin + 1;
            }

            // �������؎�
            tmpKin = (decimal)(long)tmpKin;

            // �}�C�i�X�␳
            if (sign == true)
            {
                tmpKin = tmpKin * (-1);
            }

            decimal a = tmpKin * (decimal)fractionUnit;

            // �Z�o�l�Z�b�g
            resultNumerical = (double)((decimal)tmpKin * (decimal)fractionUnit);

        }

        // 2009/02/14 ADD >>>>>>>>>>>>>>>>>>>>>>>>
        private bool CheckValueNum(string num)
        {
            //�����񂪐��l�ϊ��\�Ȕ͈͂�
            try
            {
                Int32.Parse(num);
                return true;
            }
            catch
            {
                return false;
            }
        }
        // 2009/02/14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<

        #endregion

        // --- ADD 2011/09/06---------->>>>>
        /// <summary>
        /// ���O�������ݏ���
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="LogDataObjProcNm">������</param>
        /// <param name="LogDataMassage">���O�ɋL�^���郁�b�Z�[�W</param>
        /// <param name="status">�ʏ탍�O�̏ꍇ�� 0 ��O���O�̏ꍇ�̓��\�b�h�̖߂�l�ȂǁB</param>
        /// <remarks>
        /// <br>Note       : ���O�������ݏ����B</br>
        /// <br>Programer  : �����</br>
        /// <br>Date       : 2011/09/06</br>
        /// </remarks>
        private void WriteLog(string enterpriseCode, string LogDataObjProcNm, string LogDataMassage, int status)
        {
            OprtnHisLogWork oprtnHisLogWork = new OprtnHisLogWork();
            object obj;

            oprtnHisLogWork.EnterpriseCode = enterpriseCode;
            oprtnHisLogWork.LogDataCreateDateTime = DateTime.Now;
            oprtnHisLogWork.LoginSectionCd = "";
            oprtnHisLogWork.LogDataKindCd = 9;
            oprtnHisLogWork.LogDataObjBootProgramNm = "�R���o�[�g����";
            oprtnHisLogWork.LogDataObjAssemblyID = "PMKHN08003R";
            oprtnHisLogWork.LogDataObjAssemblyNm = "�R���o�[�g����";
            oprtnHisLogWork.LogDataObjClassID = "ConvertProcessDB";
            oprtnHisLogWork.LogDataObjProcNm = LogDataObjProcNm;
            oprtnHisLogWork.LogOperationStatus = 0;
            oprtnHisLogWork.LogOperaterDtProcLvl = "99";
            oprtnHisLogWork.LogOperaterFuncLvl = "99";
            oprtnHisLogWork.LogOperationStatus = status;
            oprtnHisLogWork.LogDataMassage = LogDataMassage;

            obj = oprtnHisLogWork;
            status = _oprtnHisLogDB.Write(ref obj);
        }
        // --- ADD 2011/09/06----------<<<<<

    }
}

