// --- DEL m.suzuki 2010/04/06 ---------->>>>>
# region // DEL
//using System;
//using System.Collections.Generic;
//using System.Text;

//using Broadleaf.Application.UIData;
//using System.IO;
//using System.Security.Cryptography;
//using Broadleaf.Application.Controller;
//using Broadleaf.Library.Net;
//using System.Net;
//using System.Runtime.Serialization.Formatters.Binary;

//namespace Broadleaf.Windows.Forms
//{
//    /// <summary>
//    /// �l�b�g���[�N�ʐM�e�X�g�@�\
//    /// </summary>
//    /// <remarks>
//    /// <br>Note       : �l�b�g���[�N�ʐM�e�X�g�@�\</br>
//    /// <br>Programmer : 23002 ��� �k��</br>
//    /// <br>Date       : 2008.04.04</br>
//    /// <br></br>
//    /// <br>Update Note:</br>
//    /// <br>Programmer :</br>
//    /// <br>Date       :</br>
//    /// </remarks>
//    public class NetWorkTest
//    {
//        #region �R���X�g���N�^
//        /// <summary>
//        /// �R���X�g���N�^
//        /// </summary>
//        public NetWorkTest()
//        {
//        }
//        #endregion

//        #region �ʐM�e�X�g����
//        /// <summary>
//        /// �ʐM�e�X�g�J�n
//        /// </summary>
//        public void TestStart(object para)
//        {
//            #region �y�������Ԍv���z�f�o�b�O�p
//#if DEBUG
//            System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
//            st.Start();
//#endif
//            #endregion

//            if( para == null )
//            {
//                return;
//            }

//            try
//            {
//                object[] paraArray = (object[])para;

//                string enterpriseCode = paraArray[0].ToString();
//                string productName    = paraArray[1].ToString();
//                string accessTicket   = paraArray[2].ToString();
//                string filePath = Path.Combine(System.Windows.Forms.Application.StartupPath , "MenuSettings\\AppSettingData");
//                //�e�X�g���ʃA�b�v���[�hWEB�T�[�r�XURL
//                string upLoadWebServiceUrl = "";

//                //�e�X�g���ڏ����擾����B
//                List<NSNetworkTestInfo> nSNetworkTestInfoList;
//                if( !NSNetworkTestInfoList_Deserialize(out nSNetworkTestInfoList, filePath, "SFNETMENU_Config2.dat") )
//                {
//                    return;
//                }

//                #region �e�X�g���ږ��Ƀ��X�g����
//                List<NSNetworkTestInfo> proxyTestList = nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.PROXY; });
//                List<NSNetworkTestInfo> netWorkTestList = nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType != NSNetworkTestInfo.ServerType.PROXY; });
//                #endregion

//                #region �v���L�V
//                //���v���L�V�e�X�g�E�ݒ�擾
//                ProxyInfo proxyInfo = NSNetworkTestAccess.CheckProxy();
//                foreach( NSNetworkTestInfo nSNetworkTestInfo in proxyTestList )
//                {
//                    if( nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.NONE_TEST )
//                    {
//                        upLoadWebServiceUrl = nSNetworkTestInfo.NSNetworkTestTargetUri.ToString();
//                        continue;
//                    }
//                    nSNetworkTestInfo.ProxyInfo = proxyInfo;
//                    nSNetworkTestInfo.Ex = proxyInfo.Ex;
//                    if( proxyInfo.Ex != null )
//                    {
//                        WebException webex = (WebException)proxyInfo.Ex;
//                        if( webex.Response == null )
//                        {
//                            //�X�e�[�^�X�R�[�h��������Ȃ���O�͑S�āu-1�v�Ƃ���B
//                            nSNetworkTestInfo.WebRequestStatusNo = -1;
//                        }
//                        else
//                        {
//                            //HTTP���N�G�X�g�̃X�e�[�^�X���Z�b�g
//                            nSNetworkTestInfo.WebRequestStatusNo = (int)( (HttpWebResponse)webex.Response ).StatusCode;
//                        }
//                    }
//                }
//                #endregion

//                //�e�X�g���s
//                TestProc(proxyInfo, netWorkTestList);
                
//                string accessKey = string.Format("{0}_{1}_{2}", enterpriseCode, productName, accessTicket);

