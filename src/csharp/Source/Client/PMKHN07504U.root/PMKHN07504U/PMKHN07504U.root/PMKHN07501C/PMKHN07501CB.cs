using System;
//using System.Collections.Generic;
//using System.Text;
using System.Windows.Forms;
using System.Collections;
//using System.Xml;
//using System.IO;
using System.Reflection;
//using System.Data;
//using Broadleaf.Application.UIData;


namespace Broadleaf.Application.Common
{

    /// <summary>
    /// ���[���T�[�r�X �I�u�W�F�N�g�Ǘ��N���X
    /// </summary>
    /// <remarks> 
    /// ���[���T�[�r�X�Ŏg�p����e��R���g���[���A�C���^�t�F�[�X���Ǘ����Ă��܂��B
    /// ���̃N���X�Ń��[���T�[�r�X�̊e��T�[�r�X���E�̃R���g���[�����s�����Ƃ��ł��܂�
    /// </remarks>
    public class MailFactoryBase
    {

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>MailInfoBase
        /// <param name="mailServiceInfoCreateMode">���[���T�[�r�X�֘A��� �������[�h</param>
        public MailFactoryBase(MailServiceInfoCreateMode mailServiceInfoCreateMode)
        {
            GetMailServiceConfigInfo(out _MailServiceConfigInfo);
            if (_MailServiceConfigInfo == null)
            {
                _MailServiceConfigInfo = new Hashtable();
            }
        }

        /// <summary>
        /// ���[���T�[�r�X ���W���[���\�����X�g
        /// </summary>
        private Hashtable _MailServiceConfigInfo = null;


        ///// <summary>
        ///// ���[���G�f�B�^����C���^�t�F�[�X�擾
        ///// </summary>
        ///// <returns>���[���G�f�B�^����C���^�t�F�[�X</returns>
        //public IMailEditor GetMailEditorInterface()
        //{
        //    object obj = null;
        //    if (_MailServiceConfigInfo.Contains(MailServiceModuleIndex.MailEditor))
        //    {
        //        MailServiceModuleInfo mailServiceModuleInfo = (MailServiceModuleInfo)_MailServiceConfigInfo[MailServiceModuleIndex.MailEditor];
        //        obj = ClassFactory(ref mailServiceModuleInfo);
        //    }

        //    //if(obj == null)
        //    //{
        //    //    MailEditorInterfaceTest mailEditorInterfaceTest = new MailEditorInterfaceTest();
        //    //    obj = mailEditorInterfaceTest;
        //    //}

        //    return (IMailEditor)obj;
        //}


        ///// <summary>
        ///// ���[���r���[�A�[����C���^�t�F�[�X�擾
        ///// </summary>
        ///// <returns>���[���r���[�A�[����C���^�t�F�[�X</returns>
        //public IMailViewer GetMailViewerInterface()
        //{

        //    object obj = null;
        //    if (_MailServiceConfigInfo.Contains(MailServiceModuleIndex.MailViewer))
        //    {
        //        MailServiceModuleInfo mailServiceModuleInfo = (MailServiceModuleInfo)_MailServiceConfigInfo[MailServiceModuleIndex.MailViewer];
        //        obj = ClassFactory(ref mailServiceModuleInfo);
        //    }

        //    //if (obj == null)
        //    //{
        //    //    MailViewerInterfaceTest mailViewerInterfaceTest = new MailViewerInterfaceTest();
        //    //    obj = mailViewerInterfaceTest;
        //    //}

        //    return (IMailViewer)obj;

        //}

        /// <summary>
        /// ���[�����M���C�u��������C���^�t�F�[�X�擾
        /// </summary>
        /// <returns>���[�����M���C�u��������C���^�t�F�[�X</returns>
        public IMailSender GetMailSenderInterface()
        {
            object obj = null;
            if (_MailServiceConfigInfo.Contains(MailServiceModuleIndex.MailSender))
            {
                MailServiceModuleInfo mailServiceModuleInfo = (MailServiceModuleInfo)_MailServiceConfigInfo[MailServiceModuleIndex.MailSender];
                obj = ClassFactory(ref mailServiceModuleInfo);
            }

            //if (obj == null)
            //{
            //    MailSenderInterfaceTest mailSenderInterfaceTest = new MailSenderInterfaceTest();
            //    obj = mailSenderInterfaceTest;
            //}

            return (IMailSender)obj;

        }


