﻿using Microsoft.EntityFrameworkCore;

namespace OMDb.API.DataContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }


}
