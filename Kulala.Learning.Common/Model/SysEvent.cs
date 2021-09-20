using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulala.Learning.Common.Model
{
    /// <summary>
    /// 保存事件的几个属性
    /// </summary>
    public class SysEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }
    }
}
