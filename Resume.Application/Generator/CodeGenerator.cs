using System;

namespace Resume.Application.Generator
{
    public class CodeGenerator
    {
        public static string GeneratUniqCode()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
