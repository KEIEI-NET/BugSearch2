//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��NET-WEB�T�[�o�Ƒ���M���鏈���N���X
// �v���O�����T�v   : ��NET-WEB�T�[�o�Ƒ���M���鏈�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LIUSY
// �� �� ��  2011/10/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LIUSY
// �� �� ��  2011/12/02  �C�����e : readmine 8432
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �x�c ����
// �� �� ��  2012/04/02  �C�����e : Http���N�G�X�g���M��Delphi5��DLL�Ŏ�������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �O��(�A�x�[���W���p��)
// �� �� ��  2012/04/10  �C�����e : Http���N�G�X�g���M������񓯊��ŏ�������
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���|��
// �� �� ��  2012/06/19  �C�����e : ��ƃR�[�h���Z�b�g����ہA���O���J�b�g����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2012/07/13  �C�����e : �d�ؒP���̌^��Double�ɕύX�i�����_�ȉ����g�p����ׁj
//                                  �o�ד`�[�ԍ��E�a�^�n��t���ԍ���string�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��
// �� �� ��  2012/09/10  �C�����e : BL�Ǘ����[�U�[�R�[�h�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �x�c ����
// �� �� ��  2012/12/06  �C�����e : �����Y��WEB�@�A�h���X�ύX�Ή�
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@WebReferences�Q�Ɛ��ύX
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�A�@�ɔ����Q�ƃt�H���_�̕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �� �� ��  2013/02/18  �C�����e : 2013/03/13�z�M���ARedmine#34610
//                                  ������}�X�^��PGID���u1003�v�ڑ��^�C�v���uA�^�C�v�v
//                                  �̏ꍇ�ɂP��XML���쐬���āA���ɂ���XML�𑗐M����B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  �@�@�@�@�@  �쐬�S�� : �N�� ����
// �� �� ��  2014/03/04  �C�����e : ��a�Y�Ə�Q�Ή���
//                                  ���M���N�G�X�g�̖⍇���ԍ���[From] [To] �̊Ԃ�
//                                  [&]��t������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10904597-00 �쐬�S�� : ���X�� �M�p
// �� �� ��  2014/04/01  �C�����e : UOE���N�G�X�g��M�d����Q�Ή�
//                                  ���}�[�N�y�у��C�����}�[�N�͎�MXML�f�[�^
//                                  ����擾����̂ł͂Ȃ��A���M�d���f�[�^��
//                                  �ϊ�����ہA�ꎞ�I�ɑޔ������l���ăZ�b�g
//                                  ����悤�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11001634-00  �쐬�S�� : ���N�n��
// �� �� ��  K2014/05/26  �C�����e : ���������G���[���b�Z�[�W���o���Ȃ��悤�ɏC���ƃG���[���O�̍X�V
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11275084-00  �쐬�S�� : �c����
// �� �� ��  2016/04/07   �C�����e : Redmine#48694 SPK�d����M�G���[�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11201848-00  �쐬�S�� : �c����
// �� �� ��  2016/09/28   �C�����e : XML�ǂݍ��݌�AXML�I�u�W�F�N�g�̕�����s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11201849-00  �쐬�S�� : ���V��
// �� �� ��  2016/10/11   �C�����e : Redmine#48880 �I�����C���ԍ����Ɓ˔[�i�敪���Ƃɑ��M���s���l�ɏC������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11202049-00  �쐬�S�� : �v��
// �� �� ��  2017/03/02   �C�����e : Redmine#48897 �r�o�j�d����M�����C��
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using System.IO;
// 2012/12/06 ��>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//using Broadleaf.Application.Controller.jp.mesaco.catalog;
using Broadleaf.Application.Controller.jp.mesaco.meijiweb;
// 2012/12/06 ��>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
using System.Xml;
using System.Net;
using System.Web.Services;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Broadleaf.Windows.Forms;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using System.Threading;// ADD K2014/05/26 ���N�n�� Redmine 42571
namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ����M�f�[�^��ϊ����AWeb�T�[�o�Ƒ���M����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ��NET-WEB�T�[�o�Ƒ���M���鏈���N���X</br>
    /// <br>Programmer	: LIUSY</br>
    /// <br>Date		: 2011/10/26</br>
    /// <br>Update Note : K2014/05/26 ���N�n��</br>
    /// <br>              ���������G���[���b�Z�[�W���o���Ȃ��悤�ɏC���ƃG���[���O�̍X�V</br>
    /// <br>Update Note : 2016/04/07 �c����</br>
    /// <br>              Redmine#48694 SPK�d����M�G���[�̑Ή�</br>
    /// <br>Update Note : 2016/09/28 �c����</br>
    /// <br>�Ǘ��ԍ�    : 11201848-00</br>
    /// <br>              Redmine#48879 XML�ǂݍ��݌�AXML�I�u�W�F�N�g�̕�����s��</br>
    /// <br>Update Note : 2016/10/11 ���V��</br>
    /// <br>�Ǘ��ԍ�    : 11201849-00</br>
    /// <br>              Redmine#48880 �I�����C���ԍ����Ɓ˔[�i�敪���Ƃɑ��M���s���l�ɏC������</br>
    /// </remarks>
    public class NetWebClient : IUOEWebClient
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        //--- 2012/04/02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //HttpWebRequest request = null;
        //--- 2012/04/02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        private XmlWriter sendWriter;
        private XmlTextReader recvReader;
        private UOESupplier _uoeSupplier;

        private string fileName = "";
        private string fileRecName = "";
        private string fristGyoNo = "";
        private string lastGyoNo = "";
        private Dictionary<int, UoeRecDtl> UoeRecDtlDic = new Dictionary<int, UoeRecDtl>();
        private Dictionary<int, int> REQNODic = new Dictionary<int, int>();
        private Dictionary<string, string> MakerDic = new Dictionary<string, string>();
        //�G���[�t���O
        private bool _errorFlag = false;
        // --- ADD ������ 2013/02/18 for Redmine#34610---------->>>>>
        //�`�^�C�v�̂t�n�d���M�ҏW�i���ׁj�N���X
        private List<UoeSndDtl> _uoeSndDtlCopyList = new List<UoeSndDtl>();
        // --- ADD ������ 2013/02/18 for Redmine#34610----------<<<<<
        // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�---------->>>>>
        /// <summary>
        /// ���}�[�N�i�[�A�z�z��
        /// </summary>
        private Dictionary<int, string> RemarkDic = new Dictionary<int, string>();

        /// <summary>
        /// ���C�����}�[�N�i�[�A�z�z��
        /// </summary>
        private Dictionary<int, string> ChkcdDic = new Dictionary<int, string>();
        // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�----------<<<<<

        // upd 2012/07/13 >>>
        //private NewDataSet2.PartsmanResponseTblDataTable _netRecvDataTable;
        private NewDataSet2.PartsmanResponseTbl1003DataTable _netRecvDataTable;
        // upd 2012/07/13 <<<
        private System.Data.DataSet dsResponse;
        private System.Data.DataTable tableresp;

        // ---ADD K2014/05/26 ���N�n�� Redmine 42571  --------------------------------------->>>>>
        //���b�Z�[�W�Z�b�g�֌W
        private const string MSGSHOWSOLT = "MSGSHOWSOLT";
        private LocalDataStoreSlot msgShowSolt = null;

        #region ���񋓑�
        /// <summary>
        /// �I�v�V�����L���L��
        /// </summary>
        public enum Option : int
        {
            /// <summary>�������[�U</summary>
            OFF = 0,
            /// <summary>�L�����[�U</summary>
            ON = 1,
        }
        #endregion

        /// <summary>�e�L�X�g�o�̓I�v�V�������</summary>
        private int _opt_FuTaBa;//OPT-CPM0110�F�t�^�oUOE�I�v�V�����i�ʁj

        //��pUSB�p
        Broadleaf.Application.Remoting.ParamData.PurchaseStatus fuTaBaPs;
        // ---ADD K2014/05/26 ���N�n�� Redmine 42571  ---------------------------------------<<<<<

        # endregion

        // ===================================================================================== //
        // �萔
        // ===================================================================================== //
        # region Const Members
        private const int DENBKB_35 = 35;
        private const int DENBKB_45 = 45;
        private const string ERROR_CODE_0 = "0";
        private const string ERROR_CODE_1 = "1";
        private const string ERROR_CODE_2 = "2";
        private const string ERROR_CODE_3 = "3";
        private const string REQUEST_ID = "BBB101";
        private const int DENBKB_60 = 60;
        private const string KUBUN_STOCK = "3";

        private const string SEND_DENBKB = "DENBKB";    //�d���敪
        private const string SEND_GYONO = "GYONO";      //�s�ԍ�
        private const string SEND_KUBUN = "KUBUN";      //�����敪
        private const string SEND_REQNO = "REQNO";      //�d���⍇���ԍ�
        private const string SEND_REQGYO = "REQGYO";    //�`�[�p�s�ԍ�
        private const string SEND_REMARK = "REMARK";    //���}�[�N�i���l�j
        private const string SEND_NHNKB = "NHNKB";      //�[�i�敪
        private const string SEND_HNSBT = "HNSBT";      //���i���
        private const string SEND_JYUHNNO = "JYUHNNO";  //���i�ԍ�
        private const string SEND_MKCD = "MKCD";        //���[�J�[�R�[�h
        private const string SEND_JYUSU = "JYUSU";      //����
        private const string SEND_BOKB = "BOKB";        //�a�^�n�敪
        private const string SEND_CHKCD = "CHKCD";      //���C�����}�[�N�i���l�j

        private const string RECV_UKENO = "UKENO";      //��t�ԍ�
        private const string RECV_DENBKB = "DENBKB";    //�d���敪
        private const string RECV_KUBUN = "KUBUN";      //�����敪
        private const string RECV_GYONO = "GYONO";      //�s�ԍ�
        private const string RECV_RESULT = "RESULT";    //��������
        private const string RECV_REQNO = "REQNO";      //�d���⍇���ԍ�
        private const string RECV_REQGYO = "REQGYO";    //�`�[�p�s�ԍ�
        private const string RECV_REMARK = "REMARK";    //���}�[�N�i���l�j
        private const string RECV_NHNKB = "NHNKB";      //�[�i�敪
        private const string RECV_HNSBT = "HNSBT";      //���i���
        private const string RECV_JYUHNNO = "JYUHNNO";  //�󒍕��i�ԍ�
        private const string RECV_SYUHNNO = "SYUHNNO";  //�o�ו��i�ԍ�
        private const string RECV_MKCD = "MKCD";        //���[�J�[�R�[�h
        private const string RECV_HINNM = "HINNM";      //�i��
        private const string RECV_SHOTIK = "SHOTIK";    //�艿
        private const string RECV_SKRTNK = "SKRTNK";    //�d�؂�P��
        private const string RECV_JYUSU = "JYUSU";      //�󒍐�
        private const string RECV_SYUSU = "SYUSU";      //�o�א�
        private const string RECV_BOKB = "BOKB";        //�a�^�n�敪
        private const string RECV_BOSU = "BOSU";        //�a�^�n��
        private const string RECV_SYUNO = "SYUNO";      //�o�ד`�[�ԍ�
        private const string RECV_BOUKENO = "BOUKENO";  //�a�^�n��t���ԍ�
        private const string RECV_CHKCD = "CHKCD";      //���C�����}�[�N�i���l�j
        private const string RECV_LINERR = "LINERR";    //���C�����b�Z�[�W
        private const string RECV_UKEYMD = "UKEYMD";    //��t���t
        private const string RECV_SDATE = "SDATE";      //�쐬���t
        private const string RECV_STIME = "STIME";      //�쐬����

        private const string STRING_CHANGE_ROW = "\r\n";
        private const string SAVE_XML_NAME = "PMUOE09020U_Maker.xml";
        private const string STRING_BOUNDARY = "-----------------------------7d21cef303f8";
        private const int ERROR_SUCCESS = 0;
        // --- ADD ������ 2013/02/18 for Redmine#34610---------->>>>>
        private const string FILESPKSEND = "\\SPKSEND.TXT";
        private const string FILESPKRECV = "\\SPKRECV.TXT";
        // --- ADD ������ 2013/02/18 for Redmine#34610----------<<<<<
        # endregion

        #region API��` 2012/04/02 �g�p���Ă��Ȃ����ߍ폜
        //[DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        //private static extern bool InternetGetConnectedState(out int lpdwFlags, int dwReserved);

        //[DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        //private static extern int InternetAttemptConnect(int dwReserved);
        #endregion

        //�@2012/04/02�@add�@Http���N�G�X�g���M��Delphi5��DLL�Ŏ������� >>>>>>>>>>>>>>>>>>>>>>>>>>>
        #region Delphi5�̃��N�G�X�g���\�b�h�Ăяo��
        [DllImport("PMPU9013.dll")]
        public extern static int xPMPU9013(string addres1,         //----�ڑ���A�h���X�̃h���C���������Z�b�g
                                           string addres2,         //----�ڑ���A�h���X�̃h���C���ȉ��̕������Z�b�g
                                           string usrname,         //----�ڑ�����ۂ̃��[�U�[ID���Z�b�g
                                           string password,        //----�ڑ�����ۂ̃p�X���[�h���Z�b�g
                                           string filepath,        //----���MXML�̊i�[����Z�b�g
                                           int ssl,                //----�v���g�R��[0:HTTP 1:HTTPS]
                                           int netflg,             //----�ڑ��^�C�v[0:Atype 1:Btype 2:Ctype]
                                           string usercode,        //----BL�Ǘ��̃��[�U�[�R�[�h���Z�b�g(��ƃR�[�h)
                                           int timeout,            //----�^�C�����Ԃ̒l���Z�b�g
                                           string nonce,           //----nonce�̐ݒ�
                                           string created,         //----created�̐ݒ�
                                           string sha1,            //----sha1�ϊ���̕�����ݒ�
                                           int irecv,              //----�d����M����t���O�u0�F�ʏ�A1�F�d����M�v
                                           int irecr,              //----��������t���O�u0�F�ʏ�A1�F�����v
                                           ref int errkbn);        //----�G���[�敪�B
        #endregion
        //�@2012/04/02�@add�@Http���N�G�X�g���M��Delphi5��DLL�Ŏ������� <<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors

        /// <summary>
        /// Web�T�[�o�Ƒ���M���鏈���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : Web�T�[�o�Ƒ���M���鏈���N���X�̏��������s���B</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011/10/26</br>
        /// <br>Update Note: K2014/05/26 ���N�n��</br>
        /// <br>             ���������G���[���b�Z�[�W���o���Ȃ��悤�ɏC���ƃG���[���O�̍X�V</br>
        /// </remarks>
        public NetWebClient(UOESupplier uoeSupplier)
        {
            // ---ADD K2014/05/26 ���N�n�� Redmine 42571  --------------------------------------->>>>>
            //OPT-CPM0110�F�t�^�oUOE�I�v�V�����i�ʁj
            fuTaBaPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
            if (fuTaBaPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FuTaBa = (int)Option.ON;
            }
            else
            {
                this._opt_FuTaBa = (int)Option.OFF;
            }
            // ---ADD K2014/05/26 ���N�n�� Redmine 42571  ---------------------------------------<<<<<
            this._uoeSupplier = uoeSupplier;
        }
        # endregion

        #region IUOEWebClient �����o

        /// <summary>
        /// Web�T�[�o�Ƒ���M���܂��B
        /// </summary>
        /// <param name="uoeSendingData"></param>
        /// <param name="isReceivingStock"></param>
        /// <param name="uoeReceivedData"></param>
        /// <param name="errorMessage"></param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : Web�T�[�o�Ƒ���M���鏈�����s���B</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011/10/26</br>
        /// <br>Update Note: 2013/02/18 ������</br>
        ///	<br>			 2013/03/13�z�M���ARedmine#34610</br>
        ///	<br>			 ������}�X�^��PGID���u1003�v�ڑ��^�C�v���uA�^�C�v�v</br>
        ///	<br>             �̏ꍇ�ɂP��XML���쐬���āA���ɂ���XML�𑗐M����B</br> 
        /// <br>Update Note: K2014/05/26 ���N�n��</br>
        /// <br>             ���������G���[���b�Z�[�W���o���Ȃ��悤�ɏC���ƃG���[���O�̍X�V</br>
        /// <br>Update Note: 2016/04/07 �c����</br>
        /// <br>             Redmine#48694 SPK�d����M�G���[�̑Ή�</br>
        /// <br>Update Note: 2016/10/11 ���V��</br>
        /// <br>�Ǘ��ԍ�   : 11201849-00</br>
        /// <br>             Redmine#48880 �I�����C���ԍ����Ɓ˔[�i�敪���Ƃɑ��M���s���l�ɏC������</br>
        /// </remarks>
        public int SendAndReceive(UoeSndHed uoeSendingData, bool isReceivingStock, out UoeRecHed uoeReceivedData, out string errorMessage)
        {

            // ---ADD K2014/05/26 ���N�n�� Redmine 42571  --------------------------------------->>>>>
            //�t�^�oUSB��p:Option.ON
            if (this._opt_FuTaBa == (int)Option.ON)
            {
                //���b�Z�[�W���擾
                msgShowSolt = Thread.GetNamedDataSlot(MSGSHOWSOLT);
            }
            // ---ADD K2014/05/26 ���N�n�� Redmine 42571  ---------------------------------------<<<<<
            uoeReceivedData = new UoeRecHed();
            errorMessage = string.Empty;
            //���N�G�X�g���M
            //--- 2012/04/02 �폜 >>>>>>>>>>>>>>>>>
            //bool Ist = false;
            //--- 2012/04/02 �폜 <<<<<<<<<<<<<<<<<
            //�G���[�t���O
            string address = "";
            IntPtr lpBuffer = IntPtr.Zero;
            int status = 0;
            string errorCode = ERROR_CODE_1;
            //--- 2012/04/02 �ǉ��ƍ폜 >>>>>>>>>>>>>>>>>
            //string myString = ""; ;
            //string content = "";
            //string fileRecStream = "";
            int errkbn = 0;
            int irecv = 0;
            int irecr = 0;
            string nonce = "";
            string created = "";
            string password = "";
            //--- 2012/04/02 �ǉ��ƍ폜 <<<<<<<<<<<<<<<<<


            //�A�h���X����
            //�G���[�t���OOFF
            if (_errorFlag == false)
            {
                //�d����M�t���OON�F������}�X�^�d����M�A�h���X
                if (isReceivingStock)
                {
                    address = _uoeSupplier.UOELoginUrl;             //������}�X�^�̎d����M�A�h���X
                    //--- 2012/04/02 �d����M����t���O >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    irecv = 1;
                    //--- 2012/04/02 �d����M����t���O <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
                //��L�ȊO�F�ʏ�A�h���X
                else
                {
                    address = _uoeSupplier.UOEStockCheckUrl;        //������}�X�^�̒ʏ픭���A�h���X
                    //--- 2012/04/02 �d����M����t���O >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    irecv = 0;
                    //--- 2012/04/02 �d����M����t���O <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
                //--- 2012/04/02 �����t���O >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                irecr = 0;
                //--- 2012/04/02 �����t���O <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            //�G���[�t���OON�F������}�X�^�����A�h���X
            else
            {
                address = _uoeSupplier.UOEForcedTermUrl; //������}�X�^�̕����m�F�A�h���X
                //--- 2012/04/02 �d����M����t���O �Ɓ@�����t���O�@>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                irecv = 0;
                irecr = 1;
                //--- 2012/04/02 �d����M����t���O �Ɓ@�����t���O�@<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }

            //---�@2012/04/02�@Delphi5��DLL���Ăяo���B>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            #region �폜�������W�b�N���������ߕ\����J�b�g����B
            /*
            // ����I�[�v������
            if (RequestOpen(this._uoeSupplier.DaihatsuOrdreDiv, address))
            {
                HttpWebResponse response = null;
                try
                {
                    // ���M�d���f�[�^��XML�t�@�C���ɕϊ�����
                    content = ConvertUoeSndHedToXML(uoeSendingData, isReceivingStock, this._uoeSupplier.InqOrdDivCd);

                    myString += STRING_BOUNDARY;
                    myString += STRING_CHANGE_ROW;
                    myString += "Content-Disposition: form-data; name=\"xml_data\"; ";
                    myString += "filename=\"" + fileName + "\"";
                    myString += STRING_CHANGE_ROW;
                    myString += STRING_CHANGE_ROW;

                    errorCode = ERROR_CODE_0;

                    myString = myString + content + STRING_CHANGE_ROW + STRING_BOUNDARY + "--" + STRING_CHANGE_ROW;



                    byte[] body = Encoding.ASCII.GetBytes(myString);
                    //request.ContentLength = body.LongLength;

                    using (Stream reqStream = request.GetRequestStream())
                    {
                        reqStream.Write(body, 0, body.Length);
                        reqStream.Close();
                    }
                    using (response = (HttpWebResponse)request.GetResponse())
                    {

                        Stream revStream = response.GetResponseStream();
                        StreamReader sr = new StreamReader(revStream, Encoding.GetEncoding(932));
                        fileRecStream = sr.ReadToEnd();

                    }
                }
                catch (WebException ex)
                {
                    if (ex.Response != null)
                    {
                        HttpWebResponse res = (HttpWebResponse)ex.Response;
                        int statusCode = (int)res.StatusCode;
                        errorMessage = "�ް�����M���ɴװ������(" + ex.Message + ")";

                        if (!_errorFlag && !isReceivingStock)
                        {
                            TMsgDisp.Show(null,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                "",
                                errorMessage,
                                status,
                                MessageBoxButtons.OK);
                        }
                        if (!isReceivingStock && !_errorFlag)
                        {
                            _errorFlag = true;
                            string errorMessageTemp = "";
                            status = SendAndReceive(uoeSendingData, isReceivingStock, out uoeReceivedData, out errorMessageTemp);
                            if (errorMessageTemp != string.Empty)
                            {
                                errorMessage = errorMessageTemp;
                            }
                        }
                        if (isReceivingStock)
                        {
                            //�ŏ��ɋ󖾍ׂ̍쐬�u�J�ǂƋU��v�@

                            byte[] toByteArray = new byte[256];
                            UoeRecDtl uoeRecDtlEmply = new UoeRecDtl();
                            uoeRecDtlEmply.RecTelegram = toByteArray;
                            uoeRecDtlEmply.RecTelegramLen = uoeRecDtlEmply.RecTelegram.Length;
                            uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);
                            //
                            uoeRecDtlEmply = new UoeRecDtl();
                            uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);
                            //�ŏI�ɋ󖾍ׂ̍쐬�u�J�ǂƋU��v
                            uoeRecDtlEmply.RecTelegram = toByteArray;
                            uoeRecDtlEmply.RecTelegramLen = uoeRecDtlEmply.RecTelegram.Length;
                            uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);
                        }
                        return status;
                    }
                    errorMessage = ex.Message;
                    status = -1;
                    return status;
                }
                response.Close();
                try
                {

                    //Rec�t�@�C���쐬

                    if (fileRecStream == string.Empty)
                    {
                        if (!isReceivingStock)
                        {
                            status = -1;
                            errorMessage = "�ް���M���ɴװ������(��M�t�@�C�����e������܂���) ";
                            return status;
                        }
                        else
                        {
                            //�ŏ��ɋ󖾍ׂ̍쐬�u�J�ǂƋU��v�@

                            byte[] toByteArray = new byte[256];
                            UoeRecDtl uoeRecDtlEmply = new UoeRecDtl();
                            uoeRecDtlEmply.RecTelegram = toByteArray;
                            uoeRecDtlEmply.RecTelegramLen = uoeRecDtlEmply.RecTelegram.Length;
                            uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);
                            //
                            uoeRecDtlEmply = new UoeRecDtl();
                            uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);
                            //�ŏI�ɋ󖾍ׂ̍쐬�u�J�ǂƋU��v
                            uoeRecDtlEmply.RecTelegram = toByteArray;
                            uoeRecDtlEmply.RecTelegramLen = uoeRecDtlEmply.RecTelegram.Length;
                            uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);
                            return status;
                        }
                    }
                    //A�^�C�v
                    if (this._uoeSupplier.InqOrdDivCd == 0)
                    {
                        fileRecName = System.IO.Directory.GetCurrentDirectory() + "\\SPKRECV.XML";
                    }
                    // B,C
                    else if (this._uoeSupplier.InqOrdDivCd != 0)
                    {
                        fileRecName = System.IO.Directory.GetCurrentDirectory() + "\\NETRECV.XML";
                    }

                    FileStream file = new FileStream(fileRecName, FileMode.Create);

                    file.Write(Encoding.UTF8.GetBytes(fileRecStream), 0, Encoding.UTF8.GetByteCount(fileRecStream));
                    file.Close();
                }
                catch (Exception ex)
                {
                    status = -1;
                    return status;
                }
            }
            else
            {
                status = -1;
                return status;
            }
            if (errorCode == ERROR_CODE_0)
            {

                // Web�T�[�r�X����̖߂�l����M�d���f�[�^�ɕϊ����� 
                ConvertXMLToUoeSndHed(uoeSendingData, isReceivingStock, errorCode, this._uoeSupplier.InqOrdDivCd, ref uoeReceivedData);
            }
            */
            #endregion

            try
            {
                // --- ADD ������ 2013/02/18 for Redmine#34610---------->>>>>
                string fileNameSend = string.Empty;
                string fileNameRecv = string.Empty;
                string xmlFileSendString = string.Empty;
                string xmlFileRecvString = string.Empty;
                FileStream fileSend = null;
                FileStream fileRecv = null;
                //B,C�^�C�v OR �������M�����s
                if (this._uoeSupplier.InqOrdDivCd != 0 || _errorFlag == true)
                {
                    //A�^�C�v����
                    if (this._uoeSupplier.InqOrdDivCd == 0)
                    {
                        //SPKSEND.TXT��SPKRECV.TXT�t�@�C���̃p�[�X���擾����B
                        fileNameSend = System.IO.Directory.GetCurrentDirectory() + FILESPKSEND;
                        fileNameRecv = System.IO.Directory.GetCurrentDirectory() + FILESPKRECV;
                        //�t�@�C���X�g���[���̍쐬
                        fileSend = new FileStream(fileNameSend, FileMode.Append, FileAccess.Write);
                        fileRecv = new FileStream(fileNameRecv, FileMode.Append, FileAccess.Write);

                        // ���M�d���f�[�^��XML�t�@�C���ɕϊ�����
                        xmlFileSendString = ConvertUoeSndHedToXML(uoeSendingData, isReceivingStock, this._uoeSupplier.InqOrdDivCd);

                        //SPKSEND.TXT�t�@�C���Ƀf�[�^���������ށB
                        if (!string.IsNullOrEmpty(xmlFileSendString))
                        {
                            fileSend.Write(Encoding.Default.GetBytes(xmlFileSendString), 0, Encoding.Default.GetByteCount(xmlFileSendString));
                            fileSend.Flush();
                        }
                    }
                    else
                    {
                        // ���M�d���f�[�^��XML�t�@�C���ɕϊ�����
                        ConvertUoeSndHedToXML(uoeSendingData, isReceivingStock, this._uoeSupplier.InqOrdDivCd);
                    }
                // --- ADD ������ 2013/02/18 for Redmine#34610----------<<<<<
                    // --- DEL ������ 2013/02/18 for Redmine#34610---------->>>>>
                    //// ���M�d���f�[�^��XML�t�@�C���ɕϊ�����
                    //ConvertUoeSndHedToXML(uoeSendingData, isReceivingStock, this._uoeSupplier.InqOrdDivCd);
                    // --- DEL ������ 2013/02/18 for Redmine#34610----------<<<<<

                    //---WSSE�K�v���̎擾�@nonce,created,password
                    nonce = CreateNonce();
                    created = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffffZ");
                    password = _uoeSupplier.UOEConnectPassword;

                    //---Delphi Method�̌Ăяo��
                    // UPD START 2012/04/10
                    //status =xPMPU9013(_uoeSupplier.UOEOrderUrl,                                                       //---�h���C��
                    //                  address.Substring(address.Length - (address.Length - 1)),                       //---�h���C���ȉ��̃A�h���X
                    //                  _uoeSupplier.UOEConnectUserId,                                                  //---�ڑ����ID
                    //                  password,                                                                       //---�ڑ���̃p�X���[�h
                    //                  System.IO.Directory.GetCurrentDirectory(),                                      //---���MXML�̃t�@�C���p�X
                    //                  _uoeSupplier.DaihatsuOrdreDiv,                                                  //---�v���g�R��
                    //                  _uoeSupplier.InqOrdDivCd,                                                       //---���M��^�C�v
                    //                  _uoeSupplier.EnterpriseCode.Substring(_uoeSupplier.EnterpriseCode.Length - 9),  //---��ƃR�[�h�̖���
                    //                  _uoeSupplier.LoginTimeoutVal * 1000,                                            //---�^�C���A�E�g
                    //                  nonce,                                                                          //---nonce���Z�b�g
                    //                  created,                                                                        //---Created���Z�b�g
                    //                  GetDigest(String.Format("{0}{1}{2}", nonce, created, password)),                //---Password���Z�b�g
                    // irecv,                                                                          //---�d����M����t���O
                    //                  irecr,                                                                          //---�����t���O
                    //                  ref errkbn);                                                                    //---�G���[���b�Z�[�W
                    xPMPU9013AsyncCall caller = xPMPU9013Async;
                    IAsyncResult result = caller.BeginInvoke(address, password, nonce, created, irecv, irecr, ref errkbn, null, null);  //�񓯊��Ăяo���J�n

                    // �񓯊��������I������܂ŃX���b�h�ҋ@
                    // �}�E�X����Ȃǂ��󂯕t���Ȃ�
                    // �����Ăяo���̗l�ɓ��삷��A�u�����Ȃ��v�ɂ͂Ȃ�Ȃ�
                    // ���� WaitOne ���̗p����ꍇ�́A���̉��� while ���̓R�����g�ɂ���
                    //result.AsyncWaitHandle.WaitOne();

                    // �񓯊��������I������܂Ń��[�v�i�|�[�����O�j����
                    // �}�E�X����Ȃǉ\
                    while (!result.IsCompleted)
                    {
                        System.Windows.Forms.Application.DoEvents(); 
                        System.Threading.Thread.Sleep(100);
                    }

                    status = caller.EndInvoke(ref errkbn, result);  // �񓯊������I��
                    // UPD END   2012/04/10

                    //---�G���[����@status=0�͐���I���B
                    if (status == 0)
                    {
                        // Web�T�[�r�X����̖߂�l����M�d���f�[�^�ɕϊ����� 
                        ConvertXMLToUoeSndHed(uoeSendingData, isReceivingStock, errorCode, this._uoeSupplier.InqOrdDivCd, ref uoeReceivedData);
                        // --- ADD ������ 2013/02/18 for Redmine#34610---------->>>>>
                        //A�^�C�v����
                        if (this._uoeSupplier.InqOrdDivCd == 0)
                        {
                             //��M�d���f�[�^�̓ǂݍ��ށB
                            xmlFileRecvString = ReadXML(fileRecName);

                            //SPKRECV.TXT�t�@�C���Ƀf�[�^���������ށB
                            if (!string.IsNullOrEmpty(xmlFileRecvString))
                            {
                                //SPKRECV.TXT�t�@�C���Ƀf�[�^���������ށB
                                fileRecv.Write(Encoding.Default.GetBytes(xmlFileRecvString), 0, Encoding.Default.GetByteCount(xmlFileRecvString));
                                fileRecv.Flush();
                            }
                        }
                        // --- ADD ������ 2013/02/18 for Redmine#34610----------<<<<<
                    }
                    else
                    {
                        //�G���[���b�Z�[�W�̐���
                        if (status == 1)
                        {
                            switch (errkbn)
                            {
                                case 1: { errorMessage = "����I�[�v���G���[(AttemptConnect)"; break; }
                                case 2: { errorMessage = "����I�[�v���G���[(Opent)"; break; }
                                case 3: { errorMessage = "����I�[�v���G���[(Connect)"; break; }
                                case 4: { errorMessage = "����I�[�v���G���[(HttpOpenRequest)"; break; }
                                case 5: { errorMessage = "����I�[�v���G���[(SetOption)"; break; }
                            }

                        }
                        else if (status == 2)
                        {
                            errorMessage = "�f�[�^���M���ɃG���[������(SendRequest) " + errkbn.ToString();
                        }
                        else if (status == 3)
                        {
                            errorMessage = "�f�[�^���M���ɃG���[������ " + errkbn.ToString();
                        }

                        // --- ADD ������ 2013/02/18 for Redmine#34610---------->>>>>
                        //A�^�C�v����
                        if (this._uoeSupplier.InqOrdDivCd == 0)
                        {
                            //�t�@�C���X�g���[�������B
                            fileSend.Close();
                            fileRecv.Close();
                        }
                        // --- ADD ������ 2013/02/18 for Redmine#34610----------<<<<<
                        //�ʏ푗�M�ŃG���[�����������ꍇ�́A�G���[���b�Z�[�W�\���㕜�����M�����s
                        if (!isReceivingStock && !_errorFlag)
                        {

                            // ---DEL K2014/05/26 ���N�n�� Redmine 42571  --------------------------------------->>>>>
                            //TMsgDisp.Show(null,
                            //              emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            //              "",
                            //              errorMessage,
                            //              status,
                            //              MessageBoxButtons.OK);
                            // ---DEL K2014/05/26 ���N�n�� Redmine 42571  ---------------------------------------<<<<<

                            // ---ADD K2014/05/26 ���N�n�� Redmine 42571  --------------------------------------->>>>>
                            if (this._opt_FuTaBa == (int)Option.ON)
                            {
                                //������������(����)�ł͂Ȃ�
                                if (!(Thread.GetData(msgShowSolt) != null
                                    && (Int32)Thread.GetData(msgShowSolt) == 1))
                                {
                                    TMsgDisp.Show(null,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      "",
                                      errorMessage,
                                      status,
                                      MessageBoxButtons.OK);

                                }
                            }
                            else
                            {
                                TMsgDisp.Show(null,
                                   emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                   "",
                                   errorMessage,
                                   status,
                                   MessageBoxButtons.OK);

                            }
                            // ---ADD K2014/05/26 ���N�n�� Redmine 42571  ---------------------------------------<<<<<

                            _errorFlag = true;
                            string errorMessageTemp = "";
                            status = SendAndReceive(uoeSendingData, isReceivingStock, out uoeReceivedData, out errorMessageTemp);
                            if (errorMessageTemp != string.Empty)
                            {
                                errorMessage = errorMessageTemp;
                            }
                        }

                        //�d����M�ŃG���[�����������ꍇ�́A�󖾍ׂ��쐬���ďI��
                        if (isReceivingStock)
                        {
                            //�ŏ��ɊJ�Ǘv�����ׂ̍쐬
                            byte[] toByteArray = new byte[256];
                            UoeRecDtl uoeRecDtlEmply = new UoeRecDtl();
                            uoeRecDtlEmply.RecTelegram = toByteArray;
                            uoeRecDtlEmply.RecTelegramLen = uoeRecDtlEmply.RecTelegram.Length;
                            uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);

                            //�󖾍ׂ̍쐬
                            uoeRecDtlEmply = new UoeRecDtl();
                            uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);

                            //�ŏI�ɕǗv�����ׂ̍쐬
                            uoeRecDtlEmply.RecTelegram = toByteArray;
                            uoeRecDtlEmply.RecTelegramLen = uoeRecDtlEmply.RecTelegram.Length;
                            uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);

                            //--- status4�͊Y���f�[�^�Ȃ��Ȃ̂ŁA���폈���Ƃ���B
                            if (status == 4)
                            {
                                status = 0;
                            }
                        }
                        return status;
                    }
                  // --- ADD ������ 2013/02/18 for Redmine#34610---------->>>>>
                    //A�^�C�v����
                    if (this._uoeSupplier.InqOrdDivCd == 0)
                    {
                        //�t�@�C���X�g���[�������B
                        fileSend.Close();
                        fileRecv.Close();
                    }
                }
                //A�^�C�v
                else
                {
                     //SPKSEND.TXT��SPKRECV.TXT�t�@�C���̃p�[�X���擾����B
                     fileNameSend = System.IO.Directory.GetCurrentDirectory() + FILESPKSEND;
                     fileNameRecv = System.IO.Directory.GetCurrentDirectory() + FILESPKRECV;
                     //�t�@�C���X�g���[���̍쐬
                     fileSend = new FileStream(fileNameSend, FileMode.Create, FileAccess.Write);
                     fileRecv = new FileStream(fileNameRecv, FileMode.Create, FileAccess.Write);
                    
                    _uoeSndDtlCopyList = uoeSendingData.UoeSndDtlList;
                    
                    password = _uoeSupplier.UOEConnectPassword;

                    //----- ADD 2016/10/11 ���V�� Redmine#48880 �I�����C���ԍ����Ɓ˔[�i�敪���Ƃɑ��M���s���l�ɏC������ ----->>>>>
                    // �[�i�敪
                    string noHinDiv = string.Empty;

                    // �d�����
                    byte[] messageByte;
                    Dictionary<string, List<UoeSndDtl>> resultUoeDtlDic = new Dictionary<string, List<UoeSndDtl>>();

                    // �[�i�敪���ƂɃO���[�v�Ƃ���
                    for (int i = 1; i < _uoeSndDtlCopyList.Count - 1; i++)
                    {
                        // �[�i�敪
                        noHinDiv = string.Empty;
                        // �d��
                        messageByte = _uoeSndDtlCopyList[i].SndTelegram;
                        // �I�����C���ԍ����ɓd������A�[�i�敪���擾����
                        UoeCommonFnc.MemCopy(ref noHinDiv, ref messageByte, 26, 1);

                        if (resultUoeDtlDic.ContainsKey(noHinDiv))
                        {
                            resultUoeDtlDic[noHinDiv].Add(_uoeSndDtlCopyList[i]);
                        }
                        else
                        {
                            List<UoeSndDtl> uoeDtlList = new List<UoeSndDtl>();
                            uoeDtlList.Add(_uoeSndDtlCopyList[i]);
                            resultUoeDtlDic.Add(noHinDiv, uoeDtlList);
                        }
                    }
                    //----- ADD 2016/10/11 ���V�� Redmine#48880 �I�����C���ԍ����Ɓ˔[�i�敪���Ƃɑ��M���s���l�ɏC������ -----<<<<<

                    //----- UPD 2016/10/11 ���V�� Redmine#48880 �I�����C���ԍ����Ɓ˔[�i�敪���Ƃɑ��M���s���l�ɏC������ ----->>>>>
                    //for (int i = 1; i < _uoeSndDtlCopyList.Count - 1; i++)
                    //{
                    //    //���M����XML�ɕϊ�����ہA�I�����C���ԍ����ɍ쐬����悤�ɂ���B
                    //    uoeSendingData.UoeSndDtlList = new List<UoeSndDtl>();
                    //    uoeSendingData.UoeSndDtlList.Add(_uoeSndDtlCopyList[0]);
                    //    uoeSendingData.UoeSndDtlList.Add(_uoeSndDtlCopyList[i]);
                    //    uoeSendingData.UoeSndDtlList.Add(_uoeSndDtlCopyList[_uoeSndDtlCopyList.Count - 1]);
                    foreach (string uoeDtlKey in resultUoeDtlDic.Keys)
                    {                        
                        //���M����XML�ɕϊ�����ہA�[�i�敪���ɍ쐬����悤�ɂ���B
                        uoeSendingData.UoeSndDtlList = new List<UoeSndDtl>();
                        uoeSendingData.UoeSndDtlList.Add(_uoeSndDtlCopyList[0]);
                        uoeSendingData.UoeSndDtlList.AddRange(resultUoeDtlDic[uoeDtlKey]);
                        uoeSendingData.UoeSndDtlList.Add(_uoeSndDtlCopyList[_uoeSndDtlCopyList.Count - 1]);
                    //----- UPD 2016/10/11 ���V�� Redmine#48880 �I�����C���ԍ����Ɓ˔[�i�敪���Ƃɑ��M���s���l�ɏC������ -----<<<<<

                        if (sendWriter != null)
                        {
                            sendWriter = null;
                        }

                        // ���M�d���f�[�^��XML�t�@�C���ɕϊ�����
                        xmlFileSendString = ConvertUoeSndHedToXML(uoeSendingData, isReceivingStock, this._uoeSupplier.InqOrdDivCd);

                        //SPKSEND.TXT�t�@�C���Ƀf�[�^���������ށB
                        if (!string.IsNullOrEmpty(xmlFileSendString))
                        {
                            fileSend.Write(Encoding.Default.GetBytes(xmlFileSendString + STRING_CHANGE_ROW), 0, Encoding.Default.GetByteCount(xmlFileSendString + STRING_CHANGE_ROW));
                            fileSend.Flush();
                        }
                        //---WSSE�K�v���̎擾�@nonce,created,password
                        nonce = CreateNonce();
                        created = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffffZ");

                        xPMPU9013AsyncCall caller = xPMPU9013Async;
                        IAsyncResult result = caller.BeginInvoke(address, password, nonce, created, irecv, irecr, ref errkbn, null, null);  //�񓯊��Ăяo���J�n

                        // �񓯊��������I������܂ŃX���b�h�ҋ@
                        // �}�E�X����Ȃǂ��󂯕t���Ȃ�
                        // �����Ăяo���̗l�ɓ��삷��A�u�����Ȃ��v�ɂ͂Ȃ�Ȃ�
                        // ���� WaitOne ���̗p����ꍇ�́A���̉��� while ���̓R�����g�ɂ���
                        //result.AsyncWaitHandle.WaitOne();

                        // �񓯊��������I������܂Ń��[�v�i�|�[�����O�j����
                        // �}�E�X����Ȃǉ\
                        while (!result.IsCompleted)
                        {
                            System.Windows.Forms.Application.DoEvents();
                            System.Threading.Thread.Sleep(100);
                        }

                        status = caller.EndInvoke(ref errkbn, result);  // �񓯊������I��

                        //---�G���[����@status=0�͐���I���B
                        if (status == 0)
                        {
                            //XML�t�@�C���쐬
                            if (recvReader != null)
                            {
                                recvReader = null;
                            }
                            //----- UPD 2016/04/07 �c���� Redmine#48694 SPK�d����M�G���[�̑Ή� ----->>>>>
                            //MakeXMLFile(this._uoeSupplier.InqOrdDivCd);
                            MakeXMLFile(this._uoeSupplier.InqOrdDivCd, isReceivingStock);
                            //----- UPD 2016/04/07 �c���� Redmine#48694 SPK�d����M�G���[�̑Ή� -----<<<<<

                            //��M�d���f�[�^�̓ǂݍ��ށB
                            xmlFileRecvString = ReadXML(fileRecName);

                            //SPKRECV.TXT�t�@�C���Ƀf�[�^���������ށB
                            if (!string.IsNullOrEmpty(xmlFileRecvString))
                            {
                                fileRecv.Write(Encoding.Default.GetBytes(xmlFileRecvString + STRING_CHANGE_ROW), 0, Encoding.Default.GetByteCount(xmlFileRecvString + STRING_CHANGE_ROW));
                                fileRecv.Flush();
                            }
                            continue;
                        }
                        else
                        {
                            //�G���[���b�Z�[�W�̐���
                            if (status == 1)
                            {
                                switch (errkbn)
                                {
                                    case 1: { errorMessage = "����I�[�v���G���[(AttemptConnect)"; break; }
                                    case 2: { errorMessage = "����I�[�v���G���[(Opent)"; break; }
                                    case 3: { errorMessage = "����I�[�v���G���[(Connect)"; break; }
                                    case 4: { errorMessage = "����I�[�v���G���[(HttpOpenRequest)"; break; }
                                    case 5: { errorMessage = "����I�[�v���G���[(SetOption)"; break; }
                                }

                            }
                            else if (status == 2)
                            {
                                errorMessage = "�f�[�^���M���ɃG���[������(SendRequest) " + errkbn.ToString();
                            }
                            else if (status == 3)
                            {
                                errorMessage = "�f�[�^���M���ɃG���[������ " + errkbn.ToString();
                            }
                            //�t�@�C���X�g���[�������B
                            fileSend.Close();
                            fileRecv.Close();

                            //�ʏ푗�M�ŃG���[�����������ꍇ�́A�G���[���b�Z�[�W�\���㕜�����M�����s
                            if (!isReceivingStock && !_errorFlag)
                            {
                                // ---DEL K2014/05/26 ���N�n�� Redmine 42571  --------------------------------------->>>>>
                                //TMsgDisp.Show(null,
                                //              emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                //              "",
                                //              errorMessage,
                                //              status,
                                //              MessageBoxButtons.OK);
                                // ---DEL K2014/05/26 ���N�n�� Redmine 42571  ---------------------------------------<<<<<

                                // ---ADD K2014/05/26 ���N�n�� Redmine 42571  --------------------------------------->>>>>
                                if (this._opt_FuTaBa == (int)Option.ON)
                                {
                                    //������������(����)�ł͂Ȃ�
                                    if (!(Thread.GetData(msgShowSolt) != null
                                        && (Int32)Thread.GetData(msgShowSolt) == 1))
                                    {
                                        TMsgDisp.Show(null,
                                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                             "",
                                             errorMessage,
                                             status,
                                             MessageBoxButtons.OK);

                                    }
                                }
                                else
                                {
                                    TMsgDisp.Show(null,
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                            "",
                                            errorMessage,
                                            status,
                                            MessageBoxButtons.OK);

                                }
                                // ---ADD K2014/05/26 ���N�n�� Redmine 42571  ---------------------------------------<<<<<
                                _errorFlag = true;
                                string errorMessageTemp = "";

                                uoeSendingData.UoeSndDtlList = _uoeSndDtlCopyList;

                                status = SendAndReceive(uoeSendingData, isReceivingStock, out uoeReceivedData, out errorMessageTemp);
                                if (errorMessageTemp != string.Empty)
                                {
                                    errorMessage = errorMessageTemp;
                                }
                            }

                            //�d����M�ŃG���[�����������ꍇ�́A�󖾍ׂ��쐬���ďI��
                            if (isReceivingStock)
                            {
                                //�ŏ��ɊJ�Ǘv�����ׂ̍쐬
                                byte[] toByteArray = new byte[256];
                                UoeRecDtl uoeRecDtlEmply = new UoeRecDtl();
                                uoeRecDtlEmply.RecTelegram = toByteArray;
                                uoeRecDtlEmply.RecTelegramLen = uoeRecDtlEmply.RecTelegram.Length;
                                uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);

                                //�󖾍ׂ̍쐬
                                uoeRecDtlEmply = new UoeRecDtl();
                                uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);

                                //�ŏI�ɕǗv�����ׂ̍쐬
                                uoeRecDtlEmply.RecTelegram = toByteArray;
                                uoeRecDtlEmply.RecTelegramLen = uoeRecDtlEmply.RecTelegram.Length;
                                uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);

                                //--- status4�͊Y���f�[�^�Ȃ��Ȃ̂ŁA���폈���Ƃ���B
                                if (status == 4)
                                {
                                    status = 0;
                                }
                            }
                            return status;
                        }

                    }
                    //�t�@�C���X�g���[�������B
                    fileSend.Close();
                    fileRecv.Close();

                    uoeSendingData.UoeSndDtlList = _uoeSndDtlCopyList;
                    // Web�T�[�r�X����̖߂�l����M�d���f�[�^�ɕϊ����� 
                    ConvertAtypeXMLToUoeSndHed(uoeSendingData, isReceivingStock, ref uoeReceivedData);
                }
                // --- ADD ������ 2013/02/18 for Redmine#34610----------<<<<<
            }
            catch (Exception ex)
            {
                //---��O�Ή�
                status = 999;
                // ---ADD K2014/05/26 ���N�n�� Redmine 42571  --------------------------------------->>>>>
                //TMsgDisp.Show(null,
                //              emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //              "",
                //              ex.Message,
                //              status,
                //              MessageBoxButtons.OK);
                // ---ADD K2014/05/26 ���N�n�� Redmine 42571  ---------------------------------------<<<<<

                // ---ADD K2014/05/26 ���N�n�� Redmine 42571  --------------------------------------->>>>>
                if (this._opt_FuTaBa == (int)Option.ON)
                {
                    //������������(����)�ł͂Ȃ�
                    if (!(Thread.GetData(msgShowSolt) != null
                        && (Int32)Thread.GetData(msgShowSolt) == 1))
                    {
                        TMsgDisp.Show(null,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             "",
                             ex.Message,
                             status,
                             MessageBoxButtons.OK);

                    }
                }
                else
                {
                    TMsgDisp.Show(null,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                "",
                                ex.Message,
                                status,
                                MessageBoxButtons.OK);

                }
                // ---ADD K2014/05/26 ���N�n�� Redmine 42571  ---------------------------------------<<<<<
                return status;
            }
            //---�@2012/04/02�@Delphi5��DLL���Ăяo���B <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return status;
        }

        // ADD START 2012/04/10
        /// <summary>
        /// Delphi Method�̌Ăяo���̃f���Q�[�g
        /// </summary>
        /// <param name="address"></param>
        /// <param name="password"></param>
        /// <param name="nonce"></param>
        /// <param name="created"></param>
        /// <param name="irecv"></param>
        /// <param name="irecr"></param>
        /// <param name="errkbn"></param>
        /// <returns>�񓯊��f���Q�[�g�̒�`</returns>
        delegate int xPMPU9013AsyncCall(string address, string password, string nonce, string created, int irecv, int irecr, ref int errkbn);
        /// <summary>
        /// Delphi Method�̌Ăяo��
        /// </summary>
        /// <param name="address"></param>
        /// <param name="password"></param>
        /// <param name="nonce"></param>
        /// <param name="created"></param>
        /// <param name="irecv"></param>
        /// <param name="irecr"></param>
        /// <param name="errkbn"></param>
        /// <returns>�������\�b�h��񓯊��Ăяo�������</returns>
        private int xPMPU9013Async(string address, string password, string nonce, string created, int irecv, int irecr, ref int errkbn)
        {
            return xPMPU9013(_uoeSupplier.UOEOrderUrl,                                                        //---�h���C��
                              address.Substring(address.Length - (address.Length - 1)),                       //---�h���C���ȉ��̃A�h���X
                              _uoeSupplier.UOEConnectUserId,                                                  //---�ڑ����ID
                              password,                                                                       //---�ڑ���̃p�X���[�h
                              System.IO.Directory.GetCurrentDirectory(),                                      //---���MXML�̃t�@�C���p�X
                              _uoeSupplier.DaihatsuOrdreDiv,                                                  //---�v���g�R��
                              _uoeSupplier.InqOrdDivCd,                                                       //---���M��^�C�v
                // ----- DEL 2012/06/19 xupz --------->>>>>
                //_uoeSupplier.EnterpriseCode.Substring(_uoeSupplier.EnterpriseCode.Length - 9),  //---��ƃR�[�h�̖��� 
                // ----- DEL 2012/06/19 xupz ---------<<<<<
                // ----- ADD 2012/06/19 xupz --------->>>>>
                //��ƃR�[�h���Z�b�g����ہA���O���J�b�g����
                              // 2012/09/10 UPD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                              //_uoeSupplier.EnterpriseCode.Substring(_uoeSupplier.EnterpriseCode.Length - 9).TrimStart('0'),  //---��ƃR�[�h�̖��� 
                              _uoeSupplier.BLMngUserCode,                                                     //BL�Ǘ����[�U�[�R�[�h
                              // 2012/09/10 UPD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
                // ----- ADD 2012/06/19 xupz ---------<<<<<
                              _uoeSupplier.LoginTimeoutVal * 1000,                                            //---�^�C���A�E�g
                              nonce,                                                                          //---nonce���Z�b�g
                              created,                                                                        //---Created���Z�b�g
                              GetDigest(String.Format("{0}{1}{2}", nonce, created, password)),                //---Password���Z�b�g
                              irecv,                                                                          //---�d����M����t���O
                              irecr,                                                                          //---�����t���O
                              ref errkbn);                                                                    //---�G���[���b�Z�[�W
        }
        // ADD END   2012/04/10

        /// -+<summary>
        /// ���M�d���f�[�^��Web�T�[�r�X�p�p�����[�^�ɕϊ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���M�d���f�[�^��Web�T�[�r�X�p�p�����[�^�ɕϊ�����</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private string ConvertUoeSndHedToXML(UoeSndHed uoeSendingData, bool isReceivingStock, int InqOrdDivCd)
        {
            //--- 2012/04/02 �폜�@���̕����̏�����Delphi5�Ŏ������邽�� >>>>>>>>>>>>>>>>>>>>
            //// �w�b�_���ǉ�
            //HeaderMake(this._uoeSupplier, InqOrdDivCd);
            //--- 2012/04/02 �폜�@���̕����̏�����Delphi5�Ŏ������邽�� <<<<<<<<<<<<<<<<<<<<

            string xmlFileString = "";
            if (_errorFlag == false)
            {   // �v�����̐ݒ�
                SetNetsendXML(uoeSendingData, isReceivingStock, InqOrdDivCd);
                xmlFileString = fileChange();
            }
            else
            {
                // --- DEL �N�䗺�� 2014/03/04---------->>>>>
                // add by liusy 2011/12/02 --------->>>>>>>
                //xmlFileString = "from=" + fristGyoNo + "to=" + lastGyoNo;
                //if (InqOrdDivCd == 0)
                //{

                //    fileName = System.IO.Directory.GetCurrentDirectory() + "\\SPKSEND.XML";
                //}
                ////B,C�^�C�v
                //else
                //{
                //    fileName = System.IO.Directory.GetCurrentDirectory() + "\\NETRECR.XML";
                //}
                // add by liusy 2011/12/02 ---------<<<<<<<
                // --- DEL �N�䗺�� 2014/03/04----------<<<<<
                // --- ADD �N�䗺�� 2014/03/04---------->>>>>
                if (InqOrdDivCd == 0)
                {
                    xmlFileString = "from=" + fristGyoNo + "to=" + lastGyoNo;
                    fileName = System.IO.Directory.GetCurrentDirectory() + "\\SPKSEND.XML";
                }
                //B�^�C�v�Ŋ��v���g�R����HTTP�i��a�A���}�g�A�C�����̂݁j
                //PM7�Ɠ����^�p�ł���ΑS������&��t������K�v���L�邪�ғ����Ď��Ԃ������Ă���
                //�S���ƃe�X�g���s���ƃe�X�g�͈͂��傫���ׂR�Ђ݂̂Ƃ���
                else if (InqOrdDivCd == 1 && _uoeSupplier.DaihatsuOrdreDiv == 0)
                {
                    xmlFileString = "from=" + fristGyoNo + "&" + "to=" + lastGyoNo;
                    fileName = System.IO.Directory.GetCurrentDirectory() + "\\NETRECR.XML";
                }
                //C�^�C�v��B�^�C�v�̃v���g�R��HTTPS
                else
                {
                    xmlFileString = "from=" + fristGyoNo + "to=" + lastGyoNo;
                    fileName = System.IO.Directory.GetCurrentDirectory() + "\\NETRECR.XML";
                }
                // --- ADD �N�䗺�� 2014/03/04----------<<<<<


                FileStream file = new FileStream(fileName, FileMode.Create);

                file.Write(Encoding.UTF8.GetBytes(xmlFileString), 0, Encoding.UTF8.GetByteCount(xmlFileString));
                file.Close();
            }

            return xmlFileString;
        }

        #region [DEL 2012/04/02 ���̕����̏�����Delphi5�Ŏ������邽��]
        //--- 2012/04/02 �폜�@���̕����̏�����Delphi5�Ŏ������邽��
        ///// <summary>
        ///// �w�b�_���ǉ�
        ///// </summary>
        //private void HeaderMake(UOESupplier uoeSupplier, int InqOrdDivCd)
        //{
        //
        //    request.Accept = "*/*";
        //    request.Headers.Add("Accept-Language", "ja");
        //    //WSSE�F�ؗp�̕���������
        //    string wsse = CreateWSSEToken(uoeSupplier.UOEConnectUserId, uoeSupplier.UOEConnectPassword);
        //
        //    //sHead = "Accept-Language: ja" + STRING_CHANGE_ROW;
        //
        //    request.Headers.Add("X-WSSE: " + wsse);
        //
        //    if (InqOrdDivCd == 2)
        //    {
        //        request.Headers.Add("X-PMREN", uoeSupplier.EnterpriseCode.Substring(uoeSupplier.EnterpriseCode.Length - 9));
        //    }
        //    request.ContentType = "multipart/form-data; boundary=" + STRING_BOUNDARY.Substring(2);
        //    request.KeepAlive = true;
        //    if (this._uoeSupplier.LoginTimeoutVal != 0)
        //    {
        //        request.Timeout = this._uoeSupplier.LoginTimeoutVal * 1000;
        //    }
        //}
        //--- 2012/04/02 �폜�@���̕����̏�����Delphi5�Ŏ������邽��
        #endregion

        /// <summary>
        /// 16�i���\�L��SHA-1���b�Z�[�W�_�C�W�F�X�g�𐶐����܂��B
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private string GetDigest(string source)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            StringBuilder answer = new StringBuilder();
            foreach (Byte b in sha1.ComputeHash(Encoding.UTF8.GetBytes(source)))
            {
                if (b < 16)
                {
                    answer.Append("0");
                }
                answer.Append(Convert.ToString(b, 16));
            }
            return answer.ToString();
        }

        /// <summary>
        /// Nonce�𐶐����܂��B
        /// Nonce�͐��x�̍����[������������𗘗p���Ă��������B
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private string CreateNonce()
        {
            Random r = new Random();
            double d1 = r.NextDouble();
            double d2 = d1 * d1;
            return GetDigest(d2.ToString());
        }

        #region [DEL 2012/04/02 ���̕����̏�����Delphi5�Ŏ������邽��]
        //--- 2012/04/02 �폜�@���̕����̏�����Delphi5�Ŏ������邽��
        ///// <summary>
        ///// Nonce�𐶐����܂��B
        ///// Nonce�͐��x�̍����[������������𗘗p���Ă��������B
        ///// </summary>
        ///// <param name="source"></param>
        ///// <returns></returns>
        //private string CreateWSSEToken(string userName, string password)
        //{
        //    StringBuilder wsseToken = new StringBuilder();
        //    string nonce = CreateNonce();
        //    string created = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffffZ");
        //    string passwordDigest = Convert.ToBase64String(Encoding.UTF8.GetBytes(GetDigest(String.Format("{0}{1}{2}", nonce, created, password))));

        //    //Username Token�̕�����𐶐����� 
        //    wsseToken.Append("UsernameToken ");
        //    wsseToken.AppendFormat("Username=\"{0}\", ", userName);
        //    wsseToken.AppendFormat("PasswordDigest=\"{0}\", ", passwordDigest);
        //    wsseToken.AppendFormat("Nonce=\"{0}\", ", nonce);
        //    wsseToken.AppendFormat("Created=\"{0}\" ", created);

        //    return wsseToken.ToString();
        //}
        //--- 2012/04/02 �폜�@���̕����̏�����Delphi5�Ŏ������邽��
        #endregion

        #region [DEL 2012/04/02 ���̕����̏�����Delphi5�Ŏ������邽��]
        //--- 2012/04/02 �폜�@���̕����̏�����Delphi5�Ŏ������邽��
        ///// <summary>
        ///// ����I�[�v������
        ///// </summary>
        ///// <param name="daihatsuOrdreDiv">UOE������}�X�^�̃v���g�R��</param>
        ///// <param name="address">�A�h���X</param>
        ///// <returns></returns>
        //private bool RequestOpen(int daihatsuOrdreDiv, string address)
        //{
        //    bool isConnected;
        //    int flags;
        //    isConnected = InternetGetConnectedState(out flags, 0);

        //    if (InternetAttemptConnect(0) != ERROR_SUCCESS || isConnected == false)
        //    {
        //        // ������I�[�y���G���[
        //        return false;
        //    }
        //    string httpHead = "";
        //    //HTTP/HTTPS �v���g�R��  
        //    if (_uoeSupplier.DaihatsuOrdreDiv == 0)
        //    {
        //        httpHead = "http://";
        //    }
        //    else
        //    {
        //        httpHead = "https://";
        //    }
        //    request = (HttpWebRequest)HttpWebRequest.Create(httpHead + _uoeSupplier.UOEOrderUrl + address);
        //    request.Method = "POST";
        //    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.0.3705; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        //    return true;
        //}
        //--- 2012/04/02 �폜�@���̕����̏�����Delphi5�Ŏ������邽��
        #endregion

        /// <summary>
        /// Web�T�[�r�X����̖߂�l����M�d���f�[�^�ɕϊ�����
        /// </summary>
        /// <param name="isReceivingStock"></param>
        /// <param name="errorCode"></param>
        /// <param name="uoeReceivedData"></param>
        /// <remarks>
        /// <br>Note       : Web�T�[�r�X����̖߂�l����M�d���f�[�^�ɕϊ�����</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011/10/26</br>
        /// <br>Update Note: 2014/04/1 ���X�؋M�p</br>
        ///	<br>			 UOE���N�G�X�g��M�d����Q�Ή�</br>
        /// <br>Update Note: 2016/04/07 �c����</br>
        /// <br>             Redmine#48694 SPK�d����M�G���[�̑Ή�</br>
        /// <br>Update Note: 2016/09/28 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11201848-00</br>
        /// <br>             Redmine#48879 XML�ǂݍ��݌�AXML�I�u�W�F�N�g�̕�����s��</br>
        /// </remarks>
        private void ConvertXMLToUoeSndHed(UoeSndHed uoeSendingData, bool isReceivingStock, string errorCode, int InqOrdDivCd, ref UoeRecHed uoeReceivedData)
        {
            uoeReceivedData = new UoeRecHed();
            uoeReceivedData.BusinessCode = uoeSendingData.BusinessCode;
            uoeReceivedData.CommAssemblyId = uoeSendingData.CommAssemblyId;
            uoeReceivedData.UOESupplierCd = uoeSendingData.UOESupplierCd;
            uoeReceivedData.UoeRecDtlList = new List<UoeRecDtl>();
            //--- 2012/04/02 �폜 >>>>>>>>>>>>>>>>>>>>>>
            //bool EmptyFlag = false;
            //--- 2012/04/02 �폜 <<<<<<<<<<<<<<<<<<<<<<

            //XML�t�@�C���쐬
            if (recvReader == null)
            {
                //A�^�C�v
                if (InqOrdDivCd == 0)
                {
                    fileRecName = System.IO.Directory.GetCurrentDirectory() + "\\SPKRECV.XML";
                }
                //
                else
                {
                    fileRecName = System.IO.Directory.GetCurrentDirectory() + "\\NETRECV.XML";
                }
                recvReader = new XmlTextReader(fileRecName);
            }

            # region XML���ڂ��e�[�u���ɃZ�b�g
            this.dsResponse = new NewDataSet2();
            // upd 2012/07/13 >>>
            //this._netRecvDataTable = ((NewDataSet2)this.dsResponse).PartsmanResponseTbl;
            //NewDataSet2.PartsmanResponseTblRow netrecvRow = this._netRecvDataTable.NewPartsmanResponseTblRow();
            this._netRecvDataTable = ((NewDataSet2)this.dsResponse).PartsmanResponseTbl1003;
            NewDataSet2.PartsmanResponseTbl1003Row netrecvRow = this._netRecvDataTable.NewPartsmanResponseTbl1003Row();
            // upd 2012/07/13 <<<
            int iCnt = 0;
            string nodeName = "";
            // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�---------->>>>>
            int iGyono = -1;
            // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�----------<<<<<

            //----- ADD 2016/09/28 �c���� Redmine#48879 XML�ǂݍ��݌�AXML�I�u�W�F�N�g�̕��� ----->>>>>
            try
            {
            //----- ADD 2016/09/28 �c���� Redmine#48879 XML�ǂݍ��݌�AXML�I�u�W�F�N�g�̕��� -----<<<<<
                if (recvReader.ReadState != ReadState.Error)
                {
                    while (recvReader.Read())
                    {
                        //--- 2012/04/02 ����͎󒍓��t�݂̂ōs�� >>>>>>>>>>>>>>>>>>>>>>>
                        //if (iCnt == 2)
                        if (iCnt == 1)
                        //--- 2012/04/02 ����͎󒍓��t�݂̂ōs�� <<<<<<<<<<<<<<<<<<<<<<<
                        {
                        //----- ADD 2016/04/07 �c���� Redmine#48694 SPK�d����M�G���[�̑Ή� ----->>>>>
                        // �d����M�ł͂Ȃ��ꍇ
                        if (!isReceivingStock)
                        {
                        //----- ADD 2016/04/07 �c���� Redmine#48694 SPK�d����M�G���[�̑Ή� -----<<<<<
                            // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�---------->>>>>
                            if (iGyono >= 0)
                            {
                                // ���}�[�N�A���C�����}�[�N��A�z�z�񂩂�擾
                                netrecvRow.REMARK = RemarkDic[iGyono];
                                netrecvRow.CHKCD = ChkcdDic[iGyono];
                            }
                            // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�----------<<<<<
                        } // ADD 2016/04/07 �c���� Redmine#48694 SPK�d����M�G���[�̑Ή�
                            // upd 2012/07/13 >>>
                            //this._netRecvDataTable.AddPartsmanResponseTblRow(netrecvRow);
                            //netrecvRow = this._netRecvDataTable.NewPartsmanResponseTblRow();
                            this._netRecvDataTable.AddPartsmanResponseTbl1003Row(netrecvRow);
                            netrecvRow = this._netRecvDataTable.NewPartsmanResponseTbl1003Row();
                            // upd 2012/07/13 <<<
                            iCnt = 0;
                            // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�---------->>>>>
                            iGyono = -1;
                            // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�----------<<<<<
                        }
                        //--- 2012/04/02 �폜 >>>>>>>>>>>>>>>>>>>>>>
                        //byte[] byteArr = null;
                        //--- 2012/04/02 �폜 <<<<<<<<<<<<<<<<<<<<<<
                        switch (recvReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (recvReader.Name != null && recvReader.Name != string.Empty)
                                {
                                    nodeName = recvReader.Name;
                                }

                                break;
                            case XmlNodeType.Text:
                                if (nodeName == RECV_UKENO)        //��t�ԍ�
                                {
                                }
                                else if (nodeName == RECV_DENBKB)        //�d���敪
                                {
                                    netrecvRow.DENBKB = int.Parse(recvReader.Value.ToString());
                                }
                                else if (nodeName == RECV_KUBUN)        //�����敪
                                {
                                    netrecvRow.KUBUN = recvReader.Value.ToString();
                                }
                                else if (nodeName == RECV_GYONO)        //�s�ԍ�
                                {
                                    netrecvRow.GYONO = int.Parse(recvReader.Value.ToString());
                                    // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�---------->>>>>
                                    iGyono = netrecvRow.GYONO;
                                    // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�----------<<<<<
                                }
                                else if (nodeName == RECV_RESULT)        //��������
                                {
                                    netrecvRow.RESULT = int.Parse(recvReader.Value.ToString());
                                }
                                else if (nodeName == RECV_REQNO)        //�d���⍇���ԍ�
                                {
                                    netrecvRow.REQNO = recvReader.Value.ToString();
                                }
                                else if (nodeName == RECV_REQGYO)        //�`�[�p�s�ԍ�
                                {
                                    netrecvRow.REQGYO = int.Parse(recvReader.Value.ToString());
                                }
                                else if (nodeName == RECV_REMARK)        //�ϰ��i���l�j
                                {
                                    // --- DEL ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�---------->>>>>
                                    //netrecvRow.REMARK = recvReader.Value.ToString();
                                    // --- DEL ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�----------<<<<<
                                //----- ADD 2016/04/07 �c���� Redmine#48694 SPK�d����M�G���[�̑Ή� ----->>>>>
                                // �d����M�̏ꍇ
                                if (isReceivingStock)
                                {
                                    // ��MXML�t�@�C��������l(REMARK)���擾�i�֑������ϊ���PMPU9013�ŏ����j
                                    netrecvRow.REMARK = recvReader.Value;
                                }
                                //----- ADD 2016/04/07 �c���� Redmine#48694 SPK�d����M�G���[�̑Ή� -----<<<<<
                                }
                                else if (nodeName == RECV_NHNKB)        //�[�i�敪
                                {
                                    netrecvRow.NHNKB = recvReader.Value.ToString();
                                }
                                else if (nodeName == RECV_HNSBT)        //���i���
                                {
                                    //�w�苒�_ �폜�i�s�v�Ɣ��f�j
                                }
                                else if (nodeName == RECV_JYUHNNO)        //�󒍕��i�ԍ�
                                {
                                    netrecvRow.JYUHNNO = recvReader.Value.ToString();
                                }
                                else if (nodeName == RECV_SYUHNNO)        //�o�ו��i�ԍ�
                                {
                                    netrecvRow.SYUHNNO = recvReader.Value.ToString();
                                }
                                else if (nodeName == RECV_MKCD)        //Ұ������
                                {
                                    netrecvRow.MKCD = recvReader.Value.ToString();
                                }
                                else if (nodeName == RECV_UKEYMD)        //��t���t
                                {
                                    netrecvRow.UKEYMD = int.Parse(recvReader.Value.ToString());
                                    //--- 2012/04/02 ����͎󒍓��t�݂̂ōs�� >>>>>>>>>>>>>>>>
                                    //if (iCnt == 1)
                                    //{
                                    //    iCnt = 2;
                                    //}
                                    iCnt = 1;
                                    //--- 2012/04/02 ����͎󒍓��t�݂̂ōs�� <<<<<<<<<<<<<<<<
                                }
                                else if (nodeName == RECV_HINNM)        //�i��
                                {
                                    //--- 2012/04/02 ����͎󒍓��t�݂̂ōs�� >>>>>>>>>>>>>>>>>
                                    //netrecvRow.HINNM = recvReader.Value.ToString();
                                    //iCnt = 1;

                                    if (recvReader.Value.ToString().Length > 20)
                                    {
                                        netrecvRow.HINNM = recvReader.Value.ToString().Substring(0, 19);
                                    }
                                    else
                                    {
                                        netrecvRow.HINNM = recvReader.Value.ToString();
                                    }
                                    //--- 2012/04/02 ����͎󒍓��t�݂̂ōs�� <<<<<<<<<<<<<<<<<

                                }
                                else if (nodeName == RECV_SHOTIK)        //�艿
                                {
                                    netrecvRow.SHOTIK = int.Parse(recvReader.Value.ToString());
                                }
                                else if (nodeName == RECV_SKRTNK)        //�d�؂�P��
                                {
                                    // upd 2012/07/13 >>>
                                    //netrecvRow.SKRTNK = int.Parse(recvReader.Value.ToString());
                                    netrecvRow.SKRTNK = double.Parse(recvReader.Value.ToString());
                                    // upd 2012/07/13 <<<
                                }
                                else if (nodeName == RECV_JYUSU)        //�󒍐�
                                {
                                    netrecvRow.JYUSU = int.Parse(recvReader.Value.ToString());
                                }
                                else if (nodeName == RECV_SYUSU)        //�o�א�
                                {
                                    netrecvRow.SYUSU = int.Parse(recvReader.Value.ToString());
                                }
                                else if (nodeName == RECV_BOKB)        //BO�敪
                                {
                                    netrecvRow.BOKB = recvReader.Value.ToString();
                                }
                                else if (nodeName == RECV_BOSU)        //BO��
                                {
                                    netrecvRow.BOSU = int.Parse(recvReader.Value.ToString());
                                }
                                else if (nodeName == RECV_SYUNO)        //�o�ד`�[�ԍ�
                                {
                                    // upd 2012/07/13 >>>
                                    //netrecvRow.SYUNO = int.Parse(recvReader.Value.ToString());
                                    netrecvRow.SYUNO = recvReader.Value.ToString();
                                    // upd 2012/07/13 <<<
                                }
                                else if (nodeName == RECV_BOUKENO)        //BO��t�ԍ�
                                {
                                    // upd 2012/07/13 >>>
                                    //netrecvRow.BOUKENO = int.Parse(recvReader.Value.ToString());
                                    netrecvRow.BOUKENO = recvReader.Value.ToString();
                                    // upd 2012/07/13 <<<
                                }
                                else if (nodeName == RECV_CHKCD)        //ײ��ϰ��i���l�j
                                {
                                    // --- DEL ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�---------->>>>>
                                    //netrecvRow.CHKCD = recvReader.Value.ToString();
                                    // --- DEL ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�---------->>>>>
                                //----- ADD 2016/04/07 �c���� Redmine#48694 SPK�d����M�G���[�̑Ή� ----->>>>>
                                // �d����M�̏ꍇ
                                if (isReceivingStock)
                                {
                                    // ��MXML�t�@�C������ײ��ϰ�(CHKCD)���擾�i�֑������ϊ���PMPU9013�ŏ����j
                                    netrecvRow.CHKCD = recvReader.Value;
                                }
                                //----- ADD 2016/04/07 �c���� Redmine#48694 SPK�d����M�G���[�̑Ή� -----<<<<<
                                }
                                else if (nodeName == RECV_LINERR)        //ײ�ү����
                                {
                                    netrecvRow.LINERR = recvReader.Value.ToString();
                                }
                                break;
                            case XmlNodeType.EndElement:
                                nodeName = "";
                                break;
                            default:
                                break;
                        }

                    }

                }
            //----- ADD 2016/09/28 �c���� Redmine#48879 XML�ǂݍ��݌�AXML�I�u�W�F�N�g�̕��� ----->>>>>
            }
            finally
            {
                if (recvReader != null)
                {
                    recvReader.Close();
                    recvReader = null;
                }
            }
            //----- ADD 2016/09/28 �c���� Redmine#48879 XML�ǂݍ��݌�AXML�I�u�W�F�N�g�̕��� -----<<<<<
            # endregion

            UoeRecDtl Dtl = new UoeRecDtl();
            Dtl.UOESalesOrderRowNo = new List<int>();

            byte[] recv_work = new byte[5120];
            byte[] toByteArray = new byte[256];
            byte[] recv = new byte[toByteArray.Length];

            UoeCommonFnc.MemSet(ref recv_work, 0x20, recv_work.Length);

            iCnt = 0;
            int recv_pnt = 0;
            string REQNO_BACK = "";

            // upd 2012/07/13 >>>
            //this.tableresp = this.dsResponse.Tables["PartsmanResponseTbl"];
            this.tableresp = this.dsResponse.Tables["PartsmanResponseTbl1003"];
            // upd 2012/07/13 <<<

            // �ŏ��ɋ󖾍ׂ̍쐬�u�J�ǂƋU��v�@
            toByteArray = new byte[256];
            Dtl = new UoeRecDtl();
            Dtl.RecTelegram = toByteArray;
            Dtl.RecTelegramLen = Dtl.RecTelegram.Length;
            uoeReceivedData.UoeRecDtlList.Add(Dtl);

            Dtl = new UoeRecDtl();

            // �e�[�u���Ɍ���������ꍇ
            if (this.tableresp.Rows.Count != 0)
            {
                // �e�[�u���̌�������LOOP
                for (int index = 0; index < tableresp.Rows.Count; index++)
                {
                    System.Data.DataRow netrecvRow1 = tableresp.Rows[index];
                    toByteArray = new byte[256];

                    //�@�d����M�ł͖����ꍇ
                    if (!isReceivingStock)
                    {
                        if (((netrecvRow1["REQNO"].ToString() != REQNO_BACK) || (iCnt == 5)) && (iCnt != 0))
                        {
                            iCnt = 0;
                            //�@ADD���K�v
                            //�@���׍s�����̃o�b�t�@���쐬���A���e���R�s�[
                            recv = new byte[recv_pnt];
                            UoeCommonFnc.MemCopy(ref recv, 0, ref recv_work, 0, recv_pnt);

                            //�@��M���̍\���̂ɓ��e���Z�b�g
                            Dtl.RecTelegram = recv;
                            Dtl.RecTelegramLen = recv.Length;
                            Dtl.DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;
                            Dtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;

                            //�@��M���̍\���̂ɒǉ�
                            uoeReceivedData.UoeRecDtlList.Add(Dtl);

                            recv_work = new byte[5120];
                            UoeCommonFnc.MemSet(ref recv_work, 0x20, recv_work.Length);

                            recv_pnt = 0;
                            Dtl = new UoeRecDtl();
                            Dtl.UOESalesOrderRowNo = new List<int>();
                        }

                        //�@RecTelegram�ɒǉ�
                        iCnt = iCnt + 1;
                        toByteArray = (byte[])ToByteArray(netrecvRow1);
                        UoeCommonFnc.MemCopy(ref recv_work, recv_pnt, ref toByteArray, 0, toByteArray.Length);
                        recv_pnt += toByteArray.Length;
                        Dtl.UOESalesOrderNo = int.Parse((string)tableresp.Rows[index]["REQNO"]);

                        // �����������瑗�M�����ꍇ�A���̖��׍s�����Z�b�g���Ȃ���΂����Ȃ�����
                        for (int index1 = 0; index1 < uoeSendingData.UoeSndDtlList.Count; index1++)
                        {
                            if (Dtl.UOESalesOrderNo == uoeSendingData.UoeSndDtlList[index1].UOESalesOrderNo)
                            {
                                Dtl.UOESalesOrderRowNo.Add(uoeSendingData.UoeSndDtlList[index1].UOESalesOrderRowNo[iCnt - 1]);
                                break;
                            }
                        }

                        REQNO_BACK = netrecvRow1["REQNO"].ToString();
                    }
                    else
                    {
                        toByteArray = (byte[])ToByteArray(netrecvRow1);

                        recv = new byte[toByteArray.Length];
                        UoeCommonFnc.MemCopy(ref recv, 0, ref toByteArray, 0, toByteArray.Length);

                        Dtl = new UoeRecDtl();
                        Dtl.RecTelegram = recv;
                        Dtl.RecTelegramLen = recv.Length;
                        Dtl.UOESalesOrderNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderNo;
                        Dtl.UOESalesOrderRowNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderRowNo;

                        Dtl.DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;
                        Dtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;

                        //�@��M���̍\���̂ɒǉ�
                        uoeReceivedData.UoeRecDtlList.Add(Dtl);
                    }
                }

                if (!isReceivingStock)
                {
                    recv = new byte[recv_pnt];
                    UoeCommonFnc.MemCopy(ref recv, 0, ref recv_work, 0, recv_pnt);
                    Dtl.RecTelegram = recv;
                    Dtl.RecTelegramLen = recv.Length;
                    Dtl.DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;
                    Dtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;
                    // ��M�d�����e�����X�g�ɒǉ�
                    uoeReceivedData.UoeRecDtlList.Add(Dtl);
                }
            }
            else
            {
                if (isReceivingStock)
                {
                    Dtl.UOESalesOrderNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderNo;
                    Dtl.UOESalesOrderRowNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderRowNo;
                    uoeReceivedData.UoeRecDtlList.Add(Dtl);
                }
            }

            //�Ō�ɋ󖾍ׂ̍쐬�u�J�ǂƋU��v�@
            toByteArray = new byte[256];
            Dtl = new UoeRecDtl();
            Dtl.RecTelegram = toByteArray;
            Dtl.RecTelegramLen = Dtl.RecTelegram.Length;
            uoeReceivedData.UoeRecDtlList.Add(Dtl);
        }

        /// <summary>
        /// �d����M�����ł���̏ꍇ�AXML�̐ݒ�
        /// </summary>
        /// <param name="uoeSendingData">�t�n�d��M�w�b�_�[�N���X</param>
        /// <remarks>
        /// <br>Note       : �d����M�����ł���̏ꍇ�AXML�̐ݒ�</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011/10/27</br>
        /// </remarks>
        private void SetReceivingStockXMLFlie(ref XmlWriter writer)
        {
            //�d���敪
            // �d���敪�Ɂg�U�O�h���Œ�ŃZ�b�g���A���̍��ڂ͉����Z�b�g�v���܂���
            writer.WriteStartElement(SEND_DENBKB);
            writer.WriteValue(DENBKB_60);
            writer.WriteFullEndElement();
            //�s�ԍ�
            writer.WriteStartElement(SEND_GYONO);
            writer.WriteValue(0);
            writer.WriteFullEndElement();
            //�d���⍇���ԍ�
            writer.WriteStartElement(SEND_REQNO);
            writer.WriteFullEndElement();
            //�`�[�p�s�ԍ�
            writer.WriteStartElement(SEND_REQGYO);
            writer.WriteValue(0);
            writer.WriteFullEndElement();
            //���}�[�N�i���l�j
            writer.WriteStartElement(SEND_REMARK);
            writer.WriteFullEndElement();
            //�[�i�敪
            writer.WriteStartElement(SEND_NHNKB);
            writer.WriteFullEndElement();
            //���i���
            writer.WriteStartElement(SEND_HNSBT);
            writer.WriteValue(0);
            writer.WriteFullEndElement();
            //���i�ԍ�
            writer.WriteStartElement(SEND_JYUHNNO);
            writer.WriteFullEndElement();
            //���[�J�[�R�[�h
            writer.WriteStartElement(SEND_MKCD);
            writer.WriteFullEndElement();
            //����
            writer.WriteStartElement(SEND_JYUSU);
            writer.WriteValue(0);
            writer.WriteFullEndElement();
            //�a�^�n�敪
            writer.WriteStartElement(SEND_BOKB);
            writer.WriteFullEndElement();
            //���C�����}�[�N�i���l�j
            writer.WriteStartElement(SEND_CHKCD);
            writer.WriteFullEndElement();

        }
        /// <summary>
        /// �t�@�C����ύX
        /// </summary>
        /// <param name="uoeSendingData">�t�n�d��M�w�b�_�[�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�@�C���̕ύX</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011/10/26</br>
        /// <br>Update Note: 2013/02/18 ������</br>
        ///	<br>			 2013/03/13�z�M���ARedmine#34610</br>
        ///	<br>			 ������}�X�^��PGID���u1003�v�ڑ��^�C�v���uA�^�C�v�v</br>
        ///	<br>             �̏ꍇ�ɂP��XML���쐬���āA���ɂ���XML�𑗐M����B</br> 
        /// </remarks>
        private string fileChange()
        {
            //�t�@�C���֑��M
            string fileString = "";
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                byte[] byDate = new byte[file.Length];
                char[] charDate = new char[file.Length];
                file.Read(byDate, 0, (int)file.Length);
                //Decoder d = Encoding.UTF8.GetDecoder();//DEL 2013/02/18 ������ for Redmine#34610
                Decoder d = Encoding.Default.GetDecoder();//ADD 2013/02/18 ������ for Redmine#34610
                d.GetChars(byDate, 0, byDate.Length, charDate, 0);
                for (int i = 0; i < charDate.Length; i++)
                {
                    fileString = fileString + charDate[i];
                }
                file.Close();
            }
            catch (Exception)
            {
                fileString = "";
            }
            return fileString;
        }
        /// <summary>
        /// xml to datatable����
        /// </summary>
        /// <remarks>
        /// <br>Note       :xml to dic�������s���܂��B</br>
        /// <br>Programmer : liusy</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void XmlLoad()
        {
            MakerDic = new Dictionary<string, string>();
            List<UoeCdparameterList> fromXmlUoeList = null;
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, SAVE_XML_NAME)))
            {
                try
                {
                    // XML���璊�o�����A�C�e���N���X�z��Ƀf�V���A���C�Y����
                    fromXmlUoeList = UserSettingController.DeserializeUserSetting<List<UoeCdparameterList>>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, SAVE_XML_NAME));
                }
                catch (InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, SAVE_XML_NAME));
                }
            }
            if (fromXmlUoeList != null && fromXmlUoeList.Count > 0)
            {
                for (int i = 0; i < fromXmlUoeList.Count; i++)
                {
                    UoeCdparameterList fromXmlUoeCdList = (UoeCdparameterList)fromXmlUoeList[i];
                    if (fromXmlUoeCdList.UoeCdparameter.Equals(String.Format("{0:D6}", this._uoeSupplier.UOESupplierCd)))
                    {
                        for (int j = 0; j < fromXmlUoeCdList.MakerCdList.Count; j++)
                        {
                            MakerDic.Add(fromXmlUoeCdList.MakerCdList[j], String.Format("{0:D6}", this._uoeSupplier.UOESupplierCd));
                        }
                    }
                }
            }

        }
        /// <summary>
        /// �v�����̐ݒ�
        /// </summary>
        /// <param name="uoeSendingData">�t�n�d��M�w�b�_�[�N���X</param>
        /// <remarks>
        /// <br>Note       : �v�����̐ݒ�</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011/10/26</br>
        /// <br>Update Note: 2013/02/18 ������</br>
        ///	<br>			 2013/03/13�z�M���ARedmine#34610</br>
        ///	<br>			 ������}�X�^��PGID���u1003�v�ڑ��^�C�v���uA�^�C�v�v</br>
        ///	<br>             �̏ꍇ�ɂP��XML���쐬���āA���ɂ���XML�𑗐M����B</br> 
        /// <br>Date       : 2011/10/26</br>
        /// <br>Update Note: 2014/04/1 ���X�؋M�p</br>
        ///	<br>			 UOE���N�G�X�g��M�d����Q�Ή�</br>
        /// </remarks>
        private void SetNetsendXML(UoeSndHed uoeSendingData, bool isReceivingStock, int InqOrdDivCd)
        {

            int j = 1;
            XmlWriterSettings settings = new XmlWriterSettings();
            // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�---------->>>>>
            int iGyono = 0;
            // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�----------<<<<<
            settings.Indent = true;
            settings.NewLineOnAttributes = false;
            settings.Encoding = Encoding.Default;
            // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�---------->>>>>
            // ���}�[�N�i�[�A�z�z��̃N���A
            RemarkDic.Clear();
            // ���C�����}�[�N�i�[�A�z�z��̃N���A
            ChkcdDic.Clear();
            // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�----------<<<<<
            //XML�t�@�C���쐬
            if (sendWriter == null)
            {

                if (InqOrdDivCd == 0)
                {
                    fileName = System.IO.Directory.GetCurrentDirectory() + "\\SPKSEND.XML";

                }
                //B,C�^�C�v
                else
                {
                    fileName = System.IO.Directory.GetCurrentDirectory() + "\\NETSEND.XML";
                }
                sendWriter = XmlWriter.Create(fileName, settings);

            }


            //Write the XML delcaration. 
            sendWriter.WriteStartDocument();
            //A�^�C�v
            if (InqOrdDivCd == 0)
            {
                //--- 2012/04/02 �ύX�@�^�O���̂̑啶���E��������SPK���ł͊m�F���Ă��邽�� >>>>>
                //sendWriter.WriteStartElement("spkSend");
                sendWriter.WriteStartElement("SpkSend");
                //--- 2012/04/02 �ύX�@�^�O���̂̑啶���E��������SPK���ł͊m�F���Ă��邽�� <<<<<

                //���Y���i��ݒ�
                XmlLoad();
            }
            //B,C�^�C�v
            else
            {
                //--- 2012/04/02 �ύX�@�^�O���̂̑啶���E��������SPK���ł͊m�F���Ă��邽�ߔO�̂��� >>>>>
                //sendWriter.WriteStartElement("netSend");
                sendWriter.WriteStartElement("NETSEND");
                //--- 2012/04/02 �ύX�@�^�O���̂̑啶���E��������SPK���ł͊m�F���Ă��邽�ߔO�̂��� <<<<<
            }

            // �J�Ǔd���̔����敪
            string kubun = null;
            for (int index = 0; index < uoeSendingData.UoeSndDtlList.Count; index++)
            {

                UoeSndDtl uoeSndDtl = uoeSendingData.UoeSndDtlList[index];
                byte[] sndTelegram = uoeSndDtl.SndTelegram;
                string readStr = null;
                if (index == 0)
                {
                    byte[] kaiTelegram = uoeSndDtl.SndTelegram;
                    UoeCommonFnc.MemCopy(ref kubun, ref kaiTelegram, 36, 1);
                }
                if (index == 0 || index == uoeSendingData.UoeSndDtlList.Count - 1)
                {
                    continue;
                }
                UoeRecDtl uoeRecDtl = new UoeRecDtl();
                // �d����M�����ł���
                if (isReceivingStock)
                {

                    // �d���敪���d���敪
                    // �d���敪�Ɂg�U�O�h���Œ�ŃZ�b�g���A���̍��ڂ͉����Z�b�g�v���܂���
                    sendWriter.WriteStartElement("DATA");
                    SetReceivingStockXMLFlie(ref sendWriter);
                    sendWriter.WriteFullEndElement();

                    //�Y���f�[�^�̏ꍇ�́A[UOESalesOrderNo]�֒l���Z�b�g
                    //�Ώۖ��ׂ�Send���̒l���Z�b�g
                }
                else if (!isReceivingStock)
                {

                    uoeRecDtl.DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_RcvNG;
                    uoeRecDtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_YES;

                    UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, 15, 1);
                    int detailCount = int.Parse(readStr);
                    for (int m = 1; m <= detailCount; m++)
                    {
                        int i = 0;
                        int iValue = 0;
                        sendWriter.WriteStartElement("DATA");
                        // �d����M�����ł͂Ȃ�
                        # region �d���敪
                        sendWriter.WriteStartElement(SEND_DENBKB);

                        // ����
                        if (uoeSendingData.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Order)
                        {
                            sendWriter.WriteValue(DENBKB_35);
                        }
                        // �݌�
                        else
                        {
                            sendWriter.WriteValue(DENBKB_45);
                        }
                        sendWriter.WriteFullEndElement();
                        i = i + 1;
                        # endregion

                        # region �����敪
                        ////B,C�^�C�v
                        if (InqOrdDivCd != 0)
                        {
                            // �J�Ǔd���̔����敪�������敪
                            sendWriter.WriteStartElement(SEND_KUBUN);
                            sendWriter.WriteValue(kubun);
                            sendWriter.WriteFullEndElement();
                        }
                        i = i + 1;
                        # endregion

                        # region �s�ԍ�
                        sendWriter.WriteStartElement(SEND_GYONO);
                        sendWriter.WriteValue(j);
                        // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�---------->>>>>
                        // ���}�[�N�A���C�����}�[�N�p�ɍs�ԍ����ꎞ�I�ɕێ�
                        iGyono = j;
                        // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�----------<<<<<
                        j++;
                        sendWriter.WriteFullEndElement();
                        # endregion

                        # region �d���⍇���ԍ�
                        i = i + 7;
                        // �d���⍇���ԍ����d���⍇���ԍ�
                        sendWriter.WriteStartElement(SEND_REQNO);
                        readStr = null;
                        UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 6);
                        sendWriter.WriteValue(readStr.Trim());
                        sendWriter.WriteFullEndElement();
                        uoeRecDtl.UOESalesOrderNo = Convert.ToInt32(readStr);
                        // --- DEL ������ 2013/02/18 for Redmine#34610---------->>>>>
                        //�����m�F�� �J�n�̖₢���킹�ԍ����擾
                        //if (index == 1)
                        //{
                        //    fristGyoNo = readStr;
                        //}
                        ////�����m�F�� �I���̖₢���킹�ԍ����擾
                        //if (index == uoeSendingData.UoeSndDtlList.Count - 2)
                        //{
                        //    lastGyoNo = readStr;
                        //}
                        // --- DEL ������ 2013/02/18 for Redmine#34610----------<<<<<
                        // --- ADD ������ 2013/02/18 for Redmine#34610---------->>>>>
                        //B,C�^�C�v
                        if (InqOrdDivCd != 0)
                        {
                            //�����m�F�� �J�n�̖₢���킹�ԍ����擾
                            if (index == 1)
                            {
                                fristGyoNo = readStr;
                            }
                            //�����m�F�� �I���̖₢���킹�ԍ����擾
                            if (index == uoeSendingData.UoeSndDtlList.Count - 2)
                            {
                                lastGyoNo = readStr;
                            }
                        }
                        else
                        {
                            //�����m�F�� �J�n�A�I���̖₢���킹�ԍ����擾
                            if (fristGyoNo == string.Empty)
                            {
                                //�J�n�̖₢���킹�ԍ����擾
                                fristGyoNo = readStr;
                                string tempReadStr = null;
                                // �ŏI���̖₢���킹�ԍ����擾
                                byte[] tempSndTelegram = _uoeSndDtlCopyList[_uoeSndDtlCopyList.Count - 2].SndTelegram;
                                UoeCommonFnc.MemCopy(ref tempReadStr, ref tempSndTelegram, i, 6);
                                //�I���̖₢���킹�ԍ����擾
                                lastGyoNo = tempReadStr;
                            }
                        }
                        // --- ADD ������ 2013/02/18 for Redmine#34610----------<<<<<
                        i = i + 6;
                        # endregion

                        # region �`�[�p�s�ԍ�
                        // ���M���i�����`�[�p�s�ԍ�
                        sendWriter.WriteStartElement(SEND_REQGYO);
                        //���M���i��(1���M�d�����̖��׍s��)���擾
                        sendWriter.WriteValue(m);
                        uoeRecDtl.UOESalesOrderRowNo.Add(m);
                        sendWriter.WriteFullEndElement();
                        i = i + 1;
                        # endregion

                        # region ���}�[�N�i���l�j
                        // ���}�[�N�i���l�j�����}�[�N�i���l�j
                        sendWriter.WriteStartElement(SEND_REMARK);
                        readStr = null;
                        UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 10);
                        sendWriter.WriteValue(readStr.Trim());
                        sendWriter.WriteFullEndElement();
                        i = i + 10;
                        // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�---------->>>>>
                        // ���}�[�N��A�z�z��Ɋi�[
                        RemarkDic.Add(iGyono, readStr.Trim());
                        // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�----------<<<<<
                        # endregion

                        # region �[�i�敪
                        // �[�i�敪���[�i�敪
                        sendWriter.WriteStartElement(SEND_NHNKB);
                        readStr = null;
                        UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 1);
                        //--- 2012/04/02 SPK�͍݌Ɋm�F�̏ꍇ�@�[�i�敪1�łȂ���΃G���[�ɂȂ錏�̑Ή��@>>>>>>>>>>>>>>
                        //sendWriter.WriteValue(readStr.Trim());
                        //sendWriter.WriteFullEndElement();

                        if ((InqOrdDivCd == 0) && (uoeSendingData.BusinessCode != (int)EnumUoeConst.TerminalDiv.ct_Order))
                        {
                            sendWriter.WriteValue("1");
                        }
                        else
                        {
                            sendWriter.WriteValue(readStr.Trim());
                        }
                        sendWriter.WriteFullEndElement();
                        //--- 2012/04/02 SPK�͍݌Ɋm�F�̏ꍇ�@�[�i�敪1�łȂ���΃G���[�ɂȂ錏�̑Ή�  <<<<<<<<<<<<<<
                        i = i + 1;
                        # endregion

                        # region ���i���
                        //�w�苒�_
                        i = i + 3;
                        //�\���敪(1)
                        i = i + 1;
                        //�\���敪(2)
                        i = i + 1;
                        // ���i��� 1:���Y���i��ݒ�i�Œ�jTODO    
                        sendWriter.WriteStartElement(SEND_HNSBT);
                        if (InqOrdDivCd == 0)
                        {
                            readStr = null;
                            UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i + (m - 1) * 43 + 20, 4);
                            if (readStr != string.Empty && MakerDic.ContainsKey(readStr))
                            {
                                sendWriter.WriteValue("6");
                            }
                            else
                            {
                                sendWriter.WriteValue("1");
                            }
                        }
                        else
                        {
                            sendWriter.WriteValue("1");
                        }
                        sendWriter.WriteFullEndElement();
                        i = i + (m - 1) * 43;
                        # endregion

                        # region ���i�ԍ�
                        // ���i�ԍ��`���C�����}�[�N�i���l�j
                        // �d���̕��i�ԍ������i�ԍ�
                        sendWriter.WriteStartElement(SEND_JYUHNNO);
                        readStr = null;
                        UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 20);
                        sendWriter.WriteValue(readStr.Trim());
                        sendWriter.WriteFullEndElement();
                        i = i + 20;
                        # endregion

                        # region ���[�J�[�R�[�h
                        // �d���̃��[�J�[�R�[�h�����[�J�[�R�[�h
                        sendWriter.WriteStartElement(SEND_MKCD);
                        readStr = null;
                        UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 4);
                        sendWriter.WriteValue(readStr.Trim());
                        sendWriter.WriteFullEndElement();
                        i = i + 4;
                        # endregion

                        # region ����
                        //���ރR�[�h
                        i = i + 4;
                        // �d���̐��ʁ�����
                        sendWriter.WriteStartElement(SEND_JYUSU);
                        readStr = null;
                        UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 3);
                        iValue = 0;
                        Int32.TryParse(readStr, out iValue);
                        sendWriter.WriteValue(iValue);
                        i = i + 3;
                        sendWriter.WriteFullEndElement();
                        # endregion

                        # region �a�^�n�敪
                        // �d���̂a�^�n�敪���a�^�n�敪
                        sendWriter.WriteStartElement(SEND_BOKB);
                        readStr = null;
                        UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 1);
                        sendWriter.WriteValue(readStr.Trim());
                        sendWriter.WriteFullEndElement();
                        i = i + 1;
                        # endregion

                        # region ײ��ϰ��i���l�j
                        //�\���R�[�h
                        i = i + 1;
                        // �d���̃`�F�b�N�R�[�h�����C�����}�[�N�i���l�j
                        sendWriter.WriteStartElement(SEND_CHKCD);
                        readStr = null;
                        UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 10);
                        sendWriter.WriteValue(readStr.Trim());
                        sendWriter.WriteFullEndElement();
                        i = i + 10;
                        // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�---------->>>>>
                        // ���C�����}�[�N��A�z�z��Ɋi�[
                        ChkcdDic.Add(iGyono, readStr.Trim());
                        // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�----------<<<<<
                        # endregion
                        sendWriter.WriteFullEndElement();
                    }
                }
                UoeRecDtlDic.Add(uoeRecDtl.UOESalesOrderNo, uoeRecDtl);

            }

            sendWriter.WriteFullEndElement();

            sendWriter.Flush();

            sendWriter.Close();

        }
        /// <summary>
        /// �o�C�g�^�z��ɕϊ�
        /// </summary>
        /// <returns>�o�C�g�^�z��</returns>
        /// <remarks>
        /// <br>Note       : �o�C�g�^�z��ɕϊ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/05/07</br>
        /// <br>Programmer : �x�c</br>
        /// <br>Date       : 2010/06/08</br>
        /// <br>Note       : Redmine#48897 �r�o�j�d����M�����C��</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2017/03/02</br>
        /// </remarks>
        public byte[] ToByteArray(System.Data.DataRow netrecvRow)
        {
            byte[] toByteArray = new byte[256];
            UoeCommonFnc.MemSet(ref toByteArray, 0x20, toByteArray.Length);
            byte[] byteArr = null;

            // Web�T�[�r�X�߂�l�̓d���敪����M�d���f�[�^�̓d���敪
            byteArr = new byte[1];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["DENBKB"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 0);

            // Web�T�[�r�X�߂�l�̏����敪����M�d���f�[�^�̏����敪
            byteArr = new byte[1];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["KUBUN"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 1);

            // Web�T�[�r�X�߂�l�̏������ʁ���M�d���f�[�^�̏�������
            byteArr = new byte[2];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["RESULT"].ToString().PadLeft(2, '0'), 2);
            byteArr.CopyTo(toByteArray, 2);

            // Web�T�[�r�X�߂�l�̓d���⍇���ԍ�����M�d���f�[�^�̓d���⍇���ԍ�
            byteArr = new byte[6];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["REQNO"].ToString().PadLeft(6, '0'), 6);
            byteArr.CopyTo(toByteArray, 4);

            // Web�T�[�r�X�߂�l�̓`�[�p�s�ԍ�����M�d���f�[�^�̉񓚓d���Ή��s��
            byteArr = new byte[1];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["REQGYO"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 10);

            // Web�T�[�r�X�߂�l�̃��}�[�N�i���l�j����M�d���f�[�^�̃��}�[�N�i���l�j
            byteArr = new byte[10];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["REMARK"].ToString(), 10);
            byteArr.CopyTo(toByteArray, 11);

            // Web�T�[�r�X�߂�l�̔[�i�敪����M�d���f�[�^�̔[�i�敪
            byteArr = new byte[1];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["NHNKB"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 21);

            // Web�T�[�r�X�߂�l�̎󒍕��i�ԍ�����M�d���f�[�^�̎󒍕��i�ԍ�
            byteArr = new byte[20];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["JYUHNNO"].ToString(), 20);
            byteArr.CopyTo(toByteArray, 25);

            // Web�T�[�r�X�߂�l�̏o�ו��i�ԍ�����M�d���f�[�^�̏o�ו��i�ԍ�
            byteArr = new byte[20];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SYUHNNO"].ToString(), 20);
            byteArr.CopyTo(toByteArray, 45);

            // Web�T�[�r�X�߂�l�̃��[�J�[�R�[�h����M�d���f�[�^�̃��[�J�[�R�[�h
            byteArr = new byte[4];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["MKCD"].ToString().PadLeft(4, '0'), 4);
            byteArr.CopyTo(toByteArray, 65);

            // Web�T�[�r�X�߂�l�̎�t���t����M�d���f�[�^�̕��ރR�[�h
            byteArr = new byte[4];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["UKEYMD"].ToString().Substring(4, 4), 4);
            byteArr.CopyTo(toByteArray, 69);

            // Web�T�[�r�X�߂�l�̕i������M�d���f�[�^�̕i��
            byteArr = new byte[20];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["HINNM"].ToString(), 20);
            byteArr.CopyTo(toByteArray, 73);

            // Web�T�[�r�X�߂�l�̒艿����M�d���f�[�^�̒艿
            byteArr = new byte[7];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SHOTIK"].ToString().PadLeft(7, '0'), 7);
            byteArr.CopyTo(toByteArray, 93);

            // Web�T�[�r�X�߂�l�̎d�ؒP������M�d���f�[�^�̎d�ؒP��
            byteArr = new byte[7];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SKRTNK"].ToString().PadLeft(7, '0'), 7);
            byteArr.CopyTo(toByteArray, 100);

            // Web�T�[�r�X�߂�l�̎󒍐�����M�d���f�[�^�̎󒍐�
            byteArr = new byte[3];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["JYUSU"].ToString().PadLeft(3, '0'), 3);
            byteArr.CopyTo(toByteArray, 107);

            // Web�T�[�r�X�߂�l�̏o�ɐ�����M�d���f�[�^�̏o�ɐ�
            byteArr = new byte[3];
            // UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SYUSU"].ToString().PadLeft(3, '0'), 3); // DEL BY �v�� 2017/03/02 FOR Redmine#48897 �r�o�j�d����M�����C��
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SYUSU"].ToString(), 3);                    // ADD BY �v�� 2017/03/02 FOR Redmine#48897 �r�o�j�d����M�����C��
            byteArr.CopyTo(toByteArray, 110);

            // Web�T�[�r�X�߂�l�̂a�^�n�敪����M�d���f�[�^�̂a�^�n�敪
            byteArr = new byte[1];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["BOKB"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 113);

            // Web�T�[�r�X�߂�l�̂a�^�n������M�d���f�[�^�̂a�^�n��
            byteArr = new byte[3];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["BOSU"].ToString().PadLeft(3, '0'), 3);
            byteArr.CopyTo(toByteArray, 115);

            // Web�T�[�r�X�߂�l�̏o�ד`�[�ԍ�����M�d���f�[�^�̏o�ד`�[�ԍ�
            byteArr = new byte[6];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            //--- 2012/04/02 �󔒂��Z�b�g���ꂽ�ꍇ�̕ϊ��Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //if ((int)netrecvRow["SYUNO"] == 0)
            //{
            //    UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            //}
            //else
            //{
            //    UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SYUNO"].ToString().PadLeft(6, '0'), 6);
            //}

            // del 2012/07/13 >>>
            //try
            //{
            //    if ((int)netrecvRow["SYUNO"] == 0)
            //    {
            //        UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            //    }
            //    else
            //    {
            //        UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SYUNO"].ToString().PadLeft(6, '0'), 6);
            //    }
            //}
            //catch
            //{
            //    if (netrecvRow["SYUNO"].ToString().Trim() == "")
            //    {
            //        UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            //    }
            //}
            // del 2012/07/13 <<<
            // add 2012/07/13 >>>
            if (netrecvRow["SYUNO"].ToString().Trim() != "")
            {
                UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SYUNO"].ToString().PadLeft(6, '0'), 6);
            }
            else
            {
                UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            }
            // add 2012/07/13 <<<
            //--- 2012/04/02 �󔒂��Z�b�g���ꂽ�ꍇ�̕ϊ��Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            byteArr.CopyTo(toByteArray, 118);

            // Web�T�[�r�X�߂�l�̂a�^�n��t�ԍ�����M�d���f�[�^�̂a�^�n��t�ԍ�
            byteArr = new byte[6];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            //--- 2012/04/02 �󔒂��Z�b�g���ꂽ�ꍇ�̕ϊ��Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //if ((int)netrecvRow["BOUKENO"] == 0)
            //{
            //    UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            //}
            //else
            //{
            //    UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["BOUKENO"].ToString().PadLeft(6, '0'), 6);
            //}

            // del 2012/07/13 >>>
            //try
            //{
            //    if ((int)netrecvRow["BOUKENO"] == 0)
            //    {
            //        UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            //    }
            //    else
            //    {
            //        UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["BOUKENO"].ToString().PadLeft(6, '0'), 6);
            //    }
            //}
            //catch
            //{
            //    if (netrecvRow["BOUKENO"].ToString().Trim() == "")
            //    {
            //        UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            //    }
            //}
            // del 2012/07/13 <<<
            // add 2012/07/13 >>>
            if (netrecvRow["BOUKENO"].ToString().Trim() != "")
            {
                UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["BOUKENO"].ToString().PadLeft(6, '0'), 6);
            }
            else
            {
                UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            }
            // add 2012/07/13 <<<
            //--- 2012/04/02 �󔒂��Z�b�g���ꂽ�ꍇ�̕ϊ��Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            byteArr.CopyTo(toByteArray, 124);

            // Web�T�[�r�X�߂�l�̃��C�����b�Z�[�W����M�d���f�[�^�̃��C���G���[
            byteArr = new byte[15];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["LINERR"].ToString(), 15);
            byteArr.CopyTo(toByteArray, 130);

            // Web�T�[�r�X�߂�l�̃��C���}�[�N�i���l�j����M�d���f�[�^�̃`�F�b�N�R�[�h
            byteArr = new byte[10];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["CHKCD"].ToString(), 10);
            byteArr.CopyTo(toByteArray, 145);

            return toByteArray;
        }
        // --- ADD ������ 2013/02/18 for Redmine#34610---------->>>>>
        /// <summary>
        /// Web�T�[�r�X����̖߂�l����M�d���f�[�^�ɕϊ�����
        /// </summary>
        /// <param name="uoeSendingData"></param>
        /// <param name="isReceivingStock"></param>
        /// <param name="uoeReceivedData"></param>
        /// <remarks>
        /// <br>Note       : Web�T�[�r�X����̖߂�l����M�d���f�[�^�ɕϊ�����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void ConvertAtypeXMLToUoeSndHed(UoeSndHed uoeSendingData, bool isReceivingStock, ref UoeRecHed uoeReceivedData)
        {
            uoeReceivedData = new UoeRecHed();
            uoeReceivedData.BusinessCode = uoeSendingData.BusinessCode;
            uoeReceivedData.CommAssemblyId = uoeSendingData.CommAssemblyId;
            uoeReceivedData.UOESupplierCd = uoeSendingData.UOESupplierCd;
            uoeReceivedData.UoeRecDtlList = new List<UoeRecDtl>();

            UoeRecDtl Dtl = new UoeRecDtl();
            Dtl.UOESalesOrderRowNo = new List<int>();

            byte[] recv_work = new byte[5120];
            byte[] toByteArray = new byte[256];
            byte[] recv = new byte[toByteArray.Length];

            UoeCommonFnc.MemSet(ref recv_work, 0x20, recv_work.Length);

            int iCnt = 0;
            int recv_pnt = 0;
            string REQNO_BACK = "";

            this.tableresp = this.dsResponse.Tables["PartsmanResponseTbl1003"];

            // �ŏ��ɋ󖾍ׂ̍쐬�u�J�ǂƋU��v�@
            toByteArray = new byte[256];
            Dtl = new UoeRecDtl();
            Dtl.RecTelegram = toByteArray;
            Dtl.RecTelegramLen = Dtl.RecTelegram.Length;
            uoeReceivedData.UoeRecDtlList.Add(Dtl);

            Dtl = new UoeRecDtl();

            // �e�[�u���Ɍ���������ꍇ
            if (this.tableresp.Rows.Count != 0)
            {
                // �e�[�u���̌�������LOOP
                for (int index = 0; index < tableresp.Rows.Count; index++)
                {
                    System.Data.DataRow netrecvRow1 = tableresp.Rows[index];
                    toByteArray = new byte[256];

                    //�@�d����M�ł͖����ꍇ
                    if (!isReceivingStock)
                    {
                        if (((netrecvRow1["REQNO"].ToString() != REQNO_BACK) || (iCnt == 5)) && (iCnt != 0))
                        {
                            iCnt = 0;
                            //�@ADD���K�v
                            //�@���׍s�����̃o�b�t�@���쐬���A���e���R�s�[
                            recv = new byte[recv_pnt];
                            UoeCommonFnc.MemCopy(ref recv, 0, ref recv_work, 0, recv_pnt);

                            //�@��M���̍\���̂ɓ��e���Z�b�g
                            Dtl.RecTelegram = recv;
                            Dtl.RecTelegramLen = recv.Length;
                            Dtl.DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;
                            Dtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;

                            //�@��M���̍\���̂ɒǉ�
                            uoeReceivedData.UoeRecDtlList.Add(Dtl);

                            recv_work = new byte[5120];
                            UoeCommonFnc.MemSet(ref recv_work, 0x20, recv_work.Length);

                            recv_pnt = 0;
                            Dtl = new UoeRecDtl();
                            Dtl.UOESalesOrderRowNo = new List<int>();
                        }

                        //�@RecTelegram�ɒǉ�
                        iCnt = iCnt + 1;
                        toByteArray = (byte[])ToByteArray(netrecvRow1);
                        UoeCommonFnc.MemCopy(ref recv_work, recv_pnt, ref toByteArray, 0, toByteArray.Length);
                        recv_pnt += toByteArray.Length;
                        Dtl.UOESalesOrderNo = int.Parse((string)tableresp.Rows[index]["REQNO"]);

                        // �����������瑗�M�����ꍇ�A���̖��׍s�����Z�b�g���Ȃ���΂����Ȃ�����
                        for (int index1 = 0; index1 < uoeSendingData.UoeSndDtlList.Count; index1++)
                        {
                            if (Dtl.UOESalesOrderNo == uoeSendingData.UoeSndDtlList[index1].UOESalesOrderNo)
                            {
                                Dtl.UOESalesOrderRowNo.Add(uoeSendingData.UoeSndDtlList[index1].UOESalesOrderRowNo[iCnt - 1]);
                                break;
                            }
                        }

                        REQNO_BACK = netrecvRow1["REQNO"].ToString();
                    }
                    else
                    {
                        toByteArray = (byte[])ToByteArray(netrecvRow1);

                        recv = new byte[toByteArray.Length];
                        UoeCommonFnc.MemCopy(ref recv, 0, ref toByteArray, 0, toByteArray.Length);

                        Dtl = new UoeRecDtl();
                        Dtl.RecTelegram = recv;
                        Dtl.RecTelegramLen = recv.Length;
                        Dtl.UOESalesOrderNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderNo;
                        Dtl.UOESalesOrderRowNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderRowNo;

                        Dtl.DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;
                        Dtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;

                        //�@��M���̍\���̂ɒǉ�
                        uoeReceivedData.UoeRecDtlList.Add(Dtl);
                    }
                }

                if (!isReceivingStock)
                {
                    recv = new byte[recv_pnt];
                    UoeCommonFnc.MemCopy(ref recv, 0, ref recv_work, 0, recv_pnt);
                    Dtl.RecTelegram = recv;
                    Dtl.RecTelegramLen = recv.Length;
                    Dtl.DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;
                    Dtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;
                    // ��M�d�����e�����X�g�ɒǉ�
                    uoeReceivedData.UoeRecDtlList.Add(Dtl);
                }
            }
            else
            {
                if (isReceivingStock)
                {
                    Dtl.UOESalesOrderNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderNo;
                    Dtl.UOESalesOrderRowNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderRowNo;
                    uoeReceivedData.UoeRecDtlList.Add(Dtl);
                }
            }

            //�Ō�ɋ󖾍ׂ̍쐬�u�J�ǂƋU��v�@
            toByteArray = new byte[256];
            Dtl = new UoeRecDtl();
            Dtl.RecTelegram = toByteArray;
            Dtl.RecTelegramLen = Dtl.RecTelegram.Length;
            uoeReceivedData.UoeRecDtlList.Add(Dtl);
        }
        /// <summary>
        /// XML�t�@�C���쐬
        /// </summary>
        /// <param name="InqOrdDivCd">�^�C�v�敪</param>
        /// <param name="isReceivingStock">�d����M�����t���O</param>
        /// <remarks>
        /// <br>Note       : XML�t�@�C���쐬</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2013/02/18</br>
        /// <br>Date       : 2011/10/26</br>
        /// <br>Update Note: 2014/04/1 ���X�؋M�p</br>
        ///	<br>			 UOE���N�G�X�g��M�d����Q�Ή�</br>
        /// <br>Update Note: 2016/04/07 �c����</br>
        /// <br>             Redmine#48694 SPK�d����M�G���[�̑Ή�</br>
        /// </remarks>
        //----- UPD 2016/04/07 �c���� Redmine#48694 SPK�d����M�G���[�̑Ή� ----->>>>>
        //private void MakeXMLFile(int InqOrdDivCd)
        private void MakeXMLFile(int InqOrdDivCd, bool isReceivingStock)
        //----- UPD 2016/04/07 �c���� Redmine#48694 SPK�d����M�G���[�̑Ή� -----<<<<<
        {
            //XML�t�@�C���쐬
            if (recvReader == null)
            {
                //A�^�C�v
                if (InqOrdDivCd == 0)
                {
                    fileRecName = System.IO.Directory.GetCurrentDirectory() + "\\SPKRECV.XML";
                }
                //
                else
                {
                    fileRecName = System.IO.Directory.GetCurrentDirectory() + "\\NETRECV.XML";
                }
                recvReader = new XmlTextReader(fileRecName);
            }

            # region XML���ڂ��e�[�u���ɃZ�b�g
            if (this.dsResponse == null)
            {
                this.dsResponse = new NewDataSet2();
                this._netRecvDataTable = ((NewDataSet2)this.dsResponse).PartsmanResponseTbl1003;
            }
            NewDataSet2.PartsmanResponseTbl1003Row netrecvRow = this._netRecvDataTable.NewPartsmanResponseTbl1003Row();
            int iCnt = 0;
            string nodeName = "";
            // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�---------->>>>>
            int iGyono = -1;
            // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�----------<<<<<

            if (recvReader.ReadState != ReadState.Error)
            {
                while (recvReader.Read())
                {
                    if (iCnt == 1)
                    {
                        //----- ADD 2016/04/07 �c���� Redmine#48694 SPK�d����M�G���[�̑Ή� ----->>>>>
                        // �d����M�ł͂Ȃ��ꍇ
                        if (!isReceivingStock)
                        {
                        //----- ADD 2016/04/07 �c���� Redmine#48694 SPK�d����M�G���[�̑Ή� -----<<<<<
                        // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�---------->>>>>
                        if (iGyono >= 0)
                        {
                            // ���}�[�N�A���C�����}�[�N��A�z�z�񂩂�擾
                            netrecvRow.REMARK = RemarkDic[iGyono];
                            netrecvRow.CHKCD = ChkcdDic[iGyono];
                        }
                        iGyono = -1;
                        // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�----------<<<<<
                        } // ADD 2016/04/07 �c���� Redmine#48694 SPK�d����M�G���[�̑Ή�
                        this._netRecvDataTable.AddPartsmanResponseTbl1003Row(netrecvRow);
                        netrecvRow = this._netRecvDataTable.NewPartsmanResponseTbl1003Row();
                        iCnt = 0;
                    }
                    switch (recvReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (recvReader.Name != null && recvReader.Name != string.Empty)
                            {
                                nodeName = recvReader.Name;
                            }

                            break;
                        case XmlNodeType.Text:
                            if (nodeName == RECV_UKENO)        //��t�ԍ�
                            {
                            }
                            else if (nodeName == RECV_DENBKB)        //�d���敪
                            {
                                netrecvRow.DENBKB = int.Parse(recvReader.Value.ToString());
                            }
                            else if (nodeName == RECV_KUBUN)        //�����敪
                            {
                                netrecvRow.KUBUN = recvReader.Value.ToString();
                            }
                            else if (nodeName == RECV_GYONO)        //�s�ԍ�
                            {
                                netrecvRow.GYONO = int.Parse(recvReader.Value.ToString());
                                // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�---------->>>>>
                                iGyono = netrecvRow.GYONO;
                                // --- ADD ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�----------<<<<<

                            }
                            else if (nodeName == RECV_RESULT)        //��������
                            {
                                netrecvRow.RESULT = int.Parse(recvReader.Value.ToString());
                            }
                            else if (nodeName == RECV_REQNO)        //�d���⍇���ԍ�
                            {
                                netrecvRow.REQNO = recvReader.Value.ToString();
                            }
                            else if (nodeName == RECV_REQGYO)        //�`�[�p�s�ԍ�
                            {
                                netrecvRow.REQGYO = int.Parse(recvReader.Value.ToString());
                            }
                            else if (nodeName == RECV_REMARK)        //�ϰ��i���l�j
                            {
                                // --- DEL ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�---------->>>>>
                                //netrecvRow.REMARK = recvReader.Value.ToString();
                                // --- DEL ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�----------<<<<<
                                //----- ADD 2016/04/07 �c���� Redmine#48694 SPK�d����M�G���[�̑Ή� ----->>>>>
                                // �d����M�̏ꍇ
                                if (isReceivingStock)
                                {
                                    // ��MXML�t�@�C��������l(REMARK)���擾�i�֑������ϊ���PMPU9013�ŏ����j
                                    netrecvRow.REMARK = recvReader.Value;
                                }
                                //----- ADD 2016/04/07 �c���� Redmine#48694 SPK�d����M�G���[�̑Ή� -----<<<<<
                            }
                            else if (nodeName == RECV_NHNKB)        //�[�i�敪
                            {
                                netrecvRow.NHNKB = recvReader.Value.ToString();
                            }
                            else if (nodeName == RECV_HNSBT)        //���i���
                            {
                                //�w�苒�_ �폜�i�s�v�Ɣ��f�j
                            }
                            else if (nodeName == RECV_JYUHNNO)        //�󒍕��i�ԍ�
                            {
                                netrecvRow.JYUHNNO = recvReader.Value.ToString();
                            }
                            else if (nodeName == RECV_SYUHNNO)        //�o�ו��i�ԍ�
                            {
                                netrecvRow.SYUHNNO = recvReader.Value.ToString();
                            }
                            else if (nodeName == RECV_MKCD)        //Ұ������
                            {
                                netrecvRow.MKCD = recvReader.Value.ToString();
                            }
                            else if (nodeName == RECV_UKEYMD)        //��t���t
                            {
                                netrecvRow.UKEYMD = int.Parse(recvReader.Value.ToString());

                                iCnt = 1;
                            }
                            else if (nodeName == RECV_HINNM)        //�i��
                            {

                                if (recvReader.Value.ToString().Length > 20)
                                {
                                    netrecvRow.HINNM = recvReader.Value.ToString().Substring(0, 19);
                                }
                                else
                                {
                                    netrecvRow.HINNM = recvReader.Value.ToString();
                                }
                            }
                            else if (nodeName == RECV_SHOTIK)        //�艿
                            {
                                netrecvRow.SHOTIK = int.Parse(recvReader.Value.ToString());
                            }
                            else if (nodeName == RECV_SKRTNK)        //�d�؂�P��
                            {
                                netrecvRow.SKRTNK = double.Parse(recvReader.Value.ToString());
                            }
                            else if (nodeName == RECV_JYUSU)        //�󒍐�
                            {
                                netrecvRow.JYUSU = int.Parse(recvReader.Value.ToString());
                            }
                            else if (nodeName == RECV_SYUSU)        //�o�א�
                            {
                                netrecvRow.SYUSU = int.Parse(recvReader.Value.ToString());
                            }
                            else if (nodeName == RECV_BOKB)        //BO�敪
                            {
                                netrecvRow.BOKB = recvReader.Value.ToString();
                            }
                            else if (nodeName == RECV_BOSU)        //BO��
                            {
                                netrecvRow.BOSU = int.Parse(recvReader.Value.ToString());
                            }
                            else if (nodeName == RECV_SYUNO)        //�o�ד`�[�ԍ�
                            {
                                netrecvRow.SYUNO = recvReader.Value.ToString();
                            }
                            else if (nodeName == RECV_BOUKENO)        //BO��t�ԍ�
                            {
                                netrecvRow.BOUKENO = recvReader.Value.ToString();
                            }
                            else if (nodeName == RECV_CHKCD)        //ײ��ϰ��i���l�j
                            {
                                // --- DEL ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�---------->>>>>
                                //netrecvRow.CHKCD = recvReader.Value.ToString();
                                // --- DEL ���X�؋M�p 2014/04/01 UOE���N�G�X�g��M�d����Q�Ή�----------<<<<<
                                //----- ADD 2016/04/07 �c���� Redmine#48694 SPK�d����M�G���[�̑Ή� ----->>>>>
                                // �d����M�̏ꍇ
                                if (isReceivingStock)
                                {
                                    // ��MXML�t�@�C������ײ��ϰ�(CHKCD)���擾�i�֑������ϊ���PMPU9013�ŏ����j
                                    netrecvRow.CHKCD = recvReader.Value;
                                }
                                //----- ADD 2016/04/07 �c���� Redmine#48694 SPK�d����M�G���[�̑Ή� -----<<<<<
                            }
                            else if (nodeName == RECV_LINERR)        //ײ�ү����
                            {
                                netrecvRow.LINERR = recvReader.Value.ToString();
                            }
                            break;
                        case XmlNodeType.EndElement:
                            nodeName = "";
                            break;
                        default:
                            break;
                    }

                }
            }
            recvReader.Close();

            # endregion
        }

        /// <summary>
        /// XML�t�@�C���̓ǂݍ���
        /// </summary>
        /// <param name="filePath">XML�t�@�C���̃p�[�X</param>
        /// <returns name="fileString">XML�t�@�C���̓��e</returns>
        /// <remarks>
        /// <br>Note       : XML�t�@�C���̓ǂݍ���</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private string ReadXML(string filePath)
        {
            string fileString = "";
            try
            {
                FileStream file = new FileStream(filePath, FileMode.Open);
                byte[] byDate = new byte[file.Length];
                char[] charDate = new char[file.Length];
                //�t�@�C���̓ǂݍ���
                file.Read(byDate, 0, (int)file.Length);
                Decoder deCoder = Encoding.Default.GetDecoder();
                deCoder.GetChars(byDate, 0, byDate.Length, charDate, 0);
                for (int i = 0; i < charDate.Length; i++)
                {
                    fileString = fileString + charDate[i];
                }
                file.Close();
            }
            catch (Exception)
            {
                fileString = "";
            }
            return fileString;
        }
        // --- ADD ������ 2013/02/18 for Redmine#34610----------<<<<<
        # endregion
    }
}