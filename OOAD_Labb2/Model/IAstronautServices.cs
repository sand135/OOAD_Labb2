using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OOAD_Labb2
{
    public interface IAstronautServices
    {
       
       Task<SpaceInfoDTO> GetDataAsync();
    }
}
