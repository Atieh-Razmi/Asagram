using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public record UpdateProvinceCommand(Guid id, ProvinceDTO ProvinceDTO) : IRequest<Unit>;
    
}
