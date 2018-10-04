using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Core.Interface
{    
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

    }
}