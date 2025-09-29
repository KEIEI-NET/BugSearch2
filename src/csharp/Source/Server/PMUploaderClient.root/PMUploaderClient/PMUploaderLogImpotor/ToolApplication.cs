using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.IO;

namespace Broadleaf.Application.Partsman.Developers
{
    public class ToolApplication
    {
        /// <summary>Singleton Objects.</summary>
        private static ToolApplication _self;

        /// <summary>zip�R�}���h</summary>
        private string _zipCommand;

        /// <summary>bcp�R�}���h</summary>
        private string _bcpCommand;

        /// <summary>SQL Server:�T�[�o�[����</summary>
        private string _sqlServerName;

        /// <summary>SQL Server:���[�U�[ID</summary>
        private string _sqlServerUser;

        /// <summary>SQL Server:�p�X���[�h</summary>
        private string _sqlServerPass;

        public string ZipCommand
        {
            get { return this._zipCommand; }
        }

        /// <summary>zip�R�}���h</summary>
        public string BcpCommand
        {
            get { return this._bcpCommand; }
        }


        /// <summary>zip�R�}���h</summary>
        public string SqlServerName
        {
            get { return this._sqlServerName; }
        }

        /// <summary>zip�R�}���h</summary>
        public string SqlServerUser
        {
            get { return this._sqlServerUser; }
        }

        /// <summary>zip�R�}���h</summary>
        public string SqlServerPass
        {
            get { return this._sqlServerPass; }
        }

        /// <summary>
        /// �R���X�g���N�^�B
        /// </summary>
        private ToolApplication()
        {
            this._zipCommand = ConfigurationManager.AppSettings["7zCommand"];
            this._bcpCommand = ConfigurationManager.AppSettings["BcpCommand"];
            this._sqlServerName = ConfigurationManager.AppSettings["SqlServer-Name"];
            this._sqlServerUser = ConfigurationManager.AppSettings["SqlServer-User"];
            this._sqlServerPass = ConfigurationManager.AppSettings["SqlServer-Pass"];
        }

        /// <summary>
        /// �C���X�^���X�擾
        /// </summary>
        /// <returns></returns>
        public static ToolApplication GetInstance()
        {
            if (_self == null)
            {
                _self = new ToolApplication();
            }
            return _self;
        }

        public string GetImportTable(FileInfo taskFileName)
        {
            string task = taskFileName.Name;
            task = task.Substring(0, 15);
            return ConfigurationManager.AppSettings[task];
        }
    }
}
