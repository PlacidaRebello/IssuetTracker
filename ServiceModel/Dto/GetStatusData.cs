﻿using ServiceModel.Type;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceModel.Dto
{
    public class GetStatusData: StatusRequest
    {
        public int StatusId { get; set; }

    }
}
