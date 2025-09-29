using System;
using System.Data;
using System.IO;
using System.Net;

using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller.NetworkConfig
{
    /// <summary>
    /// XMLネットワーク設定クラス（未使用）
    /// </summary>
    public class XMLNetworkConfig : AbstractNetworkConfig
    {
        #region <AbstractNetworkConfig メンバ>

        /// <summary>
        /// IPアドレスを取得します。
        /// </summary>
        /// <see cref="AbstractNetworkConfig"/>
        public override IPAddress IPAddress
        {
            get { return IPAddress.Parse(ConfigRow[IP_ADDRESS_CLM_NAME].ToString()); }
        }

        /// <summary>
        /// ポート番号を取得します。
        /// </summary>
        /// <see cref="AbstractNetworkConfig"/>
        public override int PortNumber
        {
            get { return int.Parse(ConfigRow[PORT_COLUMN_NAME].ToString()); }
        }

        /// <summary>
        /// 初期化します。
        /// </summary>
        /// <see cref="AbstractNetworkConfig"/>
        protected override void Initialize()
        {
            Clear();
        }

        #endregion // </INetworkConfig メンバ>

        #region <XML設定内容>

        /// <summary>設定ファイル名</summary>
        private const string CONFIG_FILE_NAME = "GetIPAddress.xml";

        /// <summary>テーブル名</summary>
        private const string TABLE_NAME = "name";
        /// <summary>IPアドレスカラム名</summary>
        private const string IP_ADDRESS_CLM_NAME = "IpAddress";
        /// <summary>ポートカラム名</summary>
        private const string PORT_COLUMN_NAME = "Port";

        /// <summary>設定テーブルのインデックス</summary>
        private int _configIndex;
        /// <summary>設定テーブルのインデックスを取得します。</summary>
        private int ConfigIndex { get { return _configIndex; } }

        /// <summary>設定DB</summary>
        private readonly DataSet _configDB;
        /// <summary>設定DBを取得します。</summary>
        private DataSet ConfigDB { get { return _configDB; } }

        /// <summary>
        /// 設定テーブルを取得します。
        /// </summary>
        private DataTable ConfigTable { get { return ConfigDB.Tables[TABLE_NAME]; } }

        /// <summary>
        /// 設定行を取得します。
        /// </summary>
        private DataRow ConfigRow { get { return ConfigTable.Rows[ConfigIndex]; } }

        #endregion // </XML設定内容>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public XMLNetworkConfig() : base()
        {
            _configIndex = 0;
            _configDB = (DataSet)XmlByteSerializer.Deserialize(
                Path.Combine(Directory.GetCurrentDirectory(), CONFIG_FILE_NAME),
                typeof(DataSet)
            );

            if (ConfigTable.Rows.Count <= 1) return;

            for (_configIndex = 0; _configIndex < ConfigTable.Rows.Count; _configIndex++)
            {
                Add(new NetworkConfigImpl(IPAddress.ToString(), PortNumber));
            }
            _configIndex = 0;
        }

        #endregion // </Constructor>
    }
}
