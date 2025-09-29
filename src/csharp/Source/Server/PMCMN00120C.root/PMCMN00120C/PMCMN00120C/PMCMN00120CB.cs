using System;
using Broadleaf.Application.Remoting;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Diagnostics;
using System.Text;
using System.Net;
using Microsoft.VisualBasic.Devices;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// Windows API �R�[���o�b�N�֐���`
    /// </summary>
    /// <remarks>
    /// <br>Note       : Windows API �R�[���o�b�N�֐���`������N���X�ł��B</br>
    /// <br>Programmer : </br>
    /// <br>Date       : 2020/06/15</br>
    /// </remarks>
    public class ExeConvert : RemoteDB
    { 
        #region �v���C�x�[�g�ϐ�

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;

        /// <summary>���i�R�[�h</summary>
        private string _goodsNo;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private int _goodsMakerCd;

        /// <summary>�ϊ��O�p�����[�^</summary>
        private double _convertSetParam;

        /// <summary>�ϊ���p�����[�^</summary>
        private double _convertGetParam;

        /// <summary>�R���o�[�g�ΏۊǗ��P</summary>
        private ConvertVersionSettingOne _convertVersionSettingOne;

        /// <summary>�R�[���o�b�N�֐��߂�X�e�[�^�X</summary>
        private int _callBackStatus;

        #endregion // �v���C�x�[�g�ϐ�

        #region �萔

        /// <summary>
        /// CLC���O�t�@�C����
        /// </summary>
        private const string CLCLogFileName = "PMCMN00120C_{0}_{1}.log";

        /// <summary>
        /// CLC���O�t�@�C����(�����p)
        /// </summary>
        private const string CLCLogFileNameSearch = "PMCMN00120C_{0}_{1}";

        /// <summary>
        /// CLC���O�t�@�C����
        /// </summary>
        private const string CLCLogErrMsg = "{0},status={1},EnterpriseCode={2},GoodsMakerCd={3},GoodsNo={4},ConvertSetParam={5},ConvertGetParam={6}";

        /// <summary>
        /// PC�i���O�o�́j
        /// </summary>
        private const string LOGOUTPUT_INFO_PC = "PC={0},";

        /// <summary>
        /// IP�A�h���X
        /// </summary>
        private const string LOGOUTPUT_INFO_IP = "IP={0},";

        /// <summary>
        /// �������g�p��/�e�� �i���O�o�́j
        /// </summary>
        private const string LOGOUTPUT_INFO_MEM = "MEM(MB)={0},";

        /// <summary>
        /// ���擾���s �i���O�o�́j
        /// </summary>
        private const string LOGOUTPUT_NA = "NA";

        /// <summary>
        /// ���擾��O �i���O�o�́j
        /// </summary>
        private const string LOGOUTPUT_EXNA = "EXNA";

        /// <summary>
        /// ���O�o�͓��e
        /// </summary>
        private const string LOGOUTPUT_MESSAGE = "{0} Process={1},SYSINFO:{2}";

        /// <summary>
        /// �X�^�b�N�t���[�������l
        /// ReleaseProc�AConvertProc�AReleaseProcDirect�AConvertProcDirect��胍�O�o�͂���ꍇ
        /// </summary>
        private const int FRAME_DEFAULT = 7;

        /// <summary>
        /// �X�^�b�N�t���[��
        /// ExecuteConvert�AExecuteConvert��胍�O�o�͂���ꍇ
        /// </summary>
        private const int FRAME_EXECUTECONVERT = 6;

        #endregion // �萔

        #region API�g�p�萔

        const uint COLOR_WINDOW = 5;

        const uint CS_VREDRAW = 0x0001;
        const uint CS_HREDRAW = 0x0002;

        const int CW_USEDEFAULT = -2147483648; // ((uint)0x80000000)

        const int IDC_ARROW = 32512;

        const int IDI_APPLICATION = 32512;

        const uint WM_CREATE = 0x0001;
        const uint WM_PAINT = 0x000F;

        const uint WS_OVERLAPPED = 0x00000000;
        const uint WS_POPUP = 0x80000000;
        const uint WS_CHILD = 0x40000000;
        const uint WS_MINIMIZE = 0x20000000;
        const uint WS_VISIBLE = 0x10000000;
        const uint WS_DISABLED = 0x08000000;
        const uint WS_CLIPSIBLINGS = 0x04000000;
        const uint WS_CLIPCHILDREN = 0x02000000;
        const uint WS_MAXIMIZE = 0x01000000;
        const uint WS_CAPTION = 0x00C00000; // WS_BORDER | WS_DLGFRAME
        const uint WS_BORDER = 0x00800000;
        const uint WS_DLGFRAME = 0x00400000;
        const uint WS_VSCROLL = 0x00200000;
        const uint WS_HSCROLL = 0x00100000;
        const uint WS_SYSMENU = 0x00080000;
        const uint WS_THICKFRAME = 0x00040000;
        const uint WS_GROUP = 0x00020000;
        const uint WS_TABSTOP = 0x00010000;

        const uint WS_MINIMIZEBOX = 0x00020000;
        const uint WS_MAXIMIZEBOX = 0x00010000;

        const uint WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX;

        #endregion // API�g�p�萔

        #region API��`

        /// <summary>
        /// �E�B���h�E�N���X�o�^
        /// </summary>
        /// <param name="pcWndClassEx"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern short RegisterClassEx(ref WNDCLASSEX pcWndClassEx);

        /// <summary>
        /// �E�B���h�E�쐬
        /// </summary>
        /// <param name="dwExStyle"></param>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <param name="dwStyle"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="nWidth"></param>
        /// <param name="nHeight"></param>
        /// <param name="hWndParent"></param>
        /// <param name="hMenu"></param>
        /// <param name="hInstance"></param>
        /// <param name="lpParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr CreateWindowEx(uint dwExStyle, string lpClassName, string lpWindowName, uint dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

        /// <summary>
        /// �W���E�B���h�E����
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="uMsg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// �A�C�R���ǂݍ���
        /// </summary>
        /// <param name="hInstance"></param>
        /// <param name="lpIconName"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr lpIconName);

        /// <summary>
        /// �E�B���h�E�폜
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern bool DestroyWindow(IntPtr hWnd);

        /// <summary>
        /// �E�B���h�E�N���X�o�^����
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern bool UnregisterClass(string lpClassName, IntPtr hInstance);

        #endregion // API��`

        #region API�g�p�\���̒�`

        /// <summary>
        /// �R�[���o�b�N�֐���`
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="uMsg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        delegate IntPtr WndProcDelgate(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// �E�B���h�E�N���X�쐬�\����
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct WNDCLASSEX
        {
            public uint cbSize;
            public uint style;
            public WndProcDelgate lpfnWndProc;
            public Int32 cbClsExtra;
            public Int32 cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            public string lpszMenuName;
            public string lpszClassName;
            public IntPtr hIconSm;
        }

        #endregion // API�g�p�\���̒�`

        #region �񋓑�

        private enum StatusCode
        {
            /// <summary>����</summary>
            Normal = 0
          , /// <summary>�����i�R���o�[�g�Ȃ��j</summary>
            NormalNotFound = 4
          , /// <summary>�ϊ��e�[�u���C���X�^���X����</summary>
            TableCreate = 2000
          , /// <summary>���C���X�^���X�n���h���擾</summary>
            GetHandle = 2010
          , /// <summary>�E�B���h�E�N���X�o�^�p�\���̐ݒ�</summary>
            RegistStructSet = 2020
          , /// <summary>�E�B���h�E�N���X�o�^</summary>
            RegistClass = 2030
          , /// <summary>�E�B���h�E�쐬</summary>
            CreateWindow = 2040
          , /// <summary>�E�B���h�E�폜</summary>
            DestroyWindow = 2050
          , /// <summary>�E�B���h�E�N���X�o�^����</summary>
            UnregisterClass = 2060
        };

        #endregion // �񋓑�

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public ExeConvert()
        {
            // �����l�Z�b�g
            _enterpriseCode = string.Empty;
            _goodsNo = string.Empty;
            _goodsMakerCd = int.MinValue;
            _convertSetParam = int.MinValue;
            _convertGetParam = int.MinValue;
            
        }

        #endregion // �R���X�g���N�^

        #region �v���p�e�B

        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// <summary>
        /// ���i���[�J�[�R�[�h
        /// </summary>
        public int GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// <summary>
        /// ���i�ԍ�
        /// </summary>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// <summary>
        /// �ϊ��O�p�����[�^
        /// </summary>
        public double ConvertSetParam
        {
            get { return this._convertSetParam; }
            set { this._convertSetParam = value; }
        }

        /// <summary>
        /// �ϊ���p�����[�^
        /// </summary>
        public double ConvertGetParam
        {
            get { return this._convertGetParam; }
            set { this._convertGetParam = value; }
        }

        #endregion

        #region public���\�b�h
        
        /// <summary>
        /// �ϊ���������
        /// </summary>
        /// <param name="procCls">0:�����A1:�ϊ�</param>
        /// <returns>���s�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ϊ������������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int ExecuteConvert(int procCls)
        {
            int status = (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;
            int lastError = 0; // �����l�F�G���[�Ȃ�
            string errMsg = string.Empty;
            IntPtr hInstance = IntPtr.Zero;
            IntPtr hWnd = IntPtr.Zero;
            int procStatus = (int)StatusCode.Normal;
            string windowClassName = Guid.NewGuid().ToString();
            string windowName = Guid.NewGuid().ToString();
            
#if DEBUG
            ClcLogOutput("Call ExeConvert.ExecuteConvert", FRAME_EXECUTECONVERT, true);
#endif

            try
            {
                if (_convertVersionSettingOne == null)
                {
                    // �ϊ��e�[�u���̃C���X�^���X����
                    procStatus = (int)StatusCode.TableCreate;

                    _convertVersionSettingOne = new ConvertVersionSettingOne();
                }

                // ���C���X�^���X�n���h���擾
                procStatus = (int)StatusCode.GetHandle;

                hInstance = Marshal.GetHINSTANCE(typeof(ExeConvert).Module);

                // �E�B���h�E�N���X�o�^�p�\���̐ݒ�
                procStatus = (int)StatusCode.RegistStructSet;

                WNDCLASSEX wcex = new WNDCLASSEX();
                wcex.cbSize = (uint)Marshal.SizeOf(wcex);
                wcex.style = CS_HREDRAW | CS_VREDRAW;

                if (procCls == (int)ConvertVersionSetting.ProcCls.CT_PROC_CONVERT)
                {
                    // �ϊ�
                    wcex.lpfnWndProc = new WndProcDelgate(ConvertProc);
                }
                else
                {
                    // ����
                    wcex.lpfnWndProc = new WndProcDelgate(ReleaseProc);
                }

                wcex.cbClsExtra = 0;
                wcex.cbWndExtra = 0;
                wcex.hInstance = hInstance;
                wcex.hIcon = LoadIcon(hInstance, new IntPtr(IDI_APPLICATION));
                wcex.hCursor = LoadIcon(hInstance, new IntPtr(IDC_ARROW));
                wcex.hbrBackground = new IntPtr(COLOR_WINDOW + 1);
                wcex.lpszMenuName = "";
                wcex.lpszClassName = windowClassName;
                wcex.hIconSm = IntPtr.Zero;

                // �E�B���h�E�N���X�o�^
                procStatus = (int)StatusCode.RegistClass;

                short rceRet = RegisterClassEx(ref wcex);

                if (rceRet == 0)
                {
                    // �G���[�������͏������f
                    // �G���[�擾
                    lastError = Marshal.GetLastWin32Error();

                    if (lastError == 0)
                    {
                        errMsg = "WAC.EC RCEError";
                    }
                    else
                    {
                        errMsg = "WAC.EC RCEError LastError�F" + lastError.ToString();
                    }

                    //���O�o��
                    WriteErrorLogProc(errMsg);
                }

                // �E�B���h�E�쐬
                procStatus = (int)StatusCode.CreateWindow;

                // �R�[���o�b�N�X�e�[�^�X�̏�����
                _callBackStatus = (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;

                // �R�[���o�b�N�֐����Ăяo�����
                hWnd = CreateWindowEx(
                    0,
                    windowClassName,
                    windowName,
                    WS_OVERLAPPEDWINDOW,
                    CW_USEDEFAULT,
                    CW_USEDEFAULT,
                    CW_USEDEFAULT,
                    CW_USEDEFAULT,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    hInstance,
                    IntPtr.Zero);

                if (hWnd == IntPtr.Zero)
                {
                    // �G���[������
                    // �G���[�擾
                    lastError = Marshal.GetLastWin32Error();

                    if (lastError == 0)
                    {
                        errMsg = "WAC.EC CWEError";
                    }
                    else
                    {
                        errMsg = "WAC.EC CWEError LastError�F" + lastError.ToString();
                    }

                    //���O�o��
                    WriteErrorLogProc(errMsg);
                }

                // �R�[���o�b�N�֐��̃X�e�[�^�X��ԋp����
                status = _callBackStatus;
            }
            catch (Exception ex)
            {
                //���O�o��
                WriteErrorLogProc(ex, "WAC.EC procStatus=" + procStatus.ToString());
            }
            finally
            {
                if (hWnd != IntPtr.Zero)
                {
                    // �E�B���h�E�폜
                    DestroyWindow(hWnd);
                }

                if (hInstance != IntPtr.Zero)
                {
                    // �E�B���h�E�N���X�o�^����
                    UnregisterClass(windowClassName, hInstance);
                }
            }

            return status;
        }

        /// <summary>
        /// �ϊ���������
        /// </summary>
        /// <param name="procCls">0:�����A1:�ϊ�</param>
        /// <returns>���s�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ϊ������������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int ExecuteConvertDirect(int procCls)
        {
            int status = (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;
            string errMsg = string.Empty;
            int procStatus = (int)StatusCode.Normal;

#if DEBUG
            ClcLogOutput("Call ExeConvert.ExecuteConvertDirect", FRAME_EXECUTECONVERT, true);
#endif

            try
            {
                if (_convertVersionSettingOne == null)
                {
                    // �ϊ��e�[�u���̃C���X�^���X����
                    procStatus = (int)StatusCode.TableCreate;

                    _convertVersionSettingOne = new ConvertVersionSettingOne();
                }

                status = ExeConvertProc(procCls);
            }
            catch (Exception ex)
            {
                //���O�o��
                WriteErrorLogProc(ex, "Exeption ExeConvert.ExecuteConvertDirect procStatus=" + procStatus.ToString());
            }
            finally
            {
            }

            return status;
        }

        #endregion // public���\�b�h

        #region private���\�b�h

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>�E�B���h�E�n���h��</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private IntPtr ReleaseProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam)
        {
            try
            {
                switch (uMsg)
                {
                    case WM_CREATE:
                        // �E�B���h�E�쐬��
                        // ��������
                        _callBackStatus = ExeConvertProc((int)ConvertVersionSetting.ProcCls.CT_PROC_RELEASE);

                        break;
                    default:
                        // �E�B���h�E�쐬���ȊO�̓V�X�e���W���E�B���h�E���������s����
                        return DefWindowProc(hWnd, uMsg, wParam, lParam);
                }
            }
            catch (Exception ex)
            {
                //���O�o��
                WriteErrorLogProc(ex, string.Format(CLCLogErrMsg, "EXP ExeConvert.ReleaseProc", _callBackStatus.ToString(), _enterpriseCode,
                                _goodsMakerCd, _goodsNo, _convertSetParam,
                                _convertVersionSettingOne.ConvertGetParam) + " uMsg=" + uMsg.ToString());
            }

            return IntPtr.Zero;
        }

        /// <summary>
        /// �ϊ�����
        /// </summary>
        /// <returns>�E�B���h�E�n���h��</returns>
        /// <remarks>
        /// <br>Note       : �ϊ��������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private IntPtr ConvertProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam)
        {
            try
            {
                switch (uMsg)
                {
                    case WM_CREATE:
                        // �E�B���h�E�쐬��
                        // �ϊ�����
                        _callBackStatus = ExeConvertProc((int)ConvertVersionSetting.ProcCls.CT_PROC_CONVERT);

                        break;

                    default:
                        // �E�B���h�E�쐬���ȊO�̓V�X�e���W���E�B���h�E���������s����
                        return DefWindowProc(hWnd, uMsg, wParam, lParam);
                }
            }
            catch (Exception ex)
            {
                //���O�o��
                WriteErrorLogProc(ex, string.Format(CLCLogErrMsg, "EXP ExeConvert.ConvertProc", _callBackStatus.ToString(), _enterpriseCode,
                                _goodsMakerCd, _goodsNo, _convertSetParam,
                                _convertVersionSettingOne.ConvertGetParam) + " uMsg=" + uMsg.ToString());
            }

            return IntPtr.Zero;
        }

        /// <summary>
        /// �ϊ���������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ϊ������������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private int ExeConvertProc(int procCls)
        {
            int status = (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;

            // �ϊ���l�̏�����
            _convertGetParam = int.MinValue;

            try
            {
                // �p�����[�^�ݒ�
                _convertVersionSettingOne.EnterpriseCode = _enterpriseCode;
                _convertVersionSettingOne.GoodsMakerCd = _goodsMakerCd;
                _convertVersionSettingOne.GoodsNo = _goodsNo;
                _convertVersionSettingOne.ConvertSetParam = _convertSetParam;

                if (procCls == (int)ConvertVersionSetting.ProcCls.CT_PROC_CONVERT)
                {
                    // �ϊ�
                    status = _convertVersionSettingOne.ConvertProc();
                }
                else
                {
                    // ����
                    status = _convertVersionSettingOne.ReleaseProc();
                }

                if (status == (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_OK)
                {
                    // �ϊ��l�ݒ�
                    _convertGetParam = _convertVersionSettingOne.ConvertGetParam;
                }
                else
                {
                    WriteErrorLogProc(string.Format(CLCLogErrMsg, "ERR ExeConvert.ExeConvertProc", status.ToString(), _enterpriseCode,
                        _goodsMakerCd, _goodsNo, _convertSetParam,
                        _convertVersionSettingOne.ConvertGetParam));
                }

            }
            catch (Exception ex)
            {
                //���O�o��
                WriteErrorLogProc(ex, string.Format(CLCLogErrMsg, "EXP ExeConvert.ExeConvertProc", status.ToString(), _enterpriseCode,
                    _goodsMakerCd, _goodsNo, _convertSetParam,
                    _convertVersionSettingOne.ConvertGetParam));
            }

            return status;
        }

        /// <summary>
        /// ���O�o��
        /// </summary>
        /// <param name="errorText"></param>
        /// <remarks>
        /// <br>Note       : ���O�o�͂��s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        internal void WriteErrorLogProc(string errorText)
        {
            try
            {
                base.WriteErrorLog(errorText);
                ClcLogOutput(errorText);
            }
            catch
            {
            }
            finally
            {
            }
        }

        /// <summary>
        /// ���O�o��
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="errorText"></param>
        /// <remarks>
        /// <br>Note       : ���O�o�͂��s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        internal void WriteErrorLogProc(Exception ex, string errorText)
        {
            try
            {
                base.WriteErrorLog(ex, errorText);
                ClcLogOutput(errorText + "ex:" + ex.Message);
            }
            catch
            {
            }
            finally
            {
            }
        }

        #region CLC���O�o��

        /// <summary>
        /// CLC���O�o��
        /// </summary>
        /// <param name="message">���O���b�Z�[�W</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        private void ClcLogOutput(string message)
        {
            ClcLogOutput(message, 7);
        }

        /// <summary>
        /// CLC���O�o��
        /// </summary>
        /// <param name="message">���O���b�Z�[�W</param>
        /// <param name="frame">�Ăяo���t���[��</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        private void ClcLogOutput(string message, int frame)
        {
            ClcLogOutputProc(message, frame, false);
        }

        /// <summary>
        /// CLC���O�o��
        /// </summary>
        /// <param name="message">���O���b�Z�[�W</param>
        /// <param name="frame">�Ăяo���t���[��</param>
        /// <param name="isappend">���P�ʂŕ����쐬���Ȃ��ꍇfalse</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        private void ClcLogOutput(string message, int frame, bool isappend)
        {
            ClcLogOutputProc(message, frame, isappend);
        }

        /// <summary>
        /// CLC���O�o��
        /// </summary>
        /// <param name="message">���O���b�Z�[�W</param>
        /// <param name="frame">
        /// �Ăяo���t���[��
        /// RelaseProc�AConvertProc��5
        /// </param>
        /// <param name="isappend">���P�ʂŕ����쐬���Ȃ��ꍇfalse</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        private void ClcLogOutputProc(string message, int frame, bool isappend)
        {
            try
            {
                DateTime now = DateTime.Now;

                string logFileName = string.Empty;

                KICLC00001C.LogHeader log = null;

                string clcFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Broadleaf\CLC\Service\Partsman\PMCMN00120C\");
                string clcFileName = string.Format(CLCLogFileNameSearch, DateTime.Now.ToString("yyyyMMdd"), "*");
                string[] clcFileFind = null;

                if (Directory.Exists(clcFilePath))
                {
                    clcFileFind = Directory.GetFiles(clcFilePath, clcFileName, SearchOption.TopDirectoryOnly);
                }

                if (clcFileFind == null || clcFileFind.Length == 0 || isappend)
                {
                    // �Ăь��N���X���擾
                    string stack = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame(frame));

                    // �o�͓��e�ɃV�X�e������t������B
                    string logoutput = string.Format(LOGOUTPUT_MESSAGE, message, stack, GetSysInfo()) + clcFileFind.Length;

                    // ���b�Z�[�W���̉��s�R�[�h���X�y�[�X�ɕϊ�
                    logoutput = logoutput.Replace("\r", "").Replace("\n", " ");

                    // ���O�t�@�C�����̍쐬
                    // "���t_PMCMN00120C_"+DateTime��Ticks+Guid������
                    logFileName = string.Format(CLCLogFileName, DateTime.Now.ToString("yyyyMMdd"), Guid.NewGuid().ToString().Replace("-", ""));

                    // ProgramData���փ��O�o��
                    log = new KICLC00001C.LogHeader();
                    log.WriteServiceLogHeader(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ProductCode, "PMCMN00120C", logFileName, logoutput);

                }
            }
            catch
            {
            }
            finally
            {
            }

        }

        #endregion // CLC���O�o��


        #region �V�X�e�����擾
        /// <summary>
        /// �V�X�e�����擾
        /// </summary>
        /// <returns>�V�X�e����񕶎���</returns>
        /// <remarks>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        private string GetSysInfo()
        {
            StringBuilder sysInfo = new StringBuilder();

            #region PC���擾
            try
            {
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_PC, Environment.MachineName));
            }
            catch
            {
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_PC, LOGOUTPUT_EXNA));
            }
            #endregion PC���擾

            #region IP�A�h���X�擾
            try
            {
                IPAddress[] adrList = Dns.GetHostAddresses(Environment.MachineName);
                StringBuilder ipAddress = new StringBuilder();
                foreach (IPAddress address in adrList)
                {
                    ipAddress.Append(address.ToString());
                    ipAddress.Append(" ");
                }
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_IP, ipAddress.ToString()));
            }
            catch
            {
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_IP, LOGOUTPUT_EXNA));
            }
            #endregion PC���擾

            #region �������g�p�ʎ擾
            try
            {
                ComputerInfo ci = new ComputerInfo();

                string avaliableMemory = (Convert.ToInt64(ci.AvailablePhysicalMemory.ToString()) / 1024 / 1024).ToString();
                string totalMemory = (Convert.ToInt64(ci.TotalPhysicalMemory.ToString()) / 1024 / 1024).ToString();

                string memUsageCap = string.Format("{0}/{1}", avaliableMemory, totalMemory);
                if (!string.IsNullOrEmpty(memUsageCap))
                {
                    // ���O�o�͓��e�i�[
                    sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_MEM, memUsageCap));
                }
                else
                {
                    // ���O�o�͓��e�i�[
                    sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_MEM, LOGOUTPUT_NA));
                }
            }
            catch
            {
                // ���O�o�͓��e�i�[
                sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_MEM, LOGOUTPUT_EXNA));
            }
            #endregion �������g�p�ʎ擾

            return sysInfo.ToString();
        }
        #endregion // �V�X�e�����擾

        #endregion // private���\�b�h

    }
}
