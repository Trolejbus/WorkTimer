using AutoMapper;
using System;
//using WorkTimer.Common.TypeConverters;
using WorkTimer.Common.ValueConverters;
using WorkTimer.Domain.Models.Models;
using WorkTimer.SQLite.Entities;

namespace WorkTimer.SQLite
{
    public class WorkTimerDataProfile: Profile
    {
        public WorkTimerDataProfile()
        {
            /*CreateMap<string, TimeSpan?>()
                
            CreateMap<TimeSpan?, string>()
                .ConvertUsing<StringToTimeSpanConverter>();*/
            CreateMap<WorkTask, WorkTaskModel>()
                .ForMember(d => d.PlannedTime,
                    opt => opt.MapFrom(src => Convert(src.PlannedTime)))
                .ReverseMap()
                .ForMember(d => d.PlannedTime,
                    opt => opt.MapFrom(src => Convert(src.PlannedTime)));
        }
        
        public string Convert(TimeSpan? sourceMember)
        {
            return sourceMember.HasValue ? sourceMember.Value.ToString() : null;
        }

        public TimeSpan? Convert(string sourceMember)
        {
            return sourceMember != null ? (TimeSpan?)TimeSpan.Parse(sourceMember) : null;
        }
    }
}
