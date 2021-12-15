using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnote.Interfaces
{
    interface IStore
    {
        /// <summary>
        /// 获取数据目录
        /// </summary>
        /// <returns></returns>
        string GetDataPath();

        /// <summary>
        /// 获取笔记目录
        /// </summary>
        /// <returns></returns>
        string GetNotePath();
    }
}
