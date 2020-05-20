using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Async_Server
{
    public interface IListener
    {
        Task<byte[]> StartListener();
    }
}
