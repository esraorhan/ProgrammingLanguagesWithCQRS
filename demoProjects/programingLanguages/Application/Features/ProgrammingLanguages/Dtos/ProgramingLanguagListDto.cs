﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Dtos
{
    public class ProgramingLanguagListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
