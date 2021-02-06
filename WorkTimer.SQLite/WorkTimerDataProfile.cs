using AutoMapper;
using System;
using WorkTimer.Domain.Models.Models;
using WorkTimer.SQLite.Entities;

namespace WorkTimer.SQLite
{
    public class WorkTimerDataProfile: Profile
    {
        public WorkTimerDataProfile()
        {
            CreateMap<WorkTask, WorkTaskModel>()
                .ForMember(d => d.PlannedTime, opt => opt.MapFrom(src => Convert(src.PlannedTime)))
                .ReverseMap()
                .ForMember(d => d.PlannedTime, opt => opt.MapFrom(src => Convert(src.PlannedTime)));
            CreateMap<WorkLog, WorkLogModel>()
                .ForMember(d => d.StartDate, opt => opt.MapFrom(src => ConvertDate(src.StartDate)))
                .ForMember(d => d.EndDate, opt => opt.MapFrom(src => ConvertDate(src.EndDate)))
                .ReverseMap()
                .ForMember(d => d.StartDate, opt => opt.MapFrom(src => ConvertDate(src.StartDate)))
                .ForMember(d => d.EndDate, opt => opt.MapFrom(src => ConvertDate(src.EndDate)));
        }
        
        public string Convert(TimeSpan? sourceMember)
        {
            return sourceMember.HasValue ? sourceMember.Value.ToString() : null;
        }

        public TimeSpan? Convert(string sourceMember)
        {
            return sourceMember != null ? (TimeSpan?)TimeSpan.Parse(sourceMember) : null;
        }

        public string ConvertDate(DateTime? sourceMember)
        {
            return sourceMember.HasValue ? sourceMember.Value.ToString() : null;
        }

        public DateTime? ConvertDate(string sourceMember)
        {
            return sourceMember != null ? (DateTime?)DateTime.Parse(sourceMember) : null;
        }
    }
}
