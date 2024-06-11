using Motoka.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.Service.Interface
{
    public interface IRentService
    {
        void Add(RentRequestDto rent);
        void UpdateRange(RentRangeUpdateDto request);
    }
}
