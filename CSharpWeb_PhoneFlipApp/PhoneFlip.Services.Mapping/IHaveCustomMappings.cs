using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFlip.Services.Mapping;

public interface IHaveCustomMappings
{
    void CreateMappings(IProfileExpression configuration);
}