//                //�e�X�g���ʂ̕ۑ��iTrue:WEB�T�[�r�X�o�R�AFalse�F���[�J���ۑ��j
//                bool status = NSNetworkTestInfoList_Serialize(nSNetworkTestInfoList,upLoadWebServiceUrl, accessKey, true, "", "");
//                if( status )
//                {
//                    //
//                    List<NSNetworkTestInfo> workList = new List<NSNetworkTestInfo>();
//                    //WEB�o�R�ł̕ۑ������������ꍇ�A���񂩂�e�X�g���s��Ȃ��悤�ɋ��DAT���㏑������B
//                    //�e�X�g���ʂ̕ۑ��iTrue:WEB�T�[�r�X�o�R�AFalse�F���[�J���ۑ��j
//                    NSNetworkTestInfoList_Serialize(workList, upLoadWebServiceUrl, accessKey, false, filePath, "SFNETMENU_Config2.dat");
//                }
//            }
//            catch(Exception ex)
//            {
//                //�����ł̃G���[�͖�������B
//                #region �y�G���[���b�Z�[�W�\���z�f�o�b�O�p
//#if DEBUG
//            System.Windows.Forms.MessageBox.Show(ex.Message.ToString());
//#endif
//                #endregion
//            }

//            #region �y�������Ԍv���z�f�o�b�O�p
//            #if DEBUG
//            st.Stop();
//            System.Windows.Forms.MessageBox.Show(st.Elapsed.TotalSeconds.ToString());
//            #endif
//            #endregion
//        }

//        /// <summary>
//        /// �ʐM�e�X�g���s��
//        /// </summary>
//        /// <param rKeyName="proxyInfo"></param>
//        /// <param rKeyName="nSNetworkTestInfoList"></param>
//        /// <returns></returns>
//        private bool TestProc(ProxyInfo proxyInfo, List<NSNetworkTestInfo> nSNetworkTestInfoList)
//        {
//            bool result = true;

//            //�e��e�X�g���s���B
//            foreach( NSNetworkTestInfo nSNetworkTestInfo in nSNetworkTestInfoList )
//            {
//                //���e�X�g���s��Ȃ��B
//                if( nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.NONE_TEST )
//                {
//                    nSNetworkTestInfo.CheckResult = false;
//                    continue;
//                }

//                #region BITS
//                if( nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.BITS )
//                {
//                    //BITS�iWINHTTP)�̃v���L�V�ݒ���擾
//                    ProxyInfo bitsproxyInfo = NSNetworkTestAccess.GetBitsProxyIngo();
//                    nSNetworkTestInfo.ProxyInfo = bitsproxyInfo;
//                }
//                else
//                {
//                    nSNetworkTestInfo.ProxyInfo = proxyInfo;
//                }

//                #endregion

//                #region HTTP
//                //��HTTP���N�G�X�g�e�X�g���s���B
//                if( nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.HTTPREQUEST )
//                {
//                    if( NSNetworkTestAccess.HttpRequest(nSNetworkTestInfo) )
//                    {
//                        nSNetworkTestInfo.CheckResult = true;
//                    }
//                    else
//                    {
//                        result = false;
//                        nSNetworkTestInfo.CheckResult = false;
//                    }
//                }
//                #endregion

//                #region �|�[�g
//                //���|�[�g�ڑ��e�X�g���s���B
//                if( nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.PORTCONNECT )
//                {
//                    if( NSNetworkTestAccess.CheckPort(nSNetworkTestInfo) )
//                    {
//                        nSNetworkTestInfo.CheckResult = true;
//                    }
//                    else
//                    {
//                        result = false;
//                        nSNetworkTestInfo.CheckResult = false;
//                    }
//                }
//                #endregion

//                #region BITS
//                //��BITS�z�M�e�X�g���s���B
//                if( nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.BITS )
//                {
//                    //BITS�iWINHTTP)�̃v���L�V�ݒ���擾
//                    ProxyInfo bitsproxyInfo = NSNetworkTestAccess.GetBitsProxyIngo();
//                    nSNetworkTestInfo.ProxyInfo = bitsproxyInfo;
//                    if( BitsMng.Download(nSNetworkTestInfo) )
//                    {
//                        nSNetworkTestInfo.CheckResult = true;
//                    }
//                    else
//                    {
//                        result = false;
//                        nSNetworkTestInfo.CheckResult = false;
//                    }
//                }
//                #endregion

//            }
//            return result;
//        }

//        #endregion

//        #region �f�[�^�N���X�ۑ��A�ǂݍ��ݏ���
//        /// <summary>
//        /// �f�[�^�N���X�ǂݍ���
//        /// </summary>
//        /// <param rKeyName="nSNetworkTestInfoList"></param>
//        /// <param rKeyName="filePath"></param>
//        /// <param rKeyName="fileName"></param>
//        /// <returns></returns>
//        private bool NSNetworkTestInfoList_Deserialize(out List<NSNetworkTestInfo> nSNetworkTestInfoList,string filePath, string fileName)
//        {
//            bool result = false;
//            nSNetworkTestInfoList = null;
//            //�Ǎ��Ώۃt�@�C���̃t���p�X
//            string fileFullName = Path.Combine(filePath, fileName);
//            try
//            {
//                if( !File.Exists(fileFullName) )
//                {
//                    return result;
//                }

