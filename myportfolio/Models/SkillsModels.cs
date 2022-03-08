using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myportfolio.Models
{
    public class SkillModel
    {
        public string Language { get; set; }
        /// <summary>
        /// 25, 50, 75
        /// </summary>
        public int Level { get; set; } = 50;

        public TypeValues Type { get; set; } = TypeValues.Programming;
    }

    public enum TypeValues
    {
        Programming,
        Database,
        Other
    }
}
