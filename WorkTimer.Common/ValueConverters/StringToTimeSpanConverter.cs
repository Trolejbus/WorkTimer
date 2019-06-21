using AutoMapper;
using System;

namespace WorkTimer.Common.ValueConverters
{
    public class StringToTimeSpanConverter
        : ITypeConverter<TimeSpan?, string>
    {
        public string Convert(
            TimeSpan? source,
            string destination,
            ResolutionContext context)
        {
            if (!source.HasValue)
            {
                return null;
            }

            return source.ToString();
        }
    }
}
