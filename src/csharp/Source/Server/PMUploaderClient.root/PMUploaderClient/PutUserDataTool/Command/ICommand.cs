using System;
using System.Collections.Generic;
using System.Text;

namespace PutUserDataTool
{
    public interface ICommand
    {
        /// <summary>
        /// コマンドを実行します。
        /// </summary>
        void Execute();
    }
}
