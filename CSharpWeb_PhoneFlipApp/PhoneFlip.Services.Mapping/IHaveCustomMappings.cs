using AutoMapper;

namespace PhoneFlip.Services.Mapping;

public interface IHaveCustomMappings
{
    void CreateMappings(IProfileExpression configuration);
}