//                byte[] desKey;
//                byte[] desIv;
//                byte[] resultBytes;
//                byte[] dataBytes;

//                resultBytes = FileReadProc(fileFullName, out desKey, out desIv);
//                dataBytes = CompoundDataProc(resultBytes, desKey, desIv);
//                using( MemoryStream r = new MemoryStream() )
//                {
//                    r.Write(dataBytes, 0, dataBytes.Length);
//                    r.Position = 0;
//                    BinaryFormatter binaryFormatter = new BinaryFormatter();
//                    nSNetworkTestInfoList = (List<NSNetworkTestInfo>)binaryFormatter.Deserialize(r);
//                }
//                if( nSNetworkTestInfoList != null && nSNetworkTestInfoList.Count > 0 )
//                {
//                    result = true;
//                }
//                else
//                {
//                    result = false;
//                }
//            }
//            catch( Exception ex )
//            {
//                result = false;
//                nSNetworkTestInfoList = null;
//            }
//            return result;
//        }

//        /// <summary>
//        /// �t�@�C���Ǎ�����
//        /// </summary>
//        /// <param rKeyName="fileFullName">�Ǎ��t�@�C���t���p�X</param>
//        /// <param rKeyName="desKey">�Í����L�[</param>
//        /// <param rKeyName="desIv">�Í����L�[</param>
//        /// <returns>�Ǎ�����</returns>
//        private byte[] FileReadProc(string fileFullName, out byte[] desKey, out byte[] desIv)
//        {
//            desKey = null;
//            desIv = null;
//            byte[] result = null;

//            //�t�@�C�������݂��Ȃ��ꍇ�I��
//            if( !File.Exists(fileFullName) )
//            {
//                return result;
//            }

//            using( FileStream fileStream = new FileStream(fileFullName, FileMode.Open) )
//            {
//                using(BinaryReader binaryReader = new BinaryReader(fileStream))
//                {
//                    RijndaelManaged rijndaelManaged = new RijndaelManaged();
                    
//                    desKey = binaryReader.ReadBytes((int)rijndaelManaged.Key.Length);
//                    desIv  = binaryReader.ReadBytes((int)rijndaelManaged.IV.Length);
//                    result = binaryReader.ReadBytes((int)( fileStream.Length - ( rijndaelManaged.Key.Length + rijndaelManaged.IV.Length ) ));
//                    binaryReader.Close();
//                }
//                fileStream.Close();
//            }

//            return result;
//        }

//        /// <summary>
//        /// ����������
//        /// </summary>
//        /// <param rKeyName="data">�������Ώۃf�[�^</param>
//        /// <param rKeyName="desKey">�Í���KEY</param>
//        /// <param rKeyName="desIv">�Í���KEY</param>
//        /// <returns>��������</returns>
//        private byte[] CompoundDataProc(byte[] data, byte[] desKey, byte[] desIv)
//        {
//            // Trippe DES �̃T�[�r�X �v���o�C�_�𐶐����܂�
//            RijndaelManaged rijndaelManaged = new RijndaelManaged();
//            byte[] destination;

//            // ���o�͗p�̃X�g���[���𐶐����܂�
//            using( MemoryStream ms = new MemoryStream() )
//            {
//                CryptoStream cs = new CryptoStream(ms, rijndaelManaged.CreateDecryptor(desKey, desIv), CryptoStreamMode.Write);

//                // �X�g���[���ɈÍ������ꂽ�f�[�^���������݂܂�
//                cs.Write(data, 0, data.Length);
//                cs.Close();

//                // ���������ꂽ�f�[�^�� byte �z��Ŏ擾���܂�
//                destination = ms.ToArray();
//                ms.Close();
//            }
//            return destination;
//        }

//        /// <summary>
//        /// �f�[�^�N���X�ۑ�
//        /// </summary>
//        /// <param rKeyName="nSNetworkTestInfoList"></param>
//        /// <returns></returns>
//        private bool NSNetworkTestInfoList_Serialize(List<NSNetworkTestInfo> nSNetworkTestInfoList,string upLoadWebServiceUrl, string accessKey, bool saveType, string filePath, string fileName)
//        {
//            bool result = false;
            
//            try
//            {
//                using( MemoryStream memoryStream = new MemoryStream() )
//                {
//                    BinaryFormatter binaryFormatter = new BinaryFormatter();
//                    binaryFormatter.Serialize(memoryStream, nSNetworkTestInfoList);

//                    byte[] aeskey;
//                    byte[] aesIV;
//                    byte[] encryptByts;

//                    //�Í�������
//                    encryptByts = EncryptionDataProc(memoryStream.ToArray(), out aeskey, out aesIV);


