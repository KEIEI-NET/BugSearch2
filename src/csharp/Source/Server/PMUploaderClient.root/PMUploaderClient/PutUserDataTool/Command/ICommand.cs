using System;
using System.Collections.Generic;
using System.Text;

namespace PutUserDataTool
{
    public interface ICommand
    {
        /// <summary>
        /// �R�}���h�����s���܂��B
        /// </summary>
        void Execute();
    }
}
