using AutoMapper;
using Buying.Infrastructure.Domain.Entities;

namespace Buying.Application.Instructions.Responses
{
    public class InstructionMapping : Profile
    {
		public InstructionMapping()
		{
            CreateMap<Instruction, InstructionResponse>()
                .ForMember(d => d.InstructionStatus, o => o.MapFrom(s => s.InstructionStatus.ToString()));

            CreateMap<Channel, ChannelResponse>();
        }
    }
}