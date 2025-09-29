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
    /// メールサービス オブジェクト管理クラス
    /// </summary>
    /// <remarks> 
    /// メールサービスで使用する各種コントロール、インタフェースを管理しています。
    /// このクラスでメールサービスの各種サービス境界のコントロールを行うことができます
    /// </remarks>
    public class MailFactoryBase
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>MailInfoBase
        /// <param name="mailServiceInfoCreateMode">メールサービス関連情報 生成モード</param>
        public MailFactoryBase(MailServiceInfoCreateMode mailServiceInfoCreateMode)
        {
            GetMailServiceConfigInfo(out _MailServiceConfigInfo);
            if (_MailServiceConfigInfo == null)
            {
                _MailServiceConfigInfo = new Hashtable();
            }
        }

        /// <summary>
        /// メールサービス モジュール構成リスト
        /// </summary>
        private Hashtable _MailServiceConfigInfo = null;


        ///// <summary>
        ///// メールエディタ操作インタフェース取得
        ///// </summary>
        ///// <returns>メールエディタ操作インタフェース</returns>
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
        ///// メールビューアー操作インタフェース取得
        ///// </summary>
        ///// <returns>メールビューアー操作インタフェース</returns>
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
        /// メール送信ライブラリ操作インタフェース取得
        /// </summary>
        /// <returns>メール送信ライブラリ操作インタフェース</returns>
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
        ///// .NSメールサービス マクロコンバーター操作インタフェース取得
        ///// </summary>
        ///// <returns>メール送信ライブラリ操作インタフェース</returns>
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
        ///// .NSメールサービス メール作成ライブラリ操作インタフェース取得
        ///// </summary>
        ///// <returns>メール作成ライブラリ操作インタフェース</returns>
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
        ///// メールバックアップデータ作成ライブラリ操作インタフェース取得
        ///// </summary>
        ///// <returns>メールバックアップデータ作成ライブラリ操作インタフェース</returns>
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
        /// メール送信履歴作成ライブラリ操作インタフェース取得
        /// </summary>
        /// <returns>メール送信履歴作成ライブラリ操作インタフェース</returns>
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
        ///// メール文書入力支援ガイド操作インタフェース取得
        ///// </summary>
        ///// <returns>メール文書入力支援ガイド操作インタフェース</returns>
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
        ///// メール文書選択ガイド操作インタフェース取得
        ///// </summary>
        ///// <returns>メール文書選択ガイド操作インタフェース</returns>
        //public IMailDocumentSelector GetMailDocumentSelectorInterface()
        //{
        //    MailDocumentSelectorInterfaceTest mailDocumentSelectorInterfaceTest = new MailDocumentSelectorInterfaceTest();
        //    return (IMailDocumentSelector)mailDocumentSelectorInterfaceTest;
        //}


        /// <summary>
        /// クラス生成
        /// </summary>
        /// <param name="mailServiceModuleInfo">メールサービス 構成モジュール情報クラス</param>
        /// <returns>生成したオブジェクト</returns>
        private object ClassFactory(ref MailServiceModuleInfo mailServiceModuleInfo)
        {

            if ((mailServiceModuleInfo.AssemblyName != "") && (mailServiceModuleInfo.ClassName != ""))
            {
                string path = System.IO.Path.GetFullPath(mailServiceModuleInfo.AssemblyName);
                // アセンブリをロード
                Assembly assembly = null;
                if (System.IO.File.Exists(path))
                {
                    assembly = Assembly.LoadFile(path);
                }

                // クラスインスタンスを作成
                if (assembly != null)
                {
                    object plugIn = assembly.CreateInstance(mailServiceModuleInfo.ClassName);
                    if (plugIn == null)
                    {
                        MessageBox.Show(path + " - " + mailServiceModuleInfo.ClassName + "\n" + "が見つかりません");
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
        /// メールサービス 構成モジュールインデックス
        /// </summary>
        private enum MailServiceModuleIndex
        {
            /// <summary>
            /// メールエディター
            /// </summary>
            MailEditor,
            /// <summary>
            /// メール送信ライブラリ 
            /// </summary>
            MailSender,
            /// <summary>
            /// メールビューアー
            /// </summary>
            MailViewer,
            /// <summary>
            /// メール作成ライブラリ
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
        /// メールサービス 構成モジュール情報クラス
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


        #region テスト用XML設定読込
        /// <summary>
        /// メールサービス 各種サービス構成情報取得(XML)
        /// </summary>
        /// <returns>取得結果 true:情報取得成功</returns>
        private bool GetMailServiceConfigInfo(out Hashtable mailServiceConfigInfo)
        {
            mailServiceConfigInfo = new Hashtable();

            //試しに追加("2010/05/25");
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

            //    // 出力ファイルの設定取得
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

            //    // ガイド設定ファイルの読込
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
    // 以下はとりあえずのテストクラス(最終的には不要になるので削除する)
    //
    //***********************************************************************************************

//    #region テストクラス

//    /// <summary>
//    /// メールエディタ操作インタフェース取得テストクラス
//    /// </summary>
//    /// <returns>メールエディタ操作インタフェース</returns>
//    class MailEditorInterfaceTest : IMailEditor
//    {


//        #region IMailEditor メンバ
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
//    /// メールビューアー操作インタフェース取得テストクラス
//    /// </summary>
//    /// <returns>メールビューアー操作インタフェース</returns>
//    class MailViewerInterfaceTest : IMailViewer
//    {

//        #region IMailViewer メンバ

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
//    /// メール送信ライブラリ操作パラメータ取得テストクラス
//    /// </summary>
//    class NsMacroConverterInterfaceTest : INsMacroConverter
//    {


//        #region INsMacroConverter メンバ

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
//    /// メールバックアップデータ作成ライブラリ操作インタフェース取得テストクラス
//    /// </summary>
//    /// <returns>メールバックアップデータ作成ライブラリ操作インタフェース</returns>
//    class MailBackupMakerInterfaceTest : IMailBackupMaker
//    {
            

//        #region IMailBackupMaker メンバ


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
////            MessageBox.Show("メールのバックアップを作成します..... \nこの辺りは後々拡張が必要だろうなぁ.....", "つぶやいてみました", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
//    /// メール送信履歴作成ライブラリ操作インタフェース取得テストクラス
//    /// </summary>
//    /// <returns>メール送信履歴作成ライブラリ操作インタフェース</returns>
//    class MailSendingHistoryMakerInterfaceTest : IMailSendingHistoryMaker
//    {


//        #region IMailSendingHistoryMaker メンバ

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


//        #region IMailSendingHistoryMaker メンバ


//        public int InitializeSendingHistory(ref MailSourceData mailSourceData)
//        {
//            return 0;
//         //   throw new Exception("The method or operation is not implemented.");
//        }

//        #endregion
//    }

//    /// <summary>
//    /// メール文書入力支援ガイド操作インタフェース取得テストクラス
//    /// </summary>
//    /// <returns>メール文書入力支援ガイド操作インタフェース</returns>
//    class MailEditHelperInterfaceTest : IMailEditHelper
//    {


//        #region IMailEditHelper メンバ

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
//    /// メール文書選択ガイド操作インタフェース取得テストクラス
//    /// </summary>
//    /// <returns>メール文書選択ガイド操作インタフェース</returns>
//    class MailDocumentSelectorInterfaceTest : IMailDocumentSelector
//    {


//        #region IMailDocumentSelector メンバ

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



//    #endregion テストクラス


}
