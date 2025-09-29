//****************************************************************************//
// �V�X�e��         : �����d����M����
// �v���O��������   : �����d����M����Controller
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/11/17  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2009/10/09  �C�����e : ��M�̊Y���f�[�^�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770032-00 �쐬�S�� : �c����
// �� �� ��  2021/09/06  �C�����e : PMKOBETSU-4166 ������Q�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.UIData;
//---ADD �c���� 2021/09/06 PMKOBETSU-4166 ������Q�Ή�----->>>>
using Microsoft.Win32;
using Broadleaf.Application.Common;
using System.Xml;
//---ADD �c���� 2021/09/06 PMKOBETSU-4166 ������Q�Ή�-----<<<<

namespace Broadleaf.Application.Controller
{
    #region <�i���X�V/>

    /// <summary>
    /// �i���X�V�p�C�x���g�p�����[�^�N���X
    /// </summary>
    public sealed class UpdateProgressEventArgs : EventArgs
    {
        #region <�i������/>

        /// <summary>�i������</summary>
        private string _name;
        /// <summary>
        /// �i�����̂̃A�N�Z�T
        /// </summary>
        /// <value>�i������</value>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        #endregion  // <�i������/>

        #region <����/>

        /// <summary>����</summary>
        private int _count;
        /// <summary>
        /// �����̃A�N�Z�T
        /// </summary>
        /// <value>����</value>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        #endregion  // <����/>

        #region <�ő�l/>

        /// <summary>�ő�l</summary>
        private int _max;
        /// <summary>
        /// �ő�l�̃A�N�Z�T
        /// </summary>
        /// <value>�ő�l</value>
        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }

        #endregion  // <�ő�l/>

        #region <�������t���O/>

        /// <summary>�������t���O</summary>
        private bool _isRunning;
        /// <summary>
        /// �������t���O�̃A�N�Z�T
        /// </summary>
        /// <value>
        /// <c>true</c> :������<br/>
        /// <c>false</c>:�����I��
        /// </value>
        public bool IsRunning
        {
            get { return _isRunning; }
            set { _isRunning = value; }
        }

        #endregion  // <�������t���O/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="name">�i������</param>
        /// <param name="count">����</param>
        public UpdateProgressEventArgs(
            string name,
            int count
        ) : this(name, count, 0)
        { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="name">�i������</param>
        /// <param name="count">����</param>
        /// <param name="max">�ő�l</param>
        public UpdateProgressEventArgs(
            string name,
            int count,
            int max
        ) : base()
        {
            _name   = name;
            _count  = count;
            _max    = max;
        }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// ������ɕϊ����܂��B
        /// </summary>
        /// <returns>������</returns>
        public override string ToString()
        {
            if (Max.Equals(0))
            {
                return Name + "[" + Count.ToString() + "]"; // LITERAL:
            }
            else
            {
                StringBuilder str = new StringBuilder();
                {
                    str.Append(Name).Append("...[").Append(Count).Append("/").Append(Max).Append("] ");

                    int progress = (int)(((double)Count / (double)Max) * 100.0);
                    str.Append(progress).Append("%");
                }
                return str.ToString();
            }
        }

        #endregion  // <Override/>
    }

    /// <summary>
    /// �i�����X�V����C�x���g�n���h��
    /// </summary>
    /// <param name="sender">�C�x���g�\�[�X</param>
    /// <param name="e">�C�x���g�p�����[�^</param>
    public delegate void UpdateProgressEventHandler(
        object sender,
        UpdateProgressEventArgs e
    );

    /// <summary>
    /// �i�����X�V����C���^�[�t�F�[�X
    /// </summary>
    public interface IProgressUpdatable
    {
        /// <summary>
        /// �i�����X�V���܂��B
        /// </summary>
        /// <param name="e">�i���X�V�p�C�x���g�p�����[�^</param>
        void Update(UpdateProgressEventArgs e);
    }

    #endregion  // <�i���X�V/>

    #region <Controller/>

    /// <summary>
    /// �����d����M����Controller�N���X
    /// </summary>
    public abstract class OroshishoStockReceptionController : IProgressUpdatable
    {
        #region <IProgressUpdatable �����o/>

        /// <summary>
        /// �i�����X�V���܂��B
        /// </summary>
        /// <param name="e">�i���X�V�p�C�x���g�p�����[�^</param>
        public void Update(UpdateProgressEventArgs e)
        {
            RaiseUpdateProgressEvent(e);
        }

        #endregion  // <IProgressUpdatable �����o/>

        #region <�i�����X�V����C�x���g/>

        /// <summary>�i�����X�V����C�x���g</summary>
        public event UpdateProgressEventHandler UpdateProgress;

        /// <summary>
        /// �i�����X�V����C�x���g�𔭐������܂��B
        /// </summary>
        /// <param name="e">�C�x���g�p�����[�^</param>
        protected void RaiseUpdateProgressEvent(UpdateProgressEventArgs e)
        {
            UpdateProgress(this, e);
        }

        #endregion  // <�i�����X�V����C�x���g/>

        #region <UOE������/>

        /// <summary>UOE������</summary>
        private readonly UOESupplierHelper _uoeSupplier;
        /// <summary>
        /// UOE��������擾���܂��B
        /// </summary>
        /// <value>UOE������</value>
        protected UOESupplierHelper UOESupplier { get { return _uoeSupplier; } }

        #endregion  // <UOE������/>

        /// <summary>
        /// ���������s���܂��B
        /// </summary>
        /// <returns>���ʃR�[�h</returns>
        public abstract int Execute();

        // 2009/10/09 Add >>>
        /// <summary>
        /// ����ID
        /// </summary>
        public abstract Result.ProcessID ProcessID { get;}
        // 2009/10/09 Add <<<

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        protected OroshishoStockReceptionController(UOESupplierHelper uoeSupplier)
        {
            _uoeSupplier = uoeSupplier;
            UpdateProgress += DebugWriteLine;
        }

        #endregion  // <Constructor/>

        #region <�f�o�b�O�p/>

        /// <summary>
        /// �i����Debug.WriteLine()���܂��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private static void DebugWriteLine(
            object sender,
            UpdateProgressEventArgs e
        )
        {
            Debug.WriteLine(e.Count.ToString());
        }

        #endregion  // <�f�o�b�O�p/>
    }

    #endregion  // <Controller/>

    /// <summary>
    /// �d����M����Controller�N���X
    /// </summary>
    public sealed class ReceiveStockAcs : OroshishoStockReceptionController
    {
        #region <������/>

        /// <summary>������</summary>
        /// <remarks>��M�e�L�X�g</remarks>
        private IAgreegate<ReceivedText> _product;
        /// <summary>
        /// �������i��M�e�L�X�g�j���擾���܂��B
        /// </summary>
        /// <value>�������i��M�e�L�X�g�j</value>
        public IAgreegate<ReceivedText> Product { get { return _product; } }

        #endregion  // <������/>

        #region const
        // �C���X�g�[���f�B���N�g��
        private const string REG_INSTALL_DIRECTORY = @"InstallDirectory";
        // ���W�X�g�L�[������
        private const string REG_KEY_CLIENT = @"Broadleaf\Product\Partsman";
        // ���W�X�g�L�[������iKEY32�j
        private const string REG_KEY32 = @"SOFTWARE\";
        // ���W�X�g�L�[������iKEY64�j ���擾�ł��Ȃ��ꍇ
        private const string REG_KEY64 = @"SOFTWARE\WOW6432Node\";
        // UISettings�t�H���_
        private const string DIR_UISETTINGS = @"UISettings";
        // ���O�o�͐���ݒ�t�@�C����
        private const string XML_FILE_NAME = @"PMUOE01303A_LogOutEnabler.xml";
        // ���O�o�͐���ݒ�t�@�C�����O�o�͋敪
        private const string XML_LOGOUTDIV = "LogOutDiv";
        // ���O�t�H���_��
        private const string LogDirName = @"Log";
        // ���O�t�@�C����
        private const string LogName = @"siirezyushindenbun_{0}.log";
        // ���t�t�H�}�[�h
        private const string DateFomart = "yyyyMMdd";
        #endregion

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        public ReceiveStockAcs(UOESupplierHelper uoeSupplier) : base(uoeSupplier) { }

        #endregion  // <Constructor/>

        #region <Override/>

        // 2009/10/09 Add >>>
        public override Result.ProcessID ProcessID { get { return Result.ProcessID.ReceiveStock; } }
        // 2009/10/09 Add <<<

        /// <summary>
        /// ���������s���܂��B
        /// </summary>
        /// <returns>���ʃR�[�h</returns>
        /// <see cref="OroshishoStockReceptionController"/>
        public override int Execute()
        {
            // ���M�d���i�J�ǁ��d���v�����ǁj
            List<UoeSndHed> uoeSndHedList = new List<UoeSndHed>();
            {
                uoeSndHedList.Add(UOESupplier.TelegramEssence.UOESendHeader);
            }
            PrintUoeSndHed(uoeSndHedList[0], UOESupplier);

            // UOE���M�@�\��p���A����M
            UoeRecHed receivedUoeRecHed = null;
            string errorMessage = string.Empty;
            int status = UOESendReceiveComponent.ReceiveUOEStockRequestText(
                UOESupplier.TelegramEssence.UOESendReceiveControlParameter,
                uoeSndHedList,
                UOESupplier.ReceivingUOESupplierType,
                out receivedUoeRecHed,
                out errorMessage
            );
            PrintUoeRecHed(receivedUoeRecHed);

            // ��M�������擾
            int receivedCount = 0;
            if (status.Equals((int)Result.Code.Normal))
            {
                if (receivedUoeRecHed != null)
                {
                    _product = new ReceivedTextAgreegate(receivedUoeRecHed);
                    receivedCount = Product.Size;
                }
                // 2009/10/09 Add >>>
                if (receivedCount == 0) status = (int)Result.RemoteStatus.NotFound;
                // 2009/10/09 Add <<<
            }

            // --- ADD  ����  2021/04/20 ---------->>>>>
            // --- UPD �c���� 2021/09/06 PMKOBETSU-4166 ������Q�Ή� ----->>>>>
            // ���O�t�@�C��������Ƃɍ쐬
            //string filePath = @"C:\Program Files (x86)\Partsman\Log\siirezyushindenbun_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            // �J�����g�f�B���N�g���擾
            string installDir = GetCurrentDirectory(REG_KEY_CLIENT);
            // �ݒ�t�@�C���擾
            bool logOutDiv = GetClientXml(installDir);
            if (logOutDiv)
            {
                // ���O�t�H���_
                string logDir = Path.Combine(installDir, LogDirName);

                if (!Directory.Exists(logDir))
                {
                    // Log�t�H���_�[�����݂��Ȃ��ꍇ�A�쐬����
                    Directory.CreateDirectory(logDir);
                }
                string filePath = Path.Combine(logDir, string.Format(LogName, DateTime.Now.ToString(DateFomart)));
                // --- UPD �c���� 2021/09/06 PMKOBETSU-4166 ������Q�Ή� -----<<<<<
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }
                // --- ADD  ����  2021/04/20 ----------<<<<<

                // --- ADD  ���J�M�m  2020/10/21 ---------->>>>>
                //��M�d���̓��e�����O�ɕۑ�
                if (receivedCount != 0)
                {
                    File.AppendAllText(filePath, DateTime.Now.ToString() + "\r\n" + _product);
                }
                // --- ADD  ����  2021/04/20 ---------->>>>>
                else
                {
                    File.AppendAllText(filePath, DateTime.Now.ToString() + " Status�F" + status.ToString() + " Count�F" + receivedCount + " ErrorMessage�F" + errorMessage + "\r\n");
                }
                // --- ADD  ����  2021/04/20 ----------<<<<<

                // --- ADD  ���J�M�m  2020/10/21 ----------<<<<<
            }// ADD �c���� 2021/09/06 PMKOBETSU-4166 ������Q�Ή�

            RaiseUpdateProgressEvent(new UpdateProgressEventArgs(
                "�d����M����", // LITERAL:
                receivedCount
            ));

            return status;
        }

        // --- ADD �c���� 2021/09/06 PMKOBETSU-4166 ������Q�Ή� ----->>>>>
        /// <summary>
        /// �N���C�A���gXML���擾
        /// ���֐��Ŕ��������O�����͌Ăяo�����Ŕj������
        /// </summary>
        /// <param name="installDir">�p�X</param>
        /// <remarks>
        /// <br>Note       : �N���C�A���gXML���擾���s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2021/09/06</br>
        /// </remarks>
        private bool GetClientXml(string installDir)
        {
            string uisettingsDir = string.Empty;
            string xmlPath = string.Empty;

            // �߂�p�����[�^�����l
            bool logOutDiv = false;

            if (!string.IsNullOrEmpty(installDir))
            {
                // �J�����g�f�B���N�g���擾�����������ꍇ
                // UISetting�t�H���_
                uisettingsDir = Path.Combine(installDir, DIR_UISETTINGS);

                // �t���p�X
                xmlPath = Path.Combine(uisettingsDir, XML_FILE_NAME);

                if (UserSettingController.ExistUserSetting(xmlPath))
                {
                    XmlReaderSettings settings = new XmlReaderSettings();
                    using (XmlReader reader = XmlReader.Create(xmlPath, settings))
                    {
                        // ���O�o�͉ې���t�@�C����ǂݍ���
                        while (reader.Read())
                        {
                            //���O�t�@�C���o�͋敪(true:�o�͂���Gfalse:�o�͂��Ȃ�)
                            if (reader.IsStartElement(XML_LOGOUTDIV)) logOutDiv = Convert.ToBoolean(reader.ReadElementString(XML_LOGOUTDIV).Trim());
                        }
                    }
                }
            }
            return logOutDiv;
        }

        /// <summary>
        /// �J�����g�f�B���N�g���̃p�X�擾
        /// ���֐��Ŕ��������O�����͌Ăяo�����Ŕj������
        /// </summary>
        /// <param name="regKeyStr">regKeyStr</param>
        /// <returns>�J�����g�f�B���N�g���t���p�X</returns>
        /// <remarks>
        /// <br>Note       : �J�����g�f�B���N�g���̃p�X���擾���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2021/09/06</br>
        /// </remarks>
        private string GetCurrentDirectory(string regKeyStr)
        {
            string defaultDir = string.Empty;

            // �߂�l�����l
            string homeDir = string.Empty;

            try
            {
                // ���s�t�@�C���i�[�p�X�������f�B���N�g���Ƃ���
                defaultDir = AppDomain.CurrentDomain.BaseDirectory;
            }
            catch
            {
                // �����f�B���N�g���͔O�̂��߂̏����̂��߁A
                // �擾�ł��Ȃ��Ă��������s����
            }

            try
            {
                // ���W�X�g�������L�[�����擾
                RegistryKey registryKey = GetRegistryKey(regKeyStr);

                if (registryKey != null)
                {
                    homeDir = registryKey.GetValue(REG_INSTALL_DIRECTORY, defaultDir).ToString();
                }
            }
            catch
            {
                // ��O�������f�B���N�g���擾�\�������邽�ߏ������s
            }

            // �擾�f�B���N�g�������݂��Ȃ��ꍇ�͏����f�B���N�g����ݒ�
            if (!Directory.Exists(homeDir))
            {
                homeDir = defaultDir;
            }

            return homeDir;
        }

        /// <summary>
        /// ���W�X�g���L�[���擾
        /// ���֐��ŗ�O�����͕s�v�Ȃ��ߌĂяo�����Ŏ�������
        /// </summary>
        /// <param name="regKeyStr">�擾���W�X�g���L�[</param>
        /// <returns>RegistryKey</returns>
        /// <remarks>
        /// <br>Note       : ���W�X�g���L�[�����擾���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2021/09/06</br>
        /// </remarks>
        private RegistryKey GetRegistryKey(string regKeyStr)
        {
            RegistryKey registryKey = null;

            // ���W�X�g�������L�[�����擾
            registryKey = Registry.LocalMachine.OpenSubKey(REG_KEY32 + regKeyStr);

            if (registryKey == null)
            {
                // �擾�ł��Ȃ��ꍇ�A�O�̂���
                registryKey = Registry.LocalMachine.OpenSubKey(REG_KEY64 + regKeyStr);
            }

            return registryKey;
        }
        // --- ADD �c���� 2021/09/06 PMKOBETSU-4166 ������Q�Ή� -----<<<<<
        #endregion  // <Override/>

        #region <Debug/>

        /// <summary>
        /// ���M�d������\�����܂��B
        /// </summary>
        /// <param name="uoeSndHed">���M�d�����</param>
        /// <param name="uoeSupplier">UOE������</param>
        [Conditional("DEBUG")]
        private static void PrintUoeSndHed(
            UoeSndHed uoeSndHed,
            UOESupplierHelper uoeSupplier
        )
        {
            Debug.WriteLine(SendingStockReceptionTelegramEssence.ConvertString(
                uoeSndHed,
                uoeSupplier
            ));
        }

        /// <summary>
        /// ��M���ʂ�\�����܂��B
        /// </summary>
        /// <param name="uoeRecHed">��M����</param>
        [Conditional("DEBUG")]
        private static void PrintUoeRecHed(UoeRecHed uoeRecHed)
        {
            Debug.WriteLine(SendingStockReceptionTelegramEssence.ConvertString(uoeRecHed));
        }

        #endregion  // <Debug/>
    }
}