//                    //WEB�T�[�r�X�ŃA�b�v���[�h���s�����ǂ���
//                    if( saveType )
//                    {
//                        //WEB�T�[�r�X�ɓn���p
//                        byte[] output = new byte[aeskey.Length + aesIV.Length + encryptByts.Length];
//                        for( int ix = 0; ix < aeskey.Length; ix++ )
//                        {
//                            output[ix] = aeskey[ix];
//                        }
//                        for( int ix = 0; ix < aesIV.Length; ix++ )
//                        {
//                            output[aeskey.Length + ix] = aesIV[ix];
//                        }
//                        for( int ix = 0; ix < encryptByts.Length; ix++ )
//                        {
//                            output[aeskey.Length + aesIV.Length + ix] = encryptByts[ix];
//                        }


//                        //�e�X�g���ʑ��M�pWEB�T�[�r�X
//                        SFCMN07000AService nsNetworkTestService = new SFCMN07000AService(upLoadWebServiceUrl);
//                        //BASIC�F�ؗpUSER��PASSWORD���Z�b�g����B
//                        //nsNetworkTestService.Credentials = new NetworkCredential("SFCMN07001UA_Up", "JqSn/2E7snMiU");

//                        //�e�X�g���ʂ̃A�b�v���[�h
//                        result = nsNetworkTestService.NSNetworkTestUpload(accessKey, output);
//                    }
//                    else
//                    {
//                        if( !Directory.Exists(filePath) )
//                        {
//                            Directory.CreateDirectory(filePath);
//                        }
//                        result = FileSaveProc(encryptByts, filePath, fileName, aeskey, aesIV);
//                    }
//                }
//            }
//            catch( Exception ex )
//            {
//                result = false;
//                //MessageBox.Show(NSNetworkTestMsgConst.MSG_CONFIGSAVE_NG);
//            }

//            return result;
//        }

//        /// <summary>
//        /// �Í�������
//        /// </summary>
//        /// <param rKeyName="data">�Í����Ώۃf�[�^</param>
//        /// <param rKeyName="desKey">�Í���KEY</param>
//        /// <param rKeyName="desIv">�Í���KEY</param>
//        /// <returns>�Í�����</returns>
//        private byte[] EncryptionDataProc(byte[] data, out byte[] aesKey, out byte[] aesIv)
//        {
//            // AES�Í������i�𐶐����܂�
//            RijndaelManaged rijndaelManaged = new RijndaelManaged();
//            aesKey = rijndaelManaged.Key;
//            aesIv = rijndaelManaged.IV;

//            // ���o�͗p�̃X�g���[���𐶐����܂�
//            MemoryStream ms = new MemoryStream();
//            CryptoStream cs = new CryptoStream(ms, rijndaelManaged.CreateEncryptor(aesKey, aesIv), CryptoStreamMode.Write);

//            // �X�g���[���ɈÍ�������f�[�^���������݂܂�
//            cs.Write(data, 0, data.Length);
//            cs.Close();

//            // �Í������ꂽ�f�[�^�� byte �z��Ŏ擾���܂�
//            byte[] destination = ms.ToArray();
//            ms.Close();

//            return destination;
//        }

//        /// <summary>
//        /// �t�@�C���ۑ�����
//        /// </summary>
//        /// <param rKeyName="encryptionData">�ۑ��f�[�^</param>
//        /// <param rKeyName="logFilePath">�ۑ��t�@�C���p�X</param>
//        /// <param rKeyName="logFileName">�ۑ��t�@�C������</param>
//        /// <param rKeyName="desKey">�Í����L�[</param>
//        /// <param rKeyName="desIv">�Í����L�[</param>
//        private bool FileSaveProc(byte[] encryptionData, string filePath, string fileName, byte[] desKey, byte[] desIv)
//        {
//            bool result = false;
//            //�ۑ��p�f�B���N�g���������ꍇ�͍쐬
//            if( !Directory.Exists(filePath) )
//            {
//                Directory.CreateDirectory(filePath);
//            }

//            //�t���p�X�擾
//            string fileFullPath = Path.Combine(filePath, fileName);

//            //�@���ɑ��݂���ꍇ
//            if( File.Exists(fileFullPath) )
//            {
//                //�A�������������݉\�ɕύX
//                File.SetAttributes(fileFullPath, FileAttributes.Normal);
//            }

//            //�t�@�C���ۑ�
//            using( FileStream fileStream = File.Create(fileFullPath) )
//            {
//                //�B�t�@�C����������
//                fileStream.Write(desKey, 0, desKey.Length);
//                fileStream.Write(desIv, 0, desIv.Length);
//                fileStream.Write(encryptionData, 0, encryptionData.Length);
//                fileStream.Close();
//                result = true;
//            }
//            return result;
//        }

//        #endregion
//    }
//}
# endregion
// --- DEL m.suzuki 2010/04/06 ----------<<<<<
