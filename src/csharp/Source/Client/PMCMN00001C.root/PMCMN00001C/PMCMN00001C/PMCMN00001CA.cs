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
        /// 日本語
        /// </summary>
        private static System.Globalization.CultureInfo culJp = new System.Globalization.CultureInfo("ja");
        /// <summary>
        /// 英語
        /// </summary>
        private static System.Globalization.CultureInfo culEn = new System.Globalization.CultureInfo("en", true);
        /// <summary>
        /// ロシア語
        /// </summary>
        private static System.Globalization.CultureInfo culRu = new System.Globalization.CultureInfo("ru", true);
        /// <summary>
        /// 中国語（とりあえず中国語ー中国）
        /// </summary>
        private static System.Globalization.CultureInfo culCh = new System.Globalization.CultureInfo("zh-CN", true);
        /// <summary>
        /// アラビア語
        /// </summary>
        private static System.Globalization.CultureInfo culAr = new System.Globalization.CultureInfo("ar", true);

        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
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
        ///   厳密に型指定されたこのリソース クラスを使用して、すべての検索リソースに対し、
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
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
            try // 環境の問題でエラーが発生する場合は無視し、日本語固定とする。
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
        /// リソースIDに対応する指定言語のストリングを取得する
        /// </summary>
        /// <param name="id">取得する文字列のリソースID</param>
        /// <returns>リソースIDに対応する指定言語のストリング</returns>
        public static string GetString(string id)
        {
            return ResourceManager.GetString(id, resourceCulture).Replace("\\\\", "\\");
        }

        /// <summary>
        /// カルチャ情報指定ストリング取得する
        /// </summary>
        /// <param name="id">取得するリソースID[リソース管理シート又はリソースファイル参照]</param>
        /// <param name="culture">取得したい言語のカルチャ名/対応するリソースがない場合はデフォルト言語になる</param>
        /// <returns>リソースIDに対応する指定言語のストリング</returns>
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
        /// 日本語ストリング取得専用メソッド
        /// </summary>
        /// <param name="id">取得するリソースID[リソース管理シート又はリソースファイル参照]</param>
        /// <returns>リソースIDに該当する日本語のストリング</returns>
        public static string GetStringJp(string id)
        {
            return ResourceManager.GetString(id, culJp).Replace("\\\\", "\\");
        }

        /// <summary>
        /// カルチャ設定メソッド
        /// 現在のスレッドのカルチャ情報を環境に指定されているカルチャ情報にセットする
        /// Application.Runメソッド又はメインフォームのコンストラクターのInitializeComponent
        /// を呼び出す前にこのメソッドを呼び出す必要があります。
        /// </summary>
        public static void SetCulture()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = Culture;
        }
    }
}