        ///// <summary>
        ///// .NS���[���T�[�r�X �}�N���R���o�[�^�[����C���^�t�F�[�X�擾
        ///// </summary>
        ///// <returns>���[�����M���C�u��������C���^�t�F�[�X</returns>
        //public INsMacroConverter GetNsMacroConverterInterface()
        //{
        //    object obj = null;
        //    if (_MailServiceConfigInfo.Contains(MailServiceModuleIndex.MailMacroConverter))
        //    {
        //        MailServiceModuleInfo mailServiceModuleInfo = (MailServiceModuleInfo)_MailServiceConfigInfo[MailServiceModuleIndex.MailMacroConverter];
        //        obj = ClassFactory(ref mailServiceModuleInfo);
        //    }

        //    //if (obj == null)
        //    //{
        //    //    NsMacroConverterInterfaceTest nsMacroConverterInterfaceTest = new NsMacroConverterInterfaceTest();
        //    //    obj = nsMacroConverterInterfaceTest;
        //    //}

        //    return (INsMacroConverter)obj;
        //}


        ///// <summary>
        ///// .NS���[���T�[�r�X ���[���쐬���C�u��������C���^�t�F�[�X�擾
        ///// </summary>
        ///// <returns>���[���쐬���C�u��������C���^�t�F�[�X</returns>
        //public INsMailFactory GetNsMailFactoryInterface()
        //{
        //    object obj = null;
        //    if (_MailServiceConfigInfo.Contains(MailServiceModuleIndex.MailFactory))
        //    {
        //        MailServiceModuleInfo mailServiceModuleInfo = (MailServiceModuleInfo)_MailServiceConfigInfo[MailServiceModuleIndex.MailFactory];
        //        obj = ClassFactory(ref mailServiceModuleInfo);
        //    }

        //    //if (obj == null)
        //    //{
        //    //    NsMailFactoryInterfaceTest nsMailFactoryInterfaceTest = new NsMailFactoryInterfaceTest();
        //    //    obj = nsMailFactoryInterfaceTest;
        //    //}

        //    return (INsMailFactory)obj;

        //}


        ///// <summary>
        ///// ���[���o�b�N�A�b�v�f�[�^�쐬���C�u��������C���^�t�F�[�X�擾
        ///// </summary>
        ///// <returns>���[���o�b�N�A�b�v�f�[�^�쐬���C�u��������C���^�t�F�[�X</returns>
        //public IMailBackupMaker GetMailBackupMakerInterface()
        //{

        //    object obj = null;
        //    if (_MailServiceConfigInfo.Contains(MailServiceModuleIndex.MailBackupMaker))
        //    {
        //        MailServiceModuleInfo mailServiceModuleInfo = (MailServiceModuleInfo)_MailServiceConfigInfo[MailServiceModuleIndex.MailBackupMaker];
        //        obj = ClassFactory(ref mailServiceModuleInfo);
        //    }

        //    //if (obj == null)
        //    //{
        //    //    MailBackupMakerInterfaceTest mailBackupMakerInterfaceTest = new MailBackupMakerInterfaceTest();
        //    //    obj = mailBackupMakerInterfaceTest;
        //    //}

        //    return (IMailBackupMaker)obj;


        //}

