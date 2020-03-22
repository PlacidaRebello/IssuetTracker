using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogic.Interfaces
{
    public interface IIssue
    {
        int Create(Issue issue);
    }
}
