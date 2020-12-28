using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laba8_oop
{
    public interface ISerializable
    {
        void save(StreamWriter writer);
        void load(StreamReader reader);
    }
}