        /// <summary>
        /// ���[�����M�����쐬���C�u��������C���^�t�F�[�X�擾
        /// </summary>
        /// <returns>���[�����M�����쐬���C�u��������C���^�t�F�[�X</returns>
        public IMailSendingHistoryMaker GetMailSendingHistoryMakerInterface()
        {

            object obj = null;
            if (_MailServiceConfigInfo.Contains(MailServiceModuleIndex.MailHistoryMaker))
            {
                MailServiceModuleInfo mailServiceModuleInfo = (MailServiceModuleInfo)_MailServiceConfigInfo[MailServiceModuleIndex.MailHistoryMaker];
                obj = ClassFactory(ref mailServiceModuleInfo);
            }

            //if (obj == null)
            //{
            //    MailSendingHistoryMakerInterfaceTest mailSendingHistoryMakerInterfaceTest = new MailSendingHistoryMakerInterfaceTest();
            //    obj = mailSendingHistoryMakerInterfaceTest;
            //}

            return (IMailSendingHistoryMaker)obj;

        }

        ///// <summary>
        ///// ���[���������͎x���K�C�h����C���^�t�F�[�X�擾
        ///// </summary>
        ///// <returns>���[���������͎x���K�C�h����C���^�t�F�[�X</returns>
        //public IMailEditHelper GetMailEditHelperInterface()
        //{

        //    object obj = null;
        //    if (_MailServiceConfigInfo.Contains(MailServiceModuleIndex.MailEditHelper))
        //    {
        //        MailServiceModuleInfo mailServiceModuleInfo = (MailServiceModuleInfo)_MailServiceConfigInfo[MailServiceModuleIndex.MailEditHelper];
        //        obj = ClassFactory(ref mailServiceModuleInfo);
        //    }

        //    //if (obj == null)
        //    //{
        //    //    MailEditHelperInterfaceTest mailEditHelperInterfaceTest = new MailEditHelperInterfaceTest();
        //    //    obj = mailEditHelperInterfaceTest;
        //    //}

        //    return (IMailEditHelper)obj;

        //}

        ///// <summary>
        ///// ���[�������I���K�C�h����C���^�t�F�[�X�擾
        ///// </summary>
        ///// <returns>���[�������I���K�C�h����C���^�t�F�[�X</returns>
        //public IMailDocumentSelector GetMailDocumentSelectorInterface()
        //{
        //    MailDocumentSelectorInterfaceTest mailDocumentSelectorInterfaceTest = new MailDocumentSelectorInterfaceTest();
        //    return (IMailDocumentSelector)mailDocumentSelectorInterfaceTest;
        //}


        /// <summary>
        /// �N���X����
        /// </summary>
        /// <param name="mailServiceModuleInfo">���[���T�[�r�X �\�����W���[�����N���X</param>
        /// <returns>���������I�u�W�F�N�g</returns>
        private object ClassFactory(ref MailServiceModuleInfo mailServiceModuleInfo)
        {

            if ((mailServiceModuleInfo.AssemblyName != "") && (mailServiceModuleInfo.ClassName != ""))
            {
                string path = System.IO.Path.GetFullPath(mailServiceModuleInfo.AssemblyName);
                // �A�Z���u�������[�h
                Assembly assembly = null;
                if (System.IO.File.Exists(path))
                {
                    assembly = Assembly.LoadFile(path);
                }

                // �N���X�C���X�^���X���쐬
                if (assembly != null)
                {
                    object plugIn = assembly.CreateInstance(mailServiceModuleInfo.ClassName);
                    if (plugIn == null)
                    {
                        MessageBox.Show(path + " - " + mailServiceModuleInfo.ClassName + "\n" + "��������܂���");
                        mailServiceModuleInfo.ClassObject = null;
                    }
                    else
                    {
                        mailServiceModuleInfo.ClassObject = plugIn;
                    }

                }
                else
                {
                    mailServiceModuleInfo.ClassObject = null;
                }
            }
            else
            {
                mailServiceModuleInfo.ClassObject = null;
            }

            return mailServiceModuleInfo.ClassObject;
        }


