﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Ventas.Infraestructure.Data.Entities;

namespace Ventas.Infraestructure.Data.Context
{
    public partial interface IVentasContextProcedures
    {
        Task<List<listarVentasResult>> listarVentasAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}