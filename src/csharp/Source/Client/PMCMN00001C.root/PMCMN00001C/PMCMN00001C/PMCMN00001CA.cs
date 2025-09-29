using System;
using System.Globalization;
using System.Resources;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;

namespace Broadleaf.Library.Localization
{
    public static class StringResourcesManager
    {
        private static ResourceManager resourceMan;

        private static CultureInfo resourceCulture;

        private static string languageInfo;
        private static string cultureInfo;

        /// <summary>
        /// ���{��
        /// </summary>
        private static System.Globalization.CultureInfo culJp = new System.Globalization.CultureInfo("ja");
        /// <summary>
        /// �p��
        /// </summary>
        private static System.Globalization.CultureInfo culEn = new System.Globalization.CultureInfo("en", true);
        /// <summary>
        /// ���V�A��
        /// </summary>
        private static System.Globalization.CultureInfo culRu = new System.Globalization.CultureInfo("ru", true);
        /// <summary>
        /// ������i�Ƃ肠����������[�����j
        /// </summary>
        private static System.Globalization.CultureInfo culCh = new System.Globalization.CultureInfo("zh-CN", true);
        /// <summary>
        /// �A���r�A��
        /// </summary>
        private static System.Globalization.CultureInfo culAr = new System.Globalization.CultureInfo("ar", true);

        /// <summary>
        ///   ���̃N���X�Ŏg�p����Ă���L���b�V�����ꂽ ResourceManager �C���X�^���X��Ԃ��܂��B
        /// </summary>
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    InitializeCultureInfo();
                }
                return resourceMan;
            }
        }

        /// <summary>
        ///   �����Ɍ^�w�肳�ꂽ���̃��\�[�X �N���X���g�p���āA���ׂĂ̌������\�[�X�ɑ΂��A
        ///   ���݂̃X���b�h�� CurrentUICulture �v���p�e�B���I�[�o�[���C�h���܂��B
        /// </summary>
        internal static global::System.Globalization.CultureInfo Culture
        {
            get
            {
                if (object.ReferenceEquals(resourceCulture, null))
                {
                    InitializeCultureInfo();
                }
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        private static void InitializeCultureInfo()
        {            
            PosTerminalMgLcDB posTerminalMgLcDB = new PosTerminalMgLcDB();
            PosTerminalMgWork posTerminalMgWork = new PosTerminalMgWork();
            posTerminalMgWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            try // ���̖��ŃG���[����������ꍇ�͖������A���{��Œ�Ƃ���B
            {
                posTerminalMgLcDB.Read(ref posTerminalMgWork, 0);
                languageInfo = posTerminalMgWork.UseLanguageDivCd;
                cultureInfo = posTerminalMgWork.UseCultureDivCd;
            }
            catch { }
            resourceCulture = CultureInfo.CreateSpecificCulture(cultureInfo);

            resourceMan = new ResourceManager("Broadleaf.Library.Localization.Resources", typeof(StringResourcesManager).Assembly);
        }

        public static string GetUseLanCd()
        {
            return languageInfo;
        }

        /// <summary>
        /// ���\�[�XID�ɑΉ�����w�茾��̃X�g�����O���擾����
        /// </summary>
        /// <param name="id">�擾���镶����̃��\�[�XID</param>
        /// <returns>���\�[�XID�ɑΉ�����w�茾��̃X�g�����O</returns>
        public static string GetString(string id)
        {
            return ResourceManager.GetString(id, resourceCulture).Replace("\\\\", "\\");
        }

        /// <summary>
        /// �J���`�����w��X�g�����O�擾����
        /// </summary>
        /// <param name="id">�擾���郊�\�[�XID[���\�[�X�Ǘ��V�[�g���̓��\�[�X�t�@�C���Q��]</param>
        /// <param name="culture">�擾����������̃J���`����/�Ή����郊�\�[�X���Ȃ��ꍇ�̓f�t�H���g����ɂȂ�</param>
        /// <returns>���\�[�XID�ɑΉ�����w�茾��̃X�g�����O</returns>
        public static string GetString(string id, string culture)
        {
            switch (culture)
            {
                case "ja":
                    return ResourceManager.GetString(id, culJp).Replace("\\\\", "\\");
                case "ru":
                    return ResourceManager.GetString(id, culRu).Replace("\\\\", "\\");
                case "zh-CN":
                    return ResourceManager.GetString(id, culCh).Replace("\\\\", "\\");
                case "ar":
                    return ResourceManager.GetString(id, culAr).Replace("\\\\", "\\");
            }
            return ResourceManager.GetString(id, culEn).Replace("\\\\", "\\");
        }

        /// <summary>
        /// ���{��X�g�����O�擾��p���\�b�h
        /// </summary>
        /// <param name="id">�擾���郊�\�[�XID[���\�[�X�Ǘ��V�[�g���̓��\�[�X�t�@�C���Q��]</param>
        /// <returns>���\�[�XID�ɊY��������{��̃X�g�����O</returns>
        public static string GetStringJp(string id)
        {
            return ResourceManager.GetString(id, culJp).Replace("\\\\", "\\");
        }

        /// <summary>
        /// �J���`���ݒ胁�\�b�h
        /// ���݂̃X���b�h�̃J���`���������Ɏw�肳��Ă���J���`�����ɃZ�b�g����
        /// Application.Run���\�b�h���̓��C���t�H�[���̃R���X�g���N�^�[��InitializeComponent
        /// ���Ăяo���O�ɂ��̃��\�b�h���Ăяo���K�v������܂��B
        /// </summary>
        public static void SetCulture()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = Culture;
        }
    }
}