        /// <summary>
        /// ���[���T�[�r�X �\�����W���[���C���f�b�N�X
        /// </summary>
        private enum MailServiceModuleIndex
        {
            /// <summary>
            /// ���[���G�f�B�^�[
            /// </summary>
            MailEditor,
            /// <summary>
            /// ���[�����M���C�u���� 
            /// </summary>
            MailSender,
            /// <summary>
            /// ���[���r���[�A�[
            /// </summary>
            MailViewer,
            /// <summary>
            /// ���[���쐬���C�u����
            /// </summary>
            MailFactory,
            /// <summary>
            /// 
            /// </summary>
            MailEditHelper,
            /// <summary>
            /// 
            /// </summary>
            MailDocumentSelector,
            /// <summary>
            /// 
            /// </summary>
            MailBackupMaker,
            /// <summary>
            /// 
            /// </summary>
            MailHistoryMaker,
            /// <summary>
            /// 
            /// </summary>
            MailMacroConverter

        }


        /// <summary>
        /// ���[���T�[�r�X �\�����W���[�����N���X
        /// </summary>
        private class MailServiceModuleInfo
        {

            public MailServiceModuleInfo(string asmName, string className)
            {
                AssemblyName = asmName;
                ClassName = className;
                ClassObject = null;
            }

            public string AssemblyName = "";
            public string ClassName = "";
            public object ClassObject = null;

        }


