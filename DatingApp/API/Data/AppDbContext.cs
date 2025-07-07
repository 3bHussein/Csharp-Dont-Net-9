using System;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
// public AppDBContext(DbContextOptions options) :base(options)
// {

//         return AppContext; 
// }

}
