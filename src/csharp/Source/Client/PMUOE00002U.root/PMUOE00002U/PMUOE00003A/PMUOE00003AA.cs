//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : UOE�ʐM���ʕ\���A�N�Z�X�N���X
// �v���O�����T�v   : UOE�ʐM���ʕ\���A�N�Z�X���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : �Ɠc �M�u
// �� �� ��  2008/12/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902931-00 �쐬�S�� : 杍^
// �� �� ��  2013/08/15  �C�����e : ��������(����)�����̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11001634-00 �쐬�S�� : ���N�n��
// �� �� ��  K2014/07/03 �C�����e : �G���[���b�Z�[�W�̗�O�G���[�Ή�
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using System.Threading;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// UOE�ʐM���ʕ\���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : UOE�ʐM���ʕ\���A�N�Z�X�N���X</br>
	/// <br>Programmer : �Ɠc �M�u</br>
	/// <br>Date       : 2008/12/13</br>
    /// <br>UpdateNote : 2009/01/20 �Ɠc �M�u�@�s��Ή�[10043]</br>
    /// <br>             2009/01/22 �Ɠc �M�u�@�s��Ή�[10346]</br>
    /// <br>             2009/02/04 �Ɠc �M�u�@�s��Ή�[10977]</br>
	/// </remarks>
	public partial class UoeSndRcvResultAcs
	{
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        // �萔
        private string ERRORMESSAGE_DATASENDCODE1 = "���̑��G���[";
        private string ERRORMESSAGE_DATASENDCODE2 = "���M�G���[";
        private string ERRORMESSAGE_DATASENDCODE3 = "��M�G���[";
        // HashTable�֘A
        private Hashtable _uoeSupplierHTable = null;                                        // UOE��������HashTable(key�FUOE������R�[�h)
        private Hashtable _dataSendName = null;                                             // �G���[���eHashTable(key�F���M�t���O)
        // List<OrderSndRcvJnl>�֘A
        private List<OrderSndRcvJnl> _orderSndRcvJnlList = null;                            // ����MJNL���X�g
        private List<OrderSndRcvJnl> _orderSndRcvJnlErrorList = null;                       // ����MJNL�G���[���X�g(���[�󎚗p)
        // �G���[���b�Z�[�W�֘A
        private SortedList<int, OrderSndRcvJnl> _sndRcvErrorUOESupplierList = null;         // ����M�G���[UOE�����惊�X�g(key�FUOE������R�[�h)
        private List<string> _sndRcvErrorMessageList = null;                                // ����M�G���[���b�Z�[�W(��ʕ\���p)
        private List<string> _stockErrorMessageList = null;                                 // �d���f�[�^�쐬�G���[���b�Z�[�W(��ʕ\���p)
        private List<string> _changeColorStringList = null;                                 // �F�ύX���镶���񃊃X�g
        //���̑�
        private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = null;                                    // UOE����MJNL�A�N�Z�X�N���X
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;               // ��ƃR�[�h
        private string _loginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;   // ���O�C�����_�R�[�h

        // ---- ADD 2013/08/15 杍^ ---- >>>>>
        //Thread���A���b�Z�[�W�֌W
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
        // ---- ADD 2013/08/15 杍^ ---- <<<<<


        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        // ���v���C�x�[�g�v���p�e�B
        /// <summary>UOE���Аݒ�}�X�^</summary>
        private UOESetting uOESetting { get { return this._uoeSndRcvJnlAcs.uOESetting; } }
        /// <summary>UOE������}�X�^</summary>
        private UOESupplierAcs uOESupplierAcs { get { return this._uoeSndRcvJnlAcs.uOESupplierAcs; } }

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region ��Constructors
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="orderSndRcvJnlList">����MJNL���X�g</param>
		public UoeSndRcvResultAcs(List<OrderSndRcvJnl> orderSndRcvJnlList)
		{
            // ---- ADD 2013/08/15 杍^ ---- >>>>>
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
            // ---- ADD 2013/08/15 杍^ ---- <<<<<

            // UOE����MJNL�A�N�Z�X�N���X�C���X�^���X��
            this._uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();

            // ��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// ���O�C�����_�R�[�h
            this._loginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;

            // ����MJNL
            this._orderSndRcvJnlList = orderSndRcvJnlList;

            // �G���[���e�擾
            this.CreateDataSendNameHTable();
            
            // UOE��������擾
            this.CreateUOESupplierHTable();

            // �e��C���X�^���X�쐬
            this._orderSndRcvJnlErrorList = new List<OrderSndRcvJnl>();
            this._sndRcvErrorMessageList = new List<string>();
            this._stockErrorMessageList = new List<string>();
            this._sndRcvErrorUOESupplierList = new SortedList<int, OrderSndRcvJnl>();
            this._changeColorStringList = new List<string>();
        }
		# endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region ��ShowDialog(�_�C�A���O�\��)
        /// <summary>
        /// �_�C�A���O�\��
        /// </summary>
        public void ShowDialog()
        {
            // �G���[������ꍇ�Ƀt�H�[����\��
            if (this.ErrorIsExists())
            {
                List<string> errorMessageList = new List<string>();     // ��ʕ\���p�G���[���b�Z�[�W

                // ---ADD K2014/07/03 ���N�n�� Redmine 42977  --------------------------------------->>>>>
                //�t�^�oUSB��p:Option.ON
                if (this._opt_FuTaBa == (int)Option.ON)
                {
                    //���b�Z�[�W���擾
                    msgShowSolt = Thread.GetNamedDataSlot(MSGSHOWSOLT);
                }
                // ---ADD K2014/07/03 ���N�n�� Redmine 42977  ---------------------------------------<<<<<

                // ����M�G���[�ǉ�
                errorMessageList = this._sndRcvErrorMessageList;
                if (errorMessageList.Count != 0)
                {
                    errorMessageList.Add("");
                }
                // �d���f�[�^�쐬�G���[�ǉ�
                foreach (string item in this._stockErrorMessageList)
                {
                    errorMessageList.Add(item);
                }

                // �t�H�[���\��
                UoeSndRcvResultDialog uoeSndRcvResultDialog = new UoeSndRcvResultDialog(this._orderSndRcvJnlErrorList       // ����M�G���[���X�g(���[�p)
                                                                                        , errorMessageList                  // �G���[���b�Z�[�W���X�g(��ʕ\���p)
                                                                                        , this._changeColorStringList);     // �F�ύX���镶���񃊃X�g
                //uoeSndRcvResultDialog.ShowDialog(); // DEL 2013/08/15 杍^

                // ---- ADD 2013/08/15 杍^ --- >>>>>
                //�t�^�o��pUSB�ł͂Ȃ�
                //��������(�蓮)�Ɣ�������(����)�ł͂Ȃ�
                //��������(�蓮)�ł���ꍇ
                if (this._opt_FuTaBa == (int)Option.OFF
                     || Thread.GetData(msgShowSolt) == null
                     || (Thread.GetData(msgShowSolt) != null && (Int32)Thread.GetData(msgShowSolt) == 2))
                {
                    uoeSndRcvResultDialog.ShowDialog();
                }
                // ---- ADD 2013/08/15 杍^ --- <<<<<
            }
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        // HashTable�쐬�֘A
        #region ��CreateDataSendNameHTable(�G���[���eHashTable�쐬)
        /// <summary>
        /// �G���[���eHashTable�쐬
        /// </summary>
        /// <remarks>
        /// <br>Note       : �G���[���eHashTable(key�F���M�t���O)���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private void CreateDataSendNameHTable()
        {
            this._dataSendName = new Hashtable();
            this._dataSendName[1] = ERRORMESSAGE_DATASENDCODE1;
            this._dataSendName[2] = ERRORMESSAGE_DATASENDCODE2;
            this._dataSendName[3] = ERRORMESSAGE_DATASENDCODE3;
        }
        #endregion

        #region ��CreateUOESupplierHTable(UOE��������HashTable�쐬)
        /// <summary>
        /// UOE��������HashTable�쐬
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE������HashTable(key�FUOE������R�[�h)���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private void CreateUOESupplierHTable()
        {
            this._uoeSupplierHTable = new Hashtable();

            ArrayList arrayList = null;
            int status = this.uOESupplierAcs.Search(out arrayList, this._enterpriseCode, this._loginSectionCd);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return;
            }

            // HashTable�Ɋi�[
            UOESupplier uoeSupplier = null;
            for (int i = 0; i <= arrayList.Count - 1; i++)
            {
                uoeSupplier = (UOESupplier)arrayList[i];
                this._uoeSupplierHTable[uoeSupplier.UOESupplierCd] = uoeSupplier;
            }
        }
        # endregion

        // �G���[���b�Z�[�W�쐬���C��
        #region ��ErrorIsExists(�G���[�L������)
        /// <summary>
        /// �G���[�L������
        /// </summary>
        /// <returns>True�F�G���[�L��AFalse�F�G���[����</returns>
        /// <remarks>
        /// <br>Note       : ����MJNL���X�g����G���[�ƂȂ������𔲂��o���A�G���[���b�Z�[�W���쐬���܂��B</br>
        /// <br>             ������M�G���[���b�Z�[�W�ɂ��Ă͍ŏ��A�G���[�ƂȂ���UOE������𒙂ߍ��݁A��ł܂Ƃ߂ă��b�Z�[�W�̍쐬���s���܂�</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private bool ErrorIsExists()
        {
            OrderSndRcvJnl orderSndRcvJnl = null;
            for (int i = 0; i <= this._orderSndRcvJnlList.Count - 1; i++)
            {
                orderSndRcvJnl = this._orderSndRcvJnlList[i];
                if (this.CheckSndRcvError(orderSndRcvJnl))
                {
                    // ����MJNL�G���[(���[�p)���X�g�ɒǉ�
                    this._orderSndRcvJnlErrorList.Add(orderSndRcvJnl);

                    // �G���[�ƂȂ���UOE���������ێ�
                    this.AddSndRcvErrorUOESupplierList(orderSndRcvJnl);
                    continue;
                }
                if (this.CheckStockError(orderSndRcvJnl))
                {
                    // �d���f�[�^�쐬�G���[���b�Z�[�W�擾
                    this.AddStockErrorMessageList();
                    continue;
                }
            }

            // ����M�G���[���b�Z�[�W�擾
            if (this._sndRcvErrorUOESupplierList.Count != 0)
            {
                this.AddSndRcvErrorMessageList();
            }

            if ((this._sndRcvErrorMessageList.Count == 0) && (this._stockErrorMessageList.Count == 0))
            {
                return false;
            }

            return true;
        }
        #endregion

        // ����M�G���[���b�Z�[�W�쐬�֘A
        #region ��CheckSndRcvError(����M�G���[����)
        /// <summary>
        /// ����M�G���[����
        /// </summary>
        /// <param name="orderSndRcvJnl">����MJNL</param>
        /// <returns>True�F����M�G���[�AFalse�F���̑�</returns>
        /// <remarks>
        /// <br>Note       : ����M�G���[�Ώۂ��ǂ���������s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private bool CheckSndRcvError(OrderSndRcvJnl orderSndRcvJnl)
        {
            // ���M�t���O���u9�F����I���v�ȊO�̏ꍇ�͑ΏۂƂ���
            if (orderSndRcvJnl.DataSendCode != 9)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region ��AddSndRcvErrorUOESupplierList(����M�G���[�ƂȂ���UOE��������擾)
        /// <summary>
        /// ����M�G���[�ƂȂ���UOE��������擾
        /// </summary>
        /// <param name="orderSndRcvJnl">����MJNL</param>
        /// <remarks>
        /// <br>Note       : ����M�G���[�ƂȂ���UOE�������ێ����܂��B</br>
        /// <br>             ���G���[�ƂȂ���UOE�����悪���łɕێ�����Ă���ꍇ�A���M�t���O�̕\���D�揇����������V���ɕێ����܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private void AddSndRcvErrorUOESupplierList(OrderSndRcvJnl orderSndRcvJnl)
        {
            // �Ή�����G���[���e������
            if (this._dataSendName.ContainsKey(orderSndRcvJnl.DataSendCode) == false)
            {
                return;
            }

            // UOE�����悪���łɓo�^����Ă���ꍇ
            if (this._sndRcvErrorUOESupplierList.ContainsKey(orderSndRcvJnl.UOESupplierCd))
            {
                // �o�^����Ă���f�[�^�Ɣ�r���ėD��x�̍��������ēo�^
                this._sndRcvErrorUOESupplierList[orderSndRcvJnl.UOESupplierCd] = this.CheckDataSendCodePriority(orderSndRcvJnl);
            }
            else
            {
                this._sndRcvErrorUOESupplierList.Add(orderSndRcvJnl.UOESupplierCd, orderSndRcvJnl);
            }
        }
        /// <summary>
        /// �D�揇�ʃ`�F�b�N
        /// </summary>
        /// <param name="newData">����MJNL</param>
        /// <returns>�D�揇�ʂ̍����f�[�^</returns>
        /// <remarks>
        /// <br>Note       : �G���[�ƂȂ���UOE�����悪���łɕێ�����Ă���ꍇ�A�D�揇���`�F�b�N���ėD�揇�̍������̂�V���ɕێ����܂��B</br>
        /// <br>             ���D�揇�E�E�E���M�t���O3(��M�G���[) �� ���M�t���O2(���M�G���[) �� ���M�t���O1(���̑��G���[)</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private OrderSndRcvJnl CheckDataSendCodePriority(OrderSndRcvJnl newData)
        {
            // ���݊i�[����Ă���UOE��������擾
            OrderSndRcvJnl oldData = (OrderSndRcvJnl)this._sndRcvErrorUOESupplierList[newData.UOESupplierCd];

            // ��r���ĐV�����f�[�^�̂ق����D��x��������Ό���
            if (oldData.DataSendCode < newData.DataSendCode)
            {
                return newData;
            }
            else
            {
                return oldData;
            }
        }
        #endregion

        #region ��AddSndRcvErrorMessageList(����M�G���[���b�Z�[�W�擾)
        /// <summary>
        /// ����M�G���[���b�Z�[�W�擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �G���[�ƂȂ���UOE����������ɑ���M�G���[���b�Z�[�W���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private void AddSndRcvErrorMessageList()
        {
            this._sndRcvErrorMessageList.Add("������M����");
            this._sndRcvErrorMessageList.Add("�@����G���[���������܂����B");
            this._sndRcvErrorMessageList.Add("�@�����������s���ĉ������B");
            this._sndRcvErrorMessageList.Add("");
            this._sndRcvErrorMessageList.Add(" �y�ʐM���ʁz");

            //�F�ύX���镶����
            this._changeColorStringList.Add(this._sndRcvErrorMessageList[1]);
            this._changeColorStringList.Add(this._sndRcvErrorMessageList[2]);

            // ����M�G���[�ƂȂ���UOE������������ɃG���[���b�Z�[�W�ҏW
            foreach (OrderSndRcvJnl orderSndRcvJnl in this._sndRcvErrorUOESupplierList.Values)
            {
                this._sndRcvErrorMessageList.Add(this.MakeUOESupplierMessage(orderSndRcvJnl));
            }
        }
        /// <summary>
        /// UOE������Ɋւ���G���[���b�Z�[�W��ҏW
        /// </summary>
        /// <param name="orderSndRcvJnl">����MJNL</param>
        /// <returns>�ҏW�����G���[���b�Z�[�W</returns>
        /// <remarks>
        /// <br>Note       : �ʐM���ʂ̊e������ɑ΂��ĊJ�n�ʒu�𑵂��Č��h����ǂ����܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private string MakeUOESupplierMessage(OrderSndRcvJnl orderSndRcvJnl)
        {
            StringBuilder SB = new StringBuilder();
            SB.Append("�@");
            //SB.Append(orderSndRcvJnl.UOESupplierName);                      // UOE�����於        //DEL 2009/01/22 �s��Ή�[10346]
            // ---ADD 2009/01/22 �s��Ή�[10346] ------------------------------------------>>>>>
            // UOE�����於
            if (orderSndRcvJnl.UOESupplierName.Length > 12)
            {
                SB.Append(orderSndRcvJnl.UOESupplierName.Substring(0, 12));
            }
            else
            {
                SB.Append(orderSndRcvJnl.UOESupplierName);
            }
            // ---ADD 2009/01/22 �s��Ή�[10346] ------------------------------------------<<<<<

            int editAreaByte = 32;
            int targetByte = TStrConv.SizeCountSJIS(SB.ToString());

            // 32�o�C�g�ő���Ȃ��ꍇ��8�o�C�g�ǉ�
            if (targetByte >= editAreaByte)
            {
                editAreaByte = editAreaByte + 8;
            }

            // �����������悤�ɃX�y�[�X�𖄂߂�
            for (int i = 1; i <= (editAreaByte - targetByte); i++)
            {
                SB.Append(" ");
            }

            SB.Append(this._dataSendName[orderSndRcvJnl.DataSendCode]);     // �G���[���e

            return SB.ToString();
        }
        #endregion

        // �d���f�[�^�쐬�G���[���b�Z�[�W�쐬�֘A
        #region ��CheckStockError(�d���f�[�^�쐬�G���[����)
        /// <summary>
        /// �d���f�[�^�쐬�G���[����
        /// </summary>
        /// <param name="orderSndRcvJnl">����MJNL</param>
        /// <returns>True�F�d���f�[�^�쐬�G���[�AFalse�F���̑�</returns>
        /// <remarks>
        /// <br>Note       : �d���f�[�^�쐬�G���[�Ώۂ��ǂ���������s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private bool CheckStockError(OrderSndRcvJnl orderSndRcvJnl)
        {
            // ���M�t���O���u9�F����I���v�ȊO�̏ꍇ�͑ΏۊO�Ƃ���
            if (orderSndRcvJnl.DataSendCode != 9)
            {
                return false;
            }

            // UOE������}�X�^�ɓo�^����Ă��Ȃ��ꍇ�͑ΏۊO�Ƃ���
            if (this._uoeSupplierHTable.ContainsKey(orderSndRcvJnl.UOESupplierCd) == false)
            {
                return false;
            }

            // ��M��(��M�L���敪)���u1:����v�Ŏd���f�[�^��M�敪(�d���L���敪)���u1:��M�L�v�̏ꍇ�͑ΏۊO�Ƃ���
            UOESupplier uoeSupplier = (UOESupplier)this._uoeSupplierHTable[orderSndRcvJnl.UOESupplierCd];
            if ((uoeSupplier.ReceiveCondition == 1) && (uoeSupplier.StockSlipDtRecvDiv == 1))
            {
                return false;
            }

            // ---ADD 2009/01/20 �s��Ή�[10043] ------------------------------------------------------------->>>>>
            // ���i�i�q�ɺ��ނ���ہj�ȊO�̏ꍇ�͑ΏۊO�Ƃ���
            if ((string.IsNullOrEmpty(orderSndRcvJnl.WarehouseCode) == false) && (orderSndRcvJnl.WarehouseCode != "0"))
            {
                return false;
            }
            // ---ADD 2009/01/20 �s��Ή�[10043] -------------------------------------------------------------<<<<<

            // ���ʂ�����A�`�[�ԍ�������(���_�ABO1�ABO2�ABO3)
            /* ---DEL 2009/02/04 �s��Ή�[10977] ------------------------------------------------------------->>>>>
            if (((orderSndRcvJnl.UOESectOutGoodsCnt != 0) && (string.IsNullOrEmpty(orderSndRcvJnl.UOESectionSlipNo)))
            || ((orderSndRcvJnl.BOShipmentCnt1 != 0) && (string.IsNullOrEmpty(orderSndRcvJnl.BOSlipNo1)))
            || ((orderSndRcvJnl.BOShipmentCnt2 != 0) && (string.IsNullOrEmpty(orderSndRcvJnl.BOSlipNo2)))
            || ((orderSndRcvJnl.BOShipmentCnt3 != 0) && (string.IsNullOrEmpty(orderSndRcvJnl.BOSlipNo3))))
               ---DEL 2009/02/04 �s��Ή�[10977] -------------------------------------------------------------<<<<< */
            // ---ADD 2009/02/04 �s��Ή�[10977] ------------------------------------------------------------->>>>>
            if (((orderSndRcvJnl.UOESectOutGoodsCnt != 0) && (string.IsNullOrEmpty(orderSndRcvJnl.UOESectionSlipNo.Trim())))
            || ((orderSndRcvJnl.BOShipmentCnt1 != 0) && (string.IsNullOrEmpty(orderSndRcvJnl.BOSlipNo1.Trim())))
            || ((orderSndRcvJnl.BOShipmentCnt2 != 0) && (string.IsNullOrEmpty(orderSndRcvJnl.BOSlipNo2.Trim())))
            || ((orderSndRcvJnl.BOShipmentCnt3 != 0) && (string.IsNullOrEmpty(orderSndRcvJnl.BOSlipNo3.Trim()))))
            // ---ADD 2009/02/04 �s��Ή�[10977] -------------------------------------------------------------<<<<<
            {
                return true;
            }

            // UOE���Аݒ�}�X�^�̃��[�J�[�t�H���[�v��敪���u0�F����v�̏ꍇ
            if (uOESetting.MakerFollowAddUpDiv == 0)
            {
                // ���ʂ�����(���[�J�[�t�H���[�AEO)
                if ((orderSndRcvJnl.MakerFollowCnt != 0) || (orderSndRcvJnl.EOAlwcCount != 0))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region ��AddStockErrorMessageList(�d���f�[�^�쐬�G���[���b�Z�[�W�擾)
        /// <summary>
        /// �d���f�[�^�쐬�G���[���b�Z�[�W�擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���f�[�^�쐬�G���[���b�Z�[�W���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private void AddStockErrorMessageList()
        {
            // �����������Ȃ̂ōŏ���1��̂�
            if (this._stockErrorMessageList.Count != 0)
            {
                return;
            }

            this._stockErrorMessageList.Add("���d���f�[�^�쐬����");
            this._stockErrorMessageList.Add("�@�d���f�[�^�쐬�G���[���������Ă��܂��B");
            this._stockErrorMessageList.Add("�@�d���A���}�b�`���X�g���o�͂��ĉ������B");

            // �F�ύX���镶�����ݒ�
            this._changeColorStringList.Add(this._stockErrorMessageList[1]);
            this._changeColorStringList.Add(this._stockErrorMessageList[2]);
        }
        #endregion
    }
}
