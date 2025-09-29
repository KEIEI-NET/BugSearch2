using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// メール初期値データアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 新規作成</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/04/06</br>
    /// </remarks>
    public class MailDefaultDataAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■ Private Member

        #endregion

        // ===================================================================================== //
        // 列挙体
        // ===================================================================================== //
        #region ■ Public Enum
        /// <summary>
        /// 簡単問合せのシステムコード
        /// </summary>
        public enum SimpleInqIdCngSysCd : int
        {
            Partsman = 300
        }
        
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■ Costructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public MailDefaultDataAcs()
        {
                   
        }

        #endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region ■ Public Method

        /// <summary>
        /// メール用初期データを書き込みます。
        /// </summary>
        /// <param name="mailDefaultHeader">メール初期ヘッダデータオブジェクト</param>
        /// <param name="mailDefaultCar">メール初期車両データオブジェクト</param>
        /// <param name="mailDefaultDetailList">メール初期明細データオブジェクトリスト</param>
        /// <param name="fileName">作成したファイル名</param>
        /// <returns>STATUS</returns>
        public int Write(MailDefaultHeader mailDefaultHeader, MailDefaultCar mailDefaultCar, List<MailDefaultDetail> mailDefaultDetailList, out string fileName)
        {
            return WriteProc(mailDefaultHeader, mailDefaultCar, mailDefaultDetailList, out fileName);
        }

        /// <summary>
        /// メール用初期データを読み込みます。
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <param name="mailDefaultHeader">メール初期ヘッダデータオブジェクト</param>
        /// <param name="mailDefaultCar">メール初期車両データオブジェクト</param>
        /// <param name="mailDefaultDetailList">メール初期明細データオブジェクトリスト</param>
        /// <returns>STATUS</returns>
        public int Read(string fileName, out MailDefaultHeader mailDefaultHeader, out MailDefaultCar mailDefaultCar, out List<MailDefaultDetail> mailDefaultDetailList)
        {
            return ReadProc(fileName, out mailDefaultHeader, out mailDefaultCar, out mailDefaultDetailList);
        }

        /// <summary>
        /// メール用初期データを削除します。
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns>STATUS</returns>
        public int Delete(string fileName)
        {
            return DeleteProc(fileName);
        }

        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■ Private Method

        /// <summary>
        /// メール用初期データを書き込みます。
        /// </summary>
        /// <param name="mailDefaultHeader">メール初期ヘッダデータオブジェクト</param>
        /// <param name="mailDefaultCar">メール初期車両データオブジェクト</param>
        /// <param name="mailDefaultDetailList">メール初期明細データオブジェクトリスト</param>
        /// <param name="fileName">ファイル名</param>
        /// <returns>STATUS</returns>
        private int WriteProc(MailDefaultHeader mailDefaultHeader, MailDefaultCar mailDefaultCar, List<MailDefaultDetail> mailDefaultDetailList, out string fileName)
        {
            fileName = Guid.NewGuid().ToString() + ".xml";
            string fullpath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName);
            MailDefaultData msd = new MailDefaultData();
            msd.HeaderInfo = mailDefaultHeader;
            msd.DetailInfoList = mailDefaultDetailList;
            msd.CarInfo = mailDefaultCar;

            try
            {
                UserSettingController.SerializeUserSetting(msd, fullpath);
            }
            catch
            {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// メール用初期データを読み込みます。
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <param name="mailDefaultHeader">メール初期ヘッダデータオブジェクト</param>
        /// <param name="mailDefaultCar">メール初期車両データオブジェクト</param>
        /// <param name="mailDefaultDetailList">メール初期明細データオブジェクトリスト</param>
        /// <returns>STATUS</returns>
        private int ReadProc(string fileName, out MailDefaultHeader mailDefaultHeader, out MailDefaultCar mailDefaultCar, out List<MailDefaultDetail> mailDefaultDetailList)
        {
            mailDefaultHeader = new MailDefaultHeader();
            mailDefaultDetailList = new List<MailDefaultDetail>();
            mailDefaultCar = new MailDefaultCar();

            string filePath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName);

            if (!System.IO.File.Exists(filePath)) return -1;

            try
            {
                object obj = UserSettingController.DeserializeUserSetting(filePath, typeof(MailDefaultData));
                if (obj != null && obj is MailDefaultData)
                {
                    MailDefaultData data = (MailDefaultData)obj;
                    mailDefaultHeader = data.HeaderInfo;
                    mailDefaultDetailList = data.DetailInfoList;
                    mailDefaultCar = data.CarInfo;
                }
                else
                {
                    return -2;
                }
            }
            catch
            {
                return -3;
            }

            return 0;
        }

        /// <summary>
        /// メール用初期データを削除します。
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private int DeleteProc(string fileName)
        {
            string filePath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName);
            if (System.IO.File.Exists(filePath))
            {
                UserSettingController.DeleteUserSetting(filePath);
            }
            return 0;
        }
        

        #endregion
    }

    /// <summary>
    /// メール初期データ
    /// </summary>
    [Serializable]
    public class MailDefaultData
    {
        #region ■ Private Member

        private MailDefaultHeader _header;
        private List<MailDefaultDetail> _detailList;
        private MailDefaultCar _car;

        #endregion

        #region ■ Constructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public MailDefaultData()
        {

        }
        #endregion

        #region ■ Property

        /// <summary>ヘッダデータ</summary>
        public MailDefaultHeader HeaderInfo
        {
            get { return _header; }
            set { _header = value; }
        }

        /// <summary>車両情報</summary>
        public MailDefaultCar CarInfo
        {
            get { return _car; }
            set { _car = value; }
        }


        /// <summary>明細リスト</summary>
        public List<MailDefaultDetail> DetailInfoList
        {
            get { return _detailList; }
            set { _detailList = value; }
        }
        #endregion
    }
}
