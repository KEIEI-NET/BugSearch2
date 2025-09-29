using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PutUserDataTool
{
    public class Logger
    {
        private static Logger _self = new Logger();

        private WriteLog writeLog;

        public delegate void WriteLog(string message);

        private Logger()
        {
            this.writeLog = delegate(string message) { };
        }

        public static Logger GetInstance()
        {
            return _self;
        }

        public void AddWriteLog(WriteLog writeLog)
        {
            this.writeLog += writeLog;
        }

        public void Log(string message,bool isFormatting)
        {
            StreamWriter writer = null;
            string msgFmt1 = Environment.NewLine + "{0:yyyy.MM.dd HH:mm:sss} {1}";
            string msgFmt2 = Environment.NewLine + "{0:HH:mm:sss} {1}";
            try
            {
                // √∑Ωƒ€∏ﬁèëçûÇ›
                writer = new StreamWriter(ToolApplication.GetInstance().LogFile, true, System.Text.Encoding.GetEncoding("shift-jis"));
                if (isFormatting)
                {
                    writer.Write(string.Format(msgFmt1, DateTime.Now, message));
                }
                else
                {
                    writer.Write(message);
                }
                writer.Flush();
            }
            catch
            {
            }
            finally
            {
                if (writer != null) writer.Close();
            }
            if (isFormatting)
            {
                this.writeLog(string.Format(msgFmt2, DateTime.Now, message));
            }
            else
            {
                this.writeLog(message);
            }
        }

        public void Log(string message, Exception ex,bool isFormatting)
        {
            StreamWriter writer = null;
            string msgFmt1 = Environment.NewLine + "{0:yyyy.MM.dd HH:mm:sss} {1} {2} MSG:{3}\r\nSTACK:{4}";
             string msgFmt2 = Environment.NewLine + "{0:HH:mm:sss} {1}";
            try
            {
                // √∑Ωƒ€∏ﬁèëçûÇ›
                writer = new StreamWriter(ToolApplication.GetInstance().LogFile, true, System.Text.Encoding.GetEncoding("shift-jis"));
                if (isFormatting)
                {
                    writer.Write(string.Format(msgFmt1, DateTime.Now, message, ex.GetType().ToString(), ex.Message, ex.StackTrace));
                }
                else
                {
                    writer.Write(message);
                }
                writer.Flush();
            }
            catch
            {
            }
            finally
            {
                if (writer != null) writer.Close();
            }
            if (isFormatting)
            {
                this.writeLog(string.Format(msgFmt2, DateTime.Now, message, ex.GetType().ToString(), ex.Message, ex.StackTrace));
            }
            else
            {
                this.writeLog(message);
            }
        }
    }
}