        #region �e�X�g�pXML�ݒ�Ǎ�
        /// <summary>
        /// ���[���T�[�r�X �e��T�[�r�X�\�����擾(XML)
        /// </summary>
        /// <returns>�擾���� true:���擾����</returns>
        private bool GetMailServiceConfigInfo(out Hashtable mailServiceConfigInfo)
        {
            mailServiceConfigInfo = new Hashtable();

            //�����ɒǉ�("2010/05/25");
            MailServiceModuleInfo mailServiceModuleInfo = new MailServiceModuleInfo("PMKHN07504U.dll", "Broadleaf.Windows.Forms.PMKHN07504UA");
            mailServiceConfigInfo.Add(MailServiceModuleIndex.MailEditor, mailServiceModuleInfo);

            mailServiceModuleInfo = new MailServiceModuleInfo("PMKHN07505C.dll", "Broadleaf.Application.Common.NsEMailSender");
            mailServiceConfigInfo.Add(MailServiceModuleIndex.MailSender, mailServiceModuleInfo);

            mailServiceModuleInfo = new MailServiceModuleInfo("SFDML02005U.dll", "Broadleaf.Windows.Forms.NsEMailViewer");
            mailServiceConfigInfo.Add(MailServiceModuleIndex.MailViewer, mailServiceModuleInfo);

            mailServiceModuleInfo = new MailServiceModuleInfo("PMKHN07506C.dll", "Broadleaf.Application.Common.NsMailFactory");
            mailServiceConfigInfo.Add(MailServiceModuleIndex.MailFactory, mailServiceModuleInfo);

            mailServiceModuleInfo = new MailServiceModuleInfo("SFDML02011U.dll", "Broadleaf.Windows.Forms.SFDML02011UA");
            mailServiceConfigInfo.Add(MailServiceModuleIndex.MailMacroConverter, mailServiceModuleInfo);

            mailServiceModuleInfo = new MailServiceModuleInfo("", "");
            mailServiceConfigInfo.Add(MailServiceModuleIndex.MailEditHelper, mailServiceModuleInfo);

            mailServiceModuleInfo = new MailServiceModuleInfo("SFDML02012C.dll", "Broadleaf.Application.Common.NsMacroConverter");
            mailServiceConfigInfo.Add(MailServiceModuleIndex.MailDocumentSelector, mailServiceModuleInfo);

            mailServiceModuleInfo = new MailServiceModuleInfo("PMKHN07508C.dll", "Broadleaf.Application.Common.MailBackupMaker");
            mailServiceConfigInfo.Add(MailServiceModuleIndex.MailBackupMaker, mailServiceModuleInfo);

            mailServiceModuleInfo = new MailServiceModuleInfo("PMKHN07507C.dll", "Broadleaf.Application.Common.MailHistoryMaker");
            mailServiceConfigInfo.Add(MailServiceModuleIndex.MailHistoryMaker, mailServiceModuleInfo);
            
            
            //string path = System.IO.Path.GetFullPath("NsMailServiceInfo.config"); 
            //bool existFile = false;
            //if (System.IO.File.Exists(path))
            //{
            //    existFile = true;
            //}
            //else
            //{
            //    string lFileName = System.IO.Path.GetFileName(path);

            //    if (System.IO.File.Exists(lFileName))
            //    {
            //        existFile = true;
            //        path = lFileName;
            //    }
            //}

            //if (existFile)
            //{

            //    XmlDocument _xmlDoc = null;
            //    bool _xPathDocEnable = false;

            //    // �o�̓t�@�C���̐ݒ�擾
            //    try
            //    {
            //        _xmlDoc = new XmlDocument();
            //        _xmlDoc.Load(path);
            //        _xPathDocEnable = true;
            //    }
            //    catch (FileNotFoundException e)
            //    {
            //        System.Windows.Forms.MessageBox.Show(e.StackTrace);
            //    }
            //    catch (XmlException e)
            //    {
            //        System.Windows.Forms.MessageBox.Show(e.StackTrace);
            //    }

            //    // �K�C�h�ݒ�t�@�C���̓Ǎ�
            //    if (_xPathDocEnable)
            //    {
            //        XmlElement xmlElem = _xmlDoc.DocumentElement;
            //        XmlElement xmlElem1 = null;
            //        XmlElement xmlElem2 = null;

            //        xmlElem1 = (XmlElement)xmlElem.SelectSingleNode("//MailServiceConfig/MailEditorAsm");

            //        if ((xmlElem1 != null) && (xmlElem1.InnerText.Trim() != ""))
            //        {
            //            xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//MailServiceConfig/MailEditorClass");

            //            if ((xmlElem2 != null) && (xmlElem2.InnerText.Trim() != ""))
            //            {
            //                MailServiceModuleInfo mailServiceModuleInfo = new MailServiceModuleInfo(xmlElem1.InnerText, xmlElem2.InnerText);
            //                mailServiceConfigInfo.Add(MailServiceModuleIndex.MailEditor, mailServiceModuleInfo);
            //            }
            //        }

            //        xmlElem1 = (XmlElement)xmlElem.SelectSingleNode("//MailServiceConfig/MailSenderAsm");
            //        if ((xmlElem1 != null) && (xmlElem1.InnerText.Trim() != ""))
            //        {
            //            xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//MailServiceConfig/MailSenderClass");

            //            if ((xmlElem2 != null) && (xmlElem2.InnerText.Trim() != ""))
            //            {
            //                MailServiceModuleInfo mailServiceModuleInfo = new MailServiceModuleInfo(xmlElem1.InnerText, xmlElem2.InnerText);
            //                mailServiceConfigInfo.Add(MailServiceModuleIndex.MailSender, mailServiceModuleInfo);
            //            }
            //        }

            //        xmlElem1 = (XmlElement)xmlElem.SelectSingleNode("//MailServiceConfig/MailViewerAsm");
            //        if ((xmlElem1 != null) && (xmlElem1.InnerText.Trim() != ""))
            //        {
            //            xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//MailServiceConfig/MailViewerClass");

            //            if ((xmlElem2 != null) && (xmlElem2.InnerText.Trim() != ""))
            //            {
            //                MailServiceModuleInfo mailServiceModuleInfo = new MailServiceModuleInfo(xmlElem1.InnerText, xmlElem2.InnerText);
            //                mailServiceConfigInfo.Add(MailServiceModuleIndex.MailViewer, mailServiceModuleInfo);
            //            }
            //        }

            //        xmlElem1 = (XmlElement)xmlElem.SelectSingleNode("//MailServiceConfig/MailFactoryAsm");
            //        if ((xmlElem1 != null) && (xmlElem1.InnerText.Trim() != ""))
            //        {
            //            xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//MailServiceConfig/MailFactoryClass");

            //            if ((xmlElem2 != null) && (xmlElem2.InnerText.Trim() != ""))
            //            {
            //                MailServiceModuleInfo mailServiceModuleInfo = new MailServiceModuleInfo(xmlElem1.InnerText, xmlElem2.InnerText);
            //                mailServiceConfigInfo.Add(MailServiceModuleIndex.MailFactory, mailServiceModuleInfo);
            //            }
            //        }

            //        xmlElem1 = (XmlElement)xmlElem.SelectSingleNode("//MailServiceConfig/MacroConverterAsm");
            //        if ((xmlElem1 != null) && (xmlElem1.InnerText.Trim() != ""))
            //        {
            //            xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//MailServiceConfig/MacroConverterClass");

            //            if ((xmlElem2 != null) && (xmlElem2.InnerText.Trim() != ""))
            //            {
            //                MailServiceModuleInfo mailServiceModuleInfo = new MailServiceModuleInfo(xmlElem1.InnerText, xmlElem2.InnerText);
            //                mailServiceConfigInfo.Add(MailServiceModuleIndex.MailMacroConverter, mailServiceModuleInfo);
            //            }
            //        }


            //        xmlElem1 = (XmlElement)xmlElem.SelectSingleNode("//MailServiceConfig/MailEditHelperAsm");
            //        if ((xmlElem1 != null) && (xmlElem1.InnerText.Trim() != ""))
            //        {
            //            xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//MailServiceConfig/MailEditHelperClass");

            //            if ((xmlElem2 != null) && (xmlElem2.InnerText.Trim() != ""))
            //            {
            //                MailServiceModuleInfo mailServiceModuleInfo = new MailServiceModuleInfo(xmlElem1.InnerText, xmlElem2.InnerText);
            //                mailServiceConfigInfo.Add(MailServiceModuleIndex.MailEditHelper, mailServiceModuleInfo);
            //            }
            //        }

            //        xmlElem1 = (XmlElement)xmlElem.SelectSingleNode("//MailServiceConfig/MailDocumentSelectorAsm");
            //        if ((xmlElem1 != null) && (xmlElem1.InnerText.Trim() != ""))
            //        {
            //            xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//MailServiceConfig/MailDocumentSelectorClass");

            //            if ((xmlElem2 != null) && (xmlElem2.InnerText.Trim() != ""))
            //            {
            //                MailServiceModuleInfo mailServiceModuleInfo = new MailServiceModuleInfo(xmlElem1.InnerText, xmlElem2.InnerText);
            //                mailServiceConfigInfo.Add(MailServiceModuleIndex.MailDocumentSelector, mailServiceModuleInfo);
            //            }
            //        }

            //        xmlElem1 = (XmlElement)xmlElem.SelectSingleNode("//MailServiceConfig/MailBackupMakerAsm");
            //        if ((xmlElem1 != null) && (xmlElem1.InnerText.Trim() != ""))
            //        {
            //            xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//MailServiceConfig/MailBackupMakerClass");

            //            if ((xmlElem2 != null) && (xmlElem2.InnerText.Trim() != ""))
            //            {
            //                MailServiceModuleInfo mailServiceModuleInfo = new MailServiceModuleInfo(xmlElem1.InnerText, xmlElem2.InnerText);
            //                mailServiceConfigInfo.Add(MailServiceModuleIndex.MailBackupMaker, mailServiceModuleInfo);
            //            }
            //        }

            //        xmlElem1 = (XmlElement)xmlElem.SelectSingleNode("//MailServiceConfig/MailHistoryMakerAsm");
            //        if ((xmlElem1 != null) && (xmlElem1.InnerText.Trim() != ""))
            //        {
            //            xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//MailServiceConfig/MailHistoryMakerClass");

            //            if ((xmlElem2 != null) && (xmlElem2.InnerText.Trim() != ""))
            //            {
            //                MailServiceModuleInfo mailServiceModuleInfo = new MailServiceModuleInfo(xmlElem1.InnerText, xmlElem2.InnerText);
            //                mailServiceConfigInfo.Add(MailServiceModuleIndex.MailHistoryMaker, mailServiceModuleInfo);
            //            }
            //        }

            //    }

            //}
            return true;
        }
        #endregion


    }



