using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Library.Runtime.InteropServices
{
    /// <summary>
    /// �t�F���J�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �t�F���J�̃��[�_�^���C�^�ɃA�N�Z�X���܂��B</br>
    /// <br>           : felica.dll,rw.dll,�y�уv���O�C���̓J�����g�f�B���N�g����</br>
    /// <br>           : �z�u����Ă��鎖��O��Ƃ��Ă��܂��B</br>
    /// <br>Programmer : 22011 Kashihara</br>
    /// <br>Date       : 2008.10.30</br>
    /// <br>Update Note: 22011 Kashihara</br>
    /// <br>           : 2009.02.16 �J�[�h�������ꂽ���Ƃ��A���|�[�����O�̃X�e�[�^�X��true�Ŗ߂錻�ۂɑΉ�</br>
    /// </remarks>
    public class FelicaAcs : IDisposable
    {
        #region delegate��`
        /// <summary>�A���|�[�����O�̃R�[���o�b�N�f���Q�[�g</summary>
        public delegate bool PollingCallBackDelegate(UInt64 idm, UInt64 pmm, bool result);
        #endregion

        #region private member
        /// <summary>FeliCa.DLL���b�p�[�N���X</summary>
        private Wrapper FeliCaDllWrapper = new Wrapper();
        /// <summary>�A���|�[�����O�p�^�C�}�[</summary>
        private System.Threading.Timer _pollingTimer;
        /// <summary>�A���|�[�����O�̍ő僊�g���C��</summary>
        private int _pollingRetryMax;
        /// <summary>�A���|�[�����O�̌����g���C��</summary>
        private int _pollingRetryCnt;
        /// <summary>�ŏI�G���[���b�Z�[�W</summary>
        private string _lastErrMsg = string.Empty;
        /// <summary>�ŏI�G���[�^�C�v(rw.dll)</summary>
        private RwErrorType _rwLastErrType = RwErrorType.RW_ERROR_NOT_OCCURRED;
        /// <summary>�ŏI�G���[�^�C�v(Felica.dll)</summary>
        private FeliCaErrorType _felicaLastErrType = FeliCaErrorType.FELICA_ERROR_NOT_OCCURRED;
        /// <summary>felica.dll���ݔ���t���O</summary>
        private bool _felicaDllExists = false;
        ///// <summary>�|�[�����O�������t���O</summary>
        //private bool _pollingFlg = false;
        #endregion

        #region public member
        /// <summary>�A���|�[�����O�������̃R�[���o�b�N�f���Q�[�g</summary>
        public PollingCallBackDelegate CallBackDelegate;
        #endregion

        #region propaty
        /// <summary>�ŏI�G���[���b�Z�[�W</summary>
        public string LastErrMsg
        {
            get
            {
                return _lastErrMsg;
            }
        }

        /// <summary>�ŏI�G���[�^�C�v(Felica.dll)</summary>
        public FeliCaErrorType FelicaLastErrType
        {
            get
            {
                return this._felicaLastErrType;
            }
        }

        /// <summary>�ŏI�G���[�^�C�v(rw.dll)</summary>
        public RwErrorType RwLastErrType
        {
            get
            {
                return this._rwLastErrType;
            }
        }
        
        #endregion

        #region constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public FelicaAcs()
        {
            // felica.dll ���݃`�F�b�N
            _felicaDllExists = FelicaDllExists();
        }
        #endregion

        #region destructor
        /// <summary>
        /// �f�X�g���N�^
        /// </summary>
        ~FelicaAcs()
        {
            Dispose();
        }

        /// <summary>
        /// �f�B�X�|�[�Y����
        /// </summary>
        public void Dispose()
        {
            try
            {
                if (_felicaDllExists)
                {
                    // �|�[�����O���ŗL��Αҋ@
                    if (_pollingTimer != null)
                        System.Threading.Thread.Sleep(800);

                    if (_pollingTimer != null)
                        StopPolling();
                    // ���[�_�[�^���C�^�[�̃N���[�Y
                    FeliCaDllWrapper.CloseReaderWriter();
                    // ���C�u����,�n���h���̊J��
                    FeliCaDllWrapper.DisposeLibrary();
                }
                HandleContainer.FreeHandle();
            }
            catch
            {
            }
        }
        #endregion

        #region InitializeLibrary /���C�u�����̏�����
        /// <summary>
        /// ���C�u�����̏�����
        /// </summary>
        /// <returns></returns>
        public bool InitializeLibrary()
        {
            // felica.dll���Ȃ���ΏI��
            if (!_felicaDllExists) return false;
            bool result = true;
    
            if (!FeliCaDllWrapper.InitializeLibrary())
            {
                GetLastErrorTypes(out _felicaLastErrType, out _rwLastErrType);
                if(_felicaLastErrType != FeliCaErrorType.FELICA_LIBRARY_ALREADY_INITIALIZED)
                    result = false;
            }
            return result;
        }
        #endregion

        #region OpenReaderWriterAuto /���[�_�[�^���C�^�[�̎����F�؂ƃI�[�v��
        /// <summary>
        /// ���[�_�[�^���C�^�[�̎����F�؂ƃI�[�v��
        /// </summary>
        /// <returns></returns>
        public bool OpenReaderWriterAuto()
        {
            // felica.dll���Ȃ���ΏI��
            if (!_felicaDllExists) return false;
            bool result = true;

            if (!FeliCaDllWrapper.OpenReaderWriterAuto())
            {
                GetLastErrorTypes(out _felicaLastErrType, out _rwLastErrType);
                if (_felicaLastErrType != FeliCaErrorType.FELICA_READER_WRITER_ALREADY_OPENED)
                    result = false;
            }
            return result;
        }
        #endregion

        #region CloseReaderWriter /���[�_�[�^���C�^�[�̃N���[�Y
        /// <summary>
        /// ���[�_�[�^���C�^�[�̃N���[�Y
        /// </summary>
        /// <returns></returns>
        public bool CloseReaderWriter()
        {
            // felica.dll���Ȃ���ΏI��
            if (!_felicaDllExists) return false;

            bool result = true;
            if (!FeliCaDllWrapper.CloseReaderWriter())
            {
                GetLastErrorTypes(out _felicaLastErrType, out _rwLastErrType);
                result = false;
            }
            return result;
        }
        #endregion

        #region DisposeLibrary /���C�u�����̊J��
        /// <summary>
        /// ���C�u�����̊J��
        /// </summary>
        /// <returns></returns>
        public bool DisposeLibrary()
        {
            bool result = true;
            if (!FeliCaDllWrapper.DisposeLibrary())
            {
                GetLastErrorTypes(out _felicaLastErrType, out _rwLastErrType);
                result = false;
            }
            return result;
        }
        #endregion

        #region GetLastErrorTypes /�ŏI�G���[�擾
        /// <summary>
        /// �ŏI�G���[�擾
        /// </summary>
        /// <param name="feliCaErrorType">felica.dll�̃G���[�^�C�v</param>
        /// <param name="rwErrorType">rw.dll�̃G���[�^�C�v</param>
        /// <returns></returns>
        public bool GetLastErrorTypes(out FeliCaErrorType feliCaErrorType, out RwErrorType rwErrorType)
        {
            // felica.dll���Ȃ���ΏI��
            if (!_felicaDllExists)
            {
                feliCaErrorType = _felicaLastErrType;
                rwErrorType = _rwLastErrType;
                return false;
            }

            bool result;
            feliCaErrorType = FeliCaErrorType.FELICA_ERROR_NOT_OCCURRED;
            rwErrorType = RwErrorType.RW_ERROR_NOT_OCCURRED;
            _lastErrMsg = string.Empty;

            // �ŏI�G���[���擾
            result = FeliCaDllWrapper.GetLastErrorTypes(ref _felicaLastErrType, ref _rwLastErrType);
            // FeliCa.dll�̃G���[
            if (_felicaLastErrType != FeliCaErrorType.FELICA_ERROR_NOT_OCCURRED)
                _lastErrMsg = (Enum.Parse(Type.GetType("Broadleaf.Library.Runtime.InteropServices.FeliCaErrorTypeMsg"), ((int)_felicaLastErrType).ToString())).ToString();
            // rw.dll�̃G���[
            if (_rwLastErrType != RwErrorType.RW_ERROR_NOT_OCCURRED)
                _lastErrMsg += ("\n" + (Enum.Parse(Type.GetType("Broadleaf.Library.Runtime.InteropServices.RwErrorTypeMsg"), ((int)_rwLastErrType).ToString())).ToString());

            // �J�[�h��������Ȃ��ȊO�̃G���[��Log�������o��
            if (((feliCaErrorType != FeliCaErrorType.FELICA_ERROR_NOT_OCCURRED) || (rwErrorType != RwErrorType.RW_ERROR_NOT_OCCURRED)) &&
                 (rwErrorType != RwErrorType.RW_CARD_NOT_FOUND))
                TMsgDisp.Show(
                               emErrorLevel.ERR_LEVEL_NODISP,	      // �G���[���x��
                               "SFCMN03505CA",						  // �A�Z���u���h�c�܂��̓N���X�h�c
                               "FeliCaAcs",							  // �v���O��������
                               "GetLastErrorTypes",			          // ��������
                               TMsgDisp.OPE_CALL,					  // �I�y���[�V����
                               _felicaLastErrType.ToString() + "," +
                               _rwLastErrType.ToString() + " :" + _lastErrMsg,
                               -1,                                    // �X�e�[�^�X
                               this,	            				  // �G���[�����������I�u�W�F�N�g
                               MessageBoxButtons.OK,				  // �\������{�^��
                               MessageBoxDefaultButton.Button1);	  // �����\���{�^��

            feliCaErrorType = _felicaLastErrType;
            rwErrorType = _rwLastErrType;
            return result;
        }
        #endregion

        #region PollingAndGetCardInformation /�|�[�����O�ƃJ�[�h���̎擾
        /// <summary>
        /// �|�[�����O�ƃJ�[�h���̎擾
        /// </summary>
        /// <param name="felicaSystemCode">�t�F���J�V�X�e���R�[�h</param>
        /// <param name="cardIdm">FeliCa��IDm</param>
        /// <param name="cardPmm">FeliCa��Pmm</param>
        /// <returns></returns>
        public bool PollingAndGetCardInformation(UInt16 felicaSystemCode, out UInt64 cardIdm, out UInt64 cardPmm)
        { 
            cardIdm = 0;
            cardPmm = 0;
            
            // felica.dll���Ȃ���ΏI��
            if (!_felicaDllExists) return false;

            // �|�[�����O���\����,�J�[�h���\����
            StructurePolling polling = new StructurePolling();
            StructureCardInformation cardInformation = new StructureCardInformation();

            byte[] bytSystemCode = BitConverter.GetBytes(felicaSystemCode);
            // BitConverter.GetBytes�̓o�C�g�̕��т��t�ɂȂ�̂Ń��o�[�X����
            Array.Reverse(bytSystemCode);
            HandleContainer.FeliCaSystemCode = GCHandle.Alloc(bytSystemCode, GCHandleType.Pinned);
            polling.FelicaSystemCode = HandleContainer.FeliCaSystemCode.AddrOfPinnedObject().ToInt32();
            
            byte[] bytCardIdm = new byte[8];
            byte[] bytCardPmm = new byte[8];

            // �p�����[�^�Z�b�g
            polling.TimeSlot = 0x00;
            HandleContainer.CardIdm = GCHandle.Alloc(bytCardIdm, GCHandleType.Pinned);
            cardInformation.CardIdm = Convert.ToUInt32(HandleContainer.CardIdm.AddrOfPinnedObject().ToInt32());

            HandleContainer.CardPmm = GCHandle.Alloc(bytCardPmm, GCHandleType.Pinned);
            cardInformation.CardPmm = Convert.ToUInt32(HandleContainer.CardPmm.AddrOfPinnedObject().ToInt32());

            byte[] bytNumberOfCards = new byte[1] { 0x00 };
            HandleContainer.NumberOfCards = GCHandle.Alloc(bytNumberOfCards, GCHandleType.Pinned);

            bool result = true;
            if (!FeliCaDllWrapper.PollingAndGetCardInformation(ref polling, ref bytNumberOfCards[0], ref cardInformation))
            {
                GetLastErrorTypes(out _felicaLastErrType, out _rwLastErrType);
                result = false;
            }
            else
            {
                // ���ʂ�true�ł��A�G���[�X�e�[�^�X�ōĔ���(�h���C�o�o�[�W�����ɂ���Ă͂��ꂪ�K�p)
                GetLastErrorTypes(out _felicaLastErrType, out _rwLastErrType);
                if (_felicaLastErrType == FeliCaErrorType.FELICA_POLLING_ERROR)
                {
                    if (_rwLastErrType == RwErrorType.RW_CARD_NOT_FOUND)
                    {
                        return false;
                    }
                    // 2009.02.16 ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>S
                    if (_rwLastErrType == RwErrorType.RW_READER_WRITER_DISCONNECTED)
                    {
                        return false;
                    }
                    // 2009.02.16 ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<E
                }

                // 2009.02.16 ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>S
                if (_felicaLastErrType == FeliCaErrorType.FELICA_LIBRARY_NOT_INITIALIZED)
                {
                    return false;
                }
                // 2009.02.16 ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<E
            }
            Array.Reverse(bytCardIdm);
            Array.Reverse(bytCardPmm);
            cardIdm = BitConverter.ToUInt64(bytCardIdm, 0);
            cardPmm = BitConverter.ToUInt64(bytCardPmm, 0);
            return result;
        }
        #endregion

        #region StartPolling�EStopPolling /�A���|�[�����O�J�n�E�I��
        /// <summary>
        /// �A���|�[�����O�J�n
        /// </summary>
        /// <param name="interval">�|�[�����O�Ԋu(ms)</param>
        /// <param name="retryCount">�|�[�����O�̃��g���C��(0�w��Ŗ������g���C)</param>
        public void StartPolling(int interval, int retryCount)
        {
            _pollingRetryCnt = 0;
            _pollingRetryMax = retryCount;
            //_pollingFlg = true;
            _pollingTimer = new System.Threading.Timer(pollingTimer_Tick, null, 0, interval);
        }

        /// <summary>
        /// �A���|�[�����O���I�����܂�
        /// </summary>
        public void StopPolling()
        {
            if (_pollingTimer != null)
            {
                _pollingTimer.Dispose();
                _pollingTimer = null;
                //_pollingFlg = false;
            }
        }

        /// <summary>
        /// �A���|�[�����O���C������(���Ԋu�ŌĂяo����܂�)
        /// </summary>
        /// <param name="state">null</param>
        private void pollingTimer_Tick(object state)
        {
            UInt64 cardIdm, cardPmm;
            _pollingRetryCnt++;

            if (_pollingTimer == null)
                return;

            lock (FeliCaDllWrapper)
            {

                if ((_pollingRetryMax != 0) && (_pollingRetryMax < _pollingRetryCnt))
                {
                    // �w��񐔓��ɃJ�[�h��������Ȃ������Ƃ�
                    StopPolling();
                    CallBackDelegate(0, 0, false);
                }
                else
                {
                    if (_pollingTimer == null)
                        return;

                    if (this.PollingAndGetCardInformation(Convert.ToUInt16(FelicaSystemCodes.Any), out cardIdm, out cardPmm))
                    {   // ����
                        if (_pollingTimer != null)
                        {
                            StopPolling();
                            CallBackDelegate(cardIdm, cardPmm, true);
                        }
                    }
                    else
                    {
                        if (_pollingTimer == null)
                            return;
                        // �G���[����(�J�[�h��������Ȃ��ȊO)
                        if (_rwLastErrType != RwErrorType.RW_CARD_NOT_FOUND)
                        {
                            if (_pollingTimer != null)
                            {
                                StopPolling();
                                CallBackDelegate(0, 0, false);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region felica.dll���݃`�F�b�N
        /// <summary>
        /// felica.dll������
        /// </summary>
        /// <returns></returns>
        private bool FelicaDllExists()
        {
            string directory;
            // ���ϐ��z��������
            foreach (System.Collections.DictionaryEntry de in System.Environment.GetEnvironmentVariables(System.EnvironmentVariableTarget.Machine))
            {
                string[] paths = de.Value.ToString().Split(';');
                foreach (string psth in paths)
                {
                    try
                    {
                        directory = psth;
                        // �_�u���N�H�[�e�[�V�����͎�菜��
                        if (directory[0] == '"') directory = directory.Substring(1, directory.Length - 2);
                        if (File.Exists(Path.Combine(directory, "felica.dll")))
                        {
                            _felicaDllExists = true;
                            break;
                        }
                    }
                    catch(Exception ex)
                    {
                        // �p�X���s���Ȏ��̓��O�𗎂Ƃ�
                        TMsgDisp.Show(
                               emErrorLevel.ERR_LEVEL_NODISP,	      // �G���[���x��
                               "SFCMN03505CA",						  // �A�Z���u���h�c�܂��̓N���X�h�c
                               "FeliCaAcs",							  // �v���O��������
                               "FelicaDllExists",			          // ��������
                               TMsgDisp.OPE_CALL,					  // �I�y���[�V����
                               ex.Message + " : " + psth,             // ���b�Z�[�W
                               -1,                                    // �X�e�[�^�X
                               this,	            				  // �G���[�����������I�u�W�F�N�g
                               MessageBoxButtons.OK,				  // �\������{�^��
                               MessageBoxDefaultButton.Button1);	  // �����\���{�^��
                    }
                }
            }
            
            if (_felicaDllExists == false)
            {
                _felicaLastErrType = FeliCaErrorType.FELICA_FILE_NOT_FOUND;
                _rwLastErrType = RwErrorType.RW_FILE_NOT_FOUND;
                _lastErrMsg = "felica.dll��������܂���";
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }

    #region �t�F���J�n���h���R���e�i
    /// <summary>
    /// �t�F���J�n���h���I�u�W�F�N�g�Q
    /// </summary>
    class HandleContainer
    {
        public static GCHandle FeliCaSystemCode;
        public static GCHandle CardIdm;
        public static GCHandle CardPmm;
        public static GCHandle NumberOfCards;
        public static GCHandle NumberOfServices;
        public static GCHandle ServiceCodeList;
        public static GCHandle ServiceKeyVersionList;
        public static GCHandle Kar;
        public static GCHandle Kbr;
        public static GCHandle BlockList;
        public static GCHandle WriteBlockData;
        public static GCHandle StatusFlag1;
        public static GCHandle StatusFlag2;
        public static GCHandle ResultNumberOfBlocks;
        public static GCHandle ReadBlockData;
        public static GCHandle AreaCodeList;
        public static GCHandle EndServiceCodeList;
        public static GCHandle CardCommandPacketData;
        public static GCHandle CardResponsePacketData;
        public static GCHandle ResponsePacketLength;
       
        public static void FreeHandle()
        {
            //free handle objects.
            if (FeliCaSystemCode.IsAllocated == true)
            {
                FeliCaSystemCode.Free();
            }
            if (CardIdm.IsAllocated == true)
            {
                CardIdm.Free();
            }
            if (CardPmm.IsAllocated == true)
            {
                CardPmm.Free();
            }
            if (NumberOfCards.IsAllocated == true)
            {
                NumberOfCards.Free();
            }
            if (NumberOfServices.IsAllocated == true)
            {
                NumberOfServices.Free();
            }
            if (ServiceKeyVersionList.IsAllocated == true)
            {
                ServiceKeyVersionList.Free();
            }
            if (ServiceCodeList.IsAllocated == true)
            {
                ServiceCodeList.Free();
            }
            if (Kar.IsAllocated == true)
            {
                Kar.Free();
            }
            if (Kbr.IsAllocated == true)
            {
                Kbr.Free();
            }
            if (BlockList.IsAllocated == true)
            {
                BlockList.Free();
            }
            if (WriteBlockData.IsAllocated == true)
            {
                WriteBlockData.Free();
            }
            if (StatusFlag1.IsAllocated == true)
            {
                StatusFlag1.Free();
            }
            if (StatusFlag2.IsAllocated == true)
            {
                StatusFlag2.Free();
            }
            if (ResultNumberOfBlocks.IsAllocated == true)
            {
                ResultNumberOfBlocks.Free();
            }
            if (ReadBlockData.IsAllocated == true)
            {
                ReadBlockData.Free();
            }
            if (AreaCodeList.IsAllocated == true)
            {
                AreaCodeList.Free();
            }
            if (EndServiceCodeList.IsAllocated == true)
            {
                EndServiceCodeList.Free();
            }
            if (CardCommandPacketData.IsAllocated == true)
            {
                CardCommandPacketData.Free();
            }
            if (CardResponsePacketData.IsAllocated == true)
            {
                CardResponsePacketData.Free();
            }
            if (ResponsePacketLength.IsAllocated == true)
            {
                ResponsePacketLength.Free();
            }
        }
    }
    #endregion
}