    //***********************************************************************************************
    //
    // �ȉ��͂Ƃ肠�����̃e�X�g�N���X(�ŏI�I�ɂ͕s�v�ɂȂ�̂ō폜����)
    //
    //***********************************************************************************************

//    #region �e�X�g�N���X

//    /// <summary>
//    /// ���[���G�f�B�^����C���^�t�F�[�X�擾�e�X�g�N���X
//    /// </summary>
//    /// <returns>���[���G�f�B�^����C���^�t�F�[�X</returns>
//    class MailEditorInterfaceTest : IMailEditor
//    {


//        #region IMailEditor �����o
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        public bool ShowEditor()
//        {
//            //System.Diagnostics.Process proc = new System.Diagnostics.Process();
//            //proc.StartInfo.FileName = "notepad.exe";
//            //proc.EnableRaisingEvents = true;
//            //proc.Exited += new EventHandler(proc_Exited);
//            //proc.Start();
//            //proc.WaitForExit();

////            proc.WaitForExit(8000);


//            return true;
//        }

//        private void proc_Exited(object sender, System.EventArgs e)
//        {

        
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string Version
//        {
//            get { return ".NS MailService Test Version"; }
//        }

//        #endregion
//    }


//    /// <summary>
//    /// ���[���r���[�A�[����C���^�t�F�[�X�擾�e�X�g�N���X
//    /// </summary>
//    /// <returns>���[���r���[�A�[����C���^�t�F�[�X</returns>
//    class MailViewerInterfaceTest : IMailViewer
//    {

//        #region IMailViewer �����o

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="mailViewerOperationInfo"></param>
//        /// <param name="mailSourceData"></param>
//        /// <returns></returns>
//        public int ShowMailViewer(ref MailViewerOperationInfo mailViewerOperationInfo, ref MailSourceData mailSourceData)
//        {

//            return 0;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string Version
//        {
//            get { return ".NS MailService Test Version"; }
//        }

//        #endregion
//    }

   
    


//    /// <summary>
//    /// ���[�����M���C�u��������p�����[�^�擾�e�X�g�N���X
//    /// </summary>
//    class NsMacroConverterInterfaceTest : INsMacroConverter
//    {


//        #region INsMacroConverter �����o

//        public int ExecuteConverter(NsMacroConverterOperationInfo nsMacroConverterOperationInfo, ref MailSourceData mailSourceData)
//        {
//            return 0;
//        }

//        public string Version
//        {
//            get { return ".NS MailService Test Version"; }
//        }

//        #endregion

//    }

//    /// <summary>
//    /// ���[���o�b�N�A�b�v�f�[�^�쐬���C�u��������C���^�t�F�[�X�擾�e�X�g�N���X
//    /// </summary>
//    /// <returns>���[���o�b�N�A�b�v�f�[�^�쐬���C�u��������C���^�t�F�[�X</returns>
//    class MailBackupMakerInterfaceTest : IMailBackupMaker
//    {
            

//        #region IMailBackupMaker �����o


//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="mailSourceData"></param>
//        /// <returns></returns>
//        public int DeleteBackupData(ref MailSourceData mailSourceData)
//        {
//            return 0;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="targetIndex"></param>
//        /// <param name="mailSourceData"></param>
//        /// <returns></returns>
//        public int DeleteBackupData(int targetIndex, ref MailSourceData mailSourceData)
//        {
//            return 0;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="targetIndex"></param>
//        /// <param name="mailSourceData"></param>
//        /// <returns></returns>
//        public int MakeBackupData(int targetIndex, ref MailSourceData mailSourceData)
//        {
//            return 0;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="mailSourceData"></param>
//        /// <returns></returns>
//        public int MakeBackupData(ref MailSourceData mailSourceData)
//        {
////            MessageBox.Show("���[���̃o�b�N�A�b�v���쐬���܂�..... \n���̕ӂ�͌�X�g�����K�v���낤�Ȃ�.....", "�Ԃ₢�Ă݂܂���", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            return 0;
//        }


//        /// <summary>
//        /// 
//        /// </summary>
//        public string Version
//        {
//            get { return ".NS MailService Test Version"; }
//        }

//        #endregion

//    }


//    /// <summary>
//    /// ���[�����M�����쐬���C�u��������C���^�t�F�[�X�擾�e�X�g�N���X
//    /// </summary>
//    /// <returns>���[�����M�����쐬���C�u��������C���^�t�F�[�X</returns>
//    class MailSendingHistoryMakerInterfaceTest : IMailSendingHistoryMaker
//    {


//        #region IMailSendingHistoryMaker �����o

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="targetIndex"></param>
//        /// <param name="mailSourceData"></param>
//        /// <returns></returns>
//        public int DeleteSendingHistory(int targetIndex, ref MailSourceData mailSourceData)
//        {
//            return 0;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="mailSourceData"></param>
//        /// <returns></returns>
//        public int DeleteSendingHistory(ref MailSourceData mailSourceData)
//        {
//            return 0;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="targetIndex"></param>
//        /// <param name="mailSourceData"></param>
//        /// <returns></returns>
//        public int MakeSendingHistory(int targetIndex, ref MailSourceData mailSourceData)
//        {
//            return 0;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="mailSourceData"></param>
//        /// <returns></returns>
//        public int MakeSendingHistory(ref MailSourceData mailSourceData)
//        {
//            return 0;
//        }


//        /// <summary>
//        /// 
//        /// </summary>
//        public string Version
//        {
//            get { return ".NS MailService Test Version"; }
//        }

//        #endregion


//        #region IMailSendingHistoryMaker �����o


//        public int InitializeSendingHistory(ref MailSourceData mailSourceData)
//        {
//            return 0;
//         //   throw new Exception("The method or operation is not implemented.");
//        }

//        #endregion
//    }

//    /// <summary>
//    /// ���[���������͎x���K�C�h����C���^�t�F�[�X�擾�e�X�g�N���X
//    /// </summary>
//    /// <returns>���[���������͎x���K�C�h����C���^�t�F�[�X</returns>
//    class MailEditHelperInterfaceTest : IMailEditHelper
//    {


//        #region IMailEditHelper �����o

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="ShowMode"></param>
//        /// <returns></returns>
//        public string ShowMailEditHelper(int ShowMode)
//        {
//            return "";
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string Version
//        {
//            get { return ".NS MailService Test Version"; }
//        }

//        #endregion
//    }

//    /// <summary>
//    /// ���[�������I���K�C�h����C���^�t�F�[�X�擾�e�X�g�N���X
//    /// </summary>
//    /// <returns>���[�������I���K�C�h����C���^�t�F�[�X</returns>
//    class MailDocumentSelectorInterfaceTest : IMailDocumentSelector
//    {


//        #region IMailDocumentSelector �����o

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="ShowMode"></param>
//        /// <param name="mailDocMng"></param>
//        /// <param name="mobileMailDocMng"></param>
//        /// <returns></returns>
//        public bool ShowMailDocumentSelectorGuide(int ShowMode, out Broadleaf.Application.UIData.MailDocMng mailDocMng, out Broadleaf.Application.UIData.MailDocMng mobileMailDocMng)
//        {
//            Broadleaf.Application.UIData.MailDocMng _mailDocMng = new Broadleaf.Application.UIData.MailDocMng();
//            Broadleaf.Application.UIData.MailDocMng _mobileMailDocMng = new Broadleaf.Application.UIData.MailDocMng();


//            mailDocMng = _mailDocMng;
//            mobileMailDocMng = _mobileMailDocMng;

//            return true;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string Version
//        {
//            get { return ".NS MailService Test Version"; }
//        }

//        #endregion
//    }



//    #endregion �e�X�g�N���X


}